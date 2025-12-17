using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;

namespace DA_Trello
{
    public partial class Columns : UserControl
    {
        public TrelloList myInternalList = new TrelloList();
        private string tempFilePath = "";
        public Columns()
        {
            InitializeComponent();
        }
        public void SetupColumn(string title, Color headerColor)
        {
            lblColumnTitle.Text = title;
            pnl_ColumnTitle.BackColor = headerColor; 
        }
        private string GetFilePath()
        {
            string cleanTitle = this.Name; 
            return $"data_{cleanTitle}.json";
        }
        //dùng để thay tên cho các cột
        public string Title
        {
            get { return lblColumnTitle.Text; } 
            set { lblColumnTitle.Text = value; }
        }
        //dùng đổi màu cho các cột
        public Color HeaderColor
        {
            get { return pnl_ColumnTitle.BackColor; } 
            set { pnl_ColumnTitle.BackColor = value; } 
        }
        // KHI BẤM NÚT "+ Add a card"
        private void pnlAddCard_Click(object sender, EventArgs e)
        {
            pnlAddCardWrapper.Visible = false; // Giấu nút kích hoạt
            pnlInputWrapper.Visible = true;      // Hiện khung nhập liệu
            txtTitle.Focus();             // Đưa con trỏ vào ô nhập
        }

        // KHI BẤM NÚT "SAVE" (Thêm thẻ)
        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string body = txtContext.Text.Trim();

            if (string.IsNullOrEmpty(title)) return;

            int priority = cmbPrior.SelectedIndex;
            if (priority < 0) priority = 0;

            NoteEntry newNote = new NoteEntry(title, body, priority, tempFilePath);

            myInternalList.Add(newNote);
            RenderList(myInternalList);

            // --- Reset giao diện về như cũ ---
            txtTitle.Clear();
            txtContext.Clear();

            // Đóng khung nhập lại
            pnlInputWrapper.Visible = false;
            pnlAddCardWrapper.Visible = true;
        }

        //KHI BẤM NÚT HỦY
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //Xóa tất cả rồi ẩn thằng input đi
            txtTitle.Clear();
            txtContext.Clear();
            pnlInputWrapper.Visible = false;
            pnlAddCardWrapper.Visible = true;
        }
        private void btnAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Chọn tài liệu đính kèm";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                //Lưu đường dẫn vào biến tạm
                tempFilePath = openFile.FileName;

                lblShowNameFile.Text = System.IO.Path.GetFileName(tempFilePath);
                lblShowNameFile.ForeColor = Color.Blue;
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            //TỰ ĐỘNG LOAD DỮ LIỆU KHI MỞ LÊN
            string path = GetFilePath();
            if (System.IO.File.Exists(path))
            {
                myInternalList.LoadFromFile(path); 
                RenderList(myInternalList); 
            }

            //Tìm parent và thông báo trước khi tắt
            if (this.ParentForm != null)
            {
                this.ParentForm.FormClosing += ParentForm_FormClosing;
            }
        }

        // Đây là hàm sẽ chạy khi bấm dấu X đỏ trên cửa sổ chính
        private void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // TỰ ĐỘNG LƯU
            string path = GetFilePath();
            myInternalList.SaveToFile(path); 
        }

        // Nhận vào TrelloList chứ không phải List<> nữa
        public void RenderList(TrelloList dataSource)
        {
            this.flw_ColumnList.Controls.Clear();

            // Nếu danh sách rỗng hoặc null
            if (dataSource == null || dataSource.head == null) return;

            // DUYỆT TRÊN DANH SÁCH ĐƯỢC TRUYỀN VÀO
            // (Lưu ý: dataSource có thể là list gốc hoặc list kết quả tìm kiếm)
            NoteNode current = dataSource.head;

            while (current != null)
            {
                // Vẽ thẻ
                Cards card = new Cards();
                card.SetData(current.Data);
                card.Margin = new Padding(25, 10, 0, 0);

                // Gắn sự kiện
                card.CardDragSuccess -= Card_CardDragSuccess;
                card.CardDragSuccess += Card_CardDragSuccess;
                card.OnDeleteClick -= Card_OnDeleteClick;
                card.OnDeleteClick += Card_OnDeleteClick;

                this.flw_ColumnList.Controls.Add(card);

                current = current.Next;
            }
        }
        public void Search(string keyword = "")
        {
            TrelloList listToRender;

            if (string.IsNullOrEmpty(keyword))
            {
                // TRƯỜNG HỢP 1: KHÔNG SEARCH
                // Render chính cái list gốc hiện tại (this.myInternalList)
                listToRender = this.myInternalList;
            }
            else
            {
                // TRƯỜNG HỢP 2: CÓ SEARCH
                // Gọi hàm Search -> Nó trả về một TrelloList MỚI chứa kết quả
                listToRender = this.myInternalList.SearchKeyWord(keyword);
            }
            RenderList(listToRender);
        }
        private void flw_ColumnList_DragEnter(object sender, DragEventArgs e)
        {
            // Kiểm tra xem hàng gửi đến có phải là NoteEntry 
            if (e.Data.GetDataPresent(typeof(NoteEntry)))
            {
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                e.Effect = DragDropEffects.None;
            }
        }

        private void flw_ColumnList_DragDrop(object sender, DragEventArgs e)
        {
            // 1. Lấy dữ liệu gửi tới
            NoteEntry receivedData = e.Data.GetData(typeof(NoteEntry)) as NoteEntry;
            if (receivedData == null) return;

            // 2. --- CHỐT CHẶN QUAN TRỌNG (CHECK TRÙNG ID) ---
            // Duyệt qua list hiện tại xem cái ID này đã tồn tại chưa?
            NoteNode current = myInternalList.head;
            bool isExist = false;

            while (current != null)
            {
                // So sánh ID chuẩn
                if (current.Data.ID == receivedData.ID)
                {
                    isExist = true;
                    break;
                }
                current = current.Next;
            }

            // Nếu đã tồn tại rồi 
            if (isExist)
            {
                e.Effect = DragDropEffects.None;
                return; 
            }
           
            // Nếu chưa tồn tại thì mới tạo mới (CLONE)
            NoteEntry newCard = new NoteEntry(receivedData.Title, receivedData.Body, receivedData.Priority, receivedData.FilePath);

            // Ép ID của card mới phải giống hệt cũ
            newCard.ID = receivedData.ID;

            //hêm vào danh sách và vẽ lại
            myInternalList.Add(newCard);
            myInternalList.SaveToFile(GetFilePath());
            RenderList(myInternalList);

            // Báo thành công để xóa
            e.Effect = DragDropEffects.Move;
        }
        private void Column_DragOver(object sender, DragEventArgs e)
        {
            //Lấy dữ liệu đang được kéo
            NoteEntry draggingData = e.Data.GetData(typeof(NoteEntry)) as NoteEntry;

            // Nếu không phải là NoteEntry thì cấm tiệt
            if (draggingData == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            // Cái thẻ này có đang nằm trong cột này không
            bool isAlreadyHere = false;
            NoteNode current = myInternalList.head;

            while (current != null)
            {
                // So sánh ID
                if (current.Data.ID == draggingData.ID)
                {
                    isAlreadyHere = true;
                    break;
                }
                current = current.Next;
            }

            //Nếu đã tồn tại
            if (isAlreadyHere)
            {
                e.Effect = DragDropEffects.None;
            }
            else
            {
                e.Effect = DragDropEffects.Move;
            }
        }

        private void Card_CardDragSuccess(object sender, EventArgs e)
        {
            // Lấy ra cái Card vừa gửi tin nhắn
            var card = sender as Cards;
            if (card == null) return;
            //tạo luồn mới cho an toàn
            this.BeginInvoke(new Action(() =>
            {
                //Xóa khỏi danh sách liên kết (Data)
                bool deleted = myInternalList.Remove(card.MyData.ID);

                if (deleted)
                {
                    //Lưu lại file
                    myInternalList.SaveToFile(GetFilePath());

                    // Cập nhật giao diện
                    RenderList(myInternalList);

                }

            }));
        }

        private void Card_OnDeleteClick(object sender, EventArgs e)
        {
            // Lấy ra cái thẻ vừa bị bấm nút xóa
            var card = sender as Cards;
            if (card == null) return;

            // Hỏi người dùng cho chắc ăn (Optional, thích thì để)
            var confirmResult = MessageBox.Show("Bạn có muốn xóa thẻ này không?",
                                             "Xác nhận xóa",
                                             MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                bool isDeleted = myInternalList.Remove(card.MyData.ID);

                if (isDeleted)
                {
                    myInternalList.SaveToFile(GetFilePath());
                    RenderList(myInternalList);
                }

            }
        }

        private void btn_RemoveAll_Click(object sender, EventArgs e)
        {
            
            // Kiểm tra: Nếu danh sách đang rỗng thì thôi
            if (myInternalList.head == null)
            {
                return;
            }

            // HỎI XÁC NHẬN 
            DialogResult result = MessageBox.Show(
                "Bạn có muốn xóa toàn bộ thẻ trong cột này không?\nHành động này không thể hoàn tác.",
                "Xác nhận xóa tất cả",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            //Nếu chọn YES 
            if (result == DialogResult.Yes)
            {
                // Xóa trong Linked List
                myInternalList.Clear();

                // Xóa trong Ổ CỨNG
                myInternalList.SaveToFile(GetFilePath());

                //Xóa trên GIAO DIỆN
                this.flw_ColumnList.Controls.Clear();
            }
        }
    
    }
}

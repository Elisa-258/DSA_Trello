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
        private TrelloList myInternalList = new TrelloList();
        private string tempFilePath = "";
        public Columns()
        {
            InitializeComponent();
        }
        public void SetupColumn(string title, Color headerColor)
        {
            lblColumnTitle.Text = title;
            pnl_ColumnTitle.BackColor = headerColor; // (Nếu em có panel header)
        }
        // Hàm tạo tên file: ví dụ cột tên "DOING" -> file là "data_DOING.json"
        private string GetFilePath()
        {
            // Giả sử cái Label tiêu đề của em tên là lblColumnTitle
            // Nếu em dùng Panel chứa chữ thì nhớ lấy Text của cái Control bên trong nhé
            // Ở đây tôi ví dụ em có biến lưu Title
            string cleanTitle = this.Name; // Hoặc lấy từ Label: lblTitle.Text.Trim();

            // Đảm bảo không có ký tự bậy bạ trong tên file
            return $"data_{cleanTitle}.json";
        }
        private void label1_Click(object sender, EventArgs e)
        {

        }
        // Thuộc tính này sẽ hiện ra bên bảng Properties ở Form chính
        public string Title
        {
            get { return lblColumnTitle.Text; } // (Thay lblTitle bằng tên thật cái Label của em)
            set { lblColumnTitle.Text = value; }
        }
        public Color HeaderColor
        {
            get { return pnl_ColumnTitle.BackColor; } // Trả về màu hiện tại
            set { pnl_ColumnTitle.BackColor = value; } // Gán màu mới
        }
        // 1. KHI BẤM NÚT "+ Add a card"
        private void pnlAddCard_Click(object sender, EventArgs e)
        {
            pnlAddButtonWrapper.Visible = false; // Giấu nút kích hoạt
            pnlAddCardWrapper.Visible = true;      // Hiện khung nhập liệu
            txtTitle.Focus();             // Đưa con trỏ vào ô nhập luôn cho tiện
        }

        // 2. KHI BẤM NÚT "SAVE" (Thêm thẻ)
        private void btnSave_Click(object sender, EventArgs e)
        {
            string title = txtTitle.Text.Trim();
            string msg = txtContext.Text.Trim();

            if (string.IsNullOrEmpty(title)) return;

            int priority = cmbPrior.SelectedIndex;
            if (priority < 0) priority = 0;


            // --- Logic thêm vào Linked List (như cũ) ---
            NoteEntry newNote = new NoteEntry(title, msg, priority, tempFilePath);

            myInternalList.Add(newNote);
            RenderList(myInternalList);

            // --- Reset giao diện về như cũ ---
            txtTitle.Clear();
            txtContext.Clear();

            // Đóng khung nhập lại
            pnlAddCardWrapper.Visible = false;
            pnlAddButtonWrapper.Visible = true;
        }

        // 3. (Optional) KHI BẤM NÚT HỦY (Nếu em có làm nút X)
        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtTitle.Clear();
            txtContext.Clear();
            pnlAddCardWrapper.Visible = false;
            pnlAddButtonWrapper.Visible = true;
        }
        private void btnAttach_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Title = "Chọn tài liệu đính kèm";

            // Nếu muốn lọc chỉ lấy ảnh hoặc pdf thì dùng dòng dưới (không bắt buộc)
            // openFile.Filter = "Image Files|*.jpg;*.jpeg;*.png|All Files|*.*";

            if (openFile.ShowDialog() == DialogResult.OK)
            {
                // 1. Lưu đường dẫn vào biến tạm
                tempFilePath = openFile.FileName;

                lblShowNameFile.Text = System.IO.Path.GetFileName(tempFilePath);
                lblShowNameFile.ForeColor = Color.Blue; // Đổi màu xanh cho nổi
            }
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            // 1. TỰ ĐỘNG LOAD DỮ LIỆU KHI MỞ LÊN
            string path = GetFilePath();
            if (System.IO.File.Exists(path))
            {
                myInternalList.LoadFromFile(path); // Gọi hàm Load hôm qua mình viết
                RenderList(myInternalList); // Vẽ lên màn hình
            }

            // 2. TÌM THẰNG CHA VÀ DẶN NÓ: "Sắp chết thì báo con!"
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
            myInternalList.SaveToFile(path); // Gọi hàm Save hôm qua mình viết
        }
        private void txtTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        // Nhận vào TrelloList chứ không phải List<> nữa
        private void RenderList(TrelloList dataSource)
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

            // Gửi hàng đi vẽ
            RenderList(listToRender);
        }
        private void flw_ColumnList_DragEnter(object sender, DragEventArgs e)
        {
            // Kiểm tra xem hàng gửi đến có phải là NoteEntry không?
            if (e.Data.GetDataPresent(typeof(NoteEntry)))
            {
                // Nếu đúng là "đồng loại", cho phép di chuyển
                e.Effect = DragDropEffects.Move;
            }
            else
            {
                // Nếu là rác (file từ ngoài desktop, text linh tinh) thì chặn
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

            // Nếu đã tồn tại rồi -> Đây là lần chạy thứ 2 (Lỗi Double Drop) hoặc người dùng cố tình drop vào chỗ cũ
            if (isExist)
            {
                // Báo hiệu Move thành công (để bên kia vẫn xóa thằng gốc đi nếu cần)
                // NHƯNG KHÔNG ADD THÊM VÀO LIST NỮA
                e.Effect = DragDropEffects.None;
                return; // <--- CẮT NGAY, KHÔNG CHẠY XUỐNG DƯỚI
            }
            // ------------------------------------------------

            // 3. Nếu chưa tồn tại thì mới tạo mới (CLONE)
            NoteEntry newCard = new NoteEntry(receivedData.Title, receivedData.Body, receivedData.Priority, receivedData.FilePath);

            // BẮT BUỘC: Ép ID của thằng mới phải giống hệt thằng cũ
            newCard.ID = receivedData.ID;

            // 4. Thêm vào danh sách và vẽ lại
            myInternalList.Add(newCard);
            myInternalList.SaveToFile(GetFilePath());
            RenderList(myInternalList);

            // 5. Báo tin mừng về cho bên kia xóa
            e.Effect = DragDropEffects.Move;
        }
        private void Column_DragOver(object sender, DragEventArgs e)
        {
            // 1. Lấy dữ liệu đang được kéo
            NoteEntry draggingData = e.Data.GetData(typeof(NoteEntry)) as NoteEntry;

            // Nếu không phải là NoteEntry thì cấm tiệt
            if (draggingData == null)
            {
                e.Effect = DragDropEffects.None;
                return;
            }

            // 2. CHECK: Cái thẻ này có đang nằm trong nhà mình không?
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

            // 3. QUYẾT ĐỊNH SỐ PHẬN
            if (isAlreadyHere)
            {
                // Nếu đã có trong cột này -> Hiện biển CẤM (Vòng tròn gạch chéo)
                e.Effect = DragDropEffects.None;
            }
            else
            {
                // Nếu chưa có -> Hiện mũi tên MOVE
                e.Effect = DragDropEffects.Move;
            }
        }

        private void Card_CardDragSuccess(object sender, EventArgs e)
        {
            // Lấy ra cái Card vừa gửi tin nhắn
            // (Thay CardControl bằng tên class UserControl Card thật của em)
            var card = sender as Cards;

            if (card == null) return;

            // Dùng BeginInvoke để đảm bảo an toàn luồng UI (như em đã làm)
            this.BeginInvoke(new Action(() =>
            {
                // 1. Xóa khỏi danh sách liên kết (Data)
                // Gọi cái hàm Remove kiểu bool mới sửa lúc nãy
                bool deleted = myInternalList.Remove(card.MyData.ID);

                if (deleted)
                {
                    // 2. Lưu lại file (nếu cần)
                    myInternalList.SaveToFile(GetFilePath());

                    // 3. Cập nhật giao diện
                    // Cách A: Vẽ lại từ đầu (An toàn nhất)
                    RenderList(myInternalList);

                    // Cách B: Chỉ xóa cái control đó thôi (Nhanh hơn, đỡ lag)
                    // this.FlowLayoutPanel.Controls.Remove(card);

               
                }
                
            }));
        }

        private void Card_OnDeleteClick(object sender, EventArgs e)
        {
            // Lấy ra cái thẻ vừa bị bấm nút xóa
            var card = sender as Cards;
            if (card == null) return;

            // Hỏi người dùng cho chắc ăn (Optional, thích thì để)
            var confirmResult = MessageBox.Show("Em có chắc muốn xóa cái này không?",
                                             "Xác nhận xóa",
                                             MessageBoxButtons.YesNo);

            if (confirmResult == DialogResult.Yes)
            {
                // 1. Gọi hàm Remove thần thánh mà tôi vừa viết lại cho em
                bool isDeleted = myInternalList.Remove(card.MyData.ID);

                if (isDeleted)
                {
                    // 2. Lưu file ngay lập tức
                    myInternalList.SaveToFile(GetFilePath());

                    // 3. Vẽ lại giao diện (để cái thẻ biến mất)
                    RenderList(myInternalList);
                }
               
            }
        }
        private void cmbPrior_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

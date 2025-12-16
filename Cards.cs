using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;


namespace DA_Trello
{
    public partial class Cards : UserControl
    {
        public event EventHandler CardDragSuccess;
        public Cards()
        {
            InitializeComponent();
            this.MouseDown += Card_MouseDown;           // Kéo cái nền
            CardTitle.MouseDown += Card_MouseDown;      // Kéo cái tiêu đề
            CardContext.MouseDown += Card_MouseDown;    // Kéo cái nội dung
                                                        // Nếu có Panel chứa thì gắn luôn cho Panel
                                                        // pnlMain.MouseDown += Card_MouseDown;
        }
        // Đây là cái "loa" để hét lên: "Ê có người bấm xóa tui nè!"
        public event EventHandler OnDeleteClick;
        
        // Biến lưu dữ liệu gốc (để biết mình là ai mà xóa)
        public NoteEntry MyData { get; private set; }
        // Hàm này giúp em truyền chữ vào thẻ nhanh gọn
        public void SetData(NoteEntry data)
        {
            this.MyData = data;

            // 2. Gán thông tin cơ bản
            CardTitle.Text = data.Title;
            CardContext.Text = data.Body;

            // 3. XỬ LÝ FILE (Code của em nằm ở đây nè - Chuẩn rồi)
            if (!string.IsNullOrEmpty(data.FilePath))
            {
                lblFile.Visible = true;
                // Lấy tên file cho gọn
                lblFile.Text = "📄 " + System.IO.Path.GetFileName(data.FilePath);

                // Lưu đường dẫn gốc vào Tag (Cái này thông minh, 10 điểm!)
                lblFile.Tag = data.FilePath;
            }
            else
            {
                lblFile.Visible = false;
                pnlFile.Visible = false;
            }
      
            // 4. XỬ LÝ MÀU ƯU TIÊN (Priority) - Đừng quên cái này!
            switch (data.Priority)
            {
                case 0: 
                    pnlPrior.BackColor = Color.Red;
                    break;
                case 1:
                    pnlPrior.BackColor = Color.Orange; 
                    break;
                case 2: 
                    pnlPrior.BackColor = Color.ForestGreen;
                    break;
            } 
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Khi nút X được bấm, kiểm tra xem có ai đang lắng nghe không (ColumnControl)
            // Nếu có thì gọi sự kiện (Invoke)
            OnDeleteClick?.Invoke(this, EventArgs.Empty);
        }
        // --- SỰ KIỆN KHI BẤM VÀO LINK ---
        // (Em quay ra Design, double click vào LinkLabel để sinh hàm này)
        private void LinkFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = lblFile.Tag as string;

            if (!string.IsNullOrEmpty(path) && System.IO.File.Exists(path))
            {
                // Lệnh này bảo Windows: "Hãy mở file này bằng app mặc định của mày đi"
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("File này hình như bị xóa mất rồi!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm hiệu ứng: Rê chuột vào thì thẻ đổi màu xám nhẹ
        private void CardItem_MouseEnter(object sender, EventArgs e)
            {
                this.BackColor = Color.WhiteSmoke;
            }

            private void CardItem_MouseLeave(object sender, EventArgs e)
            {
                this.BackColor = Color.White;
            }

            private void Cards_Load(object sender, EventArgs e)
            {

            }
        private void Card_MouseDown(object sender, MouseEventArgs e)
        {
            // Chỉ kéo khi nhấn chuột trái
            if (e.Button == MouseButtons.Left && MyData != null)
            {
                // 1. Bắt đầu lệnh kéo thả (DoDragDrop là hàm có sẵn của WinForms)
                // Tham số 1: Dữ liệu cần gửi đi (Chính là cái NoteEntry)
                // Tham số 2: Hiệu ứng (Move là di chuyển)
                DragDropEffects result = DoDragDrop(MyData, DragDropEffects.Move);
       
                // 2. Nếu bên kia nhận thành công (kết quả trả về là Move)
                if (result == DragDropEffects.Move)
                {
                    // Báo hiệu cho cột cũ biết để xóa đi
                    CardDragSuccess?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }


}

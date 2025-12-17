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
            //cho phép kéo card ở mọi element
            this.MouseDown += Card_MouseDown;           
            CardTitle.MouseDown += Card_MouseDown;      
            CardContext.MouseDown += Card_MouseDown;    
        }

        public event EventHandler OnDeleteClick;
        
        // Biến lưu dữ liệu gốc 
        public NoteEntry MyData { get; private set; }
        public void SetData(NoteEntry data)
        {
            this.MyData = data;

            // Gán thông tin cơ bản
            CardTitle.Text = data.Title;
            CardContext.Text = data.Body;

            // XỬ LÝ FILE 
            if (!string.IsNullOrEmpty(data.FilePath))
            {
                lblFile.Visible = true;
                lblFile.Text = "📄 " + System.IO.Path.GetFileName(data.FilePath);
                lblFile.Tag = data.FilePath;
            }
            else
            {
                lblFile.Visible = false;
                pnlFile.Visible = false;
            }
      
            // XỬ LÝ MÀU ƯU TIÊN (Priority)
            switch (data.Priority)
            {
                case 0: //khẩn
                    pnlPrior.BackColor = Color.Red;
                    break;
                case 1: //quan trọng
                    pnlPrior.BackColor = Color.Orange; 
                    break;
                case 2: //không quan trọng
                    pnlPrior.BackColor = Color.ForestGreen;
                    break;
            } 
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            // Khi nút X được bấm thì kiểm tra
            OnDeleteClick?.Invoke(this, EventArgs.Empty);
        }
       
        private void LinkFile_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string path = lblFile.Tag as string;

            if (!string.IsNullOrEmpty(path) && System.IO.File.Exists(path))
            {
                //Để window mở file bằng app mặc định
                Process.Start(new ProcessStartInfo(path) { UseShellExecute = true });
            }
            else
            {
                MessageBox.Show("Không tìm được file", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Thêm hiệu ứng: Rê chuột vào thì thẻ đổi màu xám nhẹ
        private void CardItem_MouseEnter(object sender, EventArgs e)
        {
            this.BackColor = Color.WhiteSmoke;
        }
        //trở về màu bình thường
        private void CardItem_MouseLeave(object sender, EventArgs e)
        {
            this.BackColor = Color.White;
        }
        private void Card_MouseDown(object sender, MouseEventArgs e)
        {
            // Chỉ kéo khi nhấn chuột trái
            if (e.Button == MouseButtons.Left && MyData != null)
            {
                // Bắt đầu lệnh kéo thả
                // Tham số 1: Dữ liệu cần gửi đi
                // Tham số 2: Hiệu ứng 
                DragDropEffects result = DoDragDrop(MyData, DragDropEffects.Move);
       
                //Nếu bên kia nhận thành công 
                if (result == DragDropEffects.Move)
                {
                    // Báo hiệu cho cột cũ biết để xóa đi
                    CardDragSuccess?.Invoke(this, EventArgs.Empty);
                }
            }
        }
    }


}

using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Menu;


namespace DA_Trello
{
    public partial class Form1 : Form
    {
        TrelloList BoardList = new TrelloList();
        public Form1()
        {
            InitializeComponent();
        }
        private void InitializeComponent()
        {
            Label lblHeader;
            panel1 = new Panel();
            btnAsc = new Button();
            lblSort = new Label();
            lblSearchBar = new Label();
            cmbSort = new ComboBox();
            txtSearch = new TextBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            colTodo = new Columns();
            colDoing = new Columns();
            colDone = new Columns();
            lblHeader = new Label();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblHeader
            // 
            lblHeader.AutoSize = true;
            lblHeader.Font = new Font("iCiel Panton Black Italic", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblHeader.ForeColor = Color.Black;
            lblHeader.Location = new Point(12, 9);
            lblHeader.Name = "lblHeader";
            lblHeader.Size = new Size(133, 32);
            lblHeader.TabIndex = 0;
            lblHeader.Text = "My Board";
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 242, 198);
            panel1.Controls.Add(btnAsc);
            panel1.Controls.Add(lblSort);
            panel1.Controls.Add(lblSearchBar);
            panel1.Controls.Add(cmbSort);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(lblHeader);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1082, 50);
            panel1.TabIndex = 0;
            // 
            // btnAsc
            // 
            btnAsc.Font = new Font("iCiel Panton Black", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAsc.Location = new Point(1035, 12);
            btnAsc.Margin = new Padding(0);
            btnAsc.Name = "btnAsc";
            btnAsc.Size = new Size(35, 27);
            btnAsc.TabIndex = 5;
            btnAsc.Text = "⬆\r\n";
            btnAsc.UseVisualStyleBackColor = true;
            btnAsc.Click += btnAsc_Click;
            // 
            // lblSort
            // 
            lblSort.AutoSize = true;
            lblSort.BackColor = Color.Transparent;
            lblSort.Font = new Font("iCiel Panton Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSort.Location = new Point(759, 12);
            lblSort.Name = "lblSort";
            lblSort.Size = new Size(82, 24);
            lblSort.TabIndex = 4;
            lblSort.Text = "Sort By:";
            // 
            // lblSearchBar
            // 
            lblSearchBar.AutoSize = true;
            lblSearchBar.BackColor = Color.Transparent;
            lblSearchBar.Font = new Font("iCiel Panton Light", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblSearchBar.Location = new Point(250, 14);
            lblSearchBar.Name = "lblSearchBar";
            lblSearchBar.Padding = new Padding(0, 0, 10, 0);
            lblSearchBar.Size = new Size(116, 24);
            lblSearchBar.TabIndex = 3;
            lblSearchBar.Text = "Search By:";
            // 
            // cmbSort
            // 
            cmbSort.DisplayMember = "0,1,2";
            cmbSort.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSort.Font = new Font("iCiel Panton Light", 10.7999992F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmbSort.FormattingEnabled = true;
            cmbSort.Items.AddRange(new object[] { "Date (Default)", "Title", "Priority" });
            cmbSort.Location = new Point(847, 11);
            cmbSort.Name = "cmbSort";
            cmbSort.Size = new Size(171, 30);
            cmbSort.TabIndex = 2;
            cmbSort.ValueMember = "0,1,2";
            cmbSort.SelectedIndexChanged += cmbSort_SelectSort;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(372, 12);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(336, 27);
            txtSearch.TabIndex = 1;
            txtSearch.TextChanged += txtSearch_TextChanged;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(colTodo, 0, 0);
            tableLayoutPanel1.Controls.Add(colDoing, 1, 0);
            tableLayoutPanel1.Controls.Add(colDone, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 50);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1082, 603);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // colTodo
            // 
            colTodo.BackColor = Color.Transparent;
            colTodo.HeaderColor = Color.FromArgb(192, 192, 255);
            colTodo.Location = new Point(3, 3);
            colTodo.Name = "colTodo";
            colTodo.Size = new Size(354, 597);
            colTodo.TabIndex = 0;
            colTodo.Title = "ToDo";
            // 
            // colDoing
            // 
            colDoing.BackColor = Color.Transparent;
            colDoing.HeaderColor = Color.FromArgb(192, 255, 192);
            colDoing.Location = new Point(363, 3);
            colDoing.Name = "colDoing";
            colDoing.Size = new Size(354, 597);
            colDoing.TabIndex = 1;
            colDoing.Title = "Doing";
            // 
            // colDone
            // 
            colDone.BackColor = Color.Transparent;
            colDone.HeaderColor = Color.FromArgb(255, 192, 192);
            colDone.Location = new Point(723, 3);
            colDone.Name = "colDone";
            colDone.Size = new Size(356, 597);
            colDone.TabIndex = 2;
            colDone.Title = "Done";
            // 
            // Form1
            // 
            BackColor = Color.FromArgb(255, 248, 222);
            ClientSize = new Size(1082, 653);
            Controls.Add(tableLayoutPanel1);
            Controls.Add(panel1);
            Font = new Font("[UEE] TuffW01-Normal", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Form1";
            Text = "This is Trello";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);

        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            string keyword = txtSearch.Text;
            colDoing.Search(keyword);
            colTodo.Search(keyword);
            colDone.Search(keyword);
        }

        private void btnAsc_Click(object sender, EventArgs e)
        {
            bool isAscending = btnAsc.Text == "⬆";
            isAscending = !isAscending;
            btnAsc.Text = isAscending ? "⬆" : "⬇";
            ApplyGlobalSort();
        }

        private void cmbSort_SelectSort(object sender, EventArgs e)
        {
            ApplyGlobalSort();
        }

        private void ApplyGlobalSort()
        {
            // Tự lấy thông tin từ UI
            int sortType = cmbSort.SelectedIndex; //lấy index
            bool isAscending = (btnAsc.Text == "⬆");  //check text nút

            //Gọi hàm sort cho 3 cột 
            Helper_SortColumn(colTodo, sortType, isAscending);
            Helper_SortColumn(colDoing, sortType, isAscending);
            Helper_SortColumn(colDone, sortType, isAscending);
        }
        // Hàm phụ trợ để sort
        private void Helper_SortColumn(Columns col, int type, bool isAsc)
        {
            //Sort theo thuật toán tương ứng
            switch (type)
            {
                case 0: col.myInternalList.SortByDate(); break;    
                case 1: col.myInternalList.SortByTitle(); break;    
                case 2: col.myInternalList.SortByPriority(); break; 
            }

            //Nếu người dùng chọn Giảm dần -> Đảo ngược
            if (!isAsc)
            {
                col.myInternalList.Reverse();
            }

            //Vẽ lại ngay lập tức
            col.RenderList(col.myInternalList);
        }

        //mặc định mỗi lần mở lên sẽ load phần này
        private void Form1_Load(object sender, EventArgs e)
        {
            //Load dữ liệu từ file lên trước (QUAN TRỌNG)
            colTodo.myInternalList.LoadFromFile("todo.json");
            colDoing.myInternalList.LoadFromFile("doing.json");
            colDone.myInternalList.LoadFromFile("done.json");

            //Set giao diện mặc định
            btnAsc.Text = "⬆";

            //Kích hoạt Sort mặc định (Date)
            if (cmbSort.Items.Count > 0)
            {
                cmbSort.SelectedIndex = 0;
                Helper_SortColumn(colTodo, 0, true);
                Helper_SortColumn(colDoing, 0, true);
                Helper_SortColumn(colDone, 0, true);
            }
        }
    }
}

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
            panel1 = new Panel();
            btnAsc = new Button();
            lblSort = new Label();
            lblSearchBar = new Label();
            cmbSort = new ComboBox();
            txtSearch = new TextBox();
            label1 = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            col_Todo = new Columns();
            col_Doing = new Columns();
            col_Done = new Columns();
            panel1.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(255, 242, 198);
            panel1.Controls.Add(btnAsc);
            panel1.Controls.Add(lblSort);
            panel1.Controls.Add(lblSearchBar);
            panel1.Controls.Add(cmbSort);
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(label1);
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
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("iCiel Panton Black Italic", 16.1999989F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(133, 32);
            label1.TabIndex = 0;
            label1.Text = "My Board";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.3333321F));
            tableLayoutPanel1.Controls.Add(col_Todo, 0, 0);
            tableLayoutPanel1.Controls.Add(col_Doing, 1, 0);
            tableLayoutPanel1.Controls.Add(col_Done, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 50);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(1082, 603);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // col_Todo
            // 
            col_Todo.BackColor = Color.Transparent;
            col_Todo.HeaderColor = Color.FromArgb(192, 192, 255);
            col_Todo.Location = new Point(3, 3);
            col_Todo.Name = "col_Todo";
            col_Todo.Size = new Size(354, 597);
            col_Todo.TabIndex = 0;
            col_Todo.Title = "ToDo";
            // 
            // col_Doing
            // 
            col_Doing.BackColor = Color.Transparent;
            col_Doing.HeaderColor = Color.FromArgb(192, 255, 192);
            col_Doing.Location = new Point(363, 3);
            col_Doing.Name = "col_Doing";
            col_Doing.Size = new Size(354, 597);
            col_Doing.TabIndex = 1;
            col_Doing.Title = "Doing";
            // 
            // col_Done
            // 
            col_Done.BackColor = Color.Transparent;
            col_Done.HeaderColor = Color.FromArgb(255, 192, 192);
            col_Done.Location = new Point(723, 3);
            col_Done.Name = "col_Done";
            col_Done.Size = new Size(356, 597);
            col_Done.TabIndex = 2;
            col_Done.Title = "Done";
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

            // Gọi lệnh search cho từng cột em đang có
            // (Thay tên biến colTodo, colDone bằng tên thật của em)
            col_Doing.Search(keyword);
            col_Todo.Search(keyword);
            col_Done.Search(keyword);
        }

        private void btnAsc_Click(object sender, EventArgs e)
        {
            bool isAscending = btnAsc.Text == "⬆"; // Ví dụ check text nút
            isAscending = !isAscending;
            btnAsc.Text = isAscending ? "⬆" : "⬇";
            ApplyGlobalSort();
        }

        private void cmbSort_SelectSort(object sender, EventArgs e)
        {
            ApplyGlobalSort();
        }


        // Hàm này KHÔNG CẦN tham số đầu vào.
        // Nó tự biết nhìn vào ComboBox và Button để lấy thông tin.
        private void ApplyGlobalSort()
        {
            // 1. Tự lấy thông tin từ UI
            int sortType = cmbSort.SelectedIndex; // Tự lấy index
            bool isAscending = (btnAsc.Text == "⬆");  // Tự check text nút

            // 2. Gọi hàm sort cho 3 cột (Helper mình viết lúc nãy)
            Helper_SortColumn(col_Todo, sortType, isAscending);
            Helper_SortColumn(col_Doing, sortType, isAscending);
            Helper_SortColumn(col_Done, sortType, isAscending);
        }
        // Hàm phụ trợ để đỡ viết lặp lại code 3 lần
        private void Helper_SortColumn(Columns col, int type, bool isAsc)
        {
            // B1: Sort theo thuật toán tương ứng
            switch (type)
            {
                case 0: col.myInternalList.SortByDate(); break;     // Bubble
                case 1: col.myInternalList.SortByTitle(); break;    // Selection
                case 2: col.myInternalList.SortByPriority(); break; // Insertion
            }

            // B2: Nếu người dùng chọn Giảm dần -> Đảo ngược
            // (Lưu ý: Các thuật toán trên mặc định là Tăng dần)
            if (!isAsc)
            {
                col.myInternalList.Reverse();
            }

            // B3: Vẽ lại ngay lập tức
            col.RenderList(col.myInternalList);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // 1. Load dữ liệu từ file lên trước (QUAN TRỌNG)
            col_Todo.myInternalList.LoadFromFile("todo.json");
            col_Doing.myInternalList.LoadFromFile("doing.json");
            col_Done.myInternalList.LoadFromFile("done.json");

            // 2. Set giao diện mặc định
            btnAsc.Text = "⬆";

            // 3. Kích hoạt Sort mặc định (Date)
            // Dòng này phải nằm SAU khi load file, nếu không là sort không khí đấy
            if (cmbSort.Items.Count > 0)
            {
                cmbSort.SelectedIndex = 0;
                Helper_SortColumn(col_Todo, 0, true);
                Helper_SortColumn(col_Doing, 0, true);
                Helper_SortColumn(col_Done, 0, true);
            }
        }
    }
}

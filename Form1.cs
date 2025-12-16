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
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1082, 50);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("[UEE] TuffW01-Normal", 13.7999992F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(105, 26);
            label1.TabIndex = 0;
            label1.Text = "My Board";
            label1.Click += label1_Click;
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
            col_Todo.Load += columns1_Load;
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
            col_Doing.Load += columns2_Load;
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
            col_Done.Load += columns3_Load;
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

        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
       

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void flwPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void columns2_Load(object sender, EventArgs e)
        {

        }

        private void columns1_Load(object sender, EventArgs e)
        {

        }

        private void columns3_Load(object sender, EventArgs e)
        {

        }


    }
}

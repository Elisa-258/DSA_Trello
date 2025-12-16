namespace DA_Trello
{
    partial class Cards
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            pnlPrior = new Panel();
            CardTitle = new Label();
            CardContext = new Label();
            lblFile = new LinkLabel();
            btn_delete = new Button();
            pnlFile = new Panel();
            pnlFile.SuspendLayout();
            SuspendLayout();
            // 
            // pnlPrior
            // 
            pnlPrior.BackColor = Color.FromArgb(42, 77, 20);
            pnlPrior.Dock = DockStyle.Left;
            pnlPrior.Location = new Point(0, 0);
            pnlPrior.MaximumSize = new Size(11, 0);
            pnlPrior.Name = "pnlPrior";
            pnlPrior.Size = new Size(6, 130);
            pnlPrior.TabIndex = 0;
            pnlPrior.MouseDown += Card_MouseDown;
            // 
            // CardTitle
            // 
            CardTitle.AutoSize = true;
            CardTitle.BackColor = Color.Transparent;
            CardTitle.Font = new Font("iCiel Panton Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            CardTitle.ForeColor = Color.FromArgb(6, 7, 14);
            CardTitle.Location = new Point(34, 15);
            CardTitle.Margin = new Padding(11, 0, 11, 0);
            CardTitle.Name = "CardTitle";
            CardTitle.Size = new Size(77, 24);
            CardTitle.TabIndex = 0;
            CardTitle.Text = "Sample";
            CardTitle.MouseDown += Card_MouseDown;
            // 
            // CardContext
            // 
            CardContext.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CardContext.AutoEllipsis = true;
            CardContext.BackColor = Color.Transparent;
            CardContext.ForeColor = Color.FromArgb(64, 64, 64);
            CardContext.Location = new Point(34, 44);
            CardContext.Margin = new Padding(10, 5, 5, 10);
            CardContext.Name = "CardContext";
            CardContext.Padding = new Padding(0, 0, 0, 10);
            CardContext.Size = new Size(241, 52);
            CardContext.TabIndex = 1;
            CardContext.Text = "Here is the context";
            CardContext.MouseDown += Card_MouseDown;
            // 
            // lblFile
            // 
            lblFile.AutoEllipsis = true;
            lblFile.AutoSize = true;
            lblFile.Location = new Point(5, 5);
            lblFile.Name = "lblFile";
            lblFile.Size = new Size(79, 20);
            lblFile.TabIndex = 2;
            lblFile.TabStop = true;
            lblFile.Text = "linkLabel1";
            lblFile.Visible = false;
            lblFile.LinkClicked += LinkFile_LinkClicked;
            // 
            // btn_delete
            // 
            btn_delete.BackColor = Color.Transparent;
            btn_delete.BackgroundImage = Properties.Resources.x_mark_18672116;
            btn_delete.BackgroundImageLayout = ImageLayout.Zoom;
            btn_delete.Location = new Point(270, 3);
            btn_delete.Name = "btn_delete";
            btn_delete.Size = new Size(25, 25);
            btn_delete.TabIndex = 3;
            btn_delete.UseVisualStyleBackColor = false;
            btn_delete.Click += btnDelete_Click;
            // 
            // pnlFile
            // 
            pnlFile.AutoSize = true;
            pnlFile.BackColor = Color.WhiteSmoke;
            pnlFile.Controls.Add(lblFile);
            pnlFile.Location = new Point(34, 99);
            pnlFile.MaximumSize = new Size(241, 0);
            pnlFile.Name = "pnlFile";
            pnlFile.Size = new Size(241, 25);
            pnlFile.TabIndex = 4;
            pnlFile.MouseDown += Card_MouseDown;
            // 
            // Cards
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(pnlFile);
            Controls.Add(CardContext);
            Controls.Add(CardTitle);
            Controls.Add(btn_delete);
            Controls.Add(pnlPrior);
            Font = new Font("iCiel Panton Light", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "Cards";
            Size = new Size(300, 130);
            Load += Cards_Load;
            MouseDown += Card_MouseDown;
            MouseEnter += CardItem_MouseEnter;
            MouseLeave += CardItem_MouseLeave;
            pnlFile.ResumeLayout(false);
            pnlFile.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel pnlPrior;
        private Label CardTitle;
        private Label CardContext;
        private LinkLabel lblFile;
        private Button btn_delete;
        private Panel pnlFile;
    }
}

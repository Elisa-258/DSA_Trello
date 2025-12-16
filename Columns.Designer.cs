namespace DA_Trello
{
    partial class Columns
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
            cmbPrior = new ComboBox();
            pnl_ColumnTitle = new Panel();
            lblColumnTitle = new Label();
            pnl_AddCard = new Panel();
            lbl_AddCard = new Label();
            flw_ColumnList = new FlowLayoutPanel();
            pnlAddButtonWrapper = new Panel();
            pnlAddCardWrapper = new Panel();
            pnlAddFile = new Panel();
            lblShowNameFile = new Label();
            pnlInput = new Panel();
            btn_Cancel = new Button();
            btn_AddFile = new Button();
            btnSave = new Button();
            txtContext = new TextBox();
            txtTitle = new TextBox();
            pnl_ColumnTitle.SuspendLayout();
            pnl_AddCard.SuspendLayout();
            pnlAddButtonWrapper.SuspendLayout();
            pnlAddCardWrapper.SuspendLayout();
            pnlAddFile.SuspendLayout();
            pnlInput.SuspendLayout();
            SuspendLayout();
            // 
            // cmbPrior
            // 
            cmbPrior.DisplayMember = "0,1,2";
            cmbPrior.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbPrior.FormattingEnabled = true;
            cmbPrior.Items.AddRange(new object[] { "Khẩn cấp", "Quan trọng", "Không quan trọng" });
            cmbPrior.Location = new Point(10, 47);
            cmbPrior.MaxDropDownItems = 3;
            cmbPrior.Name = "cmbPrior";
            cmbPrior.Size = new Size(280, 28);
            cmbPrior.TabIndex = 1;
            cmbPrior.SelectedIndexChanged += cmbPrior_SelectedIndexChanged;
            // 
            // pnl_ColumnTitle
            // 
            pnl_ColumnTitle.BackColor = Color.FromArgb(192, 192, 255);
            pnl_ColumnTitle.Controls.Add(lblColumnTitle);
            pnl_ColumnTitle.Dock = DockStyle.Top;
            pnl_ColumnTitle.Font = new Font("iCiel Panton Black", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            pnl_ColumnTitle.Location = new Point(0, 0);
            pnl_ColumnTitle.Margin = new Padding(5);
            pnl_ColumnTitle.Name = "pnl_ColumnTitle";
            pnl_ColumnTitle.Size = new Size(350, 45);
            pnl_ColumnTitle.TabIndex = 0;
            // 
            // lblColumnTitle
            // 
            lblColumnTitle.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            lblColumnTitle.AutoSize = true;
            lblColumnTitle.Location = new Point(155, 11);
            lblColumnTitle.Margin = new Padding(10);
            lblColumnTitle.Name = "lblColumnTitle";
            lblColumnTitle.Size = new Size(56, 24);
            lblColumnTitle.TabIndex = 0;
            lblColumnTitle.Text = "ToDo";
            lblColumnTitle.Click += label1_Click;
            // 
            // pnl_AddCard
            // 
            pnl_AddCard.BackColor = Color.White;
            pnl_AddCard.Controls.Add(lbl_AddCard);
            pnl_AddCard.Location = new Point(25, 8);
            pnl_AddCard.Margin = new Padding(0);
            pnl_AddCard.Name = "pnl_AddCard";
            pnl_AddCard.Padding = new Padding(25, 10, 25, 0);
            pnl_AddCard.Size = new Size(300, 50);
            pnl_AddCard.TabIndex = 1;
            pnl_AddCard.Click += pnlAddCard_Click;
            // 
            // lbl_AddCard
            // 
            lbl_AddCard.AutoSize = true;
            lbl_AddCard.BackColor = Color.Transparent;
            lbl_AddCard.Font = new Font("iCiel Panton Light Italic", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_AddCard.Location = new Point(11, 14);
            lbl_AddCard.Name = "lbl_AddCard";
            lbl_AddCard.Size = new Size(128, 24);
            lbl_AddCard.TabIndex = 0;
            lbl_AddCard.Text = "+ Add a card";
            lbl_AddCard.Click += pnlAddCard_Click;
            // 
            // flw_ColumnList
            // 
            flw_ColumnList.AllowDrop = true;
            flw_ColumnList.AutoScroll = true;
            flw_ColumnList.Dock = DockStyle.Fill;
            flw_ColumnList.FlowDirection = FlowDirection.TopDown;
            flw_ColumnList.ForeColor = Color.Black;
            flw_ColumnList.Location = new Point(0, 355);
            flw_ColumnList.Name = "flw_ColumnList";
            flw_ColumnList.Size = new Size(350, 145);
            flw_ColumnList.TabIndex = 2;
            flw_ColumnList.WrapContents = false;
            flw_ColumnList.DragDrop += flw_ColumnList_DragDrop;
            flw_ColumnList.DragEnter += flw_ColumnList_DragEnter;
            flw_ColumnList.DragOver += Column_DragOver;
            // 
            // pnlAddButtonWrapper
            // 
            pnlAddButtonWrapper.Controls.Add(pnl_AddCard);
            pnlAddButtonWrapper.Dock = DockStyle.Top;
            pnlAddButtonWrapper.Location = new Point(0, 295);
            pnlAddButtonWrapper.Name = "pnlAddButtonWrapper";
            pnlAddButtonWrapper.Size = new Size(350, 60);
            pnlAddButtonWrapper.TabIndex = 0;
            // 
            // pnlAddCardWrapper
            // 
            pnlAddCardWrapper.Controls.Add(pnlAddFile);
            pnlAddCardWrapper.Controls.Add(pnlInput);
            pnlAddCardWrapper.Dock = DockStyle.Top;
            pnlAddCardWrapper.Location = new Point(0, 45);
            pnlAddCardWrapper.Name = "pnlAddCardWrapper";
            pnlAddCardWrapper.Size = new Size(350, 250);
            pnlAddCardWrapper.TabIndex = 0;
            pnlAddCardWrapper.Visible = false;
            // 
            // pnlAddFile
            // 
            pnlAddFile.BackColor = Color.White;
            pnlAddFile.Controls.Add(lblShowNameFile);
            pnlAddFile.Location = new Point(25, 210);
            pnlAddFile.Name = "pnlAddFile";
            pnlAddFile.Size = new Size(300, 40);
            pnlAddFile.TabIndex = 1;
            // 
            // lblShowNameFile
            // 
            lblShowNameFile.AutoEllipsis = true;
            lblShowNameFile.AutoSize = true;
            lblShowNameFile.BackColor = Color.Transparent;
            lblShowNameFile.Font = new Font("iCiel Panton Light", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblShowNameFile.ForeColor = Color.White;
            lblShowNameFile.Location = new Point(10, 10);
            lblShowNameFile.Name = "lblShowNameFile";
            lblShowNameFile.Size = new Size(39, 20);
            lblShowNameFile.TabIndex = 0;
            lblShowNameFile.Text = "Test";
            // 
            // pnlInput
            // 
            pnlInput.BackColor = Color.White;
            pnlInput.Controls.Add(btn_Cancel);
            pnlInput.Controls.Add(btn_AddFile);
            pnlInput.Controls.Add(btnSave);
            pnlInput.Controls.Add(txtContext);
            pnlInput.Controls.Add(cmbPrior);
            pnlInput.Controls.Add(txtTitle);
            pnlInput.Location = new Point(25, 10);
            pnlInput.Margin = new Padding(0);
            pnlInput.Name = "pnlInput";
            pnlInput.Padding = new Padding(25, 0, 25, 0);
            pnlInput.Size = new Size(300, 200);
            pnlInput.TabIndex = 0;
            // 
            // btn_Cancel
            // 
            btn_Cancel.Font = new Font("iCiel Panton Light Italic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_Cancel.Location = new Point(144, 165);
            btn_Cancel.Name = "btn_Cancel";
            btn_Cancel.Size = new Size(70, 29);
            btn_Cancel.TabIndex = 5;
            btn_Cancel.Text = "Cancel";
            btn_Cancel.UseVisualStyleBackColor = true;
            btn_Cancel.Click += btnCancel_Click;
            // 
            // btn_AddFile
            // 
            btn_AddFile.Font = new Font("iCiel Panton Light Italic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_AddFile.Location = new Point(10, 165);
            btn_AddFile.Name = "btn_AddFile";
            btn_AddFile.Size = new Size(70, 29);
            btn_AddFile.TabIndex = 4;
            btn_AddFile.Text = "Add File";
            btn_AddFile.UseVisualStyleBackColor = true;
            btn_AddFile.Click += btnAttach_Click;
            // 
            // btnSave
            // 
            btnSave.Font = new Font("iCiel Panton Light Italic", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnSave.Location = new Point(220, 165);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(70, 29);
            btnSave.TabIndex = 3;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // txtContext
            // 
            txtContext.Location = new Point(10, 85);
            txtContext.Multiline = true;
            txtContext.Name = "txtContext";
            txtContext.Size = new Size(280, 75);
            txtContext.TabIndex = 2;
            // 
            // txtTitle
            // 
            txtTitle.Location = new Point(10, 10);
            txtTitle.Name = "txtTitle";
            txtTitle.Size = new Size(280, 27);
            txtTitle.TabIndex = 0;
            txtTitle.TextChanged += txtTitle_TextChanged;
            // 
            // Columns
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Transparent;
            Controls.Add(flw_ColumnList);
            Controls.Add(pnlAddButtonWrapper);
            Controls.Add(pnlAddCardWrapper);
            Controls.Add(pnl_ColumnTitle);
            Name = "Columns";
            Size = new Size(350, 500);
            DragOver += Column_DragOver;
            pnl_ColumnTitle.ResumeLayout(false);
            pnl_ColumnTitle.PerformLayout();
            pnl_AddCard.ResumeLayout(false);
            pnl_AddCard.PerformLayout();
            pnlAddButtonWrapper.ResumeLayout(false);
            pnlAddCardWrapper.ResumeLayout(false);
            pnlAddFile.ResumeLayout(false);
            pnlAddFile.PerformLayout();
            pnlInput.ResumeLayout(false);
            pnlInput.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnl_ColumnTitle;
        private Label lblColumnTitle;
        private Panel pnl_AddCard;
        private Label lbl_AddCard;
        private FlowLayoutPanel flw_ColumnList;
        private Panel pnlAddButtonWrapper;
        private Panel pnlAddCardWrapper;
        private Panel pnlInput;
        private TextBox txtTitle;
        private TextBox txtContext;
        private Button btn_AddFile;
        private Button btnSave;
        private Button btn_Cancel;
        private Panel pnlAddFile;
        private Label lblShowNameFile;
        private ComboBox cmbPrior;
    }
}

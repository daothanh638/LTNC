using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace t5
{
    partial class Form1
    {
        private IContainer components = null;
        private Panel headerPanel;
        private PictureBox logoPictureBox;
        private Label lblAppTitle;
        private Label lblStudentId;
        private TextBox txtStudentId;
        private Label lblFullName;
        private TextBox txtFullName;
        private Label lblDob;
        private DateTimePicker dtpDob;
        private Label lblGender;
        private RadioButton rdoMale;
        private RadioButton rdoFemale;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblClass;
        private ComboBox cboClass;
        private Label lblScore;
        private NumericUpDown nudScore;
        private Label lblStatus;
        private ComboBox cboStatus;
        private Label lblKeyword;
        private TextBox txtKeyword;
        private Label lblFilterClass;
        private ComboBox cboFilterClass;
        private Label lblFilterScoreFrom;
        private NumericUpDown nudFilterScoreFrom;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnReset;
        private Button btnSearch;
        private Button btnShowAll;
        private DataGridView dgvStudents;
        private StatusStrip statusStrip;
        private ToolStripStatusLabel toolStripStatusLabel;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            headerPanel = new Panel();
            logoPictureBox = new PictureBox();
            lblAppTitle = new Label();
            lblStudentId = new Label();
            txtStudentId = new TextBox();
            lblFullName = new Label();
            txtFullName = new TextBox();
            lblDob = new Label();
            dtpDob = new DateTimePicker();
            lblGender = new Label();
            rdoMale = new RadioButton();
            rdoFemale = new RadioButton();
            lblEmail = new Label();
            txtEmail = new TextBox();
            lblPhone = new Label();
            txtPhone = new TextBox();
            lblClass = new Label();
            cboClass = new ComboBox();
            lblScore = new Label();
            nudScore = new NumericUpDown();
            lblStatus = new Label();
            cboStatus = new ComboBox();
            lblKeyword = new Label();
            txtKeyword = new TextBox();
            lblFilterClass = new Label();
            cboFilterClass = new ComboBox();
            lblFilterScoreFrom = new Label();
            nudFilterScoreFrom = new NumericUpDown();
            btnAdd = new Button();
            btnEdit = new Button();
            btnDelete = new Button();
            btnReset = new Button();
            btnSearch = new Button();
            btnShowAll = new Button();
            dgvStudents = new DataGridView();
            // added Matched checkbox column
            var colMatched = new DataGridViewCheckBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn9 = new DataGridViewTextBoxColumn();
            statusStrip = new StatusStrip();
            toolStripStatusLabel = new ToolStripStatusLabel();
            headerPanel.SuspendLayout();
            ((ISupportInitialize)logoPictureBox).BeginInit();
            ((ISupportInitialize)nudScore).BeginInit();
            ((ISupportInitialize)nudFilterScoreFrom).BeginInit();
            ((ISupportInitialize)dgvStudents).BeginInit();
            statusStrip.SuspendLayout();
            SuspendLayout();
            // 
            // headerPanel
            // 
            headerPanel.BackColor = Color.FromArgb(32, 83, 120);
            headerPanel.Controls.Add(logoPictureBox);
            headerPanel.Controls.Add(lblAppTitle);
            headerPanel.Location = new Point(0, 0);
            headerPanel.Name = "headerPanel";
            headerPanel.Size = new Size(1180, 56);
            headerPanel.TabIndex = 0;
            headerPanel.Paint += headerPanel_Paint;
            // 
            // logoPictureBox
            // 
            logoPictureBox.BackColor = Color.White;
            logoPictureBox.Location = new Point(12, 8);
            logoPictureBox.Name = "logoPictureBox";
            logoPictureBox.Size = new Size(40, 40);
            logoPictureBox.TabIndex = 0;
            logoPictureBox.TabStop = false;
            logoPictureBox.Click += logoPictureBox_Click;
            // 
            // lblAppTitle
            // 
            lblAppTitle.AutoSize = true;
            lblAppTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblAppTitle.ForeColor = Color.White;
            lblAppTitle.Location = new Point(60, 14);
            lblAppTitle.Name = "lblAppTitle";
            lblAppTitle.Size = new Size(204, 28);
            lblAppTitle.TabIndex = 1;
            lblAppTitle.Text = "QUẢN LÝ SINH VIÊN";
            lblAppTitle.Click += lblAppTitle_Click;
            // 
            // lblStudentId
            // 
            lblStudentId.AutoSize = true;
            lblStudentId.Location = new Point(12, 70);
            lblStudentId.Name = "lblStudentId";
            lblStudentId.Size = new Size(91, 20);
            lblStudentId.TabIndex = 1;
            lblStudentId.Text = "Mã sinh viên";
            // 
            // txtStudentId
            // 
            txtStudentId.Location = new Point(110, 67);
            txtStudentId.Name = "txtStudentId";
            txtStudentId.Size = new Size(180, 27);
            txtStudentId.TabIndex = 2;
            // 
            // lblFullName
            // 
            lblFullName.AutoSize = true;
            lblFullName.Location = new Point(300, 70);
            lblFullName.Name = "lblFullName";
            lblFullName.Size = new Size(73, 20);
            lblFullName.TabIndex = 3;
            lblFullName.Text = "Họ và tên";
            // 
            // txtFullName
            // 
            txtFullName.Location = new Point(375, 67);
            txtFullName.Name = "txtFullName";
            txtFullName.Size = new Size(240, 27);
            txtFullName.TabIndex = 4;
            // 
            // lblDob
            // 
            lblDob.AutoSize = true;
            lblDob.Location = new Point(625, 70);
            lblDob.Name = "lblDob";
            lblDob.Size = new Size(74, 20);
            lblDob.TabIndex = 5;
            lblDob.Text = "Ngày sinh";
            // 
            // dtpDob
            // 
            dtpDob.Format = DateTimePickerFormat.Short;
            dtpDob.Location = new Point(705, 65);
            dtpDob.Name = "dtpDob";
            dtpDob.Size = new Size(130, 27);
            dtpDob.TabIndex = 6;
            // 
            // lblGender
            // 
            lblGender.AutoSize = true;
            lblGender.Location = new Point(844, 70);
            lblGender.Name = "lblGender";
            lblGender.Size = new Size(65, 20);
            lblGender.TabIndex = 7;
            lblGender.Text = "Giới tính";
            // 
            // rdoMale
            // 
            rdoMale.AutoSize = true;
            rdoMale.Location = new Point(915, 68);
            rdoMale.Name = "rdoMale";
            rdoMale.Size = new Size(62, 24);
            rdoMale.TabIndex = 8;
            rdoMale.Text = "Nam";
            rdoMale.UseVisualStyleBackColor = true;
            // 
            // rdoFemale
            // 
            rdoFemale.AutoSize = true;
            rdoFemale.Location = new Point(982, 68);
            rdoFemale.Name = "rdoFemale";
            rdoFemale.Size = new Size(50, 24);
            rdoFemale.TabIndex = 9;
            rdoFemale.Text = "Nữ";
            rdoFemale.UseVisualStyleBackColor = true;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(12, 115);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(46, 20);
            lblEmail.TabIndex = 13;
            lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            txtEmail.Location = new Point(110, 112);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(300, 27);
            txtEmail.TabIndex = 14;
            txtEmail.TextChanged += txtEmail_TextChanged;
            // 
            // lblPhone
            // 
            lblPhone.AutoSize = true;
            lblPhone.Location = new Point(426, 119);
            lblPhone.Name = "lblPhone";
            lblPhone.Size = new Size(78, 20);
            lblPhone.TabIndex = 15;
            lblPhone.Text = "Điện thoại";
            // 
            // txtPhone
            // 
            txtPhone.Location = new Point(510, 115);
            txtPhone.Name = "txtPhone";
            txtPhone.Size = new Size(200, 27);
            txtPhone.TabIndex = 16;
            // 
            // lblClass
            // 
            lblClass.AutoSize = true;
            lblClass.Location = new Point(680, 28);
            lblClass.Name = "lblClass";
            lblClass.Size = new Size(62, 20);
            lblClass.TabIndex = 17;
            lblClass.Text = "Lớp học";
            // 
            // cboClass
            // 
            cboClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cboClass.Items.AddRange(new object[] { "Kỹ thuật phần mềm 01", "Trí tuệ nhân tạo 01", "Khoa học dữ liệu 01" });
            cboClass.Location = new Point(740, 24);
            cboClass.Name = "cboClass";
            cboClass.Size = new Size(200, 28);
            cboClass.TabIndex = 18;
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(729, 119);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(45, 20);
            lblScore.TabIndex = 19;
            lblScore.Text = "Điểm";
            // 
            // nudScore
            // 
            nudScore.DecimalPlaces = 1;
            nudScore.Location = new Point(789, 115);
            nudScore.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudScore.Name = "nudScore";
            nudScore.Size = new Size(120, 27);
            nudScore.TabIndex = 20;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(940, 119);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(75, 20);
            lblStatus.TabIndex = 17;
            lblStatus.Text = "Trạng thái";
            // 
            // cboStatus
            // 
            cboStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            cboStatus.Items.AddRange(new object[] { "Đang học", "Tạm nghỉ", "Đã tốt nghiệp" });
            cboStatus.Location = new Point(1040, 115);
            cboStatus.Name = "cboStatus";
            cboStatus.Size = new Size(140, 28);
            cboStatus.TabIndex = 18;
            cboStatus.SelectedIndexChanged += cboStatus_SelectedIndexChanged;
            // 
            // lblKeyword
            // 
            lblKeyword.Location = new Point(0, 0);
            lblKeyword.Name = "lblKeyword";
            lblKeyword.Size = new Size(100, 23);
            lblKeyword.TabIndex = 0;
            // 
            // txtKeyword
            // 
            txtKeyword.Location = new Point(12, 12);
            txtKeyword.Name = "txtKeyword";
            txtKeyword.PlaceholderText = "Mã, họ tên, email hoặc điện thoại";
            txtKeyword.Size = new Size(420, 27);
            txtKeyword.TabIndex = 0;
            // 
            // lblFilterClass
            // 
            lblFilterClass.Location = new Point(0, 0);
            lblFilterClass.Name = "lblFilterClass";
            lblFilterClass.Size = new Size(100, 23);
            lblFilterClass.TabIndex = 0;
            // 
            // cboFilterClass
            // 
            cboFilterClass.DropDownStyle = ComboBoxStyle.DropDownList;
            cboFilterClass.Items.AddRange(new object[] { "Tất cả lớp", "Kỹ thuật phần mềm 01", "Trí tuệ nhân tạo 01", "Khoa học dữ liệu 01" });
            cboFilterClass.Location = new Point(450, 12);
            cboFilterClass.Name = "cboFilterClass";
            cboFilterClass.Size = new Size(200, 28);
            cboFilterClass.TabIndex = 1;
            // 
            // lblFilterScoreFrom
            // 
            lblFilterScoreFrom.Location = new Point(0, 0);
            lblFilterScoreFrom.Name = "lblFilterScoreFrom";
            lblFilterScoreFrom.Size = new Size(100, 23);
            lblFilterScoreFrom.TabIndex = 0;
            // 
            // nudFilterScoreFrom
            // 
            nudFilterScoreFrom.DecimalPlaces = 1;
            nudFilterScoreFrom.Location = new Point(670, 12);
            nudFilterScoreFrom.Maximum = new decimal(new int[] { 10, 0, 0, 0 });
            nudFilterScoreFrom.Name = "nudFilterScoreFrom";
            nudFilterScoreFrom.Size = new Size(80, 27);
            nudFilterScoreFrom.TabIndex = 2;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(40, 167, 69);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(662, 172);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(80, 28);
            btnAdd.TabIndex = 19;
            btnAdd.Text = "Thêm";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += btnAdd_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(23, 162, 184);
            btnEdit.ForeColor = Color.White;
            btnEdit.Location = new Point(755, 172);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(80, 28);
            btnEdit.TabIndex = 20;
            btnEdit.Text = "Sửa";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += btnEdit_Click;
            // 
            // btnDelete
            // 
            btnDelete.BackColor = Color.FromArgb(220, 53, 69);
            btnDelete.ForeColor = Color.White;
            btnDelete.Location = new Point(844, 172);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(80, 28);
            btnDelete.TabIndex = 21;
            btnDelete.Text = "Xóa";
            btnDelete.UseVisualStyleBackColor = false;
            btnDelete.Click += btnDelete_Click;
            // 
            // btnReset
            // 
            btnReset.Location = new Point(940, 172);
            btnReset.Name = "btnReset";
            btnReset.Size = new Size(100, 28);
            btnReset.TabIndex = 22;
            btnReset.Text = "Làm mới";
            btnReset.Click += btnReset_Click;
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(770, 10);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(90, 28);
            btnSearch.TabIndex = 3;
            btnSearch.Text = "Tìm kiếm";
            btnSearch.Click += btnSearch_Click;
            // 
            // btnShowAll
            // 
            btnShowAll.Location = new Point(868, 10);
            btnShowAll.Name = "btnShowAll";
            btnShowAll.Size = new Size(90, 28);
            btnShowAll.TabIndex = 4;
            btnShowAll.Text = "Hiển thị tất cả";
            btnShowAll.Click += btnShowAll_Click;
            // 
            // dgvStudents
            // 
            dgvStudents.AllowUserToAddRows = false;
            dgvStudents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvStudents.ColumnHeadersHeight = 29;
            // include matched checkbox as first column
            colMatched.Name = "colMatched";
            colMatched.HeaderText = "Matched";
            colMatched.ReadOnly = true;
            colMatched.Width = 60;
            colMatched.SortMode = DataGridViewColumnSortMode.NotSortable;
            dgvStudents.Columns.AddRange(new DataGridViewColumn[] { colMatched, dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7, dataGridViewTextBoxColumn8, dataGridViewTextBoxColumn9 });
            dgvStudents.Location = new Point(0, 236);
            dgvStudents.Name = "dgvStudents";
            dgvStudents.RowHeadersVisible = false;
            dgvStudents.RowHeadersWidth = 51;
            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.Size = new Size(1260, 260);
            dgvStudents.TabIndex = 3;
            dgvStudents.CellContentClick += dgvStudents_CellContentClick;
            dgvStudents.SelectionChanged += dgvStudents_SelectionChanged;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Mã SV";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Họ và tên";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "Ngày sinh";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Giới tính";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Email";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Điện thoại";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "Điểm";
            dataGridViewTextBoxColumn7.MinimumWidth = 6;
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Lớp";
            dataGridViewTextBoxColumn8.MinimumWidth = 6;
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // dataGridViewTextBoxColumn9
            // 
            dataGridViewTextBoxColumn9.HeaderText = "Trạng thái";
            dataGridViewTextBoxColumn9.MinimumWidth = 6;
            dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            // 
            // statusStrip
            // 
            statusStrip.ImageScalingSize = new Size(20, 20);
            statusStrip.Items.AddRange(new ToolStripItem[] { toolStripStatusLabel });
            statusStrip.Location = new Point(0, 605);
            statusStrip.Name = "statusStrip";
            statusStrip.Size = new Size(1284, 26);
            statusStrip.TabIndex = 4;
            // 
            // toolStripStatusLabel
            // 
            toolStripStatusLabel.Name = "toolStripStatusLabel";
            toolStripStatusLabel.Size = new Size(138, 20);
            toolStripStatusLabel.Text = "Tổng số: 0 sinh viên";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1284, 631);
            Controls.Add(headerPanel);
            Controls.Add(lblStudentId);
            Controls.Add(txtStudentId);
            Controls.Add(lblFullName);
            Controls.Add(txtFullName);
            Controls.Add(lblDob);
            Controls.Add(dtpDob);
            Controls.Add(lblGender);
            Controls.Add(rdoMale);
            Controls.Add(rdoFemale);
            Controls.Add(lblEmail);
            Controls.Add(txtEmail);
            Controls.Add(lblPhone);
            Controls.Add(txtPhone);
            Controls.Add(lblClass);
            Controls.Add(cboClass);
            Controls.Add(lblScore);
            Controls.Add(nudScore);
            Controls.Add(lblStatus);
            Controls.Add(cboStatus);
            Controls.Add(btnAdd);
            Controls.Add(btnEdit);
            Controls.Add(btnDelete);
            Controls.Add(btnReset);
            Controls.Add(txtKeyword);
            Controls.Add(cboFilterClass);
            Controls.Add(nudFilterScoreFrom);
            Controls.Add(btnSearch);
            Controls.Add(btnShowAll);
            Controls.Add(dgvStudents);
            Controls.Add(statusStrip);
            Name = "Form1";
            Text = "Ứng dụng quản lý sinh viên";
            Load += Form1_Load;
            headerPanel.ResumeLayout(false);
            headerPanel.PerformLayout();
            ((ISupportInitialize)logoPictureBox).EndInit();
            ((ISupportInitialize)nudScore).EndInit();
            ((ISupportInitialize)nudFilterScoreFrom).EndInit();
            ((ISupportInitialize)dgvStudents).EndInit();
            statusStrip.ResumeLayout(false);
            statusStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }
    }
}

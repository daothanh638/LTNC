using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace WinFormsApp2
{
    public partial class QLSV : Form
    {
        // In-memory model
        private readonly List<SinhVien> students = new();
        private readonly List<LopHoc> classes = new();

        // Regex for class code: CSE + 4 digits
        private static readonly Regex ClassCodeRegex = new("^CSE\\d{4}$", RegexOptions.Compiled | RegexOptions.IgnoreCase);

        public QLSV()
        {
            InitializeComponent();

            // Wire up button events here so Designer file doesn't need to be edited
            btnAdd.Click += BtnAdd_Click;
            btnEdit.Click += BtnEdit_Click;
            btnRemove.Click += BtnRemove_Click;
            btnRefresh.Click += BtnRefresh_Click;
            btnSearch.Click += BtnSearch_Click;
            btnShowAll.Click += BtnShowAll_Click;

            // Wire student id leave handler to detect existing student
            txtStudentId.Leave += TxtStudentId_Leave;

            // Initial button states
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnRemove.Enabled = false;

            dgvStudents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvStudents.MultiSelect = false;
            dgvStudents.AutoGenerateColumns = false;

            // configure columns so data appears when AutoGenerateColumns is false
            ConfigureDataGrid();

            // Enter key on search boxes triggers search
            txtSearch.KeyDown += TxtSearch_KeyDown;
            txtSearchValue.KeyDown += TxtSearch_KeyDown;
        }

        private void ConfigureDataGrid()
        {
            if (dgvStudents == null) return;
            dgvStudents.Columns.Clear();

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStudentId",
                HeaderText = "Mã sinh viên",
                DataPropertyName = "StudentId",
                ReadOnly = true,
                Width = 90
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colFullName",
                HeaderText = "Họ và tên",
                DataPropertyName = "FullName",
                Width = 160
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colEmail",
                HeaderText = "Email",
                DataPropertyName = "Email",
                Width = 180
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colDate",
                HeaderText = "Ngày sinh",
                DataPropertyName = "DateOfBirth",
                Width = 90
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colPhone",
                HeaderText = "Điện thoại",
                DataPropertyName = "Phone",
                Width = 110
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colGender",
                HeaderText = "Giới tính",
                DataPropertyName = "Gender",
                Width = 80
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colScore",
                HeaderText = "Điểm",
                DataPropertyName = "Score",
                Width = 60,
                DefaultCellStyle = { Format = "N1" }
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colStatus",
                HeaderText = "Trạng thái",
                DataPropertyName = "Status",
                Width = 80
            });

            dgvStudents.Columns.Add(new DataGridViewTextBoxColumn
            {
                Name = "colClass",
                HeaderText = "Lớp học",
                DataPropertyName = "Classes",
                Width = 120
            });

            dgvStudents.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeData();
            RefreshGrid(students);

            // Set tab order to traverse top->bottom, left->right
            SetTabOrder();
            // default focus
            txtStudentId.Select();
        }

        private void SetTabOrder()
        {
            // Define an explicit tab order: top-down, left-right roughly by control appearance
            var order = new Control[]
            {
                txtStudentId,
                txtFullName,
                txtEmail,
                dtpDate,
                txtPhone,
                nudScore,
                cbClass,
                cbStatus,
                btnAdd,
                btnEdit,
                btnRemove,
                btnRefresh,
                txtSearch,
                cbSearchField,
                txtSearchValue,
                btnSearch,
                btnShowAll,
                dgvStudents
            };

            for (int i = 0; i < order.Length; i++)
            {
                order[i].TabIndex = i;
            }
        }

        private void InitializeData()
        {
            // Seed some classes that respect the CSExxxx pattern
            var seedCodes = new[] { "CSE1000", "CSE1001", "CSE2002", "CSE3003" };
            foreach (var code in seedCodes)
            {
                if (ClassCodeRegex.IsMatch(code))
                {
                    classes.Add(new LopHoc { Code = code, Name = code + " - Sample" });
                }
            }

            // Populate UI pickers
            cbClass.Items.Clear();
            cbClass.Items.AddRange(classes.Select(c => c.Code).ToArray());
            if (cbClass.Items.Count > 0) cbClass.SelectedIndex = 0;

            cbStatus.Items.Clear();
            cbStatus.Items.AddRange(new[] { "Đang học", "Đã nghỉ" });
            cbStatus.SelectedIndex = 0;

            cbSearchField.Items.Clear();
            cbSearchField.Items.Add("Tất cả lớp");
            cbSearchField.Items.AddRange(classes.Select(c => c.Code).Cast<object>().ToArray());
            cbSearchField.SelectedIndex = 0;

            // Seed sample students for testing
            var c1 = classes.FirstOrDefault(c => c.Code == "CSE1000");
            var c2 = classes.FirstOrDefault(c => c.Code == "CSE1001");
            var c3 = classes.FirstOrDefault(c => c.Code == "CSE2002");

            var sampleStudents = new[]
            {
                new SinhVien { StudentId = "SV1000", FullName = "Nguyễn Văn An", Email = "an.van@example.com", DateOfBirth = new DateTime(2000,1,15), Phone = "0901234567", Gender = "Nam", Score = 8.5, Status = "Đang học", Class = c1 },
                new SinhVien { StudentId = "SV1001", FullName = "Trần Thị Bình", Email = "binh.tran@example.com", DateOfBirth = new DateTime(1999,5,30), Phone = "0912345678", Gender = "Nữ", Score = 7.2, Status = "Đang học", Class = c2 },
                new SinhVien { StudentId = "SV1002", FullName = "Lê Hoàng Minh", Email = "minh.le@example.com", DateOfBirth = new DateTime(2001,3,20), Phone = "0987654321", Gender = "Nam", Score = 9.1, Status = "Đã nghỉ", Class = c1 },
                new SinhVien { StudentId = "SV1003", FullName = "Phạm Thị Hương", Email = "huong.pham@example.com", DateOfBirth = new DateTime(2002,11,5), Phone = "0977123456", Gender = "Nữ", Score = 6.0, Status = "Đang học", Class = c3 }
            };

            foreach (var s in sampleStudents)
            {
                // ensure class list link
                if (s.Class != null)
                {
                    s.Class.Students.Add(s);
                }
                students.Add(s);
            }
        }

        private void RefreshGrid(IEnumerable<SinhVien> source)
        {
            var view = source.Select(s => new StudentView
            {
                StudentId = s.StudentId,
                FullName = s.FullName,
                Email = s.Email,
                DateOfBirth = s.DateOfBirth.ToShortDateString(),
                Phone = s.Phone,
                Gender = s.Gender,
                Score = s.Score,
                Status = s.Status,
                Classes = s.Class != null ? s.Class.Code : string.Empty
            }).ToList();

            dgvStudents.DataSource = new BindingSource { DataSource = view };
            txtTotal.Text = view.Count.ToString();
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            var id = txtStudentId.Text?.Trim();
            if (string.IsNullOrEmpty(id))
            {
                MessageBox.Show("StudentId is required.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (students.Any(s => s.StudentId.Equals(id, StringComparison.OrdinalIgnoreCase)))
            {
                MessageBox.Show("StudentId already exists.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var selectedClassCode = cbClass.SelectedItem as string;
            LopHoc selectedClass = null;
            if (!string.IsNullOrEmpty(selectedClassCode))
            {
                if (!ClassCodeRegex.IsMatch(selectedClassCode))
                {
                    MessageBox.Show("Class code must follow CSE + 4 digits.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                selectedClass = classes.FirstOrDefault(c => c.Code.Equals(selectedClassCode, StringComparison.OrdinalIgnoreCase));
                if (selectedClass == null)
                {
                    selectedClass = new LopHoc { Code = selectedClassCode, Name = selectedClassCode };
                    classes.Add(selectedClass);
                    cbClass.Items.Add(selectedClass.Code);
                }
            }

            var student = new SinhVien
            {
                StudentId = id,
                FullName = txtFullName.Text?.Trim() ?? string.Empty,
                Email = txtEmail.Text?.Trim() ?? string.Empty,
                DateOfBirth = dtpDate.Value,
                Phone = txtPhone.Text?.Trim() ?? string.Empty,
                Gender = rbFemale.Checked ? "Nữ" : "Nam",
                Score = (double)nudScore.Value,
                Status = cbStatus.SelectedItem as string ?? string.Empty,
                Class = selectedClass
            };

            // validate
            if (!ValidateModel(student, out var errors))
            {
                MessageBox.Show(string.Join("\n", errors.Select(r => r.ErrorMessage)), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            selectedClass!.Students.Add(student);
            students.Add(student);
            RefreshGrid(students);
            ClearInputs();
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null) return;
            var idConfirm = dgvStudents.CurrentRow.Cells[0].Value as string ?? "";
            var ok = MessageBox.Show($"Bạn có chắc chắn muốn cập nhật thông tin sinh viên '{idConfirm}'?\nHành động này sẽ ghi đè dữ liệu hiện tại.", "Xác nhận cập nhật", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (ok != DialogResult.Yes) return;

            var id = dgvStudents.CurrentRow.Cells[0].Value as string; // StudentId column
            var student = students.FirstOrDefault(s => s.StudentId.Equals(id, StringComparison.OrdinalIgnoreCase));
            if (student == null) return;

            var selectedClassCode = cbClass.SelectedItem as string;
            LopHoc? selectedClass = null;
            if (!string.IsNullOrEmpty(selectedClassCode) && ClassCodeRegex.IsMatch(selectedClassCode))
            {
                selectedClass = classes.FirstOrDefault(c => c.Code.Equals(selectedClassCode, StringComparison.OrdinalIgnoreCase));
                selectedClass ??= new LopHoc { Code = selectedClassCode, Name = selectedClassCode };
            }

            var updatedStudent = new SinhVien
            {
                StudentId = student.StudentId,
                FullName = txtFullName.Text?.Trim() ?? string.Empty,
                Email = txtEmail.Text?.Trim() ?? string.Empty,
                DateOfBirth = dtpDate.Value,
                Phone = txtPhone.Text?.Trim() ?? string.Empty,
                Gender = rbFemale.Checked ? "Nữ" : "Nam",
                Score = (double)nudScore.Value,
                Status = cbStatus.SelectedItem as string ?? string.Empty,
                Class = selectedClass
            };

            if (!ValidateModel(updatedStudent, out var errors))
            {
                MessageBox.Show(string.Join("\n", errors.Select(r => r.ErrorMessage)), "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (selectedClass != null && !classes.Contains(selectedClass))
            {
                classes.Add(selectedClass);
                cbClass.Items.Add(selectedClass.Code);
            }

            student.Class?.Students.Remove(student);
            student.FullName = updatedStudent.FullName;
            student.Email = updatedStudent.Email;
            student.DateOfBirth = updatedStudent.DateOfBirth;
            student.Phone = updatedStudent.Phone;
            student.Gender = updatedStudent.Gender;
            student.Score = updatedStudent.Score;
            student.Status = updatedStudent.Status;
            student.Class = selectedClass;
            selectedClass!.Students.Add(student);
            RefreshGrid(students);
        }

        private void BtnRemove_Click(object sender, EventArgs e)
        {
            if (dgvStudents.CurrentRow == null) return;
            var id = dgvStudents.CurrentRow.Cells[0].Value as string;
            var student = students.FirstOrDefault(s => s.StudentId.Equals(id, StringComparison.OrdinalIgnoreCase));
            if (student == null) return;

            var confirm = MessageBox.Show($"Bạn có thực sự muốn xóa sinh viên '{id}'? Hành động này không thể hoàn tác.", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (confirm != DialogResult.Yes) return;

            // Remove from class
            if (student.Class != null)
            {
                student.Class.Students.Remove(student);
            }

            students.Remove(student);
            RefreshGrid(students);
        }

        private void BtnRefresh_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Bạn muốn xóa trắng các trường nhập và bắt đầu nhập sinh viên mới?", "Xác nhận làm mới", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;
            ClearInputs();
            btnAdd.Enabled = true;
            btnEdit.Enabled = false;
            btnRemove.Enabled = false;
            txtStudentId.Select();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            var keyword = txtSearch.Text.Trim();
            var selectedClass = cbSearchField.SelectedItem as string ?? "Tất cả lớp";
            var minimumScore = 0d;
            if (!string.IsNullOrWhiteSpace(txtSearchValue.Text) &&
                !double.TryParse(txtSearchValue.Text, out minimumScore))
            {
                MessageBox.Show("Điểm tối thiểu phải là một số từ 0 đến 10.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (minimumScore is < 0 or > 10)
            {
                MessageBox.Show("Điểm tối thiểu phải nằm trong khoảng từ 0 đến 10.", "Dữ liệu không hợp lệ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            IEnumerable<SinhVien> result = students;
            if (!string.IsNullOrWhiteSpace(keyword))
            {
                result = result.Where(s =>
                    s.StudentId.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    s.FullName.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    s.Email.Contains(keyword, StringComparison.OrdinalIgnoreCase) ||
                    s.Phone.Contains(keyword, StringComparison.OrdinalIgnoreCase));
            }

            if (!string.Equals(selectedClass, "Tất cả lớp", StringComparison.Ordinal))
                result = result.Where(s => s.Class?.Code == selectedClass);

            result = result.Where(s => s.Score >= minimumScore);
            RefreshGrid(result);
        }

        private void TxtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true;
                e.SuppressKeyPress = true;
                BtnSearch_Click(sender, EventArgs.Empty);
            }
        }

        private void BtnShowAll_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            txtSearchValue.Clear();
            if (cbSearchField.Items.Count > 0) cbSearchField.SelectedIndex = 0;
            RefreshGrid(students);
        }

        private static bool ValidateModel(object model, out IList<ValidationResult> results)
        {
            var ctx = new ValidationContext(model, serviceProvider: null, items: null);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(model, ctx, results, validateAllProperties: true);
        }

        private void ClearInputs()
        {
            txtStudentId.Clear();
            txtFullName.Clear();
            txtEmail.Clear();
            txtPhone.Clear();
            rbMale.Checked = true;
            rbFemale.Checked = false;
            dtpDate.Value = DateTime.Today;
            nudScore.Value = 0;
            if (cbClass.Items.Count > 0) cbClass.SelectedIndex = 0;
            if (cbStatus.Items.Count > 0) cbStatus.SelectedIndex = 0;
        }

        // Legacy designer event handlers (kept to avoid designer edit) - forward to new implementations where appropriate
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void radioButton5_CheckedChanged(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void textBox2_TextChanged(object sender, EventArgs e) { }
        private void MSV_TextChanged(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { BtnAdd_Click(sender, e); }
        private void button3_Click(object sender, EventArgs e) { BtnRemove_Click(sender, e); }
        private void button6_Click(object sender, EventArgs e) { BtnShowAll_Click(sender, e); }

        private void TxtStudentId_Leave(object sender, EventArgs e)
        {
            var id = txtStudentId.Text?.Trim();
            if (string.IsNullOrEmpty(id))
            {
                // no id entered => prepare for add
                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnRemove.Enabled = false;
                ClearInputs();
                txtStudentId.Text = string.Empty;
                return;
            }

            var existing = students.FirstOrDefault(s => s.StudentId.Equals(id, StringComparison.OrdinalIgnoreCase));
            if (existing != null)
            {
                // populate controls and enable edit/delete
                txtFullName.Text = existing.FullName;
                txtEmail.Text = existing.Email;
                dtpDate.Value = existing.DateOfBirth == default ? DateTime.Today : existing.DateOfBirth;
                txtPhone.Text = existing.Phone;
                rbMale.Checked = existing.Gender == "Nam";
                rbFemale.Checked = existing.Gender == "Nữ";
                nudScore.Value = (decimal)existing.Score;
                cbStatus.SelectedItem = existing.Status;
                if (existing.Class != null)
                {
                    var idx = cbClass.Items.IndexOf(existing.Class.Code);
                    if (idx >= 0) cbClass.SelectedIndex = idx;
                }

                btnAdd.Enabled = false;
                btnEdit.Enabled = true;
                btnRemove.Enabled = true;
            }
            else
            {
                // new student: clear other fields and enable add
                txtFullName.Clear();
                txtEmail.Clear();
                dtpDate.Value = DateTime.Today;
                txtPhone.Clear();
                nudScore.Value = 0;
                if (cbClass.Items.Count > 0) cbClass.SelectedIndex = 0;

                btnAdd.Enabled = true;
                btnEdit.Enabled = false;
                btnRemove.Enabled = false;
            }
        }

        // Simple view used for DataGridView binding
        private class StudentView
        {
            public string StudentId { get; set; }
            public string FullName { get; set; }
            public string Email { get; set; }
            public string DateOfBirth { get; set; }
            public string Phone { get; set; }
            public string Gender { get; set; }
            public double Score { get; set; }
            public string Status { get; set; }
            public string Classes { get; set; }
        }

    }
}

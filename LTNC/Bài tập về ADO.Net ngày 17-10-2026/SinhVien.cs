using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace t5
{
    public class SinhVien
    {
        [Required(ErrorMessage = "Mã sinh viên là bắt buộc")]
        public string Id { get; set; }

        [Required(ErrorMessage = "Họ và tên là bắt buộc")]
        [StringLength(200, ErrorMessage = "Họ và tên không vượt quá 200 ký tự")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Ngày sinh là bắt buộc")]
        public DateTime Dob { get; set; }

        [Required(ErrorMessage = "Giới tính là bắt buộc")]
        public string Gender { get; set; }

        [EmailAddress(ErrorMessage = "Email không hợp lệ")]
        public string Email { get; set; }

        [Phone(ErrorMessage = "Số điện thoại không hợp lệ")]
        public string Phone { get; set; }

        [Range(0, 10, ErrorMessage = "Điểm phải trong khoảng 0 - 10")]
        public decimal Score { get; set; }

        [Required(ErrorMessage = "Lớp là bắt buộc")]
        public string Lop { get; set; }

        public string Status { get; set; }

        public SinhVien() { }

        public SinhVien(string id, string fullName, DateTime dob, string gender, string email, string phone, decimal score, string lop, string status)
        {
            Id = id;
            FullName = fullName;
            Dob = dob;
            Gender = gender;
            Email = email;
            Phone = phone;
            Score = score;
            Lop = lop;
            Status = status;
        }

        public bool Validate(out ICollection<ValidationResult> results)
        {
            var ctx = new ValidationContext(this);
            results = new List<ValidationResult>();
            return Validator.TryValidateObject(this, ctx, results, true);
        }
    }
}

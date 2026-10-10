using System;
using System.ComponentModel.DataAnnotations;

namespace WinFormsApp2;

/// <summary>Một sinh viên thuộc một lớp học.</summary>
public class SinhVien
{
    [Required(ErrorMessage = "Mã sinh viên không được để trống.")]
    [RegularExpression("^[A-Za-z0-9]{1,20}$", ErrorMessage = "Mã sinh viên chỉ gồm chữ và số, tối đa 20 ký tự.")]
    public string StudentId { get; set; } = string.Empty;

    [Required(ErrorMessage = "Họ tên không được để trống.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Họ tên phải từ 2 đến 100 ký tự.")]
    public string FullName { get; set; } = string.Empty;

    [Required(ErrorMessage = "Email không được để trống.")]
    [EmailAddress(ErrorMessage = "Email không đúng định dạng.")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "Ngày sinh không hợp lệ.")]
    public DateTime DateOfBirth { get; set; }

    [Required(ErrorMessage = "Số điện thoại không được để trống.")]
    [Phone(ErrorMessage = "Số điện thoại không đúng định dạng.")]
    public string Phone { get; set; } = string.Empty;

    [Required(ErrorMessage = "Giới tính không được để trống.")]
    public string Gender { get; set; } = "Nam";

    [Range(0, 10, ErrorMessage = "Điểm phải nằm trong khoảng từ 0 đến 10.")]
    public double Score { get; set; }

    [Required(ErrorMessage = "Trạng thái không được để trống.")]
    public string Status { get; set; } = string.Empty;

    [Required(ErrorMessage = "Lớp học không được để trống.")]
    public LopHoc? Class { get; set; }
}

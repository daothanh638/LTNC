using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WinFormsApp2;

/// <summary>Một lớp học có thể có nhiều sinh viên.</summary>
public class LopHoc
{
    [Required(ErrorMessage = "Mã lớp không được để trống.")]
    [RegularExpression("^CSE\\d{4}$", ErrorMessage = "Mã lớp phải có dạng CSE và bốn chữ số.")]
    public string Code { get; set; } = string.Empty;

    [Required(ErrorMessage = "Tên lớp không được để trống.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "Tên lớp phải từ 2 đến 100 ký tự.")]
    public string Name { get; set; } = string.Empty;

    public List<SinhVien> Students { get; set; } = new();
}

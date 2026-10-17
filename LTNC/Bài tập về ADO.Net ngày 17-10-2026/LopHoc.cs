using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace t5
{
    public class LopHoc
    {
        [Required]
        public string MaLop { get; set; }

        [Required]
        public string TenLop { get; set; }

        public List<SinhVien> SinhViens { get; set; } = new List<SinhVien>();

        public LopHoc() { }

        public LopHoc(string maLop, string tenLop)
        {
            MaLop = maLop;
            TenLop = tenLop;
        }
    }
}

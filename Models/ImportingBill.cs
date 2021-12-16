using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingManagermenWF.Models
{
    public class ImportingBill
    {
        public string? MaPN { get; set; }
        public string? MaNCC { get; set; }
        public string? MaHang { get; set; }
        public DateTime NgayNhap { get; set; }
        public int SoLuongNhap { get; set; }
        public int GiaNhap { get; set; }
    }
}

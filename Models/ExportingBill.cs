using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingManagermenWF.Models
{
    public class ExportingBill
    {
        public string? MaPX { get; set; }
        public string? MaKH { get; set; }
        public string? MaHang { get; set; }
        public DateTime NgayBan { get; set; }
        public int SoLuongBan { get; set; }
        public int GiaBan { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SellingManagermenWF.Models
{
    public class Product
    {
        public string? MaHang { get; set; }
        public string? TenHang { get; set; }
        public string? LoaiHang { get; set; }
        public string? DonViTinh { get; set; }
        public int Hangcon { get; set; }
    }
}

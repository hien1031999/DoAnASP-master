using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP1.Areas.Admin.Models
{
    public class CTHD
    {
        [Key]
        public int MaCTHD { get; set; }
        public int MaHD { get; set; }
        [ForeignKey("MaHD")]
        public int MaSP { get; set; }
        [ForeignKey("MaSP")]
        public string SoLuong { get; set; }
        public string ThanhTien { get; set; }
        public ICollection<HoaDon> HoaDon { get; set; }
        public virtual SanPhamModels SanPham { get; set; }
        
    }
}

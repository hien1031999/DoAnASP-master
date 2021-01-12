using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP1.Areas.Admin.Models
{
    public class LoaiSPModels
    {
        [Key]
        public int MaLoai { get; set; }
        public string Ten { get; set; }
        public int TT { get; set; }
        public int MaNCC { get; set; }
        [ForeignKey("MaNCC")]
        public virtual NCC NCC { get; set; }

        public ICollection<SanPhamModels> LstSanPham { get; set; }
    }
}

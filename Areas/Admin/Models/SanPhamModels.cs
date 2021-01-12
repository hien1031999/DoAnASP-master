using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP1.Areas.Admin.Models
{
    public class SanPhamModels
    {

        [Key]
        public int MaSP { get; set; }
        public string TenSP { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime NgaySX { get; set; }
        [StringLength(255)]
        [Column(TypeName = "nvarchar(255")]
        public string Hinh { get; set; }
        public string MoTa { get; set; }
        [Range(100, 1000000000)]
        [DataType(DataType.Currency)]
        [Column(TypeName = "decimal(18,2")]
        public decimal Gia { get; set; }
        public int TrangThai { get; set; }

        public int MaLoai { get; set; }
        [ForeignKey("MaLoai")]
        public LoaiSPModels LoaiSP { get; set; }

    }
}

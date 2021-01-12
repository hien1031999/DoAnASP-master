using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP1.Areas.Admin.Models
{
    public class Comment
    {
        [Key]
        public int IdComment { get; set; }
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        public int MaSP { get; set; }
        [ForeignKey("MaSP")]
        public virtual SanPhamModels SanPham { get; set; }
        public string NoiDung { get; set; }
        public string Time { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DoAnASP1.Areas.Admin.Models
{
    public class NCC
    { 
        [Key]
        public int ID { get; set; }
        public string TenNCC { get; set; }
        public string DiaChi { get; set; }
        public string TrangThai { get; set; }
        public ICollection<LoaiSPModels> LSP { get; set; }
    }
}

using DocumentFormat.OpenXml.Drawing;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    [Table("ProductInfo")]
    public class ProductInfo
    {
        [Key]
        public int Pid { get; set; }
        public string Pname { get; set; }
        public string Ptype { get; set; }
        public string Pcompany { get; set; }
        public string Price { get; set; }
        public string Pkuaidi { get; set; }
        public DateTime Psendtime { get; set; }
        public DateTime Prectime { get; set; }
        public string Pdest { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    [Table("T_Department")]
    public class Department
    {
        [Key]
        public int DId { get; set; }
        public string DName { get; set; }
    }
}

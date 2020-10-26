using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    [Table("T_Work")]
    public class Work
    {
        [Key]
        public int WId { get; set; }
        public int DId { get; set; }
        public string WName { get; set; }
        public int WAge { get; set; }
        public int WState { get; set; }
    }
}

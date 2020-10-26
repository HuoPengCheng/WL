using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class WorkandDepView
    {
        [Key]
        public int WId { get; set; }
        public int DId { get; set; }
        public string DName { get; set; }
        public string WName { get; set; }
        public int WAge { get; set; }
        public int WState { get; set; }
        
    }
}

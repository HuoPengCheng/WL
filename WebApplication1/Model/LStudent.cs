using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class LStudent
    {
        [Key]
        public int LId { get; set; }
        public string Name { get; set; }
        public string Sex { get; set; }
        public int  Age { get; set; }

    }
}

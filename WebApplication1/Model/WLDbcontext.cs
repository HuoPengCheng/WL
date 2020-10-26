using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Model
{
    public class WLDbcontext: DbContext
    {
        public WLDbcontext() { }
        public WLDbcontext(DbContextOptions<WLDbcontext> options) : base(options) { }

        public DbSet<Work> Work { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<WorkandDepView> WorkandDepView { get; set; }
    }
}

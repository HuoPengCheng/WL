using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class HPCController : ControllerBase
    {
        public WLDbcontext db;
        public HPCController(WLDbcontext db) { this.db = db; }
        public async Task<ActionResult<IEnumerable<Student>>> Show()
        {
            return await db.Student.ToListAsync();
        }
    }
}

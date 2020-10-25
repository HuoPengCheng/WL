using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Dal;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [EnableCors("cors")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class PLStController : ControllerBase
    {
        Sdal d = new Sdal();
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<PLStudent> Get()
        {
            return d.Show();
        }
        [HttpPost]
        public IEnumerable<PLStudent> Gets(string Pname="")
        {
            var b = d.Show();
            if (!string.IsNullOrEmpty(Pname))
            {
                b = b.Where(m => m.Pname.Contains(Pname)).ToList();
            }
            return b;
        }
        [HttpPost]
        public IEnumerable<PLStudent> GetSS(int id=0)
        {
            var b = d.Show();
            if (id!=0)
            {
                b = b.Where(m => m.Pid == id).ToList();
            }
            return b;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public int Post(string Pname, string Psex, string Phao, string Ptele)
        {
            return d.Add(Pname,Psex,Phao,Ptele);
        }

        // PUT api/<ValuesController>/5
        [HttpPost]
        public int Put( string Pname, string Psex, string Phao, string Ptele,int Pid)
        {
            return d.Upt( Pname, Psex, Phao, Ptele,Pid);
        }

        // DELETE api/<ValuesController>/5
        [HttpPost]
        public int Delete(int id)
        {
            return d.Del(id);
        }

    }
}

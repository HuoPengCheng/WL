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
    public class LDKController : ControllerBase
    {
        public WLDbcontext db;
        public LDKController(WLDbcontext db) { this.db = db; }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<LStudent>>> Show(string name = "", string sex = "")
        {
            var list = from s in db.LStudent select s;
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(p => p.Name.Contains(name));
            }
            if (!string.IsNullOrEmpty(sex))
            {
                list = list.Where(p => p.Sex == sex);
            }
            return await list.ToListAsync();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<int>> Del(int id)
        {
            db.LStudent.Remove(db.LStudent.Find(id));
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<int>> Add(string name,string sex ,int age )
        {
            LStudent s = new LStudent();
            s.Name = name;
            s.Sex = sex;
            s.Age = age;
            db.LStudent.Add(s);
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<LStudent>>> Fan(int id)
        {
            var list = from u in db.LStudent select u;
            list = list.Where(p => p.LId == id);
            return await list.ToListAsync();
        }
        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="id"></param>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        public async Task<ActionResult<int>> Update(int id, string name, string sex ,int age)
        {
            LStudent s = db.LStudent.Find(id);
            s.Name = name;
           
            s.Sex = sex;
            s.Age = age;
            return await db.SaveChangesAsync();
        }
    
    }
}

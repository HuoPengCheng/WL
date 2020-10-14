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
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<Student>>> Show()
        {
            return await db.Student.ToListAsync();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult<int>>Del(int id)
        {
           db.Student.Remove(db.Student.Find(id));
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        public async Task<ActionResult<int>> Add(string name,int age,string sex)
        {
            Student s = new Student();
            s.Name = name;
            s.Age = age;
            s.Sex = sex;
            db.Student.Add(s);
            return await db.SaveChangesAsync();
        }
        
        public async Task<ActionResult<int>>Update(int id ,string name,int age,string sex)
        {
            Student s = db.Student.Find(id);
            s.Name = name;
            s.Age = age;
            s.Sex = sex;
            return await db.SaveChangesAsync();
        }
    }
}

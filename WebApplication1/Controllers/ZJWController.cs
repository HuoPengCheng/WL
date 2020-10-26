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
    public class ZJWController : ControllerBase
    {
        public WLDbcontext db;
        public ZJWController(WLDbcontext db) { this.db = db; }
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<ProductInfo>>> Show(string name = "", string sex = "")
        {
            var list = from s in db.Products select s;
            if (!string.IsNullOrEmpty(name))
            {
                list = list.Where(p => p.Pname.Contains(name));
            }
            //if (!string.IsNullOrEmpty(sex))
            //{
            //    list = list.Where(p => p.Sex == sex);
            //}
            return await list.ToListAsync();
        }
        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult<int>> Del(int id)
        {
            db.Products.Remove(db.Products.Find(id));
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="name"></param>
        /// <param name="age"></param>
        /// <param name="sex"></param>
        /// <returns></returns>
        public async Task<ActionResult<int>> Add(string name,string type, string company,string price,string kuaidi,string sendtime,string rectime,string dest)
        {
            ProductInfo product = new ProductInfo();
            product.Pname = name;
            product.Ptype = type;
            product.Pcompany = company;
            product.Price = price;
            product.Pkuaidi = kuaidi;
            product.Psendtime = sendtime;
            product.Prectime = rectime;
            product.Pdest = dest;
            db.Products.Add(product);
            return await db.SaveChangesAsync();
        }
        /// <summary>
        /// 反填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ActionResult<IEnumerable<ProductInfo>>> Fan(int id)
        {
            var list = from u in db.Products select u;
            list = list.Where(p => p.Pid == id);
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
        public async Task<ActionResult<int>> Update(int id, string name, string type, string company, string price, string kuaidi, string sendtime, string rectime, string dest)
        {
            ProductInfo product = db.Products.Find(id);
            product.Pname = name;
            product.Ptype = type;
            product.Pcompany = company;
            product.Price = price;
            product.Pkuaidi = kuaidi;
            product.Psendtime = sendtime;
            product.Prectime = rectime;
            product.Pdest = dest;
            return await db.SaveChangesAsync();
        }
    }
}
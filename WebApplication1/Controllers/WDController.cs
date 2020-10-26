using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Model;

namespace WebApplication1.Controllers
{
    [EnableCors("cors")] //设置跨域处理的代理
    [ApiController]
    public class WDController : Controller
    {
        public WLDbcontext db;

        DBhelper dBhelper = new DBhelper();

        public WDController(WLDbcontext db) { this.db = db; }

        /// <summary>
        /// 获取员工信息
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetWorkandDeps")]
        public List<WorkandDepView> GetWorkandDeps()
        {
            string sql = $"select * from T_Work w join T_Department d on w.DId=d.DId where w.WState=1";
            return dBhelper.GetList<WorkandDepView>(sql);
        }

        /// <summary>
        /// 反填
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetWorkandDepsByWId")]
        public List<WorkandDepView> GetWorkandDepsByWId(int WId)
        {
            string sql = $"select * from T_Work w join T_Department d on w.DId=d.DId where w.WState=1 and WId={WId}";
            return dBhelper.GetList<WorkandDepView>(sql);
        }

        /// <summary>
        /// 回收站
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/RGetWorkandDeps")]
        public List<WorkandDepView> RGetWorkandDeps()
        {
            string sql = $"select * from T_Work w join T_Department d on w.DId=d.DId where w.WState=0";
            return dBhelper.GetList<WorkandDepView>(sql);
        }

        /// <summary>
        /// 查询work表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetWorks")]
        public List<Work> GetWorks()
        {
            string sql = $"select * from T_Work";
            return dBhelper.GetList<Work>(sql);
        }

        /// <summary>
        /// 查询Dep表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Route("api/GetDepartments")]
        public List<Department> GetDepartments()
        {
            string sql = $"select * from T_Department";
            return dBhelper.GetList<Department>(sql);
        }

        /// <summary>
        /// 添加员工
        /// </summary>
        /// <param name="DId"></param>
        /// <param name="WName"></param>
        /// <param name="WAge"></param>
        /// <param name="WSex"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/AddWorks")]
        public int AddWorks(int DId, string WName, int WAge)
        {
            string sql = $"insert into T_Work values({DId},'{WName}',{WAge},1)";
            return dBhelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 假删与还原
        /// </summary>
        /// <param name="WId"></param>
        /// <param name="Action"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/DandR")]
        public int DandR(int WId, int Action)
        {
            if (Action == 1)
            {
                string sql = $"update T_Work set WState=0 where WId={WId}";
                return dBhelper.ExecuteNonQuery(sql);
            }
            else
            {
                string sql = $"update T_Work set WState=1 where WId={WId}";
                return dBhelper.ExecuteNonQuery(sql);
            }
        }

        /// <summary>
        /// 真删除
        /// </summary>
        /// <param name="WId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/DelWorks")]
        public int DelWorks(int WId)
        {
            string sql = $"delete from T_Work where WId={WId}";
            return dBhelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 修改工人
        /// </summary>
        /// <param name="WId"></param>
        /// <param name="DId"></param>
        /// <param name="WName"></param>
        /// <param name="WAge"></param>
        /// <param name="WSex"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("api/UptWorks")]
        public int UptWorks(int WId,int DId, string WName, int WAge)
        {
            string sql = $"update T_Work set DId={DId},WName='{WName}',WAge={WAge} where WId={WId}";
            return dBhelper.ExecuteNonQuery(sql);
        }
    }
}

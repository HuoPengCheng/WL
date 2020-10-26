using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WebApplication1.Model;

namespace WebApplication1.Dal
{
    public class Sdal
    {
        //显示
        public List<PLStudent> Show()
        {
            string sql = "select * from PLStudent";
            var b = DBHelper.GetTable(sql);
            var bn = JsonConvert.SerializeObject(b);
            var cn = JsonConvert.DeserializeObject<List<PLStudent>>(bn);
            return cn;
        }
        //删除
        public int Del(int id)
        {
            string sql = "delete from PLStudent where Pid="+id;
            var b = DBHelper.CUD(sql);
            return b;
        }
        //添加
        public int Add(string Pname,string Psex,string Phao,string Ptele)
        {
            string sql = string.Format("insert into PLStudent values('{0}','{1}','{2}','{3}')",Pname,Psex,Phao,Ptele);
            var b = DBHelper.CUD(sql);
            return b;
        }
        //修改
        public int Upt(string Pname, string Psex, string Phao, string Ptele,int Pid)
        {
            string sql = string.Format("update PLStudent set Pname='{0}',Psex='{1}',Phao='{2}',Ptele='{3}' where Pid={4}",Pname,Psex,Phao,Ptele,Pid);
            var b = DBHelper.CUD(sql);
            return b;
        }
    }
}

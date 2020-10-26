using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace WebApplication1.Controllers
{
    public class DBhelper
    {
        private  readonly string constr = "Data Source=.;Initial Catalog=WL;User Id=sa;Password=123456;";
        //private readonly string constr = "Data Source=.;Initial Catalog=WMS;User ID=sa; Password=1234;";

        //执行增删改的方法
        public  int ExecuteNonQuery(string sql)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                int i = cmd.ExecuteNonQuery();
                conn.Close();
                return i;
            }
        }

        /// <summary>
        /// 查询表中数据
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public  DataTable GetDataTable(string sql)
        {
            using (SqlConnection conn = new SqlConnection(constr))
            {
                SqlCommand cmd = new SqlCommand(sql, conn);
                conn.Open();
                DataTable dt = new DataTable();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                sda.Fill(dt);
                conn.Close();
                return dt;
            }
        }
        /// <summary>
        /// 根据查询结果转化成json字符串
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <returns></returns>
        public  List<T> GetList<T>(string sql)
        {
            DataTable dt = GetDataTable(sql);
            string str = JsonConvert.SerializeObject(dt);
            List<T> list = JsonConvert.DeserializeObject<List<T>>(str);
            return list;
        }


        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="name">存储过程名称</param>
        /// <param name="paras">参数列表</param>
        /// <returns>表值结果</returns>
        public  DataTable DoProc(string name, SqlParameter[] paras = null)
        {
            using (SqlConnection conn = new SqlConnection(constr))//创建链接
            {
                SqlCommand cmd = conn.CreateCommand();//创建命令对象
                cmd.CommandText = name;//设置命令对象要执行的文本(存储过程名称)
                cmd.CommandType = CommandType.StoredProcedure;//设置存储过程要执行的类型
                //判断参数是否为NULL,如果为null,则初始化参数
                if (paras == null)
                    paras = new SqlParameter[] { };

                cmd.Parameters.AddRange(paras);//将参数列表加入到命令对象的参数队列中

                DataTable dt = new DataTable();//实例化一个空的DataTable对象
                SqlDataAdapter sda = new SqlDataAdapter(cmd);//利用命令对象,实例化适配器对象
                sda.Fill(dt);//用适配器对象填充dt数据

                return dt;//返回dt表数据
            }
        }

        internal  DataTable DoProc(string v, Microsoft.Data.SqlClient.SqlParameter[] parameter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 直接使用存储过程获取List集合
        /// </summary>
        /// <typeparam name="T">泛型的类型</typeparam>
        /// <param name="name">存储过程名称</param>
        /// <param name="paras">参数列表</param>
        /// <returns></returns>
        public  List<T> GetList<T>(string name, SqlParameter[] paras = null)
        {
            DataTable dt = DoProc(name, paras);//执行存储过程,将返回数据集用dt接收
            string str = JsonConvert.SerializeObject(dt);//将DataTable序列化为json格式的字符串
            List<T> list = JsonConvert.DeserializeObject<List<T>>(str);//将json格式的字符串反序列化为List<T>的泛型集合
            return list;

        }
    }
}
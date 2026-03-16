using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.IO;

namespace WebQywyBusiness
{
    public class DataBusiness
    {
        //获取webconfig connectionString 数据库访问配置信息
        private static readonly string connectionStr = ConfigurationManager.ConnectionStrings["Conn"].ToString();
        public DataBusiness()
        { }

        #region SqlDataBase insert delete update
        #region RunReturnInt(CommandType commandtype,string commandtext)
        /// <summary>
        /// RunReturnInt 返回受影响行数
        /// </summary>
        /// <param name="commandtype">数据库执行类型</param>
        /// <param name="commandtext">sql 语句(存储过程)</param>
        /// <returns>返回受影响行数</returns>
        public static int RunReturnInt(CommandType commandtype, string commandtext)
        {
            int runint = RunReturnInt(commandtype, commandtext, null);
            return runint;
        }
        #endregion

        #region RunReturnInt(CommandType commandtype, string commandtext, SqlParameter[] pars)
        /// <summary>
        /// RunReturnInt 返回受影响行数
        /// </summary>
        /// <param name="commandtype">数据库执行类型</param>
        /// <param name="commandtext">sql 语句(存储过程)</param>
        /// <param name="pars">sql 参数数组</param>
        /// <returns>返回受影响行数</returns>
        public static int RunReturnInt(CommandType commandtype, string commandtext, SqlParameter[] pars)
        {
            int runint = RunReturnInt("", commandtype, commandtext, pars);
            return runint;
        }
        #endregion

        #region RunReturnInt(string connectionString, CommandType commandtype, string commandtext, SqlParameter[] pars)
        /// <summary>
        /// RunReturnInt 返回受影响行数
        /// </summary>
        /// <param name="connectionString">链接数据库</param>
        /// <param name="commandtype">数据库执行类型</param>
        /// <param name="commandtext">sql 语句(存储过程)</param>
        /// <param name="pars">sql 参数数组</param>
        /// <returns>返回受影响行数</returns>
        public static int RunReturnInt(string connectionString, CommandType commandtype, string commandtext, SqlParameter[] pars)
        {
            int runint = 0;
            try
            {
                connectionString = connectionString == "" ? connectionStr : connectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand com = new SqlCommand())
                    {
                        PrepareSqlCommand(con, com, commandtype, commandtext, pars);
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        runint = com.ExecuteNonQuery();
                        if (con.State != ConnectionState.Closed)
                            con.Close();
                    }
                }
            }
            catch (Exception e)
            {
                runint = 0;
                throw new Exception(e.Message);
            }
            return runint;
        }
        #endregion

        #region RunReturnScalar(CommandType commandtype,string commandtext)
        /// <summary>
        /// RunReturnScalar 返回首行首列
        /// </summary>
        /// <param name="commandtext">sql 语句(存储过程)</param>
        /// <param name="commandtype">数据库执行类型</param>
        /// <returns>返回首行首列 object</returns>
        public static object RunReturnScalar(CommandType commandtype, string commandtext)
        {
            object runint = RunReturnScalar(commandtype, commandtext, null);
            return runint;
        }
        #endregion

        #region RunReturnScalar(CommandType commandtype, string commandtext, SqlParameter[] pars)
        /// <summary>
        /// RunReturnScalar 返回首行首列
        /// </summary>
        /// <param name="commandtype">数据库执行类型</param>
        /// <param name="commandtext">sql 语句(存储过程)</param>
        /// <param name="pars">sql 参数数组</param>
        /// <returns>返回首行首列 object</returns>
        public static object RunReturnScalar(CommandType commandtype, string commandtext, SqlParameter[] pars)
        {
            object runint = RunReturnScalar("", commandtype, commandtext, pars);
            return runint;
        }
        #endregion

        #region RunReturnScalar(string connectionString, CommandType commandtype, string commandtext, SqlParameter[] pars)
        /// <summary>
        /// RunReturnScalar 返回首行首列
        /// </summary>
        /// <param name="connectionString">链接数据库</param>
        /// <param name="commandtype">数据库执行类型</param>
        /// <param name="commandtext">sql 语句(存储过程)</param>
        /// <param name="pars">sql 参数数组</param>
        /// <returns>返回首行首列 object</returns>
        public static object RunReturnScalar(string connectionString, CommandType commandtype, string commandtext, SqlParameter[] pars)
        {
            object runint = null;
            try
            {
                connectionString = connectionString == "" ? connectionStr : connectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand com = new SqlCommand())
                    {
                        PrepareSqlCommand(con, com, commandtype, commandtext, pars);
                        if (con.State != ConnectionState.Open)
                            con.Open();
                        runint = com.ExecuteScalar();
                        if (con.State != ConnectionState.Closed)
                            con.Close();
                    }
                }
            }
            catch (Exception e)
            {
                runint = null;
                throw new Exception(e.Message);
            }
            return runint;
        }
        #endregion
        #endregion

        #region SqlDataBase SqlDataReader DataSet PageDataSet
        #region RunReturnSqlDataReader(CommandType commandtype, string commandtext)
        /// <summary>
        /// RunReturnSqlDataReader 返回SqlDataReader集合
        /// </summary>
        /// <param name="commandtype">数据库执行类型</param>
        /// <param name="commandtext">sql 语句(存储过程)</param>
        /// <param name="pars">参数数组</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader RunReturnSqlDataReader(CommandType commandtype, string commandtext)
        {
            SqlDataReader datareader = RunReturnSqlDataReader(commandtype, commandtext, null);
            return datareader;
        }
        #endregion

        #region RunReturnSqlDataReader(CommandType commandtype, string commandtext, SqlParameter[] pars)
        /// <summary>
        /// RunReturnSqlDataReader 返回SqlDataReader集合
        /// </summary>
        /// <param name="commandtype">数据库执行类型</param>
        /// <param name="commandtext">sql 语句(存储过程)</param>
        /// <param name="pars">参数数组</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader RunReturnSqlDataReader(CommandType commandtype, string commandtext, SqlParameter[] pars)
        {
            SqlDataReader datareader = RunReturnSqlDataReader("", commandtype, commandtext, pars);
            return datareader;
        }
        #endregion

        #region RunReturnSqlDataReader(string connectionString, CommandType commandtype, string commandtext, SqlParameter[] pars)
        /// <summary>
        /// RunReturnSqlDataReader 返回SqlDataReader集合
        /// </summary>
        /// <param name="connectionString">链接数据库</param>
        /// <param name="commandtype">数据库执行类型</param>
        /// <param name="commandtext">sql 语句(存储过程)</param>
        /// <param name="pars">参数数组</param>
        /// <returns>SqlDataReader</returns>
        public static SqlDataReader RunReturnSqlDataReader(string connectionString, CommandType commandtype, string commandtext, SqlParameter[] pars)
        {
            SqlDataReader datareader;
            SqlConnection con = null;
            try
            {
                connectionString = connectionString == "" ? connectionStr : connectionString;
                con = new SqlConnection(connectionString);
                using (SqlCommand com = new SqlCommand())
                {
                    PrepareSqlCommand(con, com, commandtype, commandtext, pars);
                    if (con.State != ConnectionState.Open)
                        con.Open();
                    datareader = com.ExecuteReader(CommandBehavior.CloseConnection);
                    com.Parameters.Clear();
                }

            }
            catch (Exception e)
            {
                if (con.State != ConnectionState.Closed)
                    con.Close();
                throw new Exception(e.Message);
            }
            return datareader;
        }
        #endregion

        #region RunReturnDataSet(CommandType commandtype, string commandtext)
        /// <summary>
        /// RunReturnDataSet 返回DataSet集合
        /// </summary>
        /// <param name="commandtype">数据库执行类型</param>
        /// <param name="commandtext">sql 语句(存储过程)</param>
        /// <param name="pars">参数数组</param>
        /// <returns>DataSet</returns>
        public static DataSet RunReturnDataSet(CommandType commandtype, string commandtext)
        {
            DataSet dataset = RunReturnDataSet(commandtype, commandtext, null);
            return dataset;
        }
        #endregion

        #region RunReturnDataSet(CommandType commandtype, string commandtext, SqlParameter[] pars)
        /// <summary>
        /// RunReturnDataSet 返回DataSet集合
        /// </summary>
        /// <param name="commandtype">数据库执行类型</param>
        /// <param name="commandtext">sql 语句(存储过程)</param>
        /// <param name="pars">参数数组</param>
        /// <returns>DataSet</returns>
        public static DataSet RunReturnDataSet(CommandType commandtype, string commandtext, SqlParameter[] pars)
        {
            DataSet dataset = RunReturnDataSet("", commandtype, commandtext, pars);
            return dataset;
        }
        #endregion

        #region RunReturnDataSet(string connectionString, CommandType commandtype, string commandtext, SqlParameter[] pars)
        /// <summary>
        /// RunReturnDataSet 返回DataSet集合
        /// </summary>
        /// <param name="connectionString">链接数据库</param>
        /// <param name="commandtype">数据库执行类型</param>
        /// <param name="commandtext">sql 语句(存储过程)</param>
        /// <param name="pars">参数数组</param>
        /// <returns>DataSet</returns>
        public static DataSet RunReturnDataSet(string connectionString, CommandType commandtype, string commandtext, SqlParameter[] pars)
        {
            DataSet dataset;
            try
            {
                connectionString = connectionString == "" ? connectionStr : connectionString;
                using (SqlConnection con = new SqlConnection(connectionString))
                {
                    using (SqlCommand com = new SqlCommand())
                    {
                        PrepareSqlCommand(con, com, commandtype, commandtext, pars);
                        using (SqlDataAdapter dad = new SqlDataAdapter(com))
                        {
                            dataset = new DataSet();
                            dad.Fill(dataset);
                            com.Parameters.Clear();
                            if (con.State != ConnectionState.Closed)
                                con.Close();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return dataset;
        }
        #endregion

        #region 【Pagation】分页存储过程
        /// <summary>
        /// 【Pagation】分页
        /// </summary>
        /// <param name="pageindex">页</param>
        /// <param name="pagesize">每页数</param>
        /// <param name="fieldList">选择字段列表 eg: and id = 1</param>
        /// <param name="tablename">表名或视图表</param>
        /// <param name="strwhere">条件</param>
        /// <param name="orderfield">排序字段及(多个条件用逗号分开)如：JobID DESC,Checkintime</param>
        /// <returns>dataset</returns>
        public static DataSet RunPageDataSet(int pageindex, int pagesize, string fieldList, string tablename, string strwhere, string orderfield, out int rowcount, out int pagecount)
        {
            DataSet ds;
            SqlParameter[] par = {
                    new SqlParameter("@pageindex",pageindex),
                    new SqlParameter("@PageSize",pagesize),
                    new SqlParameter("@FieldList",fieldList),
                    new SqlParameter("@TableName",tablename),
                    new SqlParameter("@StrWhere",strwhere),
                    new SqlParameter("@OrderField",orderfield),
                    new SqlParameter("@RowCount",SqlDbType.Int),
                    new SqlParameter("@PageCount",SqlDbType.Int) };
            par[6].Direction = ParameterDirection.Output;
            par[7].Direction = ParameterDirection.Output;
            ds = RunReturnDataSet(CommandType.StoredProcedure, "Pagation", par);
            rowcount = int.Parse(par[6].Value.ToString());
            pagecount = int.Parse(par[7].Value.ToString());
            return ds;
        }
        #endregion

        #endregion

        #region PrepareSqlCommand
        #region PrepareSqlCommand(SqlConnection conn, SqlCommand com, CommandType commandtype, string commandtext)
        /// <summary>
        /// PrepareSqlCommand(SqlCommand 数据填充)
        /// </summary>
        /// <param name="con">数据库连接</param>
        /// <param name="com">数据库执行命令</param>    
        /// <param name="commandtype">数据库执行类型</param>    
        /// <param name="commandtext">SQL 执行语句(存储过程)</param>    
        private static void PrepareSqlCommand(SqlConnection conn, SqlCommand com, CommandType commandtype, string commandtext)
        {
            PrepareSqlCommand(conn, com, commandtype, commandtext, null);
        }
        #endregion

        #region PrepareSqlCommand(SqlConnection conn, SqlCommand com, CommandType commandtype, string commandtext, SqlParameter[] pars)
        /// <summary>
        /// PrepareSqlCommand (SqlCommand 数据填充)
        /// </summary>
        /// <param name="com">数据库执行命令</param>
        /// <param name="commandtext">SQL 执行语句(存储过程)</param>
        /// <param name="conn">数据库连接</param>
        /// <param name="commandtype">数据库执行类型</param>
        /// <param name="pars">sql 参数数组</param>
        private static void PrepareSqlCommand(SqlConnection conn, SqlCommand com, CommandType commandtype, string commandtext, SqlParameter[] pars)
        {
            try
            {
                com.CommandText = commandtext;
                com.CommandType = commandtype;
                com.Connection = conn;
                if (pars != null)
                {
                    foreach (SqlParameter par in pars)
                        com.Parameters.Add(par);
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
        #endregion
        #endregion

        #region md5加密
        /// <summary>
        /// md5加密
        /// </summary>
        /// <param name="str">密码</param>
        /// <param name="code">16(16位MD5加密),32(32位加密)</param>
        /// <returns></returns>
        public static string md5(string str, int code)
        {
            string OutStr = "";
            switch (code)
            {
                case 16://16位MD5加密（取32位加密的9~25字符） 
                    OutStr = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower().Substring(8, 16);
                    break;
                case 32://32位加密 
                    OutStr = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
                    break;
                default:
                    OutStr = "00000000000000000000000000000000";
                    break;
            }

            return OutStr;
        }
        #endregion
    }
}

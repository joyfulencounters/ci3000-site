using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Xml.Linq;
using System.Data.SqlClient;
using WebQywyBusiness;
/// <summary>
///search 的摘要说明
/// </summary>
namespace WebQywy
{
    public class search
    {
        #region 词搜索词单（更多）
        public static DataTable Search_wordlist_OfWord_Page(int pageIndex, int pageSize, string name, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@name",SqlDbType.VarChar,16),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = name;
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "Search_wordlist_OfWord_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }
        #endregion

        #region 词单关键字搜索词单
        public static DataTable Search_wordlist_OfWordlist_Page(int pageIndex, int pageSize, string name, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@name",SqlDbType.VarChar,50),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = name;
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "Search_wordlist_OfWordlist_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }
        #endregion

        #region 词搜索
        /// <summary>
        /// 词搜索(并返回ID)
        /// </summary>
        /// <param name="name">词名</param>
        /// <returns>返回词ID</returns>
        public static int Search_word_OfWord(string name)
        {
            SqlParameter[] pars = {
                new SqlParameter("@name",SqlDbType.VarChar,16)
            };
            pars[0].Value = name;
            object obj = DataBusiness.RunReturnScalar(CommandType.Text, "select w_id from aml_word where [name] = @name", pars);
            return obj == null ? 0 : int.Parse(obj.ToString());
        }
        #endregion   
     
        #region Tag 搜索词
        /// <summary>
        /// Tag 搜索词
        /// </summary>
        /// <param name="name">Tag名</param>
        /// <returns>返回词列表</returns>
        public static DataTable Search_word_OfTag_Page(int pageIndex, int pageSize, string name, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@name",SqlDbType.VarChar,20),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = name;
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "Search_word_OfTag_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }
        #endregion

    }
}
using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web.Security;
using System.Data.SqlClient;
using System.Data.OleDb;
using WebQywyBusiness;
namespace WebQywy
{
    //千言万语后台管理
    public class admin
    {
        #region 推荐词单列表
        /// <summary>
        /// 推荐词单列表
        /// </summary>
        /// <returns></returns>
        public static DataTable Show_adm_wordlist_Page(int pageIndex, int pageSize, string name, string cont, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@name",SqlDbType.VarChar,100),
                new SqlParameter("@cont",SqlDbType.VarChar,200),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = name;
            pars[3].Value = name;
            pars[4].Direction = ParameterDirection.Output;
            pars[5].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_adm_wordlist_Page", pars);
            rowCount = int.Parse(pars[4].Value.ToString());
            pageCount = int.Parse(pars[5].Value.ToString());
            return ds.Tables[0];
        }
        #endregion

        #region 词列表
        /// <summary>
        /// 词列表
        /// </summary>
        /// <returns></returns>
        public static DataTable Show_adm_word_Page(int pageIndex, int pageSize, string orderby, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@orderby",SqlDbType.VarChar,50),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = orderby;
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_adm_word_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }
        #endregion        

        #region 后台首页词带图列表
		public static DataTable Show_adm_wordcomm_Page(int pageIndex, int pageSiz,string name, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@name",SqlDbType.VarChar,20),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSiz;
            pars[2].Value = name;
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_adm_wordcomm_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }
	    #endregion

        #region 创建首页推荐词
        public static int WordsCommend_Add(int wid,string pic)
        {
            SqlParameter[] pars = { new SqlParameter("@w_id", SqlDbType.Int), new SqlParameter("@wpic",SqlDbType.VarChar,100) };
            pars[0].Value = wid;
            pars[1].Value = pic;
            return DataBusiness.RunReturnInt(CommandType.StoredProcedure, "sp_WordComm_Create", pars);
        }
        #endregion

        #region 首页推荐取消词
        public static int WordsCommend_State(int wid,int state)
        {
            SqlParameter[] pars = { new SqlParameter("@w_id", SqlDbType.Int), new SqlParameter("@iscommend", SqlDbType.Int) };
            pars[0].Value = wid;
            pars[1].Value = state;
            return DataBusiness.RunReturnInt(CommandType.StoredProcedure, "sp_WordCommState", pars);
        }
        #endregion

        #region 编辑词单推荐状态
        public static int WordListComment_Edit(int wlid, int state)
        {
            SqlParameter[] pars = { 
                new SqlParameter("@wlid",SqlDbType.Int),         
                new SqlParameter("@state",SqlDbType.Int)
            };
            pars[0].Value = wlid;
            pars[1].Value = state;
            int num = DataBusiness.RunReturnInt(CommandType.StoredProcedure, "sp_WordListComment_Edit", pars);
            return num;
        }
        #endregion

        #region ExcelToDataTable
        public static DataTable ExcelToDataTable(string strExcelFileName, string strSheetName)
        {
            string strConn = "Provider=Microsoft.Jet.OLEDB.4.0;" + "Data Source=" + strExcelFileName + ";" + "Extended Properties=Excel 5.0;";
            string strExcel = string.Format("select * from [{0}$]", strSheetName);
            DataSet ds = new DataSet();
            using (OleDbConnection conn = new OleDbConnection(strConn))
            {
                conn.Open();
                OleDbDataAdapter adapter = new OleDbDataAdapter(strExcel, strConn);
                adapter.Fill(ds, strSheetName);
                conn.Close();
            }
            return ds.Tables[strSheetName];
        }
        #endregion

        #region 词评论分页
        public static DataTable Show_adm_Word_Remark_Page(int pageIndex, int pageSize, string orderby, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@orderby",SqlDbType.VarChar,200),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = orderby;
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_adm_Word_Remark_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }
        #endregion

        #region 词单评论分页
        public static DataTable Show_adm_WordList_Remark_Page(int pageIndex, int pageSize, string orderby, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@orderby",SqlDbType.VarChar,200),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = orderby;
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_adm_WordList_Remark_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }
        #endregion

        #region 词TAG分页
        public static DataTable Show_adm_Word_Tag_Page(int pageIndex, int pageSize, string orderby, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@orderby",SqlDbType.VarChar,200),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = orderby;
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_adm_Word_Tag_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }
        #endregion

        #region 敏感词汇
		#region 插入敏感词汇
        /// <summary>
        /// 敏感词
        /// </summary>
        /// <param name="name"></param>
        public static void InsertDataToSqlTable(string name)
        {
            SqlParameter[] pars = { new SqlParameter("@name",SqlDbType.VarChar,50) };
            pars[0].Value = name;
            string sql = @"if not exists(select 1 from aml_keenness where [name] = @name) begin insert aml_keenness ([name]) values(@name) end";
            DataBusiness.RunReturnInt(CommandType.Text, sql, pars);
        }
        /// <summary>
        /// 评论和词单敏感词
        /// </summary>
        /// <param name="name"></param>
        public static void Adm_keeness2_Add(string name)
        {
            SqlParameter[] pars = { new SqlParameter("@name", SqlDbType.VarChar, 50) };
            pars[0].Value = name;
            string sql = @"if not exists(select 1 from aml_keenness2 where [name] = @name) begin insert aml_keenness2 ([name]) values(@name) end";
            DataBusiness.RunReturnInt(CommandType.Text, sql, pars);
        }
        #endregion

        #region 敏感词汇列表
        public static DataTable Show_adm_keenness_Page(int pageIndex, int pageSize,string sear, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@like",SqlDbType.VarChar,200),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = sear;
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_adm_keenness_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }
        public static DataTable Show_adm_keenness2_Page(int pageIndex, int pageSize, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@like",SqlDbType.VarChar,200),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = "";
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_adm_keenness2_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }
        #endregion

        #region 敏感词汇删除
        public static int Adm_keenness_Del(int id)
        {
            SqlParameter[] pars = { new SqlParameter("@id", SqlDbType.Int) };
            pars[0].Value = id;
            int num = DataBusiness.RunReturnInt(CommandType.Text, "delete aml_keenness where k_id = @id ", pars);
            return num;
        }
        //评论词单敏感词
        public static int Adm_keenness2_Del(int id)
        {
            SqlParameter[] pars = { new SqlParameter("@id", SqlDbType.Int) };
            pars[0].Value = id;
            int num = DataBusiness.RunReturnInt(CommandType.Text, "delete aml_keenness2 where id = @id ", pars);
            return num;
        }
        #endregion
        #endregion

        #region 有趣方言
        #region 方言列表
        public static DataTable Show_adm_salutate_Page(int pageIndex, int pageSize, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Direction = ParameterDirection.Output;
            pars[3].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_adm_salutate_Page", pars);
            rowCount = int.Parse(pars[2].Value.ToString());
            pageCount = int.Parse(pars[3].Value.ToString());
            return ds.Tables[0];
        }
        #endregion
        #region 添加
        public static void Adm_salutate_Add(string title, string cont, int state)
        {
            SqlParameter[] pars = { new SqlParameter("@title", SqlDbType.VarChar, 50), new SqlParameter("@content", SqlDbType.VarChar, 50), new SqlParameter("@state", SqlDbType.TinyInt) };
            pars[0].Value = title; pars[1].Value = cont; ; pars[2].Value = state;
            string sql = @"insert into aml_salutation (title,[content],state) values (@title,@content,@state)";
            DataBusiness.RunReturnInt(CommandType.Text, sql, pars);
        }
        #endregion
        #region 删除
        public static void Adm_salutate_Del(int id)
        {
            SqlParameter[] pars = { new SqlParameter("@id", SqlDbType.Int) };
            pars[0].Value = id;
            string sql = @"delete aml_salutation where id = @id";
            DataBusiness.RunReturnInt(CommandType.Text, sql, pars);
        }
        #endregion
        #endregion

        #region 用户列表
        public static DataTable Show_adm_users_Page(int pageIndex, int pageSize, string orderby, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@orderby",SqlDbType.VarChar,50),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = orderby;
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_adm_users_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }        
        #endregion

        #region 注册用户统计
        public static DataTable Show_adm_users_regCount()
        {
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_adm_users_regCount");
            return ds.Tables[0];
        }
        #endregion                
    }
}
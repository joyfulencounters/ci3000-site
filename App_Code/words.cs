using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Xml.Linq;
using System.Data.SqlClient;
using WebQywyBusiness;
/// <summary>
///words 的摘要说明
/// </summary>
namespace WebQywy
{
    public class words
    {
        #region 所有评论（词和词单）分页
        public static DataTable Show_WWl_Remark_Uid_Page(int pageIndex, int pageSize, int userid, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@userid",SqlDbType.Int),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = userid;
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_WWl_Remark_Uid_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }
        #endregion

        #region 某用户（词和词单）最新评论分页
        public static DataTable Show_WWl_Remark_New_Page(int pageIndex, int pageSize, int userid, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@userid",SqlDbType.Int),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = userid;
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_WWl_Remark_New_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }
        #endregion

        #region 对我的词评论分页
        public static DataTable Show_User_RemarkW_Page(int pageIndex, int pageSize, int userid, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@userid",SqlDbType.Int),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = userid;
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_User_RemarkW_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }
        #endregion

        #region 对我的词单评论分页
        public static DataTable Show_User_RemarkWL(int num, int userid)
        {
            string sql = @"select top " + num.ToString() + " * from Aml_remarkwl where wl_id in (select wl_id from Aml_wordList where adduserid=@userid) and [user_id]<>@userid order by addtime desc";
            SqlParameter[] pars = { new SqlParameter("@userid",SqlDbType.Int) };
            pars[0].Value = userid;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.Text, sql, pars);
            return ds.Tables[0];
        }
        #endregion

        #region 词处理

        #region 词列表分页
        public static DataTable Show_Words_Uid_Page(int pageIndex, int pageSize, int userid, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@userid",SqlDbType.Int),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = userid;
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_Words_Uid_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }
        #endregion

        #region 词评论分页
        public static DataTable Show_Word_Remark_Page(int pageIndex, int pageSize, int wid, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@wid",SqlDbType.Int),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = wid;
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_Word_Remark_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }
        #endregion

        #region 与该词类似的词【及】分页
        public static DataTable Show_Words_likeTag(int wid)
        {
            SqlParameter[] pars = { 
                new SqlParameter("@wid",SqlDbType.Int)
            };
            pars[0].Value = wid;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_Words_likeTag", pars);
            return ds.Tables[0];
        }
        public static DataTable Show_Words_likeTag_Page(int pageIndex, int pageSize, int wid, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@wid",SqlDbType.Int),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = wid;
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_Words_likeTag_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }
        #endregion        

        #region 创建词(词单)
        public static DataTable Show_Words()
        {
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.Text, "select aw.*,awt.[name] as type from Aml_word as aw inner join Aml_wordType as awt on aw.t_id = awt.t_id");
            return ds.Tables[0];
        }
        #endregion

        #region 词基本信息
        public static DataTable Show_Info_Word_One(int wid)
        {
            SqlParameter[] pars = { 
                new SqlParameter("@wid",SqlDbType.Int)
            };
            pars[0].Value = wid;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_Info_Word_One", pars);
            return ds.Tables[0];
        }
        public static DataTable Show_Info_Word_One(int wid,int uid)
        {
            SqlParameter[] pars = { 
                new SqlParameter("@wid",SqlDbType.Int),
                new SqlParameter("@uid",SqlDbType.Int)
            };
            pars[0].Value = wid;
            pars[1].Value = uid;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_Info_Word_OneU", pars);
            return ds.Tables[0];
        }
        #endregion

        #region 这个词加入了以下词单
        public static DataTable Show_Word_OfWordList(int wid)
        {
            string sql = @"select top 4 awlc.*,au.userid,au.realname,au.avater,awl.[name] from Aml_wordlistC as awlc inner join aml_users as au 
                         on awlc.adduserid = au.userid inner join Aml_wordList as awl on awl.wl_id = awlc.wl_id where w_id = @wid order by awlc.addtime desc";
            SqlParameter[] pars = { new SqlParameter("@wid", SqlDbType.Int) };
            pars[0].Value = wid;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.Text, sql, pars);
            return ds.Tables[0];
        }
        #endregion        

        #region 创建词(词单)
        public static bool Word_Create(string name, string content, int uid, int type, int wlid, out string errorMsg)
        {
            if (string.IsNullOrEmpty(name)) { errorMsg = "词不能为空"; return false; }
            SqlParameter[] pars = { 
                new SqlParameter("@word",SqlDbType.VarChar,16),
                new SqlParameter("@content",SqlDbType.VarChar,200),
                new SqlParameter("@type",SqlDbType.Int),
                new SqlParameter("@wlid",SqlDbType.Int),
                new SqlParameter("@userid",SqlDbType.Int)
            };
            pars[0].Value = name;
            pars[1].Value = content;
            pars[2].Value = type;
            pars[3].Value = wlid;
            pars[4].Value = uid;
            object obj = DataBusiness.RunReturnScalar(CommandType.StoredProcedure, "sp_Words_Create", pars);
            bool solution = false;
            switch (int.Parse(obj.ToString()))
            {
                case -1:
                    errorMsg = "有过敏词汇";
                    break;
                case 0:
                    errorMsg = "已存在或添加失败";
                    break;
                default:
                    errorMsg = "添加成功";
                    solution = true;
                    break;
            }
            return solution;
        }
        #endregion

        #region 检测词合法性
        public static string Word_Check(string name,int uid,int wlid)
        {
            if (string.IsNullOrEmpty(name)) return "不能为空";
            SqlParameter[] pars = {                 
                new SqlParameter("@word",SqlDbType.VarChar,16),
                new SqlParameter("@uid",SqlDbType.Int),
                new SqlParameter("@wlid",SqlDbType.Int)
            };
            pars[0].Value = name;
            pars[1].Value = uid;
            pars[2].Value = wlid;
            object obj = DataBusiness.RunReturnScalar(CommandType.StoredProcedure, "sp_Word_Check", pars);
            string errorMsg = "";
            switch (int.Parse(obj.ToString()))
            {                    
                case -3:
                    errorMsg = "已经收入到该词单中了";
                    break;
                case -2:
                    errorMsg = "True";
                    break;
                case -1:
                    errorMsg = "有过敏词汇";
                    break;
                case 0:
                    errorMsg = "添加失败";
                    break;
                default:
                    errorMsg = "TrueEnd";
                    break;
            }
            return errorMsg;
        }
        #endregion        

        #region 创建词
        public static bool Word_Create(string name, string content, int uid, int type,out string errorMsg)
        {
            return Word_Create(name, content, uid, type, 0, out errorMsg);
        }
        #endregion

        #region 编辑词
        public static bool Word_Edit(int wid, string name, string content, int uid, int type, out string errorMsg)
        {
            if (string.IsNullOrEmpty(name)) { errorMsg = "词不能为空"; return false; }
            SqlParameter[] pars = {                 
                new SqlParameter("@word",SqlDbType.VarChar,16),
                new SqlParameter("@content",SqlDbType.VarChar,200),
                new SqlParameter("@type",SqlDbType.Int),
                new SqlParameter("@userid",SqlDbType.Int),
                new SqlParameter("@wid",SqlDbType.Int)
            };
            pars[0].Value = name;
            pars[1].Value = content;
            pars[2].Value = type;
            pars[3].Value = uid;
            pars[4].Value = wid;
            object obj = DataBusiness.RunReturnScalar(CommandType.StoredProcedure, "sp_Words_Edit", pars);
            bool solution = false;
            switch (int.Parse(obj.ToString()))
            {
                case -1:
                    errorMsg = "有过敏词汇";
                    break;
                case 0:
                    errorMsg = "已存在或添加失败";
                    break;
                default:
                    errorMsg = "修改成功";
                    solution = true;
                    break;
            }
            return solution;
        }
        #endregion

        #region 删除词『』『』『』
        public static int Word_Delete(int wid)
        {
            SqlParameter[] pars = {                        
                new SqlParameter("@wid",SqlDbType.Int)
            };
            pars[0].Value = wid;
            int num = DataBusiness.RunReturnInt(CommandType.StoredProcedure, "sp_Words_Delete", pars);
            return num;
        }
        #endregion

        #region 评论词
        public static int Word_Remark(string content, int uid,bool type, int wid)
        {
            SqlParameter[] pars = {                
                new SqlParameter("@content",SqlDbType.VarChar,2000),
                new SqlParameter("@userid",SqlDbType.Int),
                new SqlParameter("@type",SqlDbType.Bit),            
                new SqlParameter("@wid",SqlDbType.Int)
            };
            pars[0].Value = content;
            pars[1].Value = uid;
            pars[2].Value = type;
            pars[3].Value = wid;
            int num = DataBusiness.RunReturnInt(CommandType.StoredProcedure, "sp_Words_Remark_Add", pars);
            return num;
        }
        #endregion

        #region 删除词评论
        public static int WordRemark_Delete(int rwid)
        {
            SqlParameter[] pars = {                        
                new SqlParameter("@rwid",SqlDbType.Int)
            };
            pars[0].Value = rwid;
            int num = DataBusiness.RunReturnInt(CommandType.StoredProcedure, "sp_Words_Remark_Delete", pars);
            return num;
        }
        #endregion

        #region 添加词到词单
        public static int WordList_Add(int wid,int wlid,int uid)
        {
            SqlParameter[] pars = {
                new SqlParameter("@wid",SqlDbType.Int),
                new SqlParameter("@wlid",SqlDbType.Int),
                new SqlParameter("@userid",SqlDbType.Int)
            };
            pars[0].Value = wid;
            pars[1].Value = wlid;
            pars[2].Value = uid;
            object obj = DataBusiness.RunReturnScalar(CommandType.StoredProcedure, "sp_WordList_Words_Add", pars);
            return obj == null ? 0 : int.Parse(obj.ToString());
        }
        #endregion

        #region 添加词到词单
        public static int WordList_Add(string name,int wlid,int uid)
        {
            if (string.IsNullOrEmpty(name)) return 0;
            SqlParameter[] pars = {
                new SqlParameter("@word",SqlDbType.VarChar,16),
                new SqlParameter("@wlid",SqlDbType.Int),
                new SqlParameter("@userid",SqlDbType.Int)
            };
            pars[0].Value = name;
            pars[1].Value = wlid;
            pars[2].Value = uid;
            int num = DataBusiness.RunReturnInt(CommandType.StoredProcedure, "sp_Words_InsertWordList", pars);
            return num;
        }
        #endregion        

        #region 删除词单的词
        public static int WordList_Delete(int wid,int wlid,int uid)
        {
            SqlParameter[] pars = {
                new SqlParameter("@wid",SqlDbType.Int),
                new SqlParameter("@wlid",SqlDbType.Int),
                new SqlParameter("@userid",SqlDbType.Int)
            };
            pars[0].Value = wid;
            pars[1].Value = wlid;
            pars[2].Value = uid;
            int num = DataBusiness.RunReturnInt(CommandType.StoredProcedure, "sp_WordList_Words_Delete", pars);
            return num;
        }
        #endregion        

        #endregion        

        #region 词单处理

        #region 某用户的词单列表
        public static DataTable Show_User_WordList(int uid)
        {
            SqlParameter[] pars = {           
                new SqlParameter("@uid",SqlDbType.Int)
            };
            pars[0].Value = uid;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_User_WordList", pars);
            return ds.Tables[0];
        }
        #endregion

        #region 某用户的词单列表分页
        public static DataTable Show_User_WordList_Page(int pageIndex, int pageSize, int uid, out int rowCount, out int pageCount)
        {
            return Show_User_WordList_Page(pageIndex, pageSize, uid, "", out rowCount, out pageCount);
        }
        
        public static DataTable Show_User_WordList_Page(int pageIndex, int pageSize, int uid, string orderby, out int rowCount, out int pageCount)
        {
            if (string.IsNullOrEmpty(orderby)) orderby = " wl_id desc";
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@uid",SqlDbType.Int),
                new SqlParameter("@orderby",SqlDbType.VarChar,20),                
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = uid;
            pars[3].Value = orderby;
            pars[4].Direction = ParameterDirection.Output;
            pars[5].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_User_WordList_Page", pars);
            rowCount = int.Parse(pars[4].Value.ToString());
            pageCount = int.Parse(pars[5].Value.ToString());
            return ds.Tables[0];
        }
        #endregion

        #region 词单的基本信息
        public static DataTable Show_Info_WordList_One(int wlid)
        {
            SqlParameter[] pars = {           
                new SqlParameter("@wlid",SqlDbType.Int)
            };
            pars[0].Value = wlid;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_Info_WordList_One",pars);
            return ds.Tables[0];
        }
        #endregion

        #region 词单中的词列表分页
        public static DataTable Show_WordList_Word_Page(int pageIndex, int pageSize, int wlid, bool type, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@wlid",SqlDbType.Int),
                new SqlParameter("@type",SqlDbType.Bit),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = wlid;
            pars[3].Value = type;
            pars[4].Direction = ParameterDirection.Output;
            pars[5].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_WordList_Word_Page", pars);
            rowCount = int.Parse(pars[4].Value.ToString());
            pageCount = int.Parse(pars[5].Value.ToString());
            return ds.Tables[0];
        }
        #endregion

        #region 词单评论分页
        public static DataTable Show_WordList_Remark_Page(int pageIndex, int pageSize, int wlid, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@wlid",SqlDbType.Int),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = wlid;
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_WordList_Remark_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }
        #endregion        

        #region 推荐词单
        /// <summary>
        /// 推荐词单
        /// </summary>
        /// <returns>Table[0] 词单信息 Table[1] 词信息</returns>
        public static DataSet Show_wordlist_commend()
        {
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_wordlist_commend");
            return ds;
        }        
        #endregion

        #region 创建词单
        public static int WordList_Create(string name,string content,int uid)
        {
            if (string.IsNullOrEmpty(name)) return 0;
            SqlParameter[] pars = { 
                new SqlParameter("@name",SqlDbType.VarChar,40),
                new SqlParameter("@content",SqlDbType.VarChar,1000),
                new SqlParameter("@userid",SqlDbType.Int)
            };
            pars[0].Value = name;
            pars[1].Value = content;
            pars[2].Value = uid;
            object obj = DataBusiness.RunReturnScalar(CommandType.StoredProcedure, "sp_WordList_Create", pars);
            return obj == null ? 0 : int.Parse(obj.ToString());
        }
        #endregion

        #region 编辑词单
        public static int WordList_Edit(string name,string content,int uid,int wlid)
        {
            if (string.IsNullOrEmpty(name)) return 0;
            SqlParameter[] pars = { 
                new SqlParameter("@wlid",SqlDbType.Int),
                new SqlParameter("@name",SqlDbType.VarChar,40),
                new SqlParameter("@content",SqlDbType.VarChar,1000),
                new SqlParameter("@userid",SqlDbType.Int)
            };
            pars[0].Value = wlid;
            pars[1].Value = name;
            pars[2].Value = content;
            pars[3].Value = uid;
            int num = DataBusiness.RunReturnInt(CommandType.StoredProcedure, "sp_WordList_Edit", pars);
            return num;
        }
        #endregion        

        #region 删除词单
        public static int WordList_Delete(int wlid)
        {
            SqlParameter[] pars = {
                new SqlParameter("@wlid",SqlDbType.Int)
            };
            pars[0].Value = wlid;
            int num = DataBusiness.RunReturnInt(CommandType.StoredProcedure, "sp_WordList_Delete", pars);
            return num;
        }
        #endregion

        #region 评论词单
        public static int WordList_Remark(string content, int uid,int wlid)
        {
            SqlParameter[] pars = {                
                new SqlParameter("@content",SqlDbType.VarChar,2000),
                new SqlParameter("@userid",SqlDbType.Int),
                new SqlParameter("@wlid",SqlDbType.Int)
            };
            pars[0].Value = content;
            pars[1].Value = uid;
            pars[2].Value = wlid;
            int num = DataBusiness.RunReturnInt(CommandType.StoredProcedure, "sp_WordList_Remark_Add", pars);
            return num;
        }
        #endregion

        #region 删除词单评论
        public static int WordListRemark_Delete(int rwlid)
        {
            SqlParameter[] pars = {
                new SqlParameter("@rwlid",SqlDbType.Int)
            };
            pars[0].Value = rwlid;
            int num = DataBusiness.RunReturnInt(CommandType.StoredProcedure, "sp_WordList_Remark_Delete", pars);
            return num;
        }
        #endregion        

        #endregion

        #region 收藏 Tag 等
                
        #region 词类型列表
        public static DataTable WordTypeList()
        {
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.Text, "select * from dbo.Aml_wordType");
            return ds.Tables[0];
        }
        #endregion

        #region 用户收藏列表分页
        public static DataTable Show_Word_Collection_Page(int pageIndex, int pageSize, int uid, out int rowCount, out int pageCount)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@pageindex",SqlDbType.Int),
                new SqlParameter("@pagesize",SqlDbType.Int),
                new SqlParameter("@uid",SqlDbType.Int),
                new SqlParameter("@RowCount",SqlDbType.Int),
                new SqlParameter("@PageCount",SqlDbType.Int)
            };
            pars[0].Value = pageIndex;
            pars[1].Value = pageSize;
            pars[2].Value = uid;
            pars[3].Direction = ParameterDirection.Output;
            pars[4].Direction = ParameterDirection.Output;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_Word_Collection_Page", pars);
            rowCount = int.Parse(pars[3].Value.ToString());
            pageCount = int.Parse(pars[4].Value.ToString());
            return ds.Tables[0];
        }
        #endregion

        #region [不] 收藏词
        public static int Word_Collection(int wid,int uid)
        {
            SqlParameter[] pars = {                 
                new SqlParameter("@wid",SqlDbType.Int),
                new SqlParameter("@userid",SqlDbType.Int)
            };
            pars[0].Value = wid;
            pars[1].Value = uid;
            object obj = DataBusiness.RunReturnScalar(CommandType.StoredProcedure, "sp_Words_Collection", pars);
            return obj == null ? 0 : int.Parse(obj.ToString());
        }
        #endregion

        #region 收藏词(检测)
        /// <summary>
        /// 收藏词是否存在
        /// </summary>
        /// <param name="name">词名</param>
        /// <param name="uid">用户ID</param>
        /// <returns>-2 添加词 -1 有敏感词汇  0> 收藏成功</returns>
        public static bool Word_Collection(string name, int uid, out string errorMsg)
        {
            if (string.IsNullOrEmpty(name)) { errorMsg = "词不能为空"; return false; }
            SqlParameter[] pars = {                 
                new SqlParameter("@word",SqlDbType.VarChar,16),
                new SqlParameter("@userid",SqlDbType.Int)
            };
            pars[0].Value = name;
            pars[1].Value = uid;
            object obj = DataBusiness.RunReturnScalar(CommandType.StoredProcedure, "sp_Words_Collection_Check", pars);
            bool solution = false;
            switch (int.Parse(obj.ToString()))
            {
                case -1:
                    errorMsg = "有过敏词汇";
                    break;
                case -2:
                    errorMsg = "Go";
                    break;
                default:
                    errorMsg = "True";
                    solution = true;
                    break;
            }
            return solution;
        }
        #endregion

        #region 创建词(收藏)
        public static bool Word_Collection(string name, string content, int uid,int type,out string errorMsg)
        {
            if (string.IsNullOrEmpty(name)) { errorMsg = "词不能为空"; return false; }
            SqlParameter[] pars = {                 
                new SqlParameter("@word",SqlDbType.VarChar,16),
                new SqlParameter("@content",SqlDbType.VarChar,200),
                new SqlParameter("@type",SqlDbType.Int),
                new SqlParameter("@userid",SqlDbType.Int)
            };
            pars[0].Value = name;
            pars[1].Value = content;
            pars[2].Value = type;
            pars[3].Value = uid;
            object obj = DataBusiness.RunReturnScalar(CommandType.StoredProcedure, "sp_Words_Collection_Create", pars);
            bool solution = false;
            switch (int.Parse(obj.ToString()))
            {
                case -1:
                    errorMsg = "有过敏词汇";
                    break;
                case 0:
                    errorMsg = "已存在或添加失败";
                    break;
                default:
                    errorMsg = "收藏成功";
                    solution = true;
                    break;
            }
            return solution;
        }
        #endregion        

        #region 创建词Tag
        public static int Words_Tag_Create(string name, int uid, int wid)
        {
            if (string.IsNullOrEmpty(name)) return 0;
            SqlParameter[] pars = { 
                new SqlParameter("@name",SqlDbType.VarChar,20),                
                new SqlParameter("@userid",SqlDbType.Int),
                new SqlParameter("@wid",SqlDbType.Int)
            };
            pars[0].Value = name;
            pars[1].Value = uid;
            pars[2].Value = wid;
            object obj = DataBusiness.RunReturnScalar(CommandType.StoredProcedure, "sp_Words_Tag_Add", pars);
            return obj == null ? 0 : int.Parse(obj.ToString());
        }
        #endregion

        #region 删除词Tag
        public static int Words_Tag_Delete(int wtid)
        {
            SqlParameter[] pars = {
                new SqlParameter("@wtid",SqlDbType.Int)
            };
            pars[0].Value = wtid;
            int num = DataBusiness.RunReturnInt(CommandType.StoredProcedure, "sp_Words_Tag_Delete", pars);
            return num;
        }
        #endregion

        #region 显示tags
        public static DataTable Show_Word_Tags(int wid)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@wid",SqlDbType.Int)
            };
            pars[0].Value = wid;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.Text, "select * from Aml_wordtag where w_id = @wid", pars);
            return ds.Tables[0];
        }
        #endregion

        #endregion
        
        #region index
        /// <summary>
        /// 最近7天内被引用最多的词
        /// </summary>
        public static DataTable Show_Word_CMost(int day)
        {
            string sql = @"select top 30 awlc.wordCount,aw.* from (select count(w_id) as wordCount,w_id from Aml_wordlistC where datediff(day,addtime,getdate()) <= "
                        + day.ToString() +"group by w_id) as awlc inner join aml_word as aw on awlc.w_id = aw.w_id order by wordCount desc";
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.Text, sql);
            return ds.Tables[0];
        }
        /// <summary>
        /// 最近7天内被引用最多的词(更多)
        /// </summary>
        public static DataTable Show_Word_CMost(int day,int num)
        {
            if (num <= 0) num = 100;
            string sql = @"select top " + num.ToString() + " awlc.wordCount,aw.* from (select count(w_id) as wordCount,w_id from Aml_wordlistC where datediff(day,addtime,getdate()) <= "
                        + day.ToString() + "group by w_id) as awlc inner join aml_word as aw on awlc.w_id = aw.w_id order by wordCount desc";
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.Text, sql);
            return ds.Tables[0];
        }
        /// <summary>
        /// 被收藏最多的词
        /// </summary>
        public static DataTable Show_Word_CollectionMost()
        {
            string sql = @"select top 10  * from (select au.userid,aw.[name],aw.w_id,au.realname,collectionNum = 
                        (select count(*) from Aml_collection as ac where ac.w_id = aw.w_id) 
                        from aml_word as aw inner join aml_users as au
                        on au.userid = aw.adduserid) as newTemp order by collectionNum desc";
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.Text, sql);
            return ds.Tables[0];
        }
        /// <summary>
        /// 他们说。。。
        /// </summary>
        public static DataTable Show_WWl_Remark_Index(int pageSize)
        {
            SqlParameter[] pars = {
                new SqlParameter("@pagesize",SqlDbType.Int)
            };
            pars[0].Value = pageSize;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_WWl_Remark_Index", pars);
            return ds.Tables[0];
        }
        /// <summary>
        /// 优先词单
        /// </summary>
        /// <returns>Table[0] 词单信息 Table[1] 词信息</returns>
        public static DataSet Show_wordlist_first_Index()
        {
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_wordlist_first_Index");
            return ds;
        }
        /// <summary>
        /// 首页最新词，词单，==
        /// </summary>
        public static DataTable Show_NCNC_Index()
        {
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_NCNC_Index");
            return ds.Tables[0];
        }
        /// <summary>
        /// 随机取词ID
        /// </summary>
        public static int Show_WordID_Random()
        {
            object obj = DataBusiness.RunReturnScalar(CommandType.Text, "select top 1 w_id from (select distinct(w_id) from aml_wordtag) as Random order by newid()");
            return obj == null ? 0 : int.Parse(obj.ToString());
        }
        /// <summary>
        /// 首页推荐词
        /// </summary>
        public static DataTable Show_WordComm(int num)
        {
            if (num == 0) num = 10;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.Text, "select top " + num + " aw.w_id,aw.[name],awc.* from aml_word as aw left join aml_wordcommend as awc on aw.w_id = awc.w_id where awc.isCommend = 1 order by createtime");
            return ds.Tables[0];
        }
        #endregion

        #region 屏蔽敏感词汇
        public static bool KillDog(string cont)
        {
            DataTable dt = KeennessList();
            bool solu = false;
            foreach (DataRow dr in dt.Rows)
            {
                if (cont.IndexOf(dr["name"].ToString()) >= 0)
                {
                    solu = true;
                    break;
                }
            }
            return solu;
        }
        private static DataTable KeennessList()
        {
            int rowCount = 0;
            int pageCount = 0;
            return admin.Show_adm_keenness2_Page(1, 50, out rowCount, out pageCount);
        }
        #endregion

    #region 随机词单（词数 6~50）
public static DataTable Show_WordList_Random()
{
    string sql = @"
    SELECT TOP 1 wl.*
    FROM Aml_wordList wl
    INNER JOIN (
        SELECT wl_id, COUNT(*) AS wordCount
        FROM Aml_wordlistC
        GROUP BY wl_id
    ) c ON wl.wl_id = c.wl_id
    WHERE c.wordCount >= 6 AND c.wordCount <= 50
    ORDER BY NEWID()
    ";

    DataSet ds = DataBusiness.RunReturnDataSet(CommandType.Text, sql);
    return ds.Tables[0];
}
#endregion

#region 词单里的所有词
public static DataTable Show_WordList_Words_All(int wlid)
{
    string sql = @"
    SELECT aw.*
    FROM Aml_wordlistC wc
    INNER JOIN Aml_word aw ON wc.w_id = aw.w_id
    WHERE wc.wl_id = @wlid
    ";

    SqlParameter[] pars = {
        new SqlParameter("@wlid", SqlDbType.Int)
    };
    pars[0].Value = wlid;

    DataSet ds = DataBusiness.RunReturnDataSet(CommandType.Text, sql, pars);
    return ds.Tables[0];
}
#endregion

    }




}

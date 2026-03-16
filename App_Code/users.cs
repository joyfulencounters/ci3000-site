using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Data.SqlClient;
using WebQywyBusiness;
/// <summary>
///users 的摘要说明
/// </summary>
namespace WebQywy
{
    public class Users
    {
        #region 用户参数属性
        private int _userID;

        private string _eMail;

        private string _realName;

        private string _password;

        private int _sex;

        private string _avater;

        private string _feeling;

        private DateTime _createDate;

        private DateTime _lastDate;

        private int _loginTimes;

        private string _validate;
       
        /// <summary>
        /// 用户ID
        /// <summary>
        public int UserID
        {
            get { return this._userID; }
            set { this._userID = value; }
        }

        /// <summary>
        /// 用户mail
        /// <summary>
        public string EMail
        {
            get { return this._eMail; }
            set { this._eMail = value; }
        }

        /// <summary>
        /// 真实姓名
        /// <summary>
        public string RealName
        {
            get { return this._realName; }
            set { this._realName = value; }
        }

        /// <summary>
        /// 密码
        /// <summary>
        public string Password
        {
            get { return this._password; }
            set { this._password = value; }
        }

        /// <summary>
        /// 头像
        /// <summary>
        public string Avater
        {
            get { return this._avater; }
            set { this._avater = value; }
        }

        /// <summary>
        /// 性别
        /// <summary>
        public int Sex
        {
            get { return this._sex; }
            set { this._sex = value; }
        }

        /// <summary>
        /// 心情
        /// <summary>
        public string Feeling
        {
            get { return this._feeling; }
            set { this._feeling = value; }
        }

        /// <summary>
        /// 注册时间
        /// <summary>
        public DateTime CreateDate
        {
            get { return this._createDate; }
            set { this._createDate = value; }
        }

        /// <summary>
        /// 上次登录时间
        /// <summary>
        public DateTime LastDate
        {
            get { return this._lastDate; }
            set { this._lastDate = value; }
        }

        /// <summary>
        /// 登录次数
        /// <summary>
        public int LoginTimes
        {
            get { return this._loginTimes; }
            set { this._loginTimes = value; }
        }

        /// <summary>
        /// 验证
        /// </summary>
        public string Validate
        {
            get { return this._validate; }
            set { this._validate = value; }
        }
        #endregion        

        #region Cookies 处理
        
        private static readonly string DomainName = Data_Public.GetConfig("CookiesDomain");

        #region 登录时设置Cookies
        
        /// <summary>
        /// 登录时设置Cookie
        /// </summary>
        public static void SetLoginCookie(Users oLogin)
        {
            oLogin.Validate = oLogin.UserID.ToString() + oLogin.EMail + oLogin.LoginTimes.ToString() + oLogin.LastDate.ToString();

            //保存登录相关Cookies
            HttpCookie loginCookie = new HttpCookie("users");

            loginCookie.Values.Add("EMail", Data_System.EncryptDes(oLogin.EMail));
            loginCookie.Values.Add("UserID", Data_System.EncryptDes(oLogin.UserID.ToString()));
            loginCookie.Values.Add("LoginTimes", Data_System.EncryptDes(oLogin.LoginTimes.ToString()));
            loginCookie.Values.Add("LastDate", Data_System.EncryptDes(oLogin.LastDate.ToString()));
            loginCookie.Values.Add("Validate", Data_System.EncryptDes(oLogin.Validate));
            loginCookie.Domain = DomainName;
            loginCookie.Expires = DateTime.Now.AddDays(30);
            HttpContext.Current.Response.Cookies.Set(loginCookie);

            SetCookies("user", "RealName", oLogin.RealName);
            SetCookies("user", "Avater", oLogin.Avater);
        }
        #endregion

        #region 获取登录Cookies        
        /// <summary>
        /// 获取登录Cookies
        /// </summary>
        public static Users GetLoginCookie()
        {
            Users oLogin = new Users();
            if (HttpContext.Current.Request.Cookies["users"] != null)
            {                
                try
                {
                    oLogin.EMail = Data_System.DecryptDes(HttpContext.Current.Request.Cookies["users"]["EMail"]);
                    oLogin.UserID = int.Parse(Data_System.DecryptDes(HttpContext.Current.Request.Cookies["users"]["UserID"]));
                    oLogin.LoginTimes = int.Parse(Data_System.DecryptDes(HttpContext.Current.Request.Cookies["users"]["LoginTimes"]));
                    oLogin.LastDate = Convert.ToDateTime(Data_System.DecryptDes(HttpContext.Current.Request.Cookies["users"]["LastDate"]));
                    oLogin.Validate = Data_System.DecryptDes(HttpContext.Current.Request.Cookies["users"]["Validate"]);

                    if (oLogin.Validate != oLogin.UserID.ToString() + oLogin.EMail + oLogin.LoginTimes.ToString() + oLogin.LastDate.ToString())
                    {
                        oLogin.EMail = "";
                        oLogin.UserID = 0;
                        oLogin.LoginTimes = 0;
                        oLogin.LastDate = DateTime.Now;
                        oLogin.Validate = "";
                        oLogin.Sex = 0;
                    }
                }
                catch
                {
                    oLogin.EMail = "";
                    oLogin.UserID = 0;
                    oLogin.LoginTimes = 0;
                    oLogin.LastDate = DateTime.Now;
                    oLogin.Validate = "";
                    oLogin.Sex = 0;
                }
            }

            oLogin.RealName = GetCookies("user", "RealName");
            oLogin.Avater = GetCookies("user", "Avater");

            return oLogin;
        }
        #endregion

        #region 保存&读取Cookies
        /// <summary>
        /// 保存Cookies
        /// </summary>
        /// <param name="cookieName">Cookies名</param>
        /// <param name="field">要设置的字段</param>
        /// <param name="value">要设置的值</param>
        /// <remarks>此方法保存的Cookies为关闭浏览器即失效的Cookies,若要设置有效时间，请调用SetCookies(string cookieName, string field, string value, int saveDay)</remarks>
        public static void SetCookies(string cookieName, string field, string value)
        {
            SetCookies(cookieName, field, value, 30);
        }

        /// <summary>
        /// 保存Cookies
        /// </summary>
        /// <param name="cookieName">Cookies名，一般为模块号</param>
        /// <param name="field">要设置的字段</param>
        /// <param name="value">要设置的值</param>
        /// <param name="saveDay">要保存的天数，0为不设置，关闭浏览器即失效</param>
        public static void SetCookies(string cookieName, string field, string value, int saveDay)
        {
            HttpCookie MyCookie = HttpContext.Current.Request.Cookies[cookieName];
            if (MyCookie == null)
                MyCookie = new HttpCookie(cookieName);
            
            value = HttpUtility.UrlEncode(value);
            MyCookie[field] = value;
            if (saveDay != 0)
                MyCookie.Expires = DateTime.Now.AddDays(saveDay);
            
            MyCookie.Domain = DomainName; //设置COOKIE 域            
            HttpContext.Current.Response.Cookies.Add(MyCookie);//写入Cookies
        }

        /// <summary>
        /// 读取Cookies
        /// </summary>
        /// <param name="cookieName">Cookies名，一般为模块号</param>
        /// <param name="field">要读取的字段</param>
        public static string GetCookies(string cookieName, string field)
        {
            string retValue = "";
            try {
                retValue = HttpContext.Current.Request.Cookies[cookieName][field];
                retValue = HttpUtility.UrlDecode(retValue);
            }
            catch {
            }
            return retValue;
        }

        #endregion

        #region 清空cookie
        /// <summary>
        /// 清除登录用户的cookie
        /// </summary>
        public static void Clear()
        {
            try
            {
                //清除所有的Cookie
                foreach (string str in HttpContext.Current.Request.Cookies.AllKeys)
                {
                    if (HttpContext.Current.Request.Cookies[str] != null)
                    {
                        HttpCookie c = HttpContext.Current.Request.Cookies[str];
                        c.Domain = DomainName;
                        c.Expires = DateTime.Now.AddYears(-2);
                        HttpContext.Current.Response.Cookies.Set(c);
                    }
                }
            }
            catch { }
        }
        #endregion

        #endregion

        #region 忘记密码修改密码前email确认
        public static bool ForgetPwd(string email)
        {
            SqlParameter[] pars = {new SqlParameter("@email",SqlDbType.VarChar,100) };
            pars[0].Value = email;
            object obj = DataBusiness.RunReturnScalar(CommandType.Text, "select 1 from aml_remail where email = @email", pars);
            return obj == null ? false : true;
        }
        #endregion

        #region 忘记密码
        public static int ForgetPwd(string email, string remark, string rand)
        {
            SqlParameter[] pars = {       
                new SqlParameter("@email",SqlDbType.VarChar,100),
                new SqlParameter("@remark",SqlDbType.VarChar,500),
                new SqlParameter("@rand",SqlDbType.VarChar,100) };
            pars[0].Value = email;
            pars[1].Value = remark;
            pars[2].Value = rand;
            int num = DataBusiness.RunReturnInt(CommandType.StoredProcedure, "sp_forgetPwd", pars);
            return num;
        }
        #endregion

        #region 已经找回密码
        public static int GetPwd(string email,string pwd)
        {
            SqlParameter[] pars = { new SqlParameter("@email", SqlDbType.VarChar, 100), new SqlParameter("@pwd", SqlDbType.VarChar, 50) };
            pars[0].Value = email; pars[1].Value = DataBusiness.md5(pwd, 16);
            int num = DataBusiness.RunReturnInt(CommandType.StoredProcedure, "sp_pwd_update", pars);
            return num;
        }
        #endregion

        #region 检测用户是否已登录(email判断)
        /// <summary>
        /// //检查登录状态，未登录则重定向至登录页
        /// </summary>
        protected void CheckLogin(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                string sFileName = HttpContext.Current.Server.UrlEncode(HttpContext.Current.Request.Url.ToString());
                HttpContext.Current.Response.Redirect(Data_Public.GetConfig("LoginUrl") + "?returnpage=" + sFileName);
            }
        }
        #endregion

        #region 用户登录
        /// <summary>
        /// 登录检查
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool CheckLogin(string email, string password)
        {
            bool retCode = false;
            SqlParameter[] pars = { 
                new SqlParameter("@email",SqlDbType.VarChar,50),
                new SqlParameter("@pwd",SqlDbType.VarChar,20)
            };
            pars[0].Value = email;
            pars[1].Value = DataBusiness.md5(password, 16);
            DataTable dt = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_User_CheckLogin", pars).Tables[0];
            if (dt.Rows.Count > 0)
            {
                //登录成功，记录cookies
                Users oLogin = new Users();
                oLogin.UserID = int.Parse(dt.Rows[0]["UserID"].ToString());
                oLogin.EMail = email;
                oLogin.LoginTimes = int.Parse(dt.Rows[0]["logintimes"].ToString());
                oLogin.LastDate = Convert.ToDateTime(dt.Rows[0]["lastdate"].ToString());
                oLogin.RealName = dt.Rows[0]["realname"].ToString();
                oLogin.Avater = dt.Rows[0]["avater"].ToString();

                Users.SetLoginCookie(oLogin);
                retCode = true;
            }
            return retCode;
        }
        /// <summary>
        /// 登录检查
        /// </summary>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public static bool CheckLoginBack(string name, string password)
        {
            bool retCode = false;
            string lgname = "ci3000";
            string lgpwd = "19870606wrz";
            if (lgname == name && lgpwd == password)
                retCode = true;
            else
                retCode = false;

            return retCode;
        }
        #endregion

        #region 用户注册
        public static bool reg(string email, string name, string pwd, string pic)
        {
            SqlParameter[] pars = { 
                new SqlParameter("@email",SqlDbType.VarChar,50),
                new SqlParameter("@name",SqlDbType.VarChar,50),
                new SqlParameter("@pwd",SqlDbType.VarChar,20),
                new SqlParameter("@pic",SqlDbType.VarChar,50)
            };
            pars[0].Value = email;
            pars[1].Value = name;
            pars[2].Value = DataBusiness.md5(pwd, 16);
            pars[3].Value = pic;
            object obj = DataBusiness.RunReturnScalar(CommandType.StoredProcedure, "sp_users_reg", pars);
            if (obj == null)
            {
                return false;
            }
            else
            {
                if (int.Parse(obj.ToString()) > 0)
                {
                    //注册成功处理
                    return true;
                }
                else
                    return false;
            }
        }
        #endregion

        #region 删除用户信息（注意）
        public static bool UserDel(int uid)
        {
            SqlParameter[] pars = {
                new SqlParameter("@userid",SqlDbType.Int)
            };
            pars[0].Value = uid;
            DataBusiness.RunReturnInt(CommandType.StoredProcedure, "sp_UserDel", pars);
            return true;            
        }
        #endregion

        #region 更新用户基本信息
        public static int UserInfo_Update(int uid,string name,string oldpwd, string pwd)
        {
            SqlParameter[] pars = {
                new SqlParameter("@userid",SqlDbType.Int),
                new SqlParameter("@name",SqlDbType.VarChar,50),
                new SqlParameter("@oldpwd",SqlDbType.VarChar,20),
                new SqlParameter("@pwd",SqlDbType.VarChar,20)
            };
            pars[0].Value = uid;
            pars[1].Value = name;
            pars[2].Value = string.IsNullOrEmpty(oldpwd) ? "" : DataBusiness.md5(oldpwd, 16);
            pars[3].Value = string.IsNullOrEmpty(pwd) ? "" : DataBusiness.md5(pwd, 16);
            object obj = DataBusiness.RunReturnScalar(CommandType.StoredProcedure, "sp_UserInfo_Update", pars);
            if (obj == null)
            {
                return 0;
            }
            else
            {
                if (int.Parse(obj.ToString()) > 0)
                {
                    SetCookies("user", "RealName", name);
                    return 1;
                }
                else if (int.Parse(obj.ToString()) == -1)
                {
                    return -1;
                }
                else
                    return 0;
            }
        }
        public static int UserInfo_Update(int uid, string pic)
        {
            SqlParameter[] pars = {
                new SqlParameter("@userid",SqlDbType.Int),
                new SqlParameter("@pic",SqlDbType.VarChar,50)
            };
            pars[0].Value = uid;
            pars[1].Value = pic;
            int num = DataBusiness.RunReturnInt(CommandType.StoredProcedure, "sp_UserInfoPic_Update", pars);
            if (num > 0) SetCookies("user", "Avater", pic);
            return num;
        }
        #endregion

        #region 检测email存在（注册）
        public static bool Chk_UserName(string email)
        {
            SqlParameter[] pars = { new SqlParameter("@email", SqlDbType.VarChar, 50) };
            pars[0].Value = email;
            object obj = DataBusiness.RunReturnScalar(CommandType.Text, "select 1 from aml_users where email = @email", pars);
            if (obj == null) //不存在
                return true;
            else
                return false;
        }
        #endregion

        #region 更新用户心情
        public static void Users_feeling_Edit(string feeling, int uid)
        {
            SqlParameter[] pars = { 
                new SqlParameter("@feeling",SqlDbType.VarChar,200),
                new SqlParameter("@userid",SqlDbType.Int)
            };
            pars[0].Value = feeling;
            pars[1].Value = uid;
            DataBusiness.RunReturnInt(CommandType.StoredProcedure, "sp_Users_feeling_Edit", pars);
        }
        #endregion

        #region 由词单获取个人基本信息（词，收藏，词单 ==）
        public static DataTable Show_UserInfo_wordlist(int wlid)
        {
            SqlParameter[] pars = { new SqlParameter("@wlid", SqlDbType.Int) };
            pars[0].Value = wlid;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "Show_UserInfo_wordlist", pars);
            return ds.Tables[0];
        }
        #endregion

        #region 由用户ID获取个人基本信息（词，收藏，词单 ==）
        public static DataTable Show_UserInfo_newword(int userid)
        {
            SqlParameter[] pars = { new SqlParameter("@userid", SqlDbType.Int) };
            pars[0].Value = userid;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "Show_UserInfo_newword", pars);
            return ds.Tables[0];
        }
        #endregion        

        #region 用户基本信息
        public static DataTable Show_UserInfo(int userid)
        {
            SqlParameter[] pars = { new SqlParameter("@userid", SqlDbType.Int) };
            pars[0].Value = userid;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.Text, "select * from aml_users where userid = @userid", pars);
            return ds.Tables[0];
        }
        public static DataTable Show_UserInfo(string name)
        {
            SqlParameter[] pars = { new SqlParameter("@name", SqlDbType.VarChar,20) };
            pars[0].Value = name;
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.Text, "select * from aml_users where realname = @name", pars);
            return ds.Tables[0];
        }
        #endregion

        #region 用户间契合指数
        public static decimal Show_SameIndexUU(int mUid,int uId)
        {
            SqlParameter[] pars = { new SqlParameter("@Muid", SqlDbType.Int), new SqlParameter("@uid", SqlDbType.Int) };
            pars[0].Value = mUid;
            pars[1].Value = uId;
            object obj = DataBusiness.RunReturnScalar(CommandType.StoredProcedure, "sp_SameIndexUU", pars);
            return decimal.Parse(obj.ToString());
        }
        //同好和我契合指数最高的15位
        public static DataTable Show_SaveLoveOfMy(int mUid)
        {
            SqlParameter[] pars = { new SqlParameter("@Muid", SqlDbType.Int) };
            pars[0].Value = mUid;            
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.StoredProcedure, "sp_SaveLoveOfMy", pars);
            return ds.Tables[0];
        }        
        #endregion

        #region index

        /// <summary>
        /// 最新注册用户
        /// </summary>
        public static DataTable Show_Users_News()
        {
            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.Text, "select top 12 realname,userid,avater from aml_users order by userid desc");
            return ds.Tables[0];
        }        

        #endregion
    }
}

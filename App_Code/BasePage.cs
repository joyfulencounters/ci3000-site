using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
/// <summary>
/// BasePage 的摘要说明
/// 网站都必须继承此类获取登录状态
/// </summary>
namespace WebQywy
{
    public class BasePage : System.Web.UI.Page
    {
        protected Users uc;        
        /// <summary>
        /// 重载构造函数,检查用户是否已登录等
        /// </summary>
        /// <param name="e"></param>
        protected override void OnLoad(EventArgs e)
        {
            try
            {
                uc = Users.GetLoginCookie();
                base.OnLoad(e);
            }
            catch (System.Threading.ThreadAbortException ex)
            {
                //捕捉线程异常，忽略重定向等引发的异常
            }
            catch (Exception ex)
            {
                throw (new Exception(ex.ToString()));
            }
        }
    }
}

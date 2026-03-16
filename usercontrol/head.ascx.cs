using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using WebQywy;

public partial class usercontrol_head : System.Web.UI.UserControl
{
    Users us = Users.GetLoginCookie();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (us.UserID > 0)
            {
                this.lit_log.Text = "<a href=\"/user/default.aspx\"><img alt=\"\"  id=\"Imagelog\" onmouseover=\"MM_swapImage('Imagelog','','/images/index/indexs_050.gif',1)\" onmouseout=\"MM_swapImgRestore()\" src=\"/images/index/indexs_05.gif\" /></a>";
                this.lit_reg.Text = "<a href=\"/user/set.aspx\"><img alt=\"\"  id=\"Imagereg\" onmouseover=\"MM_swapImage('Imagereg','','/images/index/indexs_060.gif',1)\" onmouseout=\"MM_swapImgRestore()\" src=\"/images/index/indexs_06.gif\" /></a>";
                this.lit_col.Text = "<a href=\"/member/loginOut.aspx\"><img alt=\"\"  id=\"Imagecol\" onmouseover=\"MM_swapImage('Imagecol','','/images/index/indexs_070.gif',1)\" onmouseout=\"MM_swapImgRestore()\" src=\"/images/index/indexs_07.gif\" /></a>";           
            }
            this.lit_random.Text = "<a href=\"/word.aspx?c=" + words.Show_WordID_Random() + "\" ><img src=\"/images/index/word.png\" class=\"png24\"  alt=\"随机取词\" id=\"Image3\" onmouseover=\"MM_swapImage('Image3','','/images/index/word1.png',1)\" onmouseout=\"MM_swapImgRestore()\" /></a>";
        }
    }
}

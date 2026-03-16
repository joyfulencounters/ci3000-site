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
public partial class user_Set : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            if (uc.UserID <= 0) Response.Redirect("/");
            GetUserInfo();
        }
    }

    private void GetUserInfo()
    {
        User_Img.Src = uc.Avater;
        lit_email.Text = uc.EMail;
        lit_OldName.Text = lit_username.Text = uc.RealName;
        
        lit_Msg.Text = Data_Public.RandomSalutation();
    }

    protected void imgbtn_submit_Click(object sender, ImageClickEventArgs e)
    {
        string name = string.IsNullOrEmpty(this.txt_NewName.Text.Trim()) ? uc.RealName : this.txt_NewName.Text.Trim();
        string oldpwd = this.txt_pwdold.Text.Trim();
        string pwd = this.txt_pwdnew.Text.Trim();
        int num = Users.UserInfo_Update(uc.UserID,name,oldpwd, pwd);
        if (num > 0)                    
            Data_Public.AlertToLocation(this, "修改成功！", "/user/set.aspx");        
        else if(num == -1)
            Data_Public.AlertToLocation(this, "原密码错误！", "/user/set.aspx");
        else
            Data_Public.AlertToLocation(this, "修改成功！", "/user/set.aspx");
    }
}

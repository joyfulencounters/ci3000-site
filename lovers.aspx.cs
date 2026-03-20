using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebQywy;
using WebQywyBusiness;

public partial class lovers : BasePage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            LoadLovers();
        }
    }

    private void LoadLovers()
    {
        if (uc == null || uc.UserID == 0)
        {
            lit_Lovers.Text = "<div class='LoverEmpty'>登录后即可查看与您志趣相投的同好</div>";
            return;
        }

        try
        {
            // 获取当前用户的词列表
            string userWordsSql = "SELECT wordid FROM aml_userword WHERE userid = @uid";
            SqlParameter[] userWordsPars = {
                new SqlParameter("@uid", SqlDbType.Int) { Value = uc.UserID }
            };
            DataSet userWordsDs = DataBusiness.RunReturnDataSet(CommandType.Text, userWordsSql, userWordsPars);
            DataTable userWordsDt = userWordsDs.Tables[0];

            if (userWordsDt == null || userWordsDt.Rows.Count == 0)
            {
                lit_Lovers.Text = "<div class='LoverEmpty'>暂无契合用户，去丰富你的词单吧</div>";
                return;
            }

            // 构建词ID列表
            System.Text.StringBuilder wordIds = new System.Text.StringBuilder();
            foreach (DataRow dr in userWordsDt.Rows)
            {
                if (wordIds.Length > 0) wordIds.Append(",");
                wordIds.Append(dr["wordid"].ToString());
            }

            // 查询有相同词的用户
            string sql = @"
                SELECT TOP 15 u.userid, u.realname, u.avater,
                       COUNT(*) as indexValue
                FROM aml_userword uw
                INNER JOIN aml_users u ON uw.userid = u.userid
                WHERE uw.wordid IN (" + wordIds.ToString() + @")
                AND u.userid != @uid
                GROUP BY u.userid, u.realname, u.avater
                ORDER BY indexValue DESC";

            DataSet ds = DataBusiness.RunReturnDataSet(CommandType.Text, sql, userWordsPars);
            DataTable dt = ds.Tables[0];

            if (dt == null || dt.Rows.Count == 0)
            {
                lit_Lovers.Text = "<div class='LoverEmpty'>暂无契合用户，去丰富你的词单吧</div>";
                return;
            }

            string html = "<div class='LoversGrid'>";
            foreach (DataRow row in dt.Rows)
            {
                string avatar = row["avater"] != null && row["avater"].ToString() != "" ? row["avater"].ToString() : "/images/default_avatar.png";
                string realname = row["realname"] != null ? row["realname"].ToString() : "匿名用户";
                int userId = row["userid"] != null ? Convert.ToInt32(row["userid"]) : 0;
                int indexValue = row["indexValue"] != null ? Convert.ToInt32(row["indexValue"]) : 0;

                html += string.Format(@"
                    <a href='/user/default.aspx?u={0}' style='text-decoration:none;'>
                        <div class='LoverCard'>
                            <img src='{1}' class='LoverAvatar' alt='{2}' />
                            <div class='LoverName'>{2}</div>
                            <div class='LoverIndex'>契合指数: {3}</div>
                        </div>
                    </a>", userId, avatar, realname, indexValue);
            }
            html += "</div>";
            lit_Lovers.Text = html;
        }
        catch (Exception ex)
        {
            lit_Lovers.Text = "<div class='LoverEmpty'>加载同好信息失败，请稍后再试</div>";
            // 调试用：记录错误日志
            System.Diagnostics.Debug.WriteLine("Lovers Error: " + ex.ToString());
        }
    }
}
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
using WebQywyBusiness;
using System.Data.SqlClient;
using System.Data.OleDb;
using System.Text;
using System.Net;
using System.IO;
using System.Xml;
public partial class Default2 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //System.Data.DataTable dt = words.Show_Words();
        //GridView1.DataSource = dt;
        //GridView1.DataBind();

        if (!IsPostBack)
        {
            DataTableToDB();
        }
    }
    protected void Repeater1_ItemCommand(object source, RepeaterCommandEventArgs e)
    {

    }

    public void DataTableToDB()
    {
        string _strExcelFileName = Server.MapPath("/file/敏感词列表.xls");
        //Response.Write(_strExcelFileName);
        DataTable dtExcel = admin.ExcelToDataTable(_strExcelFileName, "Sheet1");

        for (int i = 75; i < dtExcel.Rows.Count; i++)
        {
            //Response.Write(dtExcel.Rows[i][0].ToString() + "-");

            admin.InsertDataToSqlTable(dtExcel.Rows[i][0].ToString());
            if (i == 86) break;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {   
        //if (!string.IsNullOrEmpty(this.FileUpload1.PostedFile.FileName))
        //{
        //    string execPath = this.FileUpload1.PostedFile.FileName;


        //    Response.Write(Server.MapPath(execPath));

        //}
    }
    protected void Button1_Click1(object sender, EventArgs e)
    {
        string method = "flickr.photos.search";
        string api_key = "f6c1a178ad3d82b26baeaa002511744e";
        string tags = "高兴"; //"%E7%99%BD%E5%A4%A9";        
        string page = "6";

        ASCIIEncoding encoding = new ASCIIEncoding();
        string postData = "method=" + method;
        postData += ("&api_key=" + api_key);
        postData += ("&tags=" + Server.UrlEncode(tags));
        postData += ("&per_page=" + page);
        byte[] data = encoding.GetBytes(postData);

        // Prepare web request...  
        HttpWebRequest myRequest =
        (HttpWebRequest)WebRequest.Create("http://api.flickr.com/services/rest/");//?method=flickr.photos.search&api_key=f6c1a178ad3d82b26baeaa002511744e&tags=%E7%99%BD%E5%A4%A9&per_page=6");

        myRequest.Method = "POST";
        myRequest.ContentType = "application/x-www-form-urlencoded";        
        myRequest.ContentLength = data.Length;
        Stream newStream = myRequest.GetRequestStream();

        // Send the data.  
        newStream.Write(data, 0, data.Length);
        newStream.Close();

        // Get response  
        HttpWebResponse myResponse = (HttpWebResponse)myRequest.GetResponse();
        StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.Default);

        string content = reader.ReadToEnd();

        XmlDocument xmldoc = new XmlDocument();
        xmldoc.Load(new System.IO.MemoryStream(System.Text.Encoding.GetEncoding("GB2312").GetBytes(content)));
        StringBuilder sb = new StringBuilder();
        XmlNode xn = xmldoc.SelectSingleNode("rsp");//查找<rsp>
        if(xn.Attributes[0].Value == "ok")
        {   
            XmlNodeList xnl = xn.ChildNodes[0].ChildNodes;
            foreach (XmlNode node in xnl)
            {
                //http://farm3.static.flickr.com/2737/4253602432_dcde4a95fe.jpg
                //<photo id="4253602432" owner="30484726@N04" secret="dcde4a95fe" server="2737" farm="3" title="P1070297" ispublic="1" isfriend="0" isfamily="0" />                
                string farm = node.Attributes["farm"].Value.ToString();
                string server = node.Attributes["server"].Value.ToString();
                string id = node.Attributes["id"].Value.ToString();
                string secret = node.Attributes["secret"].Value.ToString();
                string title = node.Attributes["title"].Value.ToString();
                string src = "http://farm" + farm + ".static.flickr.com/" + server + "/" + id + "_" + secret + ".jpg";
                sb.AppendFormat("<img src=\"{0}\" alt=\"{1}\" width=\"90\" height=\"90\" />", src, title);
            }
        }
        this.Literal1.Text = sb.ToString();

        
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Response.Write("44"+this.Literal1.Text);
    }
}

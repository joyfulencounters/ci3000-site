using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Xml.Linq;
using System.Data.SqlClient;
using WebQywyBusiness;
using System.Xml;
using System.Text;
using System.Net;
using System.IO;
namespace WebQywy
{
    public class Qywyxml
    {        
        #region 同好XML 用户
        public string Show_SaveLoveOfMy(int uid)
        {
            DataTable dt = Users.Show_SaveLoveOfMy(uid);
            StringBuilder sbXml = new StringBuilder();
            sbXml.Append("<?xml version=\"1.0\" encoding=\"UTF-8\" ?>");
            sbXml.Append("<content>");
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                sbXml.Append("<photo>");
                sbXml.AppendFormat("<title>{0}</title>", dt.Rows[i]["realname"].ToString());
                sbXml.AppendFormat("<tmb>{0}</tmb>", dt.Rows[i]["avater"].ToString());
                sbXml.AppendFormat("<img>{0}</img>", dt.Rows[i]["avater"].ToString());
                sbXml.AppendFormat("<userlink>{0}</userlink>", "http://www.ci3000.com/user/default.aspx?u=" + dt.Rows[i]["userid"].ToString());
                sbXml.AppendFormat("<desc>{0}</desc>", dt.Rows[i]["realname"].ToString());
                sbXml.Append("</photo>");
            }
            sbXml.Append("</content>");
            return sbXml.ToString();
        }
        #endregion

        #region 创建XML
        public void CreateXML(int uid)
        {
            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.Load(HttpContext.Current.Server.MapPath("/flash/category1.xml"));

            XmlNode xmlNode = xmlDoc.SelectSingleNode("content");//查找<content>
            xmlNode.RemoveAll();
            DataTable dt = Users.Show_SaveLoveOfMy(uid);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                XmlElement photo = xmlDoc.CreateElement("photo");
                XmlElement title = xmlDoc.CreateElement("title");
                title.InnerText = dt.Rows[i]["realname"].ToString();
                XmlElement tmb = xmlDoc.CreateElement("tmb");
                tmb.InnerText = dt.Rows[i]["avater"].ToString();
                XmlElement img = xmlDoc.CreateElement("img");
                img.InnerText = dt.Rows[i]["avater"].ToString();
                XmlElement userlink = xmlDoc.CreateElement("userlink");
                userlink.InnerText = "/user/default.aspx?u=" + dt.Rows[i]["userid"].ToString();
                XmlElement desc = xmlDoc.CreateElement("desc");
                desc.InnerText = dt.Rows[i]["userid"].ToString() + dt.Rows[i]["savelove"].ToString();
                photo.AppendChild(title);
                photo.AppendChild(tmb);
                photo.AppendChild(img);
                photo.AppendChild(userlink);
                photo.AppendChild(desc);

                xmlNode.AppendChild(photo);
            }
            xmlDoc.Save(HttpContext.Current.Server.MapPath("/flash/category1.xml"));            
        }        
        #endregion

        #region flickr 返回相关图片
        public string ShowFlickrImg(string tag)
        {
            string method = "flickr.photos.search";
            string api_key = "f6c1a178ad3d82b26baeaa002511744e";
            string tags = tag;// "高兴"; //"%E7%99%BD%E5%A4%A9";        
            string page = "6";
            try
            {
                ASCIIEncoding encoding = new ASCIIEncoding();
                string postData = "method=" + method;
                postData += ("&api_key=" + api_key);
                postData += ("&text=" + System.Web.HttpContext.Current.Server.UrlEncode(tags));
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
                if (xn.Attributes[0].Value == "ok")
                {
                    XmlNodeList xnl = xn.ChildNodes[0].ChildNodes;
                    foreach (XmlNode node in xnl)
                    {
                        //http://farm3.static.flickr.com/2737/4253602432_dcde4a95fe.jpg
                        //<photo id="4253602432" owner="30484726@N04" secret="dcde4a95fe" server="2737" farm="3" title="P1070297" ispublic="1" isfriend="0" isfamily="0" /> 
                        //http://www.flickr.com/photos/7841384@N07/1153699093/
                        string farm = node.Attributes["farm"].Value.ToString();
                        string server = node.Attributes["server"].Value.ToString();
                        string id = node.Attributes["id"].Value.ToString();
                        string secret = node.Attributes["secret"].Value.ToString();
                        string title = node.Attributes["title"].Value.ToString();
                        string owner = node.Attributes["owner"].Value.ToString();
                        string src = "http://farm" + farm + ".static.flickr.com/" + server + "/" + id + "_" + secret + "_s.jpg";
                        sb.AppendFormat("<span style=\"margin:10px 17px; float:left;border:1px #ccc solid;padding:2px;width:75px;height:75px;\" ><a href=\"http://www.flickr.com/photos/" + owner + "/" + id + "/\" target=\"_blank\"><img src=\"{0}\" alt=\"{1}\" width=\"75\" height=\"75\" /></a></span>", src, title);
                    }
                }
                return sb.ToString();
            }
            catch (Exception ex)
            {
                return "";
            }
        }
        #endregion
    }
}
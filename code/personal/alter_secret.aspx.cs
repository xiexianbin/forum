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

public partial class alter_secret : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == "")
        {
            Response.Write("<script>alert('请登录...');window.location.href='../login.aspx'</script>");
        }
    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        if (this.username.Value == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请输入用户名!');</script>");
        }
        else if (this.secret.Value == "")
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('请输入密码!');</script>");
        }
        else
        {
            if (SqlHelper.Login(this.username.Value, this.secret.Value))
            {
                Session["userName"] = this.username.Value;
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('登录成功!');</script>");
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('登录失败!');</script>");
            }
        }
    }
    protected void LinkButton_logout_Command(object sender, CommandEventArgs e)
    {
        Session["userName"] = "";
    }
    protected void LinkButton1_logout_Command(object sender, CommandEventArgs e)
    {
        Session["userName"] = "";
    }

    protected void Button2_Command(object sender, CommandEventArgs e)
    {
        string old_sec = this.his_sec.Text.ToString();
        string new_sec = this.news_sec.Text.ToString();

        string sql = "select u_secret from [users] where u_name = '" + Session["userName"] + "'";
        if (SqlHelper.ExecuteNonQuery(sql) > 0)
        {
            if (old_sec == SqlHelper.ExecuteScalar(sql))
            {
                string sql_new = "update users set u_secret = '" + new_sec + "' where u_name = '" + Session["userName"] + "'";
                if (SqlHelper.ExecuteNonQuery(sql_new) > 0)
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改成功!');</script>");
                }
                else
                {
                    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败!');</script>");

                }
            }
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败!');</script>");
        }
    }
}

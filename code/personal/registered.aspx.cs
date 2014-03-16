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

public partial class registered : System.Web.UI.Page
{
    
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string sex = radiobutton1.Checked == true ? "男" : "女";
        string sql = "insert into users(u_name,u_secret,u_regedit_time,u_r_name,u_age,u_sex,u_school, u_qq, u_email, u_address, u_head_image, u_personal) values('"
            + name.Value + "','" + secret1.Text + "','" + DateTime.Now.ToString() + "','" + r_name.Value + "','" + age.Value + "','"
            + sex + "','" + school.Value + "','" + qq.Value + "','" + email.Value + "','" + address.Value + "','" + headimage.Value
            + "','" + personal.Value + "')";
       
        if (SqlHelper.ExecuteNonQuery(sql) > 0)
        {
            Response.Write("<script>alert('恭喜您，注册成功！请登录...');window.location.href='../login.aspx'</script>");

        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('注册失败!');</script>");
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
}

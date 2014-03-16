using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class getback : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

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
    protected void Button2_Click(object sender, EventArgs e)
    {
        //string name = this.textfield.ToString();
        //string sql_name = "select u_name, u_question from users where u_name = '" + name +"'";
        //if (SqlHelper.ExecuteNonQuery(sql_name) > 0)
        //{
        //    //设置前台lablle1为内容
        //}
        //else
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('用户名不存在!');</script>");
        //}
    }
}
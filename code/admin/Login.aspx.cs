using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_Login : db
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string num = "";

        if (Session["check"] != null)
        {
            num = Session["check"].ToString();
            ViewState["Check"] = num.ToLower();
            Session["check"] = null;
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string yzm = Session["Random"].ToString();


        if (yzm == this.chknumber.Value.ToLower().ToString())
        {
            string str2 = "select count(*) from super_users where s_u_name='" + this.user.Value.ToString() + "'";
            int count = Convert.ToInt32(ExecSelec(str2));
            if (count > 0)
            {
                string str = "select s_u_secret from super_users where s_u_name='" + this.user.Value.ToString() + "'";
                string pwd = Convert.ToString(ExecSelec(str));
                if (pwd == Convert.ToString(this.pwd.Value.Trim()))
                {
                    Session["admin"] = "admin";
                   // string UID = "select UserID from t_adminlogin where UserName='" + this.user.Value.ToString() + "'";
                   // Session["UserID"] = ExecSelec(UID);
                    Session["Name"] = this.user.Value.ToString();
                    Response.Redirect("main.html");

                }
                else
                {
                    MessageBox("用户名或密码错误！");
                }
            }
            else
            {
                MessageBox("该用户不存在！");
            }
        }
        else
        {
            MessageBox("验证码不正确！");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        this.user.Value = "";
        this.pwd.Value = "";
    }
}
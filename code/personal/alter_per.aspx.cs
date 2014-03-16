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
using System.Data.SqlClient;

public partial class alter_per : System.Web.UI.Page
{
    public DataRow ds_alter;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == "")
        {
            Response.Write("<script>alert('请登录...');window.location.href='../login.aspx'</script>");
        }
        ds_alter = ShowPage().Rows[0];
        if (!IsPostBack)
        {
            
            if (ds_alter["u_sex"].ToString() == "男")
            {
                rb_man.Checked = true;
            }
            else
            {
                rb_wom.Checked = true;
            }
            this.r_name.Value = ds_alter["u_r_name"].ToString();
            this.age.Text = ds_alter["u_age"].ToString();
            this.qq.Text = ds_alter["u_qq"].ToString();
            this.email.Text = ds_alter["u_email"].ToString();
            this.address.Text = ds_alter["u_address"].ToString();
            this.personal.Value = ds_alter["u_personal"].ToString();
        }
    }

    public DataTable ShowPage()
    {
        string sql = "select * from users where u_name='" + Session["userName"] + "'";
        return SqlHelper.ExecuteDataSetsql(sql).Tables[0];
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
    //修改
    protected void submit_Click(object sender, EventArgs e)
    {
        string sex = rb_man.Checked == true ? "男" : "女";
        int age1 = int.Parse(this.age.Text);
        string sql = "update users set u_r_name = '" + this.r_name.Value + "', u_age = '"
            + age1 + "', u_sex='" + sex + "', u_school = '" + this.school.Text.ToString() + "', u_qq = '" + this.qq.Text.ToString()
            + "', u_email = '" + this.email.Text.ToString() + "', u_address = '" + this.address.Text.ToString()
            + "', u_personal = '" + this.personal.Value.ToString() + "' where u_name='" + Session["userName"] + "'";
        if (SqlHelper.ExecuteNonQuery(sql) > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('您的资料已成功修改!');</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('修改失败!');</script>");
        }
    }
}

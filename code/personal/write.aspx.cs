using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class personal_write : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == "")
        {
            Response.Write("<script>alert('请登录...');window.location.href='../login.aspx'</script>");
        }
        CKEditor.config.uiColor = "#B5B1F3";
        CKEditor.config.toolbar = new object[]
            {
				new object[] { "Bold", "Italic", "Underline", "Strike"},
				new object[] { "NumberedList", "BulletedList", "-", "Outdent", "Indent"},
				new object[] { "JustifyLeft", "JustifyCenter", "JustifyRight", "JustifyBlock" },
				new object[] { "Link", "Unlink" },
				new object[] { "Image",  "Table", "Smiley", "SpecialChar" },
				new object[] { "Font", "FontSize", "TextColor", "BGColor" },
            };
    }

    //保存并发表
    protected void btpublic_Click(object sender, EventArgs e)
    {
        string sql = "insert into diarylisting(u_name,d_type,d_title,d_text,d_time) values(@name,@dType,@title,@content,@time)";
        SqlParameter[] para = new SqlParameter[]{
            new SqlParameter("@name", SqlDbType.NChar,30),
            new SqlParameter("@dType",SqlDbType.NChar,30),
            new SqlParameter("@title",SqlDbType.NChar,50),
            new SqlParameter("@content",SqlDbType.NText),
            new SqlParameter("@time",SqlDbType.DateTime)
        };
        para[0].Value = Session["userName"];
        para[1].Value = this.select.SelectedValue.ToString();
        para[2].Value = this.title1.Value;
        para[3].Value = this.CKEditor.Text;
        para[4].Value = DateTime.Now;

        if (SqlHelper.ExecuteNonQuery(sql, para) > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('发表成功!');</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('发表失败!');</script>");
        }

    }

    //保存草稿
    protected void btSavedraft_Click(object sender, EventArgs e)
    {
        string sql = "insert into diarylisting(u_name,d_type,d_title,d_text,d_time,d_draft) values(@name,@dType,@title,@content,@time,@draft)";
        SqlParameter[] para = new SqlParameter[]{
            new SqlParameter("@name", SqlDbType.NChar,30),
            new SqlParameter("@dType",SqlDbType.NChar,30),
            new SqlParameter("@title",SqlDbType.NChar,50),
            new SqlParameter("@content",SqlDbType.NText),
            new SqlParameter("@time",SqlDbType.DateTime),
            new SqlParameter("@draft",SqlDbType.NChar,10)
        };
        para[0].Value = Session["userName"];
        para[1].Value = this.select.SelectedValue;
        para[2].Value = this.title1.Value;
        para[3].Value = this.CKEditor.Text;
        para[4].Value = DateTime.Now;
        para[5].Value = "yes";

        if (SqlHelper.ExecuteNonQuery(sql, para) > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('草稿保存成功!');</script>");

        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('草稿保存失败!');</script>");

        }
    }

    //隐藏日记
    protected void bthide_Click(object sender, EventArgs e)
    {
        string sql = "insert into diarylisting(u_name,d_type,d_title,d_text,d_time,d_p_or_s,d_draft) values(@name,@dType,@title,@content,@time,@p_or_s,@draft)";
        SqlParameter[] para = new SqlParameter[]{
            new SqlParameter("@name", SqlDbType.NChar,30),
            new SqlParameter("@dType",SqlDbType.NChar,30),
            new SqlParameter("@title",SqlDbType.NChar,50),
            new SqlParameter("@content",SqlDbType.NText),
            new SqlParameter("@time",SqlDbType.DateTime),
            new SqlParameter("@p_or_s",SqlDbType.Char),
            new SqlParameter("@draft",SqlDbType.NChar,10)
        };
        para[0].Value = Session["userName"];
        para[1].Value = this.select.SelectedValue;
        para[2].Value = this.title1.Value;
        para[3].Value = this.CKEditor.Text;
        para[4].Value = DateTime.Now;
        para[5].Value = 's';
        para[6].Value = "yes";

        if (SqlHelper.ExecuteNonQuery(sql, para) > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('隐藏保存成功!');</script>");

        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('隐藏保存失败!');</script>");
        }
    }

    //重置
    protected void btreset_Click(object sender, EventArgs e)
    {
        this.title1.Value = "";
        this.CKEditor.Text = "";
        this.select.SelectedValue = "励志日记";
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
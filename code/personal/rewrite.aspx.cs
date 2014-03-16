using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;

public partial class personal_rewrite : System.Web.UI.Page
{
    public DataRow ds_diary_rewrite;
    private static int id = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == "")
        {
            Response.Write("<script>alert('请登录...');window.location.href='../login.aspx'</script>");
        }
        id = int.Parse(Request.QueryString["id"].ToString());
        ds_diary_rewrite = ShowPage().Rows[0];
        if (!IsPostBack)
        {
            this.title1.Value = ds_diary_rewrite["d_title"].ToString();
            this.CKEditor.Text = ds_diary_rewrite["d_text"].ToString();
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

    public DataTable ShowPage()
    {
        string sql = "select * from diarylisting where d_id=" + id;
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

    //更新日记
    protected void btpublic_Click(object sender, EventArgs e)
    {
        string new_title = this.title1.Value;
        string new_type=this.select.SelectedValue.ToString();
        string new_text = CKEditor.Text.ToString();
        DateTime new_time = DateTime.Now;
        string sql = "update diarylisting set d_type='" + new_type 
            + "',d_title='" + new_title + "',d_text='" 
            + new_text + "',d_time='" + new_time + "' where d_id=" + id;

        if (SqlHelper.ExecuteNonQuery(sql) > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('更新成功!');</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('更新失败!');</script>");
        }

    }

    //保存草稿
    protected void btSavedraft_Click(object sender, EventArgs e)
    {
        string new_title = this.title1.Value;
        string new_type = this.select.SelectedValue.ToString();
        string new_text = CKEditor.Text.ToString();
        DateTime new_time = DateTime.Now;
        string sql = "update diarylisting set d_type='" + new_type
            + "',d_title='" + new_title + "',d_text='"
            + new_text + "',d_time='" + new_time + "', d_draft='yes' where d_id=" + id;

        if (SqlHelper.ExecuteNonQuery(sql) > 0)
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
        string new_title = this.title1.Value;
        string new_type = this.select.SelectedValue.ToString();
        string new_text = CKEditor.Text.ToString();
        DateTime new_time = DateTime.Now;
        string sql = "update diarylisting set d_type='" + new_type
            + "',d_title='" + new_title + "',d_text='"
            + new_text + "',d_time='" + new_time + "', d_p_or_s='s' where d_id=" + id;

        if (SqlHelper.ExecuteNonQuery(sql) > 0)
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
    protected void LinkButton_logout_Command(object sender, CommandEventArgs e)
    {
        Session["userName"] = "";
    }
    protected void LinkButton1_logout_Command(object sender, CommandEventArgs e)
    {
        Session["userName"] = "";
    }
}
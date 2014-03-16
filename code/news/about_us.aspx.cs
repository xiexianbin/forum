using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class news_about_us : System.Web.UI.Page
{
    public DataRow ds_news;
    public DataTable ds_hot_diary;//热门日记
    public DataTable ds_contact;//联系方式
    public int c_hot_diary;
    private static int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        ds_hot_diary = ShowPage_hot_diary();
        id = int.Parse(Request.QueryString["id"].ToString());
        ds_news = ShowPage_news().Rows[0];
        ds_contact = ShowPage_contact();
        MakeSureCount();
        IncReadNumber();
    }
    public void IncReadNumber()
    {
        string sql = "update news set n_num = n_num+1 where n_id = '" + id + "'";
        SqlHelper.ExecuteDataSetsql(sql);
    }
    public void MakeSureCount()
    {
        if (ds_hot_diary.Rows.Count > 6)
            c_hot_diary = 6;
        else
        {
            c_hot_diary = ds_hot_diary.Rows.Count;
        }
    }
    public DataTable ShowPage_hot_diary()
    {
        string sql = "select * from diarylisting where d_draft='no' and d_p_or_s='p' order by d_good desc";
        return SqlHelper.ExecuteDataSetsql(sql).Tables[0];
    }
    public DataTable ShowPage_news()
    {
        string sql = "select * from news where n_id=" + id;
        return SqlHelper.ExecuteDataSetsql(sql).Tables[0];
    }
    public DataTable ShowPage_contact()
    {
        string sql = "select * from recommend where c_type = 'new_s'";
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
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('用户名或密码错误!');</script>");
            }
        }
    }

    protected void LinkButton_logout_Command(object sender, CommandEventArgs e)
    {
        Session["userName"] = "";
    }
}
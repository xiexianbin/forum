using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class bznews : System.Web.UI.Page
{
    public DataTable ds_news_bz;//考研新闻
    public DataTable ds_hot_diary;//热门日记
    public DataTable ds_bz_recommend;
    public string SQL = "";

    public int c_hot_diary;
    protected void Page_Load(object sender, EventArgs e)
    {
        AspNetPager1.RecordCount = SqlHelper.GetDataCount("select * from  news WHERE n_type='bznews'");
        SQL = "select * from news where n_type='bznews' order by n_time desc";

        if (!IsPostBack)
        {
            AspNetPager1.CurrentPageIndex = 1;
            ds_news_bz = SqlHelper.ExecuteDataTable(SQL, AspNetPager1);
        }
        ds_hot_diary = ShowPage_hot_diary();
        MakeSureCount();
        ds_bz_recommend = ShowPage_bz_recommend();
    }
    public void MakeSureCount()
    {
        if (ds_hot_diary.Rows.Count > 5)
            c_hot_diary = 5;
        else
        {
            c_hot_diary = ds_hot_diary.Rows.Count;
        }
    }
    public DataTable ShowPage_news_bz()
    {
        string sql = "select * from news where n_type='bznews' order by n_time desc";
        return SqlHelper.ExecuteDataSetsql(sql).Tables[0];
    }
    public DataTable ShowPage_hot_diary()
    {
        string sql = "select * from diarylisting where d_draft='no' and d_p_or_s='p' order by d_good desc";
        return SqlHelper.ExecuteDataSetsql(sql).Tables[0];
    }
    public DataTable ShowPage_bz_recommend()
    {
        string sql = "select * from recommend where c_type='bznews'";
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

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        ds_news_bz = SqlHelper.ExecuteDataTable(SQL, AspNetPager1);
    }
}
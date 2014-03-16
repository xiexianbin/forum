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

public partial class index : System.Web.UI.Page
{
    public DataTable ds_hot_diary;//热门日记
    public DataTable ds_news_bz;//本站新闻
    public DataTable ds_news_ky;//考研新闻
    public DataTable ds_wr_years;//风雨那些年
    public DataTable ds_about_us;//关于我们
    public DataTable ds_url;//推荐连接

    public int c_hot_diary;//热门日记的显示条数
    public int c_news_bz;
    public int c_news_ky;
    public int c_wr_years;
    public int c_about_us;
    protected void Page_Load(object sender, EventArgs e)
    {
        ds_hot_diary = ShowPage_hot_diary();
        ds_news_bz = ShowPage_news_bz();
        ds_news_ky = ShowPage_news_ky();
        ds_wr_years = ShowPage_wr_years();
        ds_about_us = ShowPage_about_us();
        ds_url = ShowPage_url();
        MakeSureCount();
    }

    public void MakeSureCount()
    {
        if (ds_hot_diary.Rows.Count > 6)
            c_hot_diary = 6;
        else
        {
            c_hot_diary = ds_hot_diary.Rows.Count;
        }
        if (ds_news_bz.Rows.Count > 6)
            c_news_bz = 6;
        else
        {
            c_news_bz = ds_news_bz.Rows.Count;
        }
        if (ds_news_ky.Rows.Count > 6)
            c_news_ky = 6;
        else
        {
            c_news_ky = ds_news_ky.Rows.Count;
        }
        if (ds_wr_years.Rows.Count > 6)
        {
            c_wr_years = 6;
        }
        else
        {
            c_wr_years = ds_wr_years.Rows.Count;
        }
        if (ds_about_us.Rows.Count > 6)
        {
            c_about_us = 6;
        }
        else
        {
            c_about_us = ds_about_us.Rows.Count;
        }
    }
    public DataTable ShowPage_url()
    {
        string sql = "select * from recommend where c_type='url' order by c_num";
        return SqlHelper.ExecuteDataSetsql(sql).Tables[0];
    }

    public DataTable ShowPage_hot_diary()
    {
        string sql = "select * from diarylisting where d_draft='no' and d_p_or_s='p' order by d_good desc";
        return SqlHelper.ExecuteDataSetsql(sql).Tables[0];
    }
    public DataTable ShowPage_news_bz()
    {
        string sql = "select * from news where n_type='bznews' order by n_time desc";
        return SqlHelper.ExecuteDataSetsql(sql).Tables[0];
    }
    public DataTable ShowPage_news_ky()
    {
        string sql = "select * from news where n_type='kynews' order by n_time desc";
        return SqlHelper.ExecuteDataSetsql(sql).Tables[0];
    }
    public DataTable ShowPage_wr_years()
    {
        string sql = "select * from news where n_type='wr_years' order by n_time desc";
        return SqlHelper.ExecuteDataSetsql(sql).Tables[0];
    }
    public DataTable ShowPage_about_us()
    {
        string sql = "select * from news where n_type='about_us' order by n_time desc";
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

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

public partial class sugreading : System.Web.UI.Page
{
    public DataTable ds_sugreading;//推荐阅读
    public DataTable ds_sug_recommend;
    public string SQL = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        AspNetPager1.RecordCount = SqlHelper.GetDataCount("select * from  news WHERE n_type='sugreading'");
        SQL = "select * from news where n_type='sugreading' order by n_time desc";

        if (!IsPostBack)
        {
            AspNetPager1.CurrentPageIndex = 1;
            ds_sugreading = SqlHelper.ExecuteDataTable(SQL, AspNetPager1);
        }
        ds_sug_recommend = ShowPage_sug_recommend();
    }

    public DataTable ShowPage_sugreading()
    {
        string sql = "select * from news where n_type='sugreading' order by n_time desc";
        return SqlHelper.ExecuteDataSetsql(sql).Tables[0];
    }
    public DataTable ShowPage_sug_recommend()
    {
        string sql = "select * from recommend where c_type = 'sugreading'";
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
        ds_sugreading = SqlHelper.ExecuteDataTable(SQL, AspNetPager1);
    }
}

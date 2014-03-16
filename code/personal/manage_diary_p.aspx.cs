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

public partial class manage_diary_p : System.Web.UI.Page
{
    public DataTable ds_m_p;
    public string SQL = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == "")
        {
            Response.Write("<script>alert('请登录...');window.location.href='../login.aspx'</script>");
        }

        AspNetPager1.RecordCount = SqlHelper.GetDataCount("select * from  diarylisting where d_draft='no' and d_p_or_s='p' and u_name='" + Session["userName"] + "'");
        SQL = "select * from diarylisting where d_draft='no' and d_p_or_s='p' and u_name='" + Session["userName"] + "' order by d_time desc";

        if (!IsPostBack)
        {
            AspNetPager1.CurrentPageIndex = 1;
            ds_m_p = SqlHelper.ExecuteDataTable(SQL, AspNetPager1);
            this.Repeater1.DataSource = ds_m_p;
            this.Repeater1.DataBind();
        }
    }

    public DataTable ShowPage()
    {
        string sql = "select * from diarylisting where d_draft='no' and d_p_or_s='p' and u_name='" + Session["userName"] + "' order by d_time desc";
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

    //删除
    protected void LinkButton_cdelete(object sender, CommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        string sql = "delete from diarylisting where d_id='" + id + "' and u_name='" + Session["userName"] + "'";
        if (SqlHelper.ExecuteNonQuery(sql) > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功!');</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败!');</script>");
        }
    }

    //隐藏
    protected void LinkButton_csec(object sender, CommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());
        string sql = "update diarylisting set d_p_or_s='s' where d_id = '" + id + "' and u_name='" + Session["userName"] + "'";
        if (SqlHelper.ExecuteNonQuery(sql) > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('隐藏成功!');</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('隐藏失败!');</script>");
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

    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        ds_m_p = SqlHelper.ExecuteDataTable(SQL, AspNetPager1);
    }
}

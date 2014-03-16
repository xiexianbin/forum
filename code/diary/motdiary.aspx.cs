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

public partial class motdiary : System.Web.UI.Page
{
    public DataTable ds_lizhi;
    public DataTable ds_mot_recommend;//联系方式
    public string SQL = "";
    //pageLoad
    protected void Page_Load(object sender, EventArgs e)
    {
        AspNetPager1.RecordCount = SqlHelper.GetDataCount("select * from  diarylisting WHERE d_type='励志日记' and d_draft='no' and d_p_or_s='p'");
        SQL = "select * from diarylisting where d_type='励志日记' and d_draft='no' and d_p_or_s='p' order by d_time desc";
            
        if (!IsPostBack)
        {
            AspNetPager1.CurrentPageIndex = 1;
            ds_lizhi = SqlHelper.ExecuteDataTable(SQL, AspNetPager1);
            this.Repeater1.DataSource = ds_lizhi;
            this.Repeater1.DataBind();
        }
        ds_mot_recommend = ShowPage_mot_recommend();
    }
    //显示推荐
    public DataTable ShowPage_mot_recommend()
    {
        string sql = "select * from recommend where c_type = 'mot'";
        return SqlHelper.ExecuteDataSetsql(sql).Tables[0];
    }
    //赞
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        int id = int.Parse(e.CommandArgument.ToString());

        string sql = "update diarylisting set d_good=d_good+1 where d_id=" + id ;
        if (SqlHelper.ExecuteNonQuery(sql) > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('成功!');</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('失败!');</script>");
        }
    }
    //登录
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
    //退出
    protected void LinkButton_logout_Command(object sender, CommandEventArgs e)
    {
        Session["userName"] = "";
    }
    //分页绑定
    protected void AspNetPager1_PageChanged(object sender, EventArgs e)
    {
        ds_lizhi = SqlHelper.ExecuteDataTable(SQL, AspNetPager1);      
    }
}

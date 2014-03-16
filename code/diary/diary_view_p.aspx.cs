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

public partial class diary_view_p : System.Web.UI.Page
{
    public DataRow ds_view_p;
    public DataTable ds_view_pCom;
    public DataTable ds_pv_recommend;//联系方式
    private static int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        id = int.Parse(Request.QueryString["id"].ToString());
        ds_view_p = ShowPage().Rows[0];
        ds_view_pCom = ShowComm();
        ds_pv_recommend = ShowPage_pv_recommend();
        IncReadNumber();
        CKEditor.config.uiColor = "#B5B1F3";
        CKEditor.config.toolbar = new object[]
            {
				new object[] { "Smiley" },
            };
    }
    public void IncReadNumber()
    {
        string sql = "update diarylisting set read_number = read_number+1 where d_id = '" + id +"'";
        SqlHelper.ExecuteDataSetsql(sql);
    }

    public DataTable ShowPage()
    {
        string sql = "select * from diarylisting where d_id=" + id;
        return SqlHelper.ExecuteDataSetsql(sql).Tables[0];
    }
    public DataTable ShowPage_pv_recommend()
    {
        string sql = "select * from recommend where c_type = 'pv'";
        return SqlHelper.ExecuteDataSetsql(sql).Tables[0];
    }
    public DataTable ShowComm()
    {
        string sql = "select * from commentlist where d_id=" + id;
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

    //评论
    protected void btSave_Click(object sender, EventArgs e)
    {
        if (Session["userName"] == "")
        {
            Response.Write("<script>alert('请登录...');window.location.href='../login.aspx'</script>");
        }
        if (this.CKEditor.Text.ToString() == "")
            Response.Write("<script>alert('请输入评论内容！！');</script>");
        else
        {
            string sql_com = "insert into commentlist(d_id,u_name,c_time,c_text) values(@dId,@uName,@cTime,@cText)";
            SqlParameter[] para = new SqlParameter[]{
            new SqlParameter("@dId",SqlDbType.Int),
            new SqlParameter("@uName",SqlDbType.NChar,30),
            new SqlParameter("@cTime",SqlDbType.DateTime),
            new SqlParameter("@cText",SqlDbType.NText)
           };
            para[0].Value = id;
            para[1].Value = Session["userName"].ToString();
            para[2].Value = DateTime.Now;
            para[3].Value = CKEditor.Text.ToString();

            if (SqlHelper.ExecuteNonQuery(sql_com, para) > 0)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('评论成功!');</script>");
                string sql = "update diarylisting set com_number = com_number+1 where d_id = '" + id + "'";
                SqlHelper.ExecuteDataSetsql(sql);
            }
            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('评论失败!');</script>");
            }
        }
    }

    protected void LinkButton_logout_Command(object sender, CommandEventArgs e)
    {
        Session["userName"] = "";
    }
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        string sql = "update diarylisting set d_good=d_good+1 where d_id=" + id;
        if (SqlHelper.ExecuteNonQuery(sql) > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('成功，谢谢您的支持!');</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('失败!');</script>");
        }
    }
}

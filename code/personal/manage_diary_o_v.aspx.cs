using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class manage_diary_o_v : System.Web.UI.Page
{
    public DataRow ds_o_v;

    public DataTable ds_o_v_oCom;

    private static int id = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["userName"] == "")
        {
            Response.Write("<script>alert('请登录...');window.location.href='../login.aspx'</script>");
        }
        id = int.Parse(Request.QueryString["id"].ToString());
        ds_o_v = ShowPage().Rows[0];
        ds_o_v_oCom = ShowComm();
        this.Repeater1.DataSource = ds_o_v_oCom;
        this.Repeater1.DataBind();
    }

    public DataTable ShowPage()
    {
        string sql = "select * from diarylisting where d_id=" + id;
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
                ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('登录失败!');</script>");
            }
        }
    }

    //删除
    protected void LinkButton_o_vdelete_Command(object sender, CommandEventArgs e)
    {
        //int id = int.Parse(e.CommandArgument.ToString());

        string sql = "delete from diarylisting where d_id=" + id;
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
    protected void LinkButton_o_vhide_Command(object sender, CommandEventArgs e)
    {
        //int id = int.Parse(e.CommandArgument.ToString());

        string sql = "update diarylisting set d_p_or_s='s',d_draft='no' where d_id =" + id;
        if (SqlHelper.ExecuteNonQuery(sql) > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('隐藏成功!');</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('隐藏失败!');</script>");
        }
    }

    //公开
    protected void LinkButton_o_vpulic_Command(object sender, CommandEventArgs e)
    {
        //int id = int.Parse(e.CommandArgument.ToString());

        string sql = "update diarylisting set d_p_or_s='p',d_draft='no' where d_id =" + id;
        if (SqlHelper.ExecuteNonQuery(sql) > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('公开成功!');</script>");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('公开失败!');</script>");
        }
    }

    protected void LinkButton_logout_Command(object sender, CommandEventArgs e)
    {
        Session["userName"] = "";
    }
    //删除评论
    protected void LinkButton_delete_com(object sender, CommandEventArgs e)
    {
        int id_com = int.Parse(e.CommandArgument.ToString());

        string sql = "delete from commentlist where c_id='" + id_com + "'";
        if (SqlHelper.ExecuteNonQuery(sql) > 0)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功!');</script>");
            string sql1 = "update diarylisting set com_number = com_number-1 where d_id = '" + id + "'";
            SqlHelper.ExecuteDataSetsql(sql1);
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除失败!');</script>");
        }
    }
}
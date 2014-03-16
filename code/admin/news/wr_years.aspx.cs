using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_news_wr_years : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bindData();
    }
    public void bindData()
    {
        string sql = "select * from news where n_type = 'wr_years'  order by n_time desc";
        SqlHelper.GridviewBind(GridView1, sql);
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string sql = "delete from  news where n_id='" + GridView1.DataKeys[e.RowIndex].Value + "'";
        SqlHelper.ExecuteNonQuery(sql);
        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功!');</script>");

    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("add_news.aspx");
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_news_sugreading : db
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bindData();
    }
    public void bindData()
    {
        string sql = "select * from news where n_type = 'sugreading'  order by n_time desc";
        SqlHelper.GridviewBind(GridView1, sql);
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string str = "delete from  news where n_id='" + GridView1.DataKeys[e.RowIndex].Value + "'";
        ExecNoneQuery(str);
        MessageBox("删除成功！！");
    }
    protected void LinkButton1_Click(object sender, EventArgs e)
    {
        Response.Redirect("add_news.aspx");
    }
}
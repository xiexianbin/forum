using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_recommend_manege_bznews_sug : db
{
    protected void Page_Load(object sender, EventArgs e)
    {
        bindData();
    }

    public void bindData()
    {
        string sql = "select * from recommend where c_type = 'bznews'";
        SqlHelper.GridviewBind(GridView1, sql);
    }
    protected void Button_add_Click(object sender, EventArgs e)
    {
        string title = this.TextBox_title.Text;
        string url = this.TextBox_url.Text;
        int num = int.Parse(this.TextBox_num.Text);
        string type = "bznews";
        string other = this.TextBox_other.Text;
        string sql = "insert into recommend(c_title, c_url, c_num, c_type, c_other) values('" + title + "', '" + url + "', '" + num + "', '" + type + "','" + other + "' )";
        ExecNoneQuery(sql);
        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('插入成功!');</script>");
    }
    protected void Button_reset_Click(object sender, EventArgs e)
    {
        this.TextBox_title.Text = "";
        this.TextBox_num.Text = "";
        this.TextBox_other.Text = "";
        this.TextBox_url.Text = "";
    }

    protected void GridView1_RowDeleting1(object sender, GridViewDeleteEventArgs e)
    {
        string sql = "delete from recommend where c_id = '" + GridView1.DataKeys[e.RowIndex].Value + "'";
        ExecNoneQuery(sql);
        ClientScript.RegisterStartupScript(this.GetType(), "", "<script>alert('删除成功!');</script>");
    }
}
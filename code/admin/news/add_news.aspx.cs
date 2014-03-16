using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_news_add_news : db
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string title = this.TextBox1.Text;
        string author = this.TextBox2.Text;
        string content = this.CKEditor.Text;
        content = HttpUtility.HtmlEncode(content);
        string time = DateTime.Now.ToString();
        string type = DropDownList1.SelectedValue.ToString();
        string str1 = "insert into news (ad_user, n_title, n_time, n_text, n_type, n_other)values('" + author + "','" + title + "','" + time + "','" + content + "','" + type + "','" + this.TextBox3.Text.ToString() + "')";
        ExecNoneQuery(str1);
        MessageBox("添加成功！");
        clear();
    }
    public void clear()
    {
        this.TextBox1.Text = "";
        this.TextBox2.Text = "";
        this.TextBox3.Text = "";
        this.CKEditor.Text = "";
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        clear();
    }
}
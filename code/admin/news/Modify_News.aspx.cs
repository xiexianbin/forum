using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_news_Modify_News : db
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string ID = Request.QueryString["id"].ToString();

            string str = "select n_title from news where n_id='" + ID + "'";
            this.TextBox1.Text = ExecSelec(str);

            string str1 = "select ad_user from news where n_id='" + ID + "'";
            this.TextBox2.Text = ExecSelec(str1);
            string str2 = "select n_text from news where n_id='" + ID + "'";
            this.CKEditor.Text = ExecSelec(str2);
            string str4 = "select n_other from news where n_id='" + ID + "'";
            this.TextBox3.Text = ExecSelec(str4);
        }

    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        string ID = Request.QueryString["id"].ToString();

        string update = "update news set n_title='" + TextBox1.Text.ToString()
            + "',n_other='" + this.TextBox3.Text.ToString() + "',n_text='" + CKEditor.Text.ToString() 
            + "',ad_user='" + this.TextBox2.Text.ToString() 
            + "',n_type='" + this.DropDownList1.SelectedValue.ToString() + "',n_time='" + DateTime.Now 
            + "' where n_id=" + ID;
        ExecNonQuery(update);
        MessageBox("更改成功！");
    }

}
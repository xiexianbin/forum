using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class admin_news_DetailNews : db
{
    public string title;
    public string content;
    public string author;
    public string time;
    public string str;
    protected void Page_Load(object sender, EventArgs e)
    {

        string id = Request.QueryString["id"];
        str = "select n_title from news where n_id='" + id + "'";
        title = ExecSelec(str);

        str = "select n_text from news where n_id='" + id + "'";
        content = ExecSelec(str);

        str = "select ad_user from news where n_id='" + id + "'";
        author = ExecSelec(str);

        str = "select n_time from news where n_id='" + id + "'";
        time = ExecSelec(str);

    }
}
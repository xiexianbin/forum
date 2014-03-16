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

public partial class login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Unnamed1_Click(object sender, EventArgs e)
    {
        if (SqlHelper.Login(this.username.Value, this.secret.Value))
        {
            Session["userName"] = this.username.Value;
            Response.Write("<script>alert('登录成功');window.location.href='personal/personal.aspx'</script>");
        }
    }
}

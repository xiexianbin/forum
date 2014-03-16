using System;
using System.Data;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using System.Data.SqlClient;
//using Wuqi.Webdiyer;
/// <summary>
///db 的摘要说明
/// </summary>
public class db: System.Web.UI.Page
{
	public db()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}
 
    //数据库连接

    public static SqlConnection constr()
    {
        SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["ConnectionString"].ToString());
        return con;
    }
   
    //登录判断方法
    public static void executenary(string str)
    {
        SqlConnection con = db.constr();
        con.Open();
        SqlCommand cmd = new SqlCommand(str, con);
        cmd.ExecuteNonQuery();
    }
        //执行sql语句
    public static SqlCommand GetCommandStr(string strSql)
    {
        SqlConnection con = constr();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandText = strSql;
        cmd.CommandType = CommandType.Text;
        return cmd;
    }
    public static void ExecNoneQuery(string str)
    {
        SqlCommand cmd = GetCommandStr(str);
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        cmd.Dispose();
    }

    public static void BindGridView(GridView gv, string SqlStr)
    {
        SqlConnection con = constr();
        con.Open();//打开数据库连接
        SqlDataAdapter ada = new SqlDataAdapter(SqlStr, con);
        DataSet ds = new DataSet();
        ada.Fill(ds);
        gv.DataSource = ds;
        gv.DataBind();
        con.Close();//关闭数据库连接
    }

   
    public static void datalistbind(DataList DlName, string str)
    {
        SqlConnection con = constr();
        con.Open();
        try
        {
            DlName.DataSource = GetDataSetStr(str, "cc");
            DlName.DataBind();
        }
        catch (Exception e)
        {
            throw new Exception(e.Message, e);
        }
        finally
        {
            con.Close();
        }

    }

    public static void BindRepter(Repeater rep, string str)
    {
        SqlConnection con = constr();
        con.Open();
        rep.DataSource = GetDataSetStr(str, "cc");
        rep.DataBind();
    }
    public static DataTable GetDataSetStr(string sqlStr, string TableName)
    {
        SqlConnection con = constr();
        con.Open();
        DataSet ds = new DataSet();
        SqlDataAdapter adapt = new SqlDataAdapter(sqlStr, con);
        adapt.Fill(ds, TableName);
        con.Close();
        con.Dispose();
        return ds.Tables[TableName];
    }

    public static SqlCommand GetCommand(string str)
    {
        SqlConnection con = db.constr();
        con.Open();
        SqlCommand cmd = new SqlCommand();
        cmd.Connection = con;
        cmd.CommandType = CommandType.Text;
        cmd.CommandText = str;
        return cmd;
    }

    public static string ExecSelec(string str)
    {
        string SqlStr;
        SqlCommand cmd = db.GetCommand(str);
        SqlStr = Convert.ToString(cmd.ExecuteScalar());
        cmd.Connection.Close();
        cmd.Dispose();
        return SqlStr;
    }

    public static void ExecNonQuery(string str)
    {
        SqlCommand cmd = GetCommand(str);
        cmd.ExecuteNonQuery();
        cmd.Connection.Close();
        cmd.Dispose();
    }
    public void GridViewBind(GridView G, string str)
    {
        SqlConnection con = constr();
        con.Open();
        G.DataSource = GetDataSetStr(str, "table");


        G.DataBind();
    }
    //写一个产生随机数的方法
    public string random(int n)
    {
        string str = "0,1,2,3,4,5,6,7,8,9,0,1,2,3,4,5,6,7,8,9,0,1,2,3,4,5,6,7,8,9,0,1,2,3,4,5,6,7,8,9,0,1,2,3,4,5,6,7,8,9,0,1,2,3,4,5,6,7,8,9,1,2";
        string[] arry = str.Split(',');
        int temp = -1;
        string num = "";
        Random rand = new Random();
        for (int i = 0; i < n; i++)
        {
            if (temp != -1)
            {
                rand = new Random(i * temp * unchecked((int)DateTime.Now.Ticks));

            }
            int r = rand.Next(61);
            if (temp != -1 && temp == r)
            {
                return random(n);
            }
            temp = r;
            num = num + arry[r];

        }
        return num;
    }
    //进行MD5加密
    public string GetMD5(string str)
    {
        return System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(str, "MD5").ToLower();
    }
    public string MessageBox(string str)
    {
        string str1;
        str1 = "<script language='javascript'>alert('" + str + "')</script>";
        Response.Write(str1);
        return str1;
    }
    //截取字符串
    public static string SubString(string str, int lenggth)
    {
        if (str.Length < lenggth)
        {
            return str;
        }
        else
        {
            string str2;
            str2 = str.Substring(0, lenggth).ToString();
            str2 = str2 + "...";
            return str2;
        }
    }

}

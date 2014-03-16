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
using Wuqi.Webdiyer;


/// <summary>
///SqlHelper 的摘要说明
/// </summary>
public class SqlHelper
{
	public SqlHelper()
	{
		//
		//TODO: 在此处添加构造函数逻辑
		//
	}

    //获取连接字符串
    public static string conneectstring = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
    //创建链接
    public static SqlConnection CreateCon()
    {
        return new SqlConnection(conneectstring);
    }
    //执行字符串的一个方法
    public static int ExecuteNonQuery(string sql, params SqlParameter[] parameters)
    {
        using (SqlConnection con = CreateCon())
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.CommandText = sql;
                cmd.Connection = con;
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                return cmd.ExecuteNonQuery();               
            }
        }
    }
    //返回一个datatable的方法
    public static DataTable ExecuteDataTable(string sql, params SqlParameter[] parameters)
    {
        using (SqlConnection con = CreateCon())
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = sql;
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                DataSet dataset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataset);
                return dataset.Tables[0];
            }
        }
    }

    //分页
    public static DataTable ExecuteDataTable(string sql, AspNetPager AspNetPager1, params SqlParameter[] parameters)
    {
        using (SqlConnection con = CreateCon())
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = sql;
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                DataSet dataset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataset, AspNetPager1.PageSize * (AspNetPager1.CurrentPageIndex - 1), AspNetPager1.PageSize, "page");
                return dataset.Tables["page"];
            }
        }
    }
    
    
    //返回一个数据集
    public static DataSet ExecuteDataSet(string sql, params SqlParameter[] parameters)
    {
        using (SqlConnection con = CreateCon())
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = sql;
                cmd.CommandType = CommandType.StoredProcedure;
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                DataSet dataset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataset);
                return dataset;
            }
        }
    }
    public static DataSet ExecuteDataSetsql(string sql, params SqlParameter[] parameters)
    {
        using (SqlConnection con = CreateCon())
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand())
            {
                cmd.Connection = con;
                cmd.CommandText = sql;
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                DataSet dataset = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(dataset);
                return dataset;
            }
        }
    }

    //创建cmd
    public static SqlCommand Command(string sql, params SqlParameter[] parameters)
    {
        using (SqlConnection con = CreateCon())
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(sql, con))
            {
                return cmd;
            }
        }
    }

    //public static DataSet ExecuteDataSet(string sql, params SqlParameter[] parameters)
    //创建一个低级的绑定datalist控件的绑定方法
    //
    //页面就用webform了，简单！！
    //
    public static void DataListBind(DataList DaltID, string str)
    {
        DaltID.DataSource = ExecuteDataTable(str).DefaultView;
        DaltID.DataBind();
    }

    //绑定repeater
    public static void RepeaterBind(Repeater rep, string str)
    {
        rep.DataSource = ExecuteDataTable(str).DefaultView;
        rep.DataBind();
    }


    //获取数据库中的行数
    public static int GetDataCount(string str, params SqlParameter[] parameters)
    {
        using (SqlConnection con = CreateCon())
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(str, con))
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataSet ds=new DataSet();
                sda.Fill(ds, "tb1");
                int count = ds.Tables["tb1"].Rows.Count;
                //if (cmd.ExecuteScalar().ToString() == "") count = -1;
                //count = cmd.ExecuteNonQuery();
                return count;
            }
        }
    }

    ///////admin 中所用的的方法

    public static void GridviewBind(GridView grdview, string str, params SqlParameter[] parameters)
    {
        //DataSet ds = ExecuteDataSetsql(str);
        using (SqlConnection con = CreateCon())
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(str, con))
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                DataSet ds = new DataSet();
                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                adapter.Fill(ds);
                grdview.DataSource = ds;
                grdview.DataBind();
            }
        }
    }

    //分页绑定的方法
    public static void GridViewAspNetPage(string strcount, string str, GridView GrdView)
    {
        using (SqlConnection con = CreateCon())
        {
            con.Open();
            SqlCommand cmd1 = new SqlCommand(strcount, con);

        }
    }

    public static DataSet ExecuteDataSet(string p, Parameter parameter)
    {
        throw new NotImplementedException();
    }

    #region 用方法返回首行、首列,返回类型string
    /// <summary>
    /// 
    /// </summary>
    /// <param name="str"></param>
    /// <param name="parameters"></param>
    /// <returns></returns>
    public static string ExecuteScalar(string str, params SqlParameter[] parameters)
    {
        using (SqlConnection con = CreateCon())
        {
            con.Open();
            using (SqlCommand cmd = new SqlCommand(str, con))
            {
                foreach (SqlParameter parameter in parameters)
                {
                    cmd.Parameters.Add(parameter);
                }
                return Convert.ToString(cmd.ExecuteScalar());
            }
        }
    }
    #endregion

    public static bool Login( string userName, string Pwd)
    {
        string sql = "select * from users where u_name=@userName and u_secret=@Pwd";
        SqlParameter[] para = new SqlParameter[]{
             new SqlParameter("@userName",SqlDbType.NVarChar,30),
             new SqlParameter("@Pwd",SqlDbType.NVarChar,30)
        };
        para[0].Value = userName;
        para[1].Value = Pwd;
        //using (SqlConnection con = CreateCon())
        //{
        //    con.Open();
        //    SqlCommand cmd = new SqlCommand(sql, con);
        //    foreach (SqlParameter parameter in para)
        //    {
        //        cmd.Parameters.Add(parameter);
        //    }
        //    if (cmd.ExecuteScalar().ToString() != null)
        //    {
        //        return true;
        //    }
        //    else { return false; }
        //}
        if (GetDataCount(sql, para) > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
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

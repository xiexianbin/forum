<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DetailNews.aspx.cs" Inherits="admin_news_DetailNews" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<title>无标题页</title>
    <style type="text/css">
        .style1
        {
            width: 91%;
            height: 180px;
        }
        .style2
        {
            color: #FF0000; 
            font-size:medium;
        }
    </style>
</head>
<body style="background-color:ButtonShadow" >
    <form id="form1" runat="server" a>
    <div align="center">
    
        <table cellpadding="0" cellspacing="0" class="style1">
            <tr>
                <td>
                    &nbsp;<%=title %></td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;发表时间：<%=time %> 发表作者：<%=author %></td>
            </tr>
            <tr>
                <td>
                    &nbsp;<%=content %></td>
            </tr>
        </table>
    
    </div>
    </form>
</body>
</html>



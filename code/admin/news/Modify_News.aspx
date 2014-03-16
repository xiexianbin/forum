<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Modify_News.aspx.cs" Inherits="admin_news_Modify_News" %>

<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>双乐科技</title>
    <link href="../../ckeditor/sample.css" rel="stylesheet" type="text/css" />
    <link href="../../ckeditor/contents.css" rel="stylesheet" type="text/css" />
</head>

<body>
    <form id="form1" runat="server">
    <div>
        <table class="style1">
            <tr>
                <td class="style2">
                    新闻标题：
                </td>
                <td>
                    <asp:TextBox ID="TextBox1" runat="server" Width="397px"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="TextBox1"
                        ErrorMessage="*" Style="color: #FF3300; background-color: #FFFFFF"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    作者：
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ControlToValidate="TextBox2"
                        ErrorMessage="*" Style="color: #FF3300"></asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    新闻类型：
                </td>
                <td>
                    <asp:DropDownList ID="DropDownList1" runat="server" Height="19px" Width="147px">
                        <asp:ListItem Value="kynews">考研新闻</asp:ListItem>
                        <asp:ListItem Value="bznews">本站动态</asp:ListItem>
                        <asp:ListItem Value="sugreading">推荐阅读</asp:ListItem>
                        <asp:ListItem Value="wr_years">风雨那些年</asp:ListItem>
                        <asp:ListItem Value="about_us">关于我们</asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    新闻内容：
                </td>
                <td>
                    <ckeditor:ckeditorcontrol id="CKEditor" runat="server" height="350px" width="750px"
                        basepath="../../ckeditor"></ckeditor:ckeditorcontrol>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    备注信息：
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Width="700px"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td class="style2">
                    &nbsp;
                </td>
                <td>
                    <asp:Button ID="Button1" runat="server" BackColor="#CCFF99" BorderStyle="Solid" Text="确认修改"
                        Width="114px" BorderColor="#66CCFF" OnClick="Button1_Click" />&nbsp;&nbsp;
                </td>
            </tr>
        </table>
    </div>
    </form>
</body>
</html>

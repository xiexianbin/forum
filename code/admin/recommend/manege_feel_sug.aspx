<%@ Page Language="C#" AutoEventWireup="true" CodeFile="manege_feel_sug.aspx.cs"
    Inherits="admin_recommend_manege_feel_sug" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link href="../css/comment.css" rel="stylesheet" type="text/css" />
    <title>双乐科技后台</title>
</head>
<body>
    <form id="form1" runat="server">
    <div id="header">
        <li class="headerli">当前位置</li>
        <span class="headerspan">>></span>
        <li class="headerli">管理菜单</li>
        <span class="headerspan">>></span>
        <li class="headerli">分类管理</li>
        <span class="headerspan">>></span>
        <li class="headerlili">情感页超链接管理</li>
    </div>
    <div class="main">
        <div class="main_add">
            <div class="main_ceng">
                <div class="main_t">
                    主题：<asp:TextBox ID="TextBox_title" runat="server" Width="250px"></asp:TextBox>
                </div>
                <div class="main_t">
                    URL：<asp:TextBox ID="TextBox_url" runat="server" Width="250px"></asp:TextBox>
                </div>
            </div>
            <div class="main_ceng">
                <div class="main_t">
                    序号：<asp:TextBox ID="TextBox_num" runat="server" Width="250px"></asp:TextBox>
                </div>
                <div class="main_t">
                    其他：<asp:TextBox ID="TextBox_other" runat="server" Width="250px"></asp:TextBox>
                </div>
            </div>
            <div class="">
                <li class="main_buttom">
                    <asp:Button ID="Button_add" runat="server" Text="增加" OnClick="Button_add_Click" /></li>
                <li class="main_buttom">
                    <asp:Button ID="Button_reset" runat="server" Text="重置" OnClick="Button_reset_Click" /></li></div>
        </div>
        <div class="main_other">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="c_id"
                CellPadding="4" ForeColor="#333333" GridLines="None" OnRowDeleting="GridView_RowDeleting"
                Width="800px">
                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                <Columns>
                    <asp:BoundField DataField="c_title" HeaderText="主题" />
                    <asp:BoundField DataField="c_url" HeaderText="URL" />
                    <asp:BoundField DataField="c_num" HeaderText="序号" />
                    <asp:BoundField DataField="c_other" HeaderText="其他" />
                    <asp:CommandField HeaderText="删除操作" ShowDeleteButton="True" />
                </Columns>
                <EditRowStyle BackColor="#999999" />
                <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                <SortedAscendingCellStyle BackColor="#E9E7E2" />
                <SortedAscendingHeaderStyle BackColor="#506C8C" />
                <SortedDescendingCellStyle BackColor="#FFFDF8" />
                <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
            </asp:GridView>
        </div>
    </div>
    </form>
</body>
</html>

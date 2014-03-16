<%@ Page Language="C#" AutoEventWireup="true" CodeFile="sugreading.aspx.cs" Inherits="admin_news_sugreading" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" CellPadding="4"
            DataKeyNames="n_id" ForeColor="#333333" GridLines="None" 
            OnRowDeleting="GridView1_RowDeleting" Width="800px">
            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
            <Columns>
                <asp:BoundField DataField="n_id" HeaderText="编号" InsertVisible="False" ReadOnly="True"
                    SortExpression="n_id" />
                <asp:BoundField DataField="n_title" HeaderText="新闻标题" SortExpression="n_title" />
                <asp:BoundField DataField="n_time" HeaderText="发表时间" SortExpression="n_time" />
                <asp:BoundField DataField="ad_user" HeaderText="发表作者" SortExpression="ad_user" />
                <asp:BoundField DataField="n_other" HeaderText="备注信息" SortExpression="n_other" />
                <asp:CommandField HeaderText="删除操作" ShowDeleteButton="True" />
                <asp:TemplateField HeaderText="修改操作">
                    <ItemTemplate>
                        <a href="Modify_News.aspx?id=<%# Eval("n_id")%>">修改</a>
                    </ItemTemplate>
                </asp:TemplateField>
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
        <br />
        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="LinkButton1_Click">添加新闻</asp:LinkButton>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" Inherits="admin_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>考研日记后台管理平台_Power_By_双乐科技</title>
    <link rel="stylesheet" type="text/css" href="css/style.css" />
    <script type="text/javascript" src="js/js.js"></script>
</head>
<body>
    <div id="top">
    </div>
    <form id="login" runat="server">
    <div id="bg">
        <div id="login_main">
            <div id="center_left">
            </div>
            <div id="center_middle">
                <div class="user">
                    <div class="user_sec_long">
                        用户名：</div>
                    <div class="user_sec_input_long">
                        <input type="text" name="user" id="user" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ErrorMessage="*"
                            ControlToValidate="user">*</asp:RequiredFieldValidator></div>
                    <div class="user_button">
                        <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Button1_Click" /></div>
                </div>
                <div class="user">
                    <div class="user_sec_long">
                        密 码：</div>
                    <div class="user_sec_input_long">
                        <input type="password" name="pwd" id="pwd" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ErrorMessage="*"
                            ControlToValidate="user">*</asp:RequiredFieldValidator></div>
                    <div class="user_button">
                        <asp:Button ID="Button2" runat="server" Text="重设" /></div>
                </div>
                <div class="user">
                    <div class="user_sec_long">
                        验证码：</div>
                    <div class="user_sec_input_long">
                        <input name="chknumber" type="text" id="chknumber" maxlength="4" class="chknumber_input"
                            runat="server" />
                        <img id="img1" alt="" src="CreatePicture.aspx" runat="server" /></div>
                </div>
            </div>
        </div>
    </div>
    <div id="bottom">
        <li>
            考研日记后台管理系统 备案 豫123456号</li>
        <li>
            双乐科技 技术支持
        </li>
    </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=gb2312" />
    <link rel="stylesheet" type="text/css" href="style/css.css">
    <link rel="stylesheet" type="text/css" href="style/other.css">
    <meta name="keywords" content="考研日记点滴记录您奋斗过的每一天,考研最新动态,考研日记网,有关考研的最新动态,大学生考研日记,双乐科技考研日记,,共享科技乐享生活,双乐科技专注做大学生最需要的网站" />
    <meta name="description" content="考研日记点滴记录您奋斗过的每一天,考研最新动态,考研日记网,有关考研的最新动态,大学生考研日记,双乐科技考研日记,,共享科技乐享生活,双乐科技专注做大学生最需要的网站" />
    <link rel="shortcut icon" href="image/favicon.ico" />
    <title>日记|大学生考研日记|大学生相互鼓励共同奋斗的平台|双乐科技考研日记|考研日记点滴记录您奋斗过的每一天|共享科技乐享生活</title>
    <style type="text/css">
        .style1
        {
            width: 61px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div class="loginheader">
        <div class="t">
            <span><a href="index.aspx">考研日记</a></span>
        </div>
    </div>
    <!--头部结束-->
    <div class="in">
        <dd class="mage">
        </dd>
        <dd class="log">
            <table width="450" border="0" cellspacing="8" cellpadding="0">
                <tr>
                    <td class="style1">
                        <div align="right">
                            用户名：</div>
                    </td>
                    <td width="146">
                        <label>
                            <input id="username" type="text" size="20" runat="server" />
                        </label>
                    </td>
                    <td width="147">
                        <a href="personal/registered.aspx">注册账号？</a>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        <div align="right">
                            密码：</div>
                    </td>
                    <td colspan="2">
                        <label>
                            <input id="secret" type="password" size="20" runat="server" />
                        </label>
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                        &nbsp;
                    </td>
                    <td colspan="2">
                        <asp:Button ID="Button1" runat="server" Text="登录" OnClick="Unnamed1_Click" />
                        <asp:Button ID="Button2" runat="server" Text="清空" />
                    </td>
                </tr>
            </table>
            <dd>
    </div>
    <!--main结束-->
    <div class="bq">
            <ul>
                <li>&copy;2013&nbsp;</li>
                <li><a href="http://www.shuangle.net" target="_blank">&nbsp;双乐科技.</a></li>
                <li class="">&nbsp;&nbsp;All rights reserved. &nbsp; </li>
            </ul>
            <ul>
                <li><a href="http://www.miibeian.gov.cn/" target="_blank">豫 ICP 备 13006843 号-2</a></li>
                <li><a href="http://shuangle.net/Responsibility/about_kyrj_Responsibility.html" target="_blank">
                    &nbsp;免责声明&nbsp;&nbsp;&nbsp;</a></li>
                <li>版权所有&nbsp;&nbsp;违版必究</li></ul>
            <ul>
                <li>联系我们：service@shuangle.net&nbsp;&nbsp;</li>
                <li><a href="tencent://message/?uin=10972072&amp;Site=谢先斌&amp;Menu=yes">QQ：10972072</a></li></ul>
        </div>
    </form>
</body>
</html>

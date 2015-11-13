<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="404.aspx.cs" Inherits="SupportPage._404" %>
<% Response.StatusCode = 404;%>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        Sorry, it seems that this page is unable to find, let met take you <a href="SupportMain.aspx">HOME</a>
    </div>
    </form>
</body>
</html>

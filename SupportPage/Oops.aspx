<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Oops.aspx.cs" Inherits="SupportPage.Oops" MasterPageFile="~/MainSite.Master" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            Oops! An error has occured!
        </div>
        <div>
            <b>I am very sorry for the inconvenience caused to you...<br>
            </b>
        </div>
        <div>
            <asp:Label ID="EXMessage" runat="server" Text="Reason:..."></asp:Label>
        </div>
    </form>
</body>
</html>

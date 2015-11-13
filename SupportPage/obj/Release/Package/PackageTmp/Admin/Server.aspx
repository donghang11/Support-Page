<%@ Page Title="Server" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="Server.aspx.cs" Inherits="SupportPage.Server" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
        </asp:SiteMapPath>
    </div>
    <div>
<%--        <label>You can input the database server name here:</label>
        <asp:TextBox runat="server" ID="ServerText"></asp:TextBox>
                <label>You can input the database user name here:</label>
        <asp:TextBox runat="server" ID="UserId"></asp:TextBox>
                <label>You can input the database password here:</label>
        <asp:TextBox runat="server" ID="Password"></asp:TextBox>
        <asp:Button runat="server" Text="Submit" OnClick="Unnamed_Click"/>--%>
    </div>
</asp:Content>

<%@ Page Title="Home" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="SupportPage.Default" EnableEventValidation="false"%>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
        <div>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
        </asp:SiteMapPath>
    </div>
    <asp:Literal ID="default_welcome" runat="server" Text="<%$ Resources:Default,welcome%>"></asp:Literal>
    <p></p>
    <div class="jumbotron">
        <asp:Label runat="server" Font-Bold="true" Text="What's new"></asp:Label>
    </div>
</asp:Content>

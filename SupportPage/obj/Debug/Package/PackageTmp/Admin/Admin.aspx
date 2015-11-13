<%@ Page Title="Admin" Language="C#" AutoEventWireup="true" CodeBehind="Admin.aspx.cs" Inherits="SupportPage.Admin" MasterPageFile="~/MainSite.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
        </asp:SiteMapPath>
    </div>
    <div class="jumbotron">
        <ul>
            <li><a href="Person.aspx">
                <asp:Literal runat="server" Text="<%$Resources:general, personlist %>"></asp:Literal></a></li>
            <li><a href="Org.aspx">
                <asp:Literal runat="server" Text="<%$Resources:general, departmentlist %>"></asp:Literal></a></li>
            <li><a href="Member.aspx">
                <asp:Literal runat="server" Text="<%$Resources:general, memberlist %>"></asp:Literal></a></li>
            <li><a href="Role.aspx">
                <asp:Literal runat="server" Text="<%$Resources:general, rolelist %>"></asp:Literal></a></li>
            <li><a href="Model.aspx">
                <asp:Literal runat="server" Text="Model list"></asp:Literal></a></li>
        </ul>
    </div>

</asp:Content>

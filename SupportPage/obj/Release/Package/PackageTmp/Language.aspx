<%@ Page Title="Language" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="Language.aspx.cs" Inherits="SupportPage.Language" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <div class="jumbotron">
        <asp:RadioButtonList id="lang" runat="server" RepeatDirection="Vertical">
            <asp:ListItem Value="zh-CN">简体中文</asp:ListItem>
            <asp:ListItem Selected="True" Value="en-US">English</asp:ListItem>
            <asp:ListItem Value="ja-JP">日本語</asp:ListItem>
        </asp:RadioButtonList>
        <asp:Button runat="server" Text="Submit" ID="lang_submit" CssClass="btn btn-default" OnClick="lang_submit_Click"/>
    </div> 
</asp:Content>

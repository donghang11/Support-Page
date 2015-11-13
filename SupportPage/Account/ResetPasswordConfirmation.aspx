<%@ Page Title="Password Reset" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="ResetPasswordConfirmation.aspx.cs" Inherits="SupportPage.Account.ResetPasswordConfirmation" Async="true" %>

<asp:Content runat="server" ID="BodyContent" ContentPlaceHolderID="MainContent">
    <h2><%: Title %>.</h2>
    <div>
        <p>Reset Password Successfully <asp:HyperLink ID="login" runat="server" NavigateUrl="~/Account/Login">Here</asp:HyperLink> To Login </p>
    </div>
</asp:Content>

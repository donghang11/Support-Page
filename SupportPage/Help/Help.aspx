<%@ Page Title="Help" Language="C#" AutoEventWireup="true" CodeBehind="/Help/Help.aspx.cs" Inherits="SupportPage.Help.Help" MasterPageFile="~/MainSite.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Help page...</h3>
    <p></p>
    <%--    <div>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
        </asp:SiteMapPath>
    </div>--%>
    <br />
    <br />
    <ul>
        <li>
            <a href="/Help/Intro.html">Introduction</a> <a href="Video/Intro.swf" style="color: red">video</a>
        </li>
        <li>
            <a href="/Help/Login.html">Logging in</a> <a href="Video/LoggingIn.swf" style="color: red">video</a>
        </li>
        <li>
            <a href="/Help/ResetPassword.html">Reset Password</a> <a href="Video/ResetPass.swf" style="color: red">video</a>
        </li>
        <li>
            <a href="/Help/Support.html">Support </a>
        </li>
        <li>
            <a href="/Help/CaseAdd.html">Adding a new case</a> <a href="Video/AddingNewCase.swf" style="color: red">video</a>
        </li>
        <li>
            <a href="/Help/SolAdd.html">Adding a new solution</a> <a href="Video/AddingNewSolution.swf" style="color: red">video</a>
        </li>
        <li>
            <a href="/Help/FileAdd.html">Adding a new file</a> <a href="Video/AddingNewFile.swf" style="color: red">video</a>
        </li>
        <li>
            <a href="../Instruction.pdf">PDF</a>
        </li>
    </ul>

    <div runat="server" id="HelpAdmin" visible="false">
        For administrator:
        <br />
        <br />

        <ul>
            <li>
                <a href="../Extra Instrucitons for administrator.pdf">Admin</a>
            </li>
        </ul>

    </div>
</asp:Content>

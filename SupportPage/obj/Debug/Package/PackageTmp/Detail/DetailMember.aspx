<%@ Page Title="Member Detail" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="DetailMember.aspx.cs" Inherits="SupportPage.DetailMember" %>

<asp:Content ID="DetailMemberContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>To add a new member</h3>
    <p></p>
    <p></p>

    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <%-- role --%>          
                <asp:Literal runat="server" Text="<%$ Resources:general, role%>"></asp:Literal>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" CssClass="form-control" ID="detailmember_role" DataSourceID="Role" DataTextField="name" DataValueField="id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="Role" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>" SelectCommand="SELECT [id], [name] FROM [trole]"></asp:SqlDataSource>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <%-- org --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, org%>"></asp:Literal>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" CssClass="form-control" ID="detailmember_org" DataSourceID="Org" DataTextField="name" DataValueField="id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="Org" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>" SelectCommand="SELECT [id], [name] FROM [org]"></asp:SqlDataSource>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <%-- start date --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, startdate2%>"></asp:Literal>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Calendar ID="detailmember_startdate" runat="server"></asp:Calendar>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <%-- buttons --%>
    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
            <asp:Button runat="server" CssClass="btn btn-default" Text="<%$ Resources:general, cancel%>" OnClick="Unnamed3_Click"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, submit%>" OnClick="Unnamed4_Click"></asp:Button>
        </div>
    </div>
</asp:Content>

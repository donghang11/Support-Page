<%@ Page Title="Role Detail" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="DetailRole.aspx.cs" Inherits="SupportPage.DetailRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>To add a new Role</h3>
    <p></p>
    <p></p>

    <asp:Table runat="server">
        <%-- name --%>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Literal runat="server" Text="<%$ Resources:general, name%>"></asp:Literal>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox TextMode="SingleLine" runat="server" Width="200px" CssClass="form-control" ID="detailrole_name" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="detailrole_name" CssClass="text-danger" ErrorMessage="Please fill up name" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <%-- description --%>
            <asp:TableCell>
                <asp:Literal runat="server" Text="<%$ Resources:Case, description%>"></asp:Literal>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" CssClass="form-control" TextMode="MultiLine" ID="detailrole_desc" Width="1000px"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="detailrole_desc" CssClass="text-danger" ErrorMessage="Please fill up description" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
            <asp:Button runat="server" CssClass="btn btn-default" Text="<%$ Resources:general, cancel%>" OnClick="Unnamed1_Click1"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, submit%>" OnClick="Unnamed2_Click"></asp:Button>
        </div>
    </div>
</asp:Content>

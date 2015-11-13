<%@ Page Title="Organization Detail" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="DetailOrg.aspx.cs" Inherits="SupportPage.DetailOrg" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>To add a new department</h3>
    <p></p>
    <p></p>

    <%-- name --%>
    <div class="form-group">
        <asp:Literal runat="server" Text="<%$ Resources:general, name%>"></asp:Literal>
        <div class="col-lg-10">
            <asp:TextBox runat="server" CssClass="form-control" ID="detailorg_name" />
        </div>
    </div>

    <%-- description --%>
    <div class="form-group">
        <asp:Literal runat="server" Text="<%$ Resources:Case, description%>"></asp:Literal>
        <div class="col-lg-10">
            <asp:TextBox runat="server" CssClass="form-control" ID="detailorg_desc" />
        </div>
    </div>

    <%-- parent --%>
    <%--    <div class="form-group">
        <label for="select" class="col-lg-2 control-label"><strong>Upper Organization</strong></label>
        <div class="col-lg-10">
            <asp:DropDownList runat="server" CssClass="form-control" ID="detailorg_parent" DataSourceID="DetailOrgUpOrgDropList" DataTextField="name" DataValueField="id">
                <asp:ListItem Enabled="true" Text="None" Selected="True" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="DetailOrgUpOrgDropList" runat="server" ConnectionString="<%$ ConnectionStrings:SupportConnectionString %>" SelectCommand="SELECT [id], [name] FROM [org]"></asp:SqlDataSource>
        </div>
    </div>--%>

    <%-- buttons --%>
    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
            <asp:Button runat="server" CssClass="btn btn-default" Text="<%$ Resources:general, cancel%>" OnClick="Unnamed1_Click"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, submit%>" OnClick="Unnamed2_Click"></asp:Button>
        </div>
    </div>
</asp:Content>

<%@ Page Title="Case Detail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailOrgEdit.aspx.cs" Inherits="SupportPage.DetailOrgEdit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Edit a case</h3>
    <p></p>
    <p></p>

    <div class="form-group">
        <%-- name --%>
        <div class="form-group">
            <label for="displayTitle" class="col-lg-2 control-label"><strong>Name</strong> </label>
            <div class="col-lg-10">
                <asp:TextBox ID="detailorg_edit_name" TextMode="SingleLine" runat="server"></asp:TextBox>
            </div>
        </div>

        <%-- parent --%>
        <div class="form-group">
            <label for="select" class="col-lg-2 control-label"><strong>Upper Organization</strong></label>
            <div class="col-lg-10">
                <asp:DropDownList runat="server" CssClass="form-control" ID="detailorg_edit_parent" DataSourceID="DetailOrgEditParentDropList" DataTextField="name" DataValueField="id" AppendDataBoundItems="false" OnDataBound="detailorg_edit_parent_DataBound">
                    <asp:ListItem Enabled="true" Text="None" Selected="True" Value=""></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="DetailOrgEditParentDropList" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>" SelectCommand="SELECT [id], [name] FROM [org]"></asp:SqlDataSource>
            </div>
        </div>

        <%-- buttons --%>
        <div class="form-group">
            <div class="col-lg-10 col-lg-offset-2">
                <asp:Button runat="server" CssClass="btn btn-default" Text="Cancel" OnClick="DetailOrgEditCancel"></asp:Button>
                <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="DetailOrgEditSubmit"></asp:Button>
            </div>
        </div>        
    </div>

</asp:Content>


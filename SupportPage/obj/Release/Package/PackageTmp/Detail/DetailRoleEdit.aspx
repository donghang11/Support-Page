<%@ Page Title="Role Detail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailRoleEdit.aspx.cs" Inherits="SupportPage.DetailRoleEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <h3>To edit a new Role</h3>
    <p></p>
    <p></p>

    <%-- description --%>
    <div class="form-group">
        <label for="inputTitle" class="col-lg-2 control-label"><strong>Description</strong> </label>
        <div class="col-lg-10">
            <asp:TextBox TextMode="MultiLine" runat="server" CssClass="form-control" ID="detailrole_edit_desc" placeholder="desc" />
        </div>
    </div>

    <%-- note --%>
    <div class="form-group">
        <label for="inputDescription" class="col-lg-2 control-label"><strong>Note</strong></label>
        <div class="col-lg-10">
            <asp:TextBox runat="server" CssClass="form-control" TextMode="MultiLine" ID="detailrole_edit_note"></asp:TextBox>
        </div>
    </div>


    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
            <asp:Button runat="server" CssClass="btn btn-default" Text="Cancel" OnClick="Unnamed1_Click1"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="Unnamed2_Click"></asp:Button>
        </div>
    </div>
</asp:Content>

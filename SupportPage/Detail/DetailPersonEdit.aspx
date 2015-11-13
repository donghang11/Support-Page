<%@ Page Title="Person Detail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailPersonEdit.aspx.cs" Inherits="SupportPage.DetailPersonEdit" %>

<asp:Content ID="DetailPersonEditContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>To add a new person</h3>
    <p></p>
    <p></p>

    <%-- name --%>
    <div class="form-group">
        <label for="inputName" class="col-lg-2 control-label"><strong>Name</strong> </label>
        <div class="col-lg-10">
            <asp:TextBox runat="server" CssClass="form-control" ID="detailperson_edit_name" />
        </div>
    </div>

    <%-- organization --%>
    <div class="form-group">
        <label class="col-lg-2 control-label"><strong>Organization</strong></label>
        <div class="col-lg-10">
            <asp:DropDownList runat="server" CssClass="form-control" ID="detailperson_edit_organization" DataSourceID="Org" DataTextField="name" DataValueField="id">
                <asp:ListItem Enabled="true" Text="None" Selected="True" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="Org" runat="server" ConnectionString="<%$ ConnectionStrings:SupportConnectionString %>" SelectCommand="SELECT [name], [id] FROM [org]"></asp:SqlDataSource>
        </div>
    </div>

    <%-- previous person --%>
    <div class="form-group">
        <label class="col-lg-2 control-label"><strong>Previous Person</strong></label>
        <div class="col-lg-10">
            <asp:DropDownList runat="server" CssClass="form-control" ID="detailperson_edit_prev_person" DataSourceID="PrevPerson" DataTextField="name" DataValueField="id">
                <asp:ListItem Enabled="true" Text="None" Selected="True" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="PrevPerson" runat="server" ConnectionString="<%$ ConnectionStrings:SupportConnectionString %>" SelectCommand="SELECT [name], [id] FROM [Person]"></asp:SqlDataSource>
        </div>
    </div>

    <%-- start date --%>
    <div class="form-group">
        <label for="inputPassword" class="col-lg-2 control-label"><strong>Start Date</strong></label>
        <div class="col-lg-10">
            <asp:Calendar ID="detailperson_edit_startdate" runat="server"></asp:Calendar>
        </div>
    </div>

    <br />

    <%-- end date --%>
    <div class="form-group">
        <label for="inputEndData" class="col-lg-2 control-label"><strong>End Date</strong></label>
        <div class="col-lg-10">
            <asp:Calendar ID="detailperson_edit_enddate" runat="server"></asp:Calendar>
        </div>
    </div>

    <%-- phone number --%>
    <div class="form-group">
        <label for="inputName" class="col-lg-2 control-label"><strong>Phone</strong> </label>
        <div class="col-lg-10">
            <asp:TextBox runat="server" CssClass="form-control" ID="detailperson_edit_phone" TextMode="Phone" />
        </div>
    </div>

    <%-- E-mail --%>
    <div class="form-group">
        <label for="inputName" class="col-lg-2 control-label"><strong>E-mail</strong> </label>
        <div class="col-lg-10">
            <asp:TextBox runat="server" CssClass="form-control" ID="detailperson_edit_email" TextMode="Email" />
        </div>
    </div>

    <%-- buttons --%>
    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
            <asp:Button runat="server" CssClass="btn btn-default" Text="Cancel" OnClick="Unnamed3_Click"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="Unnamed4_Click"></asp:Button>
        </div>
    </div>
</asp:Content>


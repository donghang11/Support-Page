<%@ Page Title="Member Detail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailMemberEdit.aspx.cs" Inherits="SupportPage.DetailMemberEdit" %>

<asp:Content ID="DetailMemberEditContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>To add a new member</h3>
    <p></p>
    <p></p>


    <%-- person --%>
    <div class="form-group">
        <label for="select" class="col-lg-2 control-label"><strong>Person</strong></label>
        <div class="col-lg-10">
            <asp:DropDownList runat="server" CssClass="form-control" ID="detailmember_edit_person" DataSourceID="Person" DataTextField="name" DataValueField="id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="Person" runat="server" ConnectionString="<%$ ConnectionStrings:SupportConnectionString %>" SelectCommand="SELECT [name], [id] FROM [Person]"></asp:SqlDataSource>
        </div>
    </div>

    <%-- role --%>
    <div class="form-group">
        <label for="select" class="col-lg-2 control-label"><strong>Role</strong></label>
        <div class="col-lg-10">
            <asp:DropDownList runat="server" CssClass="form-control" ID="detailmember_edit_role" DataSourceID="Role" DataTextField="descrpition" DataValueField="id">
                <asp:ListItem Enabled="true" Text="None" Selected="True" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="Role" runat="server" ConnectionString="<%$ ConnectionStrings:SupportConnectionString %>" SelectCommand="SELECT [descrpition], [id] FROM [Role]"></asp:SqlDataSource>
        </div>
    </div>


    <%-- case --%>
    <div class="form-group">
        <label for="select" class="col-lg-2 control-label"><strong>Case</strong></label>
        <div class="col-lg-10">
            <asp:DropDownList runat="server" CssClass="form-control" ID="detailmember_edit_case" DataSourceID="Case" DataTextField="sub" DataValueField="id">
            </asp:DropDownList>
            <asp:SqlDataSource ID="Case" runat="server" ConnectionString="<%$ ConnectionStrings:SupportConnectionString %>" SelectCommand="SELECT [sub], [Id] FROM [Incident]"></asp:SqlDataSource>
        </div>
    </div>

    <%-- start date --%>
    <div class="form-group">
        <label for="inputPassword" class="col-lg-2 control-label"><strong>Start Date</strong></label>
        <div class="col-lg-10">
            <asp:Calendar ID="detailmember_edit_startdate" runat="server"></asp:Calendar>
        </div>
    </div>

    <%-- phone number --%>
    <div class="form-group">
        <label for="inputName" class="col-lg-2 control-label"><strong>Phone</strong> </label>
        <div class="col-lg-10">
            <asp:TextBox runat="server" CssClass="form-control" ID="detailmember_edit_phone" TextMode="Phone" />
        </div>
    </div>

    <%-- E-mail --%>
    <div class="form-group">
        <label for="inputName" class="col-lg-2 control-label"><strong>E-mail</strong> </label>
        <div class="col-lg-10">
            <asp:TextBox runat="server" CssClass="form-control" ID="detailmember_edit_email" TextMode="Email" />
        </div>
    </div>


    <br />

    <%-- end date --%>
    <div class="form-group">
        <label for="inputEndData" class="col-lg-2 control-label"><strong>End Date</strong></label>
        <div class="col-lg-10">
            <asp:Calendar ID="detailmember_edit_enddate" runat="server"></asp:Calendar>
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

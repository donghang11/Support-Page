<%@ Page Title="Case Detail" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailCaseEdit.aspx.cs" Inherits="SupportPage.DetailCaseEdit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Edit a case</h3>
    <p></p>
    <p></p>

    <%-- title --%>
    <div class="form-group">
        <label for="displayTitle" class="col-lg-2 control-label"><strong>Title</strong> </label>
        <div class="col-lg-10">
            <asp:TextBox ID="detailcase_edit_title" runat="server" TextMode="SingleLine"></asp:TextBox>
        </div>
    </div>

    <%-- start date --%>
    <div class="form-group">
        <label for="inputPassword" class="col-lg-2 control-label"><strong>Start Date</strong></label>
        <div class="col-lg-10">
            <asp:Calendar ID="detailcase_edit_startdate" runat="server"></asp:Calendar>
        </div>
    </div>
    <br />

    <%-- end date --%>
    <div class="form-group">
        <label for="inputEndData" class="col-lg-2 control-label"><strong>End Date</strong></label>
        <div class="col-lg-10">
            <asp:Calendar ID="detailcase_edit_enddate" runat="server"></asp:Calendar>
        </div>
    </div>

    <%-- description --%>
    <div class="form-group">
        <label for="inputDescription" class="col-lg-2 control-label"><strong>Description</strong></label>
        <div class="col-lg-10">
            <asp:TextBox CssClass="form-control" Rows="6" TextMode="MultiLine" ID="detailcase_edit_desc" runat="server"></asp:TextBox>
        </div>
    </div>

    <%-- note --%>
    <div class="form-group">
        <label for="inputDescription" class="col-lg-2 control-label"><strong>Note</strong></label>
        <div class="col-lg-10">
            <asp:TextBox CssClass="form-control" Rows="6" TextMode="MultiLine" ID="detailcase_edit_note" runat="server"></asp:TextBox>
        </div>
    </div>

    <%-- drafter --%>
    <div class="form-group">
        <label for="select" class="col-lg-2 control-label"><strong>Drafter</strong></label>
        <div class="col-lg-10">
            <asp:DropDownList runat="server" CssClass="form-control" ID="detailcase_edit_drafter" DataTextField="name" DataValueField="id" DataSourceID="DetailCaseEditDropDrafter">
                <asp:ListItem Enabled="true" Text="None" Selected="True" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="DetailCaseEditDropDrafter" runat="server" ConnectionString="<%$ ConnectionStrings:SupportConnectionString %>" SelectCommand="SELECT [name], [id] FROM [Person]"></asp:SqlDataSource>
        </div>
    </div>

    <%-- handler --%>
    <div class="form-group">
        <label for="select" class="col-lg-2 control-label"><strong>Handler</strong></label>
        <div class="col-lg-10">
            <asp:DropDownList runat="server" CssClass="form-control" ID="detailcase_edit_handler" DataSourceID="DetailCaseEditDropHandler" DataTextField="name" DataValueField="id">
                <asp:ListItem Enabled="true" Text="None" Selected="True" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="DetailCaseEditDropHandler" runat="server" ConnectionString="<%$ ConnectionStrings:SupportConnectionString %>" SelectCommand="select m.id, p.name from Person p, member m where p.id = m.person"></asp:SqlDataSource>
        </div>
    </div>

    <%-- parent --%>
    <div class="form-group">
        <label for="select" class="col-lg-2 control-label"><strong>Parent</strong></label>
        <div class="col-lg-10">
            <asp:DropDownList runat="server" CssClass="form-control" ID="detailcase_edit_parent" DataSourceID="DetailCaseEditDropParent" DataTextField="sub" DataValueField="Id">
                <asp:ListItem Enabled="true" Text="None" Selected="True" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="DetailCaseEditDropParent" runat="server" ConnectionString="<%$ ConnectionStrings:SupportConnectionString %>" SelectCommand="SELECT [Id], [sub] FROM [Incident]"></asp:SqlDataSource>
        </div>
    </div>

    <%-- buttons cancel and submit --%>
    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
            <asp:Button runat="server" CssClass="btn btn-default" Text="Cancel" OnClick="DetailCaseEditCancel"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="DetailCaseEditSubmit"></asp:Button>
        </div>
    </div>

</asp:Content>


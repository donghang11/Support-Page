<%@ Page Title="Case Action" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailActionEdit.aspx.cs" Inherits="SupportPage.DetailActionEdit" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <%-- name --%>
    <div class="form-group">
        <label for="inputTitle" class="col-lg-2 control-label"><strong>Name</strong> </label>
        <div class="col-lg-10">
            <asp:TextBox runat="server" CssClass="form-control" ID="detailaction_edit_name" />
        </div>
    </div>

    <%-- date --%>
    <div class="form-group">
        <label class="col-lg-2 control-label"><strong>Date</strong></label>
        <div class="col-lg-10">
            <asp:Calendar ID="detailaction_edit_date" runat="server"></asp:Calendar>
        </div>
    </div>
    <br />

    <%-- description --%>
    <div class="form-group">
        <label for="inputDescription" class="col-lg-2 control-label"><strong>Description</strong></label>
        <div class="col-lg-10">
            <asp:TextBox CssClass="form-control" TextMode="MultiLine" runat="server" ID="detailaction_edit_desc"></asp:TextBox>
        </div>
    </div>

    <%-- note --%>
    <div class="form-group">
        <label class="col-lg-2 control-label"><strong>Note</strong></label>
        <div class="col-lg-10">
            <asp:TextBox runat="server" CssClass="form-control" TextMode="MultiLine" ID="detailaction_edit_note"></asp:TextBox>
        </div>
    </div>

    <%-- sender --%>
    <div class="form-group">
        <label for="select" class="col-lg-2 control-label"><strong>Sender</strong></label>
        <div class="col-lg-10">
            <asp:DropDownList runat="server" CssClass="form-control" ID="detailaction_edit_sender" DataSourceID="DetailActionDrop" DataTextField="name" DataValueField="id" AutoPostBack="false">
                <asp:ListItem Enabled="true" Text="None" Selected="True" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="DetailActionDrop" runat="server" ConnectionString="<%$ ConnectionStrings:SupportConnectionString %>" SelectCommand="SELECT p.name, m.id FROM Member AS m INNER JOIN Person AS p ON m.person = p.id"></asp:SqlDataSource>
        </div>
    </div>

    <%-- receiver --%>
    <div class="form-group">
        <label for="select" class="col-lg-2 control-label"><strong>Receiver</strong></label>
        <div class="col-lg-10">
            <asp:DropDownList runat="server" CssClass="form-control" ID="detailaction_edit_receiver" DataSourceID="DetailActionReceiverDrop" DataTextField="name" DataValueField="id">
                <asp:ListItem Enabled="true" Text="None" Selected="True" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="DetailActionReceiverDrop" runat="server" ConnectionString="<%$ ConnectionStrings:SupportConnectionString %>" SelectCommand="SELECT p.name, m.id FROM Member AS m INNER JOIN Person AS p ON m.person = p.id"></asp:SqlDataSource>
        </div>
    </div>

    <%-- incident --%>
    <div class="form-group">
        <label for="select" class="col-lg-2 control-label"><strong>Case</strong></label>
        <div class="col-lg-10">
            <asp:DropDownList runat="server" CssClass="form-control" ID="detailaction_edit_case" DataSourceID="DetailActionCaseDrop" DataTextField="sub" DataValueField="id">
                <asp:ListItem Enabled="true" Text="None" Selected="True" Value=""></asp:ListItem>
            </asp:DropDownList>
            <asp:SqlDataSource ID="DetailActionCaseDrop" runat="server" ConnectionString="<%$ ConnectionStrings:SupportConnectionString %>" SelectCommand="SELECT [Id], [sub] FROM [Incident]"></asp:SqlDataSource>
        </div>
    </div>

    <%-- buttons --%>
    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
            <asp:Button runat="server" CssClass="btn btn-default" Text="Cancel" OnClick="Unnamed2_Click"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="Submit" OnClick="Unnamed3_Click"></asp:Button>
        </div>
    </div>
</asp:Content>

<%@ Page Title="Person Detail" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="DetailPerson.aspx.cs" Inherits="SupportPage.DetailPerson" %>

<asp:Content ID="DetailPersonContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>To add a new person</h3>
    <p></p>
    <p></p>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css">
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>

    <table runat="server">
        <tr>
            <td>
                <br />
                <%-- last name --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, lastname%>"></asp:Literal>
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="detailperson_lastname" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="detailperson_lastname" CssClass="text-danger" ErrorMessage="Please fill up last name" />
            </td>
        </tr>
        <tr>
            <td>
                <%-- first name --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, firstname%>"></asp:Literal>
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="detailperson_firstname" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="detailperson_firstname" CssClass="text-danger" ErrorMessage="Please fill up first name" />
            </td>
        </tr>
        <tr>
            <td>
                <%-- start date --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, startdate%>"></asp:Literal>
                <br />
            </td>
            <td>
                <%--<asp:Calendar ID="detailperson_startdate" runat="server" ></asp:Calendar>--%>
                <asp:TextBox runat="server" ID="detailperson_startdate"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="detailperson_startdate" CssClass="text-danger" ErrorMessage="Please fill up start date" />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <%-- phone number --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, phonenumber%>"></asp:Literal>
            </td>
            <td>
                <br />
                <asp:TextBox runat="server" CssClass="form-control" ID="detailperson_phone" TextMode="Phone" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="detailperson_phone" CssClass="text-danger" ErrorMessage="Please fill up phone number" />
            </td>
        </tr>
        <tr>
            <td>
                <%-- E-mail --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, email%>"></asp:Literal>
            </td>
            <td>
                <asp:TextBox runat="server" CssClass="form-control" ID="detailperson_email" TextMode="Email" />
                <asp:RequiredFieldValidator runat="server" ControlToValidate="detailperson_email" CssClass="text-danger" ErrorMessage="Please fill up E-mail" />
            </td>
        </tr>
    </table>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=detailperson_startdate.ClientID%>").datepicker({
                changeMonth: true,
                changeYear: true
            });
        });
    </script>


    <%-- buttons --%>
    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
            <asp:Button runat="server" CssClass="btn btn-default" Text="<%$ Resources:general, cancel%>" OnClick="Unnamed3_Click"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, submit%>" OnClick="Unnamed4_Click"></asp:Button>
        </div>
    </div>
</asp:Content>


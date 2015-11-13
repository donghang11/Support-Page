<%@ Page Title="Member Detail" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="DetailMember.aspx.cs" Inherits="SupportPage.DetailMember" %>

<asp:Content ID="DetailMemberContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>To add a new member</h3>
    <p></p>
    <p></p>

    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css">
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>

    <script type="text/javascript">
        $(document).ready(function () {
            $("#<%=detailmember_startdate.ClientID%>").datepicker({
                 changeMonth: true,
                 changeYear: true
             });
         });
    </script>

    <table runat="server">
        <tr>
            <td>
                <br />
                <%-- role --%>          
                <asp:Literal runat="server" Text="<%$ Resources:general, role%>"></asp:Literal>
                <br />
            </td>
            <td>
                <br />
                <asp:DropDownList runat="server" CssClass="form-control" ID="detailmember_role" Width="300" DataSourceID="Role" DataTextField="name" DataValueField="id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="Role" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>" SelectCommand="SELECT [id], [name] FROM [trole]"></asp:SqlDataSource>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <%-- org --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, org%>"></asp:Literal>
                <br />
            </td>
            <td>
                <br />
                <asp:DropDownList runat="server" CssClass="form-control" ID="detailmember_org" Width="300" DataSourceID="Org" DataTextField="name" DataValueField="id">
                </asp:DropDownList>
                <asp:SqlDataSource ID="Org" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>" SelectCommand="SELECT [id], [name] FROM [org]"></asp:SqlDataSource>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <%-- start date --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, startdate2%>"></asp:Literal>
                <br />
            </td>
            <td>
                <br />
                <asp:TextBox runat="server" CssClass="form-control" ID="detailmember_startdate"></asp:TextBox>
                <asp:RequiredFieldValidator runat="server" ControlToValidate="detailmember_startdate" CssClass="text-danger" ErrorMessage="Please fill up start date" />
                <br />
            </td>
        </tr>
    </table>



    <%-- buttons --%>
    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
            <asp:Button runat="server" CssClass="btn btn-default" Text="<%$ Resources:general, cancel%>" OnClick="Unnamed3_Click"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, submit%>" OnClick="Unnamed4_Click"></asp:Button>
        </div>
    </div>
</asp:Content>

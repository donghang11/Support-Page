<%@ Page Title="Person Detail" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="DetailPerson.aspx.cs" Inherits="SupportPage.DetailPerson" %>

<asp:Content ID="DetailPersonContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>To add a new person</h3>
    <p></p>
    <p></p>
    <link rel="stylesheet" href="http://code.jquery.com/ui/1.11.0/themes/smoothness/jquery-ui.css">
    <script src="http://code.jquery.com/jquery-1.10.2.js"></script>
    <script src="http://code.jquery.com/ui/1.11.0/jquery-ui.js"></script>

    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <%-- last name --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, lastname%>"></asp:Literal>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" CssClass="form-control" ID="detailperson_lastname" />
                
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <%-- first name --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, firstname%>"></asp:Literal>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" CssClass="form-control" ID="detailperson_firstname" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <%-- start date --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, startdate%>"></asp:Literal>
            </asp:TableCell>
            <asp:TableCell>
                <%--<asp:Calendar ID="detailperson_startdate" runat="server" ></asp:Calendar>--%>
                <asp:TextBox runat="server" ID="detailperson_startdate"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <%-- phone number --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, phonenumber%>"></asp:Literal>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" CssClass="form-control" ID="detailperson_phone" TextMode="Phone" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <%-- E-mail --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, email%>"></asp:Literal>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" CssClass="form-control" ID="detailperson_email" TextMode="Email" />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

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


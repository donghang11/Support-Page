<%@ Page Title="Case Detail" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="DetailMember2.aspx.cs" Inherits="SupportPage.DetailMember2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Detail of a member</h3>
    <p></p>
    <p></p>

    <%-- buttons back, edit, submit and cancel --%>
    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
            <asp:Button ID="detailmember2_btn_back" runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, back%>" OnClick="detailmember2_btn_back_Click"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, edit%>" OnClick="Unnamed_Click"></asp:Button>
            <asp:Button runat="server" ID="detailmember2_submit" CssClass="btn btn-primary" Text="<%$ Resources:general, submit%>" Visible="false" OnClick="detailmember2_submit_Click"></asp:Button>
            <asp:Button runat="server" ID="detailmember2_cancel" CssClass="btn btn-primary" Text="<%$ Resources:general, cancel%>" Visible="false" OnClick="detailmember2_cancel_Click"></asp:Button>
            <div style="text-align: right">
                <asp:DropDownList runat="server" ID="detailmember2_active" CssClass="btn btn-default dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="detailmember2_active_SelectedIndexChanged">
                    <asp:ListItem Text="<%$ Resources:general, active%>" Value="0"></asp:ListItem>
                    <asp:ListItem Text="<%$ Resources:general, deactive%>" Value="1"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button runat="server" ID="detailMember2_delete" CssClass="btn btn-primary" Text="<%$ Resources:general, delete%>" BackColor="Red" Visible="true" OnClientClick="return confirmation();" OnClick="detailMember2_delete_Click"></asp:Button>
            </div>
        </div>
    </div>


    <%-- function for deleting alert --%>
    <script type="text/javascript">
        function confirmation() {
            if (confirm('are you sure you want to delete ?')) {
                return true;
            } else {
                return false;
            }
        }
    </script>
    <asp:Table BorderColor="LightBlue" BorderStyle="Ridge" runat="server" Width="600">
        <asp:TableRow>
            <asp:TableCell>
        <%-- last name --%>
               <asp:Label runat="server" Text="<%$ Resources:general, lastname%>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <div class="col-lg-10">
                    <asp:Label ID="detailmember2_lastname" runat="server" Width="200"></asp:Label>
                </div>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <%-- first name --%>
                        <asp:Label runat="server" Text="<%$ Resources:general, firstname%>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <div class="col-lg-10">
                    <asp:Label ID="detailmember2_firstname" runat="server"></asp:Label>
                </div>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <%-- start date --%>
                   <asp:Label runat="server" Text="<%$ Resources:general, startdate%>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <div class="col-lg-10">
                    <asp:Label ID="detailmember2_start_date" runat="server"></asp:Label>
                </div>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>    
                <%-- role --%>
        <asp:Label runat="server" Text="<%$ Resources:general, role%>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <div>
                    <asp:Label CssClass="form-control" ID="detailmember2_role" runat="server"></asp:Label>
                </div>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <%-- org --%>
                   <asp:Label runat="server" Text="<%$ Resources:general, org%>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <div>
                    <asp:Label CssClass="form-control" ID="detailmember2_org" runat="server"></asp:Label>
                </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

<%@ Page Title="Case Detail" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="DetailPerson2.aspx.cs" Inherits="SupportPage.DetailPerson2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Detail of a person</h3>
    <p></p>
    <p></p>

    <%-- buttons back, edit, submit and cancel --%>
    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
            <asp:Button ID="detailperson2_btn_back" runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, back%>" OnClick="detailperson2_btn_back_Click"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, edit%>" OnClick="Unnamed1_Click"></asp:Button>
            <asp:Button runat="server" ID="detailperson2_submit" CssClass="btn btn-primary" Text="<%$ Resources:general, submit%>" Visible="false" OnClick="detailperson2_submit_Click"></asp:Button>
            <asp:Button runat="server" ID="detailperson2_cancel" CssClass="btn btn-primary" Text="<%$ Resources:general, cancel%>" Visible="false" OnClick="detailperson2_cancel_Click"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, setmember%>" Visible="true" OnClick="Unnamed_Click"></asp:Button>
            <div style="text-align: right; margin-right:250px">
                <asp:DropDownList runat="server" ID="detailperson2_active" CssClass="btn btn-default dropdown-toggle" OnSelectedIndexChanged="detailperson2_active_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="active" Value="0"></asp:ListItem>
                    <asp:ListItem Text="deactive" Value="1"></asp:ListItem>
                </asp:DropDownList>
                <asp:Button runat="server" ID="detailperson2_delete" CssClass="btn btn-primary" Text="<%$ Resources:general, delete%>" BackColor="Red" Visible="true" OnClientClick="return confirmation();" OnClick="detailperson2_delete_Click"></asp:Button>
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
    <asp:Table runat="server" BorderStyle="Ridge" BorderColor="LightBlue" Width="1000">
        <asp:TableRow>
            <asp:TableCell>
                <%-- last name --%>
                <asp:Label runat="server" Text="<%$ Resources:general, lastname%>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <div class="col-lg-10">
                    <asp:TextBox TextMode="SingleLine" Width="100" ID="detailperson2_lastname" runat="server" ReadOnly="true"></asp:TextBox>
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
                    <asp:TextBox ID="detailperson2_firstname" TextMode="SingleLine" Width="100" runat="server" ReadOnly="true"></asp:TextBox>
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
                    <asp:Label ID="detailperson2_start_date" runat="server"></asp:Label>
                </div>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <%-- phone number --%>
                <asp:Label runat="server" Text="<%$ Resources:general, phonenumber%>"></asp:Label>     

            </asp:TableCell>
            <asp:TableCell>
                <div class="col-lg-10">
                    <asp:TextBox TextMode="SingleLine" Width="200" runat="server" CssClass="form-control" ID="detailperson2_phone" ReadOnly="true" />
                </div>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <%-- E-mail --%>
                <asp:Label runat="server" Text="<%$ Resources:general, email%>"></asp:Label>  

            </asp:TableCell>
            <asp:TableCell>
                <div class="col-lg-10">
                    <asp:TextBox TextMode="SingleLine" Width="200" runat="server" CssClass="form-control" ID="detailperson2_email" ReadOnly="true" />
                </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

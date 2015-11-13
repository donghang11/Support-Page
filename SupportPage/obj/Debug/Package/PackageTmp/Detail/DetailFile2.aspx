<%@ Page Title="Case Detail" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="DetailFile2.aspx.cs" Inherits="SupportPage.DetailFile2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
<%--    <div>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
        </asp:SiteMapPath>
    </div>--%>

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

    <table>
        <tr>
            <td>
                <%-- name --%>
                <asp:Label runat="server" Text="<%$ Resources:general, name%>"></asp:Label>
            </td>            
            <td>
                <asp:TextBox ID="detailfile2_name" runat="server" CssClass="form-control" ReadOnly="false" Width="250" AutoPostBack="true" OnTextChanged="detailfile2_name_TextChanged"></asp:TextBox>
            </td>
        </tr>

        <tr>
            <td>
                <%-- case --%>
                <asp:Label runat="server" Text="<%$ Resources:Case, case_name%>"></asp:Label>
            </td>
            <td>
                <asp:Label ID="detailfile2_case" runat="server" CssClass="form-control" Width="500"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <%-- path --%>
                <asp:Label runat="server" Text="<%$ Resources:general, path%>"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="detailfile2_path" runat="server" CssClass="form-control" AutoPostBack="true" ReadOnly="false" Width="500" OnTextChanged="detailfile2_path_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <%-- sender --%>
                <asp:Label runat="server" Text="<%$ Resources:general, sender%>"></asp:Label>
            </td>
            <td>
                <asp:Label CssClass="form-control" ID="detailfile2_sender" runat="server" Width="300"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <%-- note --%>
                <asp:Label runat="server" Text="<%$ Resources:general, note%>"></asp:Label>
            </td>
            <td>
                <asp:TextBox CssClass="form-control" ID="detailfile2_note" TextMode="MultiLine" Width="500" AutoPostBack="true" runat="server" ReadOnly="false" OnTextChanged="detailfile2_note_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td>
                <%-- date --%>
                <asp:Label runat="server" Text="<%$ Resources:general, date%>"></asp:Label>
            </td>
            <td>
                <asp:Label CssClass="form-control" ID="detailfile2_date" runat="server"></asp:Label>
            </td>
        </tr>
    </table>
    <div style="text-align: right; margin-right: 250px">
        <asp:Button runat="server" ID="detailafile2_delete" CssClass="btn btn-primary" Text="<%$ Resources:general, delete%>" BackColor="Red" Visible="true" OnClientClick="return confirmation();" OnClick="detailafile2_delete_Click"></asp:Button>
    </div>
</asp:Content>

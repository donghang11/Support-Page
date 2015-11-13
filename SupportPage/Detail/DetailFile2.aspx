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
    <div style="text-align: left">
        <asp:Button runat="server" ID="Button1" CssClass="btn btn-primary" Text="BACK" Visible="true" OnClick="Button1_Click"></asp:Button>
    </div>
    <table>
        <tr>
            <td>
                <br />
                <%-- name --%>
                <asp:Label runat="server" Text="<%$ Resources:general, name%>" Font-Bold="true" ForeColor="#8C4510"></asp:Label>
                <br />
            </td>
            <td>
                <br />
                <asp:TextBox ID="detailfile2_name" runat="server" CssClass="form-control" ReadOnly="false" Width="250" AutoPostBack="true" OnTextChanged="detailfile2_name_TextChanged"></asp:TextBox>
                <br />
            </td>
        </tr>

        <tr>
            <td>
                <br />
                <%-- case --%>
                <br />
                <asp:Label runat="server" Text="<%$ Resources:Case, case_name%>" Font-Bold="true" ForeColor="#8C4510"></asp:Label>
                <br />
            </td>
            <td>
                <br />
                <asp:Label ID="detailfile2_case" runat="server"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <%-- path --%>
                <asp:Label runat="server" Text="<%$ Resources:general, path%>" Font-Bold="true" ForeColor="#8C4510"></asp:Label>
                <br />
            </td>
            <td>
                <br />
                <asp:TextBox ID="detailfile2_path" runat="server" CssClass="form-control" AutoPostBack="true" ReadOnly="false" Width="500" OnTextChanged="detailfile2_path_TextChanged"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <%-- sender --%>
                <asp:Label runat="server" Text="<%$ Resources:general, sender%>" Font-Bold="true" ForeColor="#8C4510"></asp:Label>
                <br />
            </td>
            <td>
                <br />
                <asp:Label CssClass="form-control" ID="detailfile2_sender" runat="server" Width="300"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <%-- note --%>
                <asp:Label runat="server" Text="<%$ Resources:general, note%>" Font-Bold="true" ForeColor="#8C4510"></asp:Label>
                <br />
            </td>
            <td>
                <br />
                <asp:TextBox CssClass="form-control" ID="detailfile2_note" TextMode="MultiLine" Width="500" AutoPostBack="true" runat="server" ReadOnly="false" OnTextChanged="detailfile2_note_TextChanged"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <%-- date --%>
                <asp:Label runat="server" Text="<%$ Resources:general, date%>" Font-Bold="true" ForeColor="#8C4510"></asp:Label>
                <br />
            </td>
            <td>
                <br />
                <asp:Label ID="detailfile2_date" runat="server"></asp:Label>
                <br />
            </td>
        </tr>
    </table>
    <div style="text-align: right; margin-right: 250px">
        <asp:Button runat="server" ID="detailafile2_delete" CssClass="btn btn-primary" Text="<%$ Resources:general, delete%>" BackColor="Red" Visible="true" OnClientClick="return confirmation();" OnClick="detailafile2_delete_Click"></asp:Button>
    </div>
</asp:Content>

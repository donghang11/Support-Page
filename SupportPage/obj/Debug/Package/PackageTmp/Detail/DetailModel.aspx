<%@ Page Title="Model detail" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="DetailModel.aspx.cs" Inherits="SupportPage.DetailModel" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Detail of a department</h3>
    <p></p>
    <div>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
        </asp:SiteMapPath>
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

    <style type="text/css">
        .select {
            border: none;
            -webkit-appearance: none;
        }
    </style>

    <table>
        <%-- interface --%>
        <tr>
            <td>
                <asp:Label runat="server" Text="interface"></asp:Label>
            </td>
            <td>
                <asp:DropDownList ID="detailmodel_interface" AutoPostBack="true" runat="server" CssClass="select" ForeColor="Blue" BorderStyle="None" OnSelectedIndexChanged="detailmodel_interface_SelectedIndexChanged">
                    <asp:ListItem Text="--Interface--" Value="-1"></asp:ListItem>
                    <asp:ListItem Text="GigE" Value="1"></asp:ListItem>
                    <asp:ListItem Text="USB2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="USB3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Camera Link" Value="4"></asp:ListItem>
                    <asp:ListItem Text="DVI/SDI" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Analog" Value="6"></asp:ListItem>
                    <asp:ListItem Text="TV Format" Value="7"></asp:ListItem>
                    <asp:ListItem Text="Industry" Value="8"></asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
        <%-- cord --%>
        <tr>
            <td>
                <asp:Label runat="server" Text="cord"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="detailmodel_cord" runat="server" TextMode="SingleLine" Width="200" ReadOnly="false" AutoPostBack="true" OnTextChanged="detailmodel_cord_TextChanged"></asp:TextBox>
            </td>
        </tr>
        <%-- name --%>
        <tr>
            <td>
                <asp:Label runat="server" Text="name"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="detailmodel_name" runat="server" TextMode="SingleLine" Width="500" ReadOnly="false" AutoPostBack="true" OnTextChanged="detailmodel_name_TextChanged"></asp:TextBox>
            </td>
        </tr>
    </table>
    <div style="text-align: right">
        <asp:Button runat="server" ID="detailmodel_delete" CssClass="btn btn-primary" Text="<%$ Resources:general, delete%>" BackColor="Red" Visible="true" OnClientClick="return confirmation();" OnClick="detailmodel_delete_Click"></asp:Button>
    </div>
</asp:Content>

<%@ Page Title="Add Case" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="DetailCase.aspx.cs" Inherits="SupportPage.DetailCase" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <table>
        <tr>
            <td>
                <%-- interface --%>
                <asp:Label runat="server" Width="200" Text="<%$ Resources:Case, interface_name%>"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="detailcase_interface"></asp:TextBox>
                <br />
            </td>
            <td>
                <%-- customer name --%>
                <asp:Label runat="server" Width="200" Text="<%$ Resources:Case, cusname%>"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="detailcase_cusname"></asp:TextBox>
                <br />
            </td>
            <td>
                <%-- distrabutor company --%>
                <asp:Label runat="server" Width="200" Text="<%$ Resources:Case, discom%>"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="detailcase_discom"></asp:TextBox>
                <br />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <%-- description --%>
                <asp:Label runat="server" Width="200" Text="<%$ Resources:Case, description%>"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="detailcase_desc" Width="600" Rows="4" TextMode="MultiLine"></asp:TextBox>
                <br />
                <br />
            </td>
        </tr>
    </table>
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell VerticalAlign="Top">
                <%-- sales --%>
                <asp:Label runat="server" Width="200" Text="<%$ Resources:Case, inform_sales%>"></asp:Label>
                <asp:DropDownList runat="server" CssClass="form-control" ID="detailcase_sales" Width="200">
                    <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                    <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                    <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                </asp:DropDownList>
                <br />
            </asp:TableCell>
            <asp:TableCell VerticalAlign="Top">
                <%-- faq --%>
                <asp:Label runat="server" Width="200" Text="<%$ Resources:Case, change_faq%>"></asp:Label>
                <asp:DropDownList runat="server" Width="200" CssClass="form-control" ID="detailcase_faq">
                    <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                    <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                    <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                </asp:DropDownList>
                <br />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <%-- support team --%>
                <asp:Label runat="server" Width="200" Text="<%$ Resources:Case, inform_support%>"></asp:Label>
                <asp:DropDownList Width="200" runat="server" CssClass="form-control" ID="detailcase_supportteam">
                    <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                    <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                    <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                </asp:DropDownList>
                <br />
            </asp:TableCell>
            <asp:TableCell>
                <%-- instruction --%>
                <asp:Label runat="server" Width="200" Text="<%$ Resources:Case, change_instruction%>"></asp:Label>
                <asp:DropDownList runat="server" Width="200" CssClass="form-control" ID="detailcase_inst">
                    <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                    <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                    <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                </asp:DropDownList>
                <br />
            </asp:TableCell>

        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <%-- technote --%>
                <asp:Label runat="server" Width="200" Text="<%$ Resources:Case, change_technote%>"></asp:Label>
                <asp:DropDownList runat="server" Width="200" CssClass="form-control" ID="detailcase_teahnote">
                    <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                    <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                    <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                </asp:DropDownList>
                <br />
            </asp:TableCell>
            <asp:TableCell>
                <%-- all company --%>
                <asp:Label runat="server" Width="200" Text="<%$ Resources:Case, inform_allcompany%>"></asp:Label>
                <asp:DropDownList runat="server" Width="200" CssClass="form-control" ID="detailcase_allcompany">
                    <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                    <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                    <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                </asp:DropDownList>
                <br />
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <%-- handler --%>
                <asp:Label runat="server" Width="200" Text="<%$ Resources:Case, handler%>"></asp:Label>
                <asp:DropDownList runat="server" Width="200" CssClass="form-control" ID="detailcase_handler" DataTextField="name" DataValueField="id" DataSourceID="SqlDataSource1">
                    <asp:ListItem Enabled="true" Text="<%$ Resources:general, none%>" Selected="True" Value=""></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:PersonnelConnectionString %>" SelectCommand="select m.id, p.lastname+p.firstname + '(' + o.name + ')' as name from person p join member m on p.id = m.person join org o on m.org = o.id"></asp:SqlDataSource>
                <br />
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    <table>
        <tr>
            <td>
                <%-- other --%>
                <asp:Label runat="server" Width="200" Text="<%$ Resources:Case, other%>"></asp:Label>
                <asp:TextBox runat="server" CssClass="form-control" ID="detailcase_other" Width="600" Rows="4" TextMode="MultiLine"></asp:TextBox>
                <br />
            </td>
        </tr>
    </table>

    <%-- buttons cancel and submit --%>
    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
            <asp:Button runat="server" CssClass="btn btn-default" Text="<%$ Resources:general, cancel%>" OnClick="Unnamed1_Click"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, submit%>" OnClick="Unnamed4_Click"></asp:Button>
        </div>
    </div>
</asp:Content>

<%@ Page Title="Case Detail" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="DetailMember2.aspx.cs" Inherits="SupportPage.DetailMember2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Detail of a member</h3>
    <p></p>
    <p></p>

    <%-- buttons back, edit, submit and cancel --%>
    <div class="form-group">
            <table style="width: 1000px">
                <tr>
                    <td>
                        <div style="text-align: left"">
                            <asp:Button ID="detailmember2_btn_back" runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, back%>" OnClick="detailmember2_btn_back_Click"></asp:Button>
                            <%--<asp:Button runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, edit%>" OnClick="Unnamed_Click"></asp:Button>
            <asp:Button runat="server" ID="detailmember2_submit" CssClass="btn btn-primary" Text="<%$ Resources:general, submit%>" Visible="false" OnClick="detailmember2_submit_Click"></asp:Button>
            <asp:Button runat="server" ID="detailmember2_cancel" CssClass="btn btn-primary" Text="<%$ Resources:general, cancel%>" Visible="false" OnClick="detailmember2_cancel_Click"></asp:Button>--%>
                        </div>
                    </td>
                    <td>
                        <div style="text-align: right; margin-right:250px">
                            <asp:DropDownList runat="server" ID="detailmember2_active" CssClass="btn btn-default dropdown-toggle" AutoPostBack="true" OnSelectedIndexChanged="detailmember2_active_SelectedIndexChanged">
                                <asp:ListItem Text="<%$ Resources:general, active%>" Value="0"></asp:ListItem>
                                <asp:ListItem Text="<%$ Resources:general, deactive%>" Value="1"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </td>
                </tr>
            </table>
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
        <table>
            <tr>
                <td style="width:100px">
                    <br />
                    <%-- last name --%>
                    <asp:Label runat="server" Font-Bold="true" ForeColor="#8C4510" Text="<%$ Resources:general, lastname%>"></asp:Label>
                    <br />
                </td>
                <td>
                    <br />
                    <asp:Label ID="detailmember2_lastname" runat="server"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <%-- first name --%>
                    <asp:Label runat="server" Font-Bold="true" ForeColor="#8C4510" Text="<%$ Resources:general, firstname%>"></asp:Label>
                    <br />
                </td>
                <td>
                    <br />
                    <asp:Label ID="detailmember2_firstname" runat="server"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <%-- start date --%>
                    <asp:Label runat="server" Font-Bold="true" ForeColor="#8C4510" Text="<%$ Resources:general, startdate%>"></asp:Label>
                    <br />
                </td>
                <td>
                    <br />
                    <asp:Label ID="detailmember2_start_date" runat="server"></asp:Label>
                    <br />
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <%-- role --%>
                    <asp:Label runat="server" Font-Bold="true" ForeColor="#8C4510" Text="<%$ Resources:general, role%>"></asp:Label>
                    <br />
                </td>
                <td>
                    <div>
                        <br />
                        <asp:DropDownList runat="server" CssClass="form-control" AutoPostBack="true" ID="detailmember2_role" Width="300" DataSourceID="Role" DataTextField="name" DataValueField="id" OnSelectedIndexChanged="detailmember2_role_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="Role" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>" SelectCommand="SELECT [id], [name] FROM [trole]"></asp:SqlDataSource>
                        <br />
                    </div>
                </td>
            </tr>
            <tr>
                <td>
                    <br />
                    <%-- org --%>
                    <asp:Label runat="server" Font-Bold="true" ForeColor="#8C4510" Text="<%$ Resources:general, org%>"></asp:Label>
                    <br />
                </td>
                <td>
                    <div>
                        <br />
                        <asp:DropDownList runat="server" CssClass="form-control" AutoPostBack="true" ID="detailmember2_org" Width="300" DataSourceID="Org" DataTextField="name" DataValueField="id" OnSelectedIndexChanged="detailmember2_org_SelectedIndexChanged">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="Org" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>" SelectCommand="SELECT [id], [name] FROM [org]"></asp:SqlDataSource>
                        <br />
                    </div>
                </td>
            </tr>
        </table>
        <div style="text-align: right">
            <asp:Button runat="server" ID="Button1" CssClass="btn btn-primary" Text="<%$ Resources:general, delete%>" BackColor="Red" Visible="true" OnClientClick="return confirmation();" OnClick="detailMember2_delete_Click"></asp:Button>
        </div>
</asp:Content>

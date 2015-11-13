<%@ Page Title="Case Detail" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="DetailPerson2.aspx.cs" Inherits="SupportPage.DetailPerson2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Detail of a person</h3>
    <p></p>
    <p></p>

    <%-- buttons back, edit, submit and cancel --%>
    <div class="form-group">
        <table style="width:1000px">
            <tr>
                <td>
                    <div style="text-align: left; margin-right: 250px">
                        <asp:Button ID="detailperson2_btn_back" runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, back%>" OnClick="detailperson2_btn_back_Click"></asp:Button>
                        <%-- <asp:Button runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, edit%>" OnClick="Unnamed1_Click"></asp:Button>
            <asp:Button runat="server" ID="detailperson2_submit" CssClass="btn btn-primary" Text="<%$ Resources:general, submit%>" Visible="false" OnClick="detailperson2_submit_Click"></asp:Button>
            <asp:Button runat="server" ID="detailperson2_cancel" CssClass="btn btn-primary" Text="<%$ Resources:general, cancel%>" Visible="false" OnClick="detailperson2_cancel_Click"></asp:Button>--%>
                        <asp:Button runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, setmember%>" Visible="true" OnClick="Unnamed_Click"></asp:Button>
                    </div>
                </td>
                <td>
                    <div style="text-align: right">
                        <asp:DropDownList runat="server" ID="detailperson2_active" CssClass="btn btn-default dropdown-toggle" OnSelectedIndexChanged="detailperson2_active_SelectedIndexChanged" AutoPostBack="true">
                            <asp:ListItem Text="active" Value="0"></asp:ListItem>
                            <asp:ListItem Text="deactive" Value="1"></asp:ListItem>
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
                <asp:TextBox TextMode="SingleLine" Width="200" CssClass="form-control" AutoPostBack="true" ID="detailperson2_lastname" runat="server" ReadOnly="false" OnTextChanged="detailperson2_lastname_TextChanged"></asp:TextBox>
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
                <asp:TextBox ID="detailperson2_firstname" CssClass="form-control" TextMode="SingleLine" AutoPostBack="true" Width="200" runat="server" ReadOnly="false" OnTextChanged="detailperson2_firstname_TextChanged"></asp:TextBox>
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
                <asp:Label ID="detailperson2_start_date" runat="server"></asp:Label>
                <br />
            </td>
        </tr>

        <tr>
            <td>
                <br />
                <%-- phone number --%>
                <asp:Label runat="server" Font-Bold="true" ForeColor="#8C4510" Text="<%$ Resources:general, phonenumber%>"></asp:Label>
                <br />
            </td>
            <td>
                <br />
                <asp:TextBox TextMode="SingleLine" Width="200" runat="server" AutoPostBack="true" CssClass="form-control" ID="detailperson2_phone" ReadOnly="false" OnTextChanged="detailperson2_phone_TextChanged" />
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <%-- E-mail --%>
                <asp:Label runat="server" Font-Bold="true" ForeColor="#8C4510" Text="<%$ Resources:general, email%>"></asp:Label>
                <br />
            </td>
            <td>
                <br />
                <asp:TextBox TextMode="SingleLine" Width="200" runat="server" AutoPostBack="true" CssClass="form-control" ID="detailperson2_email" ReadOnly="false" OnTextChanged="detailperson2_email_TextChanged" />
                <br />
            </td>
        </tr>
    </table>
    <div style="text-align: right">
        <asp:Button runat="server" ID="Button1" CssClass="btn btn-primary" Text="<%$ Resources:general, delete%>" BackColor="Red" Visible="true" OnClientClick="return confirmation();" OnClick="detailperson2_delete_Click"></asp:Button>
    </div>

</asp:Content>

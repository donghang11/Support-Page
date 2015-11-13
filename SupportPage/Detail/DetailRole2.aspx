<%@ Page Title="Case Detail" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="DetailRole2.aspx.cs" Inherits="SupportPage.DetailRole2" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Detail of a role</h3>
    <p></p>
    <p></p>
    <%-- buttons: back, edit, submit, cancel --%>
    <div style="text-align: left; margin-right: 250px">
        <asp:Button ID="detailrole2_back" runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, back%>" OnClick="detailcase2_btn_back_Click"></asp:Button>
        <%--<asp:Button runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, edit%>" OnClick="Unnamed1_Click"></asp:Button>
        <asp:Button runat="server" ID="detailrole2_submit" CssClass="btn btn-primary" Text="<%$ Resources:general, submit%>" OnClick="Unnamed_Click" Visible="false"></asp:Button>
        <asp:Button runat="server" ID="detailrole2_cancel" CssClass="btn btn-primary" Text="<%$ Resources:general, cancel%>" OnClick="detailrole2_cancel_Click" Visible="false"></asp:Button>--%>
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
            <td>
                <br />
                <%-- name --%>
                <asp:Label runat="server" Text="<%$ Resources:general, name%>"></asp:Label>
                <br />
            </td>
            <td>
                <br />
                <asp:TextBox CssClass="form-control" ID="detailrole2_name" runat="server" ReadOnly="false" TextMode="SingleLine" AutoPostBack="true" OnTextChanged="detailrole2_name_TextChanged"></asp:TextBox>
                <br />
            </td>
        </tr>
        <tr>
            <td>
                <br />
                <%-- description --%>
                <asp:Label runat="server" Text="<%$ Resources:Case, description%>"></asp:Label>
                <br />
            </td>
            <td>
                <br />
                <asp:TextBox CssClass="form-control" TextMode="MultiLine" ID="detailrole2_description" ReadOnly="false" AutoPostBack="true" Width="1000px" runat="server" OnTextChanged="detailrole2_description_TextChanged"></asp:TextBox>
                <br />
            </td>
        </tr>
    </table>


    <%-- member list --%>
    <asp:Label runat="server" Text="<%$ Resources:default, member%>" Font-Bold="true"></asp:Label>
    <asp:GridView ID="detailrole2_member_gridview" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover " PageSize="5" AllowPaging="True" ShowHeader="False" AllowSorting="True" DataSourceID="MemberDataSource" DataKeyNames="id" EmptyDataText="There is no member available now." OnRowCommand="detailrole2_member_gridview_RowCommand" OnRowDataBound="detailrole2_member_gridview_RowDataBound">
        <Columns>
            <asp:TemplateField ShowHeader="False" Visible="False">
                <ItemTemplate>
                    <asp:LinkButton ID="DetailRoleMemberDBClick" runat="server" CausesValidation="false" CommandName="DoubleClick" Text="DoubleClick" CommandArgument='<%# Eval("id") %>' OnClientClick="document.forms[0].target ='_blank';"></asp:LinkButton>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" InsertVisible="False" ReadOnly="True" />
            <asp:BoundField DataField="Column1" HeaderText="Column1" SortExpression="Column1" ReadOnly="True" />
            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="MemberDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>"
        SelectCommand="SELECT m.id, p.lastname + p.firstname, r.name FROM member m left join person p on m.person = p.id left join trole r on m.role = r.id WHERE m.role = @id">
        <SelectParameters>
            <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
        </SelectParameters>
    </asp:SqlDataSource>

    <div style="text-align: right">
        <asp:Button runat="server" ID="detailrole2_delete" CssClass="btn btn-primary" Text="<%$ Resources:general, delete%>" BackColor="Red" Visible="true" OnClientClick="return confirmation();" OnClick="detailrole2_delete_Click"></asp:Button>
    </div>
</asp:Content>

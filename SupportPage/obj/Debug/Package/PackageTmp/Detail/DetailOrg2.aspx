<%@ Page Title="Department Detail" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="DetailOrg2.aspx.cs" Inherits="SupportPage.DetailOrg2" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h3>Detail of a department</h3>
    <p></p>
    <p></p>
    <%-- buttons back, edit, submit and cancel --%>
    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
            <asp:Button ID="detailorg2_btn_back" runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, back%>" OnClick="detailorg2_btn_back_Click"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, edit%>" OnClick="Unnamed_Click"></asp:Button>
            <asp:Button runat="server" ID="detailorg2_submit" CssClass="btn btn-primary" Text="<%$ Resources:general, submit%>" Visible="false" OnClick="detailorg2_submit_Click"></asp:Button>
            <asp:Button runat="server" ID="detailorg2_cancel" CssClass="btn btn-primary" Text="<%$ Resources:general, cancel%>" Visible="false" OnClick="detailorg2_cancel_Click"></asp:Button>
            <asp:Button runat="server" ID="detailorg2_addchild" CssClass="btn btn-primary" Text="<%$ Resources:general, addchild%>" OnClick="detailorg2_addchild_Click"></asp:Button>
            <div style="text-align: right">
                <asp:Button runat="server" ID="detailorg2_delete" CssClass="btn btn-primary" Text="<%$ Resources:general, delete%>" BackColor="Red" Visible="true" OnClientClick="return confirmation();" OnClick="detailorg2_delete_Click"></asp:Button>
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

    <asp:Table runat="server">
        <%-- name --%>
        <asp:TableRow>
            <asp:TableCell>
        <asp:Label runat="server" Text="<%$ Resources:general, name%>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="detailorg2_name" runat="server" TextMode="SingleLine" Width="200" ReadOnly="true"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <%-- description --%>
        <asp:TableRow>
            <asp:TableCell>
        <asp:Label runat="server" Text="<%$ Resources:Case, description%>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="detailorg2_desc" runat="server" TextMode="MultiLine" Width="500" ReadOnly="true"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <%-- parent --%>
        <asp:TableRow>
            <asp:TableCell>
        <asp:Label runat="server" Text="<%$ Resources:Case, parent%>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="detailorg2_parent" runat="server" TextMode="SingleLine" Width="200" ReadOnly="true"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>

        <%-- member list --%>
        <asp:TableRow>
            <asp:TableCell>
    <asp:Label runat="server" Text="<%$ Resources:default, member%>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:GridView ID="detailorg2_member_gridview" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover " PageSize="5" AllowPaging="True" ShowHeader="False" AllowSorting="True" DataSourceID="MemberDataSource" DataKeyNames="id" EmptyDataText="There is no member available now." OnRowCommand="detailorg2_member_gridview_RowCommand" OnRowDataBound="detailorg2_member_gridview_RowDataBound">
                    <Columns>
                        <asp:TemplateField ShowHeader="False" Visible="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="DetailOrgMemberDBClick" runat="server" CausesValidation="false" CommandName="DoubleClick" Text="DoubleClick" CommandArgument='<%# Eval("id") %>' OnClientClick="document.forms[0].target ='_blank';"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" InsertVisible="False" ReadOnly="True" />
                        <asp:BoundField DataField="Column1" HeaderText="Column1" SortExpression="Column1" ReadOnly="True" />
                        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="MemberDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>"
                    SelectCommand="SELECT m.id, p.lastname + p.firstname, r.name FROM member m left join person p on m.person = p.id left join trole r on m.role = r.id WHERE m.org = @id">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
</asp:Content>

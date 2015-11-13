<%@ Page Title="Action Detail" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="DetailAction2.aspx.cs" Inherits="SupportPage.DetailAction2" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
        </asp:SiteMapPath>
    </div>

    <style type="text/css">
        .select {
            border: none;
            -webkit-appearance: none;
        }
    </style>

    <%-- buttons back, edit, submit and cancel 
    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
            <asp:Button ID="detailaction2_btn_back" runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, back%>" OnClick="detailaction2_btn_back_Click"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, edit%>" OnClick="Unnamed_Click"></asp:Button>
            <asp:Button runat="server" ID="detailaction2_submit" CssClass="btn btn-primary" Text="<%$ Resources:general, submit%>" Visible="false" OnClick="detailaction2_submit_Click"></asp:Button>
            <asp:Button runat="server" ID="detailaction2_cancel" CssClass="btn btn-primary" Text="<%$ Resources:general, cancel%>" Visible="false" OnClick="detailaction2_cancel_Click"></asp:Button>
            <div style="text-align: right">
                <asp:Button runat="server" ID="detailaction2_delete" CssClass="btn btn-primary" Text="<%$ Resources:general, delete%>" BackColor="Red" Visible="true" OnClientClick="return confirmation();" OnClick="detailaction2_delete_Click"></asp:Button>
            </div>
        </div>
    </div>
    --%>

    <%-- do not resize --%>
    <style type="text/css">
        textarea {
            resize: none;
        }
    </style>

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
                <%-- case --%>
                <asp:Label runat="server" Text="<%$ Resources:Case, case_name%>"  Font-Bold="true" ForeColor="#8C4510"></asp:Label>
                <br />
            </td>
            <td>
                <br />
                <asp:Label ID="detailaction2_case" runat="server"></asp:Label>
                <br />
            </td>
        </tr>
        <tr>
            <td  style="width:100px">
                <br />
                <%-- date --%>
                <asp:Label runat="server" Text="<%$ Resources:general, date%>" Font-Bold="true" ForeColor="#8C4510"></asp:Label>
                <br />
            </td>
            <td>
                <br />
                <asp:Label ID="detailaction2_date" runat="server"></asp:Label>
                <br />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td  style="width:100px">
                <br />
                <%-- sender --%>
                <asp:Label runat="server" Text="<%$ Resources:general, sender%>" Font-Bold="true" ForeColor="#8C4510"></asp:Label>
                <br />
            </td>
            <td>
                <br />
                <asp:DropDownList ID="detailaction2_sender" CssClass="select" runat="server" AutoPostBack="True" BorderStyle="None" Width="200px" DataSourceID="HandlerSqlDataSource" DataTextField="name" DataValueField="id" OnSelectedIndexChanged="detailAction2_sender_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Text="--sender--" Value=""></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="HandlerSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>" SelectCommand="select m.id, p.lastname+p.firstname + '(' + o.name + ')' as name from person p join member m on p.id = m.person join org o on m.org = o.id"></asp:SqlDataSource>
                <br />
            </td>
        </tr>
        <tr>
            <td  style="width:100px">
                <br />
                <%-- receiver --%>
                <asp:Label runat="server" Text="<%$ Resources:general, receiver%>"  Font-Bold="true" ForeColor="#8C4510"></asp:Label>
                <br />
            </td>
            <td>
                <br />
                <asp:TextBox CssClass="form-control" ID="detailaction2_receiver" runat="server" Width="300" OnTextChanged="detailaction2_receiver_TextChanged" AutoPostBack="True"></asp:TextBox>
                <br />
            </td>
        </tr>
    </table>
    <table>
        <tr>
            <td>
                <asp:Label runat="server" Text="<%$ Resources:Case, description%>"  Font-Bold="true" ForeColor="#8C4510"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <%-- description --%>
                <asp:TextBox ID="detailaction2_desc" runat="server" TextMode="MultiLine" Rows="10" Width="1000" CssClass="form-control" ReadOnly="false" OnTextChanged="detailaction2_desc_TextChanged" AutoPostBack="True"></asp:TextBox>
            </td>
        </tr>
    </table>

    <table style="width: 1000px">
        <tr>
            <td>
                <%-- file list --%>
                <div>
                    <asp:Label runat="server" Font-Bold="true" ForeColor="#8C4510" Text="<%$Resources:Case, file %>"></asp:Label>
                    <asp:ImageButton ID="detailaction2_addfile" CssClass="btn btn-primary" runat="server" BackColor="Transparent" BorderStyle="None" ImageUrl="~/Images/plus_mark2.png" AlternateText="ADD" OnClick="detailaction2_addfile_Click" />
                </div>
                <asp:GridView ID="detailaction2_file_gridview" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover " GridLines="None" PageSize="2" AllowPaging="True" AllowSorting="True" DataSourceID="FileDataSource" DataKeyNames="id" EmptyDataText="There is no file available now." BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2" OnRowDataBound="detailaction2_file_gridview_RowDataBound">
                    <Columns>
                        <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" InsertVisible="False" ReadOnly="True" Visible="true" />
                        <asp:BoundField DataField="fpath" HeaderText="path" SortExpression="fpath" />
                        <asp:BoundField DataField="sender" HeaderText="sender" SortExpression="sender" />
                        <asp:BoundField DataField="note" HeaderText="note" SortExpression="note" />
                        <asp:BoundField DataField="dt" HeaderText="date" SortExpression="dt" DataFormatString="{0:MM/dd/yyyy}" />
                    </Columns>
                    <FooterStyle BackColor="#F7DFB5" ForeColor="#8C4510" />
                    <HeaderStyle BackColor="#A55129" Font-Bold="True" ForeColor="White" />
                    <PagerStyle ForeColor="#8C4510" HorizontalAlign="Center" />
                    <RowStyle BackColor="#FFF7E7" ForeColor="#8C4510" />
                    <SelectedRowStyle BackColor="#738A9C" Font-Bold="True" ForeColor="White" />
                    <SortedAscendingCellStyle BackColor="#FFF1D4" />
                    <SortedAscendingHeaderStyle BackColor="#B95C30" />
                    <SortedDescendingCellStyle BackColor="#F1E5CE" />
                    <SortedDescendingHeaderStyle BackColor="#93451F" />
                </asp:GridView>
                <asp:SqlDataSource ID="FileDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>"
                    SelectCommand="SELECT name, id, fpath, sender, note, dt FROM Files f WHERE f.action = @id">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="id" QueryStringField="id" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>

    <div style="text-align: right">
        <asp:Button runat="server" ID="Button1" CssClass="btn btn-primary" Text="<%$ Resources:general, delete%>" BackColor="Red" Visible="true" OnClientClick="return confirmation();" OnClick="detailaction2_delete_Click"></asp:Button>
    </div>
</asp:Content>

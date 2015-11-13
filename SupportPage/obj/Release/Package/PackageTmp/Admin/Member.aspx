<%@ Page Title="Member" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="Member.aspx.cs" Inherits="SupportPage.Member" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
        </asp:SiteMapPath>
    </div>
    <div>
        <ul class="nav nav-pills">
            <li>
                <div style="text-align: right">
                    <asp:DropDownList runat="server" ID="Member_pageSize" CssClass="btn btn-default dropdown-toggle" OnSelectedIndexChanged="Member_pageSize_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Selected="True" Text="10" Value="10"></asp:ListItem>
                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                        <asp:ListItem Text="100" Value="100"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
        </ul>
    </div>
    <%-- show active --%>
    <asp:CheckBox runat="server" Text="<%$Resources:general, showonlyactive %>" Checked="false" ID="MemberShowOnlyActive" AutoPostBack="true" OnCheckedChanged="MemberShowOnlyActive_CheckedChanged" />

    <div>
        <asp:GridView ID="member_gridview" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover " AllowPaging="True" AllowSorting="True" DataSourceID="MemberDataSource" DataKeyNames="id" OnRowCommand="member_gridview_RowCommand" OnRowDataBound="member_gridview_RowDataBound">
            <Columns>
                <asp:TemplateField ShowHeader="False" Visible="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="MemberDoubleClick" runat="server" CausesValidation="false" CommandName="DoubleClick" Text="DoubleClick" CommandArgument='<%# Eval("id") %>' OnClientClick="document.forms[0].target ='_blank';"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" InsertVisible="False" ReadOnly="True" Visible="false" />
                <asp:BoundField DataField="lastname" HeaderText="<%$Resources:general, lastname %>" SortExpression="lastname" />
                <asp:BoundField DataField="firstname" HeaderText="<%$Resources:general, firstname %>" SortExpression="firstname" />
                <asp:BoundField DataField="name" HeaderText="<%$Resources:general, role %>" SortExpression="name" />
                <asp:BoundField DataField="name1" HeaderText="<%$Resources:general, org %>" SortExpression="name1" />

            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="MemberDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>" SelectCommand="select m.id, p.lastname, p.firstname, r.name, o.name from Member m left join Person p on m.person = p.id left join trole r on m.role = r.id left join Org o on m.org = o.id"
            DeleteCommand="DELETE FROM [Member] Where Id = @ID">
            <DeleteParameters>
                <asp:Parameter Name="ID" />
            </DeleteParameters>
        </asp:SqlDataSource>
    </div>

</asp:Content>

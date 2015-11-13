<%@ Page Title="Role" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="Role.aspx.cs" Inherits="SupportPage.Role" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
        </asp:SiteMapPath>
    </div>
    <div>
        <ul class="nav nav-pills">
            <li>
                <asp:Button ID="role_but_add" runat="server" Text="<%$Resources:general, add%>" CssClass="btn btn-primary" OnClick="role_but_add_Click" />
            </li>
            <li>
                <div style="text-align: right">
                    <asp:DropDownList runat="server" ID="Role_pageSize" CssClass="btn btn-default dropdown-toggle" OnSelectedIndexChanged="Role_pageSize_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Selected="True" Text="10" Value="10"></asp:ListItem>
                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                        <asp:ListItem Text="100" Value="100"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
        </ul>
    </div>
    <div>
        <asp:GridView ID="role_gridview" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover " AllowPaging="True" AllowSorting="True" DataSourceID="RoleDataSource" DataKeyNames="id" OnRowDataBound="role_gridview_RowDataBound" OnRowCommand="role_gridview_RowCommand">
            <Columns>
                <asp:TemplateField ShowHeader="False" Visible="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="RoleDoubleClick" runat="server" CausesValidation="false" CommandName="DoubleClick" Text="DoubleClick" CommandArgument='<%# Eval("id") %>' OnClientClick="document.forms[0].target ='_blank';"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" ReadOnly="True" InsertVisible="False" Visible="false" />
                <asp:BoundField DataField="name" HeaderText="<%$Resources:general, name%>" SortExpression="name" />
                <asp:BoundField DataField="description" HeaderText="<%$Resources:Case, description%>" SortExpression="description" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="RoleDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>" SelectCommand="SELECT [id], [name], [description] FROM [trole]"></asp:SqlDataSource>
    </div>
</asp:Content>

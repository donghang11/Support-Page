<%@ Page Title="Department" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="Model.aspx.cs" Inherits="SupportPage.Model" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
        </asp:SiteMapPath>
    </div>
    <div>
        <ul class="nav nav-pills">
            <li>
                <asp:Button ID="model_but_add" runat="server" Text="<%$Resources:general, add %>" CssClass="btn btn-primary" OnClick="model_but_add_Click" />
            </li>
            <li>
                <div style="text-align: right">
                    <asp:DropDownList runat="server" ID="Model_pageSize" CssClass="btn btn-default dropdown-toggle" OnSelectedIndexChanged="Model_pageSize_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Selected="True" Text="100" Value="100"></asp:ListItem>
                        <asp:ListItem Text="200" Value="200"></asp:ListItem>
                        <asp:ListItem Text="500" Value="500"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
        </ul>
    </div>
    <div>
        <asp:GridView ID="model_gridview" runat="server" AutoGenerateColumns="False" PageSize="100" CssClass="table table-striped table-hover " AllowPaging="True" AllowSorting="True" DataKeyNames="id" DataSourceID="ModelDataSource" OnRowCommand="Model_gridview_RowCommand" OnRowDataBound="Model_gridview_RowDataBound">
            <Columns>
                <asp:TemplateField ShowHeader="False" Visible="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="ModelDoubleClick" runat="server" CausesValidation="false" CommandName="DoubleClick" Text="DoubleClick" CommandArgument='<%# Eval("id") %>' OnClientClick="document.forms[0].target ='_blank';"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" ReadOnly="True" InsertVisible="False" Visible="false" />
                <asp:TemplateField HeaderText="Interface" SortExpression="interface">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%#Bind("interface") %>'>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Image runat="server" ID="Image1" ImageUrl='<%# Eval("interface","~/Images/l{0}.jpg") %>'/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="cord" HeaderText="Cord" SortExpression="cord" />
                <asp:BoundField DataField="name" HeaderText="<%$Resources:general, name %>" SortExpression="name" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="ModelDataSource" runat="server" ConnectionString="<%$ ConnectionStrings: Support %>" SelectCommand="SELECT [id], [interface], [cord], [name] FROM [model]"></asp:SqlDataSource>
    </div>

</asp:Content>

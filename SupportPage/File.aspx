<%@ Page Title="File" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="File.aspx.cs" Inherits="SupportPage.File" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>These are the files available for the cases.</h3>
    <p></p>
    <div>
        <ul class="nav nav-pills">
            <li>
                <div style="text-align: right">
                    <asp:DropDownList runat="server" ID="File_pageSize" CssClass="btn btn-default dropdown-toggle" OnSelectedIndexChanged="File_pageSize_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Selected="True" Text="10" Value="10"></asp:ListItem>
                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                        <asp:ListItem Text="100" Value="100"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
        </ul>
    </div>
    <div class="jumbotron">
        <asp:GridView ID="File_gridview" runat="server" AutoGenerateColumns="False" PageSize="10" CssClass="table table-striped table-hover " AllowPaging="True" AllowSorting="True" DataSourceID="FileDataSource" DataKeyNames="id" OnRowCommand="File_gridview_RowCommand" OnRowDataBound="File_gridview_RowDataBound">
            <Columns>
                <asp:TemplateField ShowHeader="False" Visible="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="FileDoubleClick" runat="server" CausesValidation="false" CommandName="DoubleClick" Text="DoubleClick" CommandArgument='<%# Eval("id") %>' OnClientClick="document.forms[0].target ='_blank';"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" ReadOnly="True" InsertVisible="False" />
                <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                <asp:BoundField DataField="incident" HeaderText="incident" SortExpression="incident" />
                <asp:BoundField DataField="sender" HeaderText="sender" SortExpression="sender" />
                <asp:BoundField DataField="fpath" HeaderText="path" SortExpression="path" />
                <asp:BoundField DataField="note" HeaderText="note" SortExpression="note" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="FileDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:SupportConnectionString %>"
            SelectCommand="SELECT * FROM [Files]"></asp:SqlDataSource>
    </div>

</asp:Content>

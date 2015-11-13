<%@ Page Title="Method" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Action.aspx.cs" Inherits="SupportPage.Action" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2><%: Title %>.</h2>
    <h3>These are the solutions available to handle varied cases.</h3>
    <p></p>
    <div>
        <ul class="nav nav-pills">
            <li>
                <asp:Button ID="act_but_generate_xml_file" runat="server" CssClass="btn btn-primary" Text="Generate XML file" />
            </li>
            <li>
                <div style="text-align: right">
                    <asp:DropDownList runat="server" ID="Action_pageSize" CssClass="btn btn-default dropdown-toggle" OnSelectedIndexChanged="Action_pageSize_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Selected="True" Text="10" Value="10"></asp:ListItem>
                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                        <asp:ListItem Text="100" Value="100"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
        </ul>
    </div>
    <div class="jumbotron">
        <asp:GridView ID="Action_gridview" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover " AllowPaging="True" AllowSorting="True" DataSourceID="ActionDataSource" OnRowCommand="Action_gridview_RowCommand" OnRowDataBound="Action_gridview_RowDataBound">
            <Columns>
                <asp:TemplateField ShowHeader="False" Visible="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="ActionDoubleClick" runat="server" CausesValidation="false" CommandName="DoubleClick" Text="DoubleClick" CommandArgument='<%# Eval("id") %>' OnClientClick="document.forms[0].target ='_blank';"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" ReadOnly="True" InsertVisible="False" />
                <asp:BoundField DataField="dt" HeaderText="dt" SortExpression="dt" Visible="false" />
                <asp:BoundField DataField="incident" HeaderText="incident" SortExpression="incident" />
                <asp:BoundField DataField="sender" HeaderText="sender" SortExpression="sender" Visible="false" />
                <asp:BoundField DataField="receiver" HeaderText="receiver" SortExpression="receiver" Visible="false" />
                <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="ActionDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:SupportConnectionString %>"
            SelectCommand="SELECT * FROM [Action]"></asp:SqlDataSource>
    </div>

</asp:Content>

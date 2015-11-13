<%@ Page Title="Person" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="Person.aspx.cs" Inherits="SupportPage.Person" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
        </asp:SiteMapPath>
    </div>
    <div>
        <ul class="nav nav-pills">
            <li>
                <asp:Button ID="person_but_add" runat="server" Text="<%$Resources:general, add %>" CssClass="btn btn-primary" OnClick="person_but_add_Click" />
            </li>
            <li>
                <div style="text-align: right">
                    <asp:DropDownList runat="server" ID="Person_pageSize" CssClass="btn btn-default dropdown-toggle" OnSelectedIndexChanged="Person_pageSize_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Selected="True" Text="10" Value="10"></asp:ListItem>
                        <asp:ListItem Text="20" Value="20"></asp:ListItem>
                        <asp:ListItem Text="100" Value="100"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
        </ul>
    </div>

    <%-- show active --%>
    <asp:CheckBox runat="server" ForeColor="#008CBA" Text="<%$Resources: general, showonlyactive %>" Checked="false" ID="PersonShowOnlyActive" AutoPostBack="true" OnCheckedChanged="PersonShowOnlyActive_CheckedChanged" />

    <div>
        <asp:GridView ID="person_gridview" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover " OnSelectedIndexChanged="person_gridview_SelectedIndexChanged" AllowPaging="True" AllowSorting="True" DataKeyNames="id" DataSourceID="PersonDataSource" OnRowCommand="person_gridview_RowCommand" OnRowDataBound="person_gridview_RowDataBound">
            <Columns>
                <asp:TemplateField ShowHeader="False" Visible="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="PersonDoubleClick" runat="server" CausesValidation="false" CommandName="DoubleClick" Text="DoubleClick" CommandArgument='<%# Eval("id") %>' OnClientClick="document.forms[0].target ='_blank';"></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" InsertVisible="False" ReadOnly="True" Visible="true" />
                <asp:BoundField DataField="lastname" HeaderText="<%$Resources:general, lastname %>" SortExpression="lastname" />
                <asp:BoundField DataField="firstname" HeaderText="<%$Resources:general, firstname %>" SortExpression="firstname" />
                <asp:BoundField DataField="phone" HeaderText="<%$Resources:general, phonenumber %>" SortExpression="phone" />
                <asp:BoundField DataField="email" HeaderText="<%$Resources:general, email %>" SortExpression="email" />

            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="PersonDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>" SelectCommand="SELECT [id], [lastname], [firstname], [phone], [email] FROM [person]"></asp:SqlDataSource>
    </div>

</asp:Content>

<%@ Page Title="Support Home" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="SupportMain.aspx.cs" Inherits="SupportPage.SupportMain" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
            <RootNodeTemplate></RootNodeTemplate>
        </asp:SiteMapPath>
    </div>
    <br />
    
    <div>
        <asp:Label runat="server" Font-Bold="true" ForeColor="#0099ff" Text="<%$ Resources:Case, recently_received%>"></asp:Label>

        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" GridLines="None" CssClass="table table-striped table-hover " DataKeyNames="id" OnRowDataBound="GridView1_RowDataBound">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" InsertVisible="False" ReadOnly="True" />
                <asp:BoundField DataField="reportdate" HeaderStyle-Wrap="false" HeaderText="Date" ItemStyle-Width="100px" DataFormatString="{0:MM/dd/ yyyy}" SortExpression="reportdate">
                    <HeaderStyle Wrap="False"></HeaderStyle>
                    <ItemStyle Wrap="false"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField SortExpression="description" HeaderText="Description" ItemStyle-Width="900px">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 900px">
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" />
                </asp:TemplateField>
                <asp:BoundField DataField="cusname" HeaderStyle-Wrap="false" HeaderText="Customer" ItemStyle-Width="200px" SortExpression="cusname">
                    <HeaderStyle Wrap="False"></HeaderStyle>

                    <ItemStyle Width="200px"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="<%$ Resources:Case, solution%>">
                    <EditItemTemplate>
                        <asp:TextBox ID="CaseActionTb1" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="CaseActionLb1" runat="server"></asp:Label>
                    </ItemTemplate>

                    <HeaderStyle Wrap="False"></HeaderStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:Label runat="server" Font-Bold="true" ForeColor="#0099ff" Text="<%$ Resources:Case, recently_updated%>"></asp:Label>

        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataSourceID="SqlDataSource2" CssClass="table table-striped table-hover" GridLines="None" DataKeyNames="id" OnRowDataBound="GridView2_RowDataBound">
            <Columns>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <asp:BoundField DataField="lastupdatedate" HeaderStyle-Wrap="false" HeaderText="Date" ItemStyle-Width="100px" DataFormatString="{0:MM/dd/yyyy}" SortExpression="lastupdatedate">
                    <HeaderStyle Wrap="False"></HeaderStyle>
                    <ItemStyle Wrap="false"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField SortExpression="Description" ItemStyle-Width="900px" HeaderText="description">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 900px">
                            <asp:Label ID="Label1" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" />
                </asp:TemplateField>
                <asp:BoundField DataField="cusname" HeaderStyle-Wrap="false" HeaderText="Customer" ItemStyle-Width="200px" SortExpression="cusname">
                    <HeaderStyle Wrap="False"></HeaderStyle>

                    <ItemStyle Width="200px"></ItemStyle>
                </asp:BoundField>
                <asp:TemplateField HeaderStyle-Wrap="false" HeaderText="<%$ Resources:Case, solution%>">
                    <EditItemTemplate>
                        <asp:TextBox ID="CaseActionTb2" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="CaseActionLb2" runat="server"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False"></HeaderStyle>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Support%>" SelectCommand="SELECT TOP 5 [id], [reportdate], [description], [cusname] FROM [Incident] ORDER BY [reportdate] DESC"></asp:SqlDataSource>

        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:Support%>" SelectCommand="SELECT TOP 5 [id], [lastupdatedate], [description], [cusname] FROM [Incident] ORDER BY [lastupdatedate] DESC"></asp:SqlDataSource>

    </div>
</asp:Content>

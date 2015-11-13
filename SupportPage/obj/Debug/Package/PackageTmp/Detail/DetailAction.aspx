<%@ Page Title="Case Action" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="DetailAction.aspx.cs" Inherits="SupportPage.DetailAction" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <%-- description --%>     
                <asp:Literal runat="server" Text="<%$ Resources:Case, description%>"></asp:Literal>   
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox CssClass="form-control" TextMode="MultiLine" runat="server" Width="600" ID="detailaction_desc"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <%-- sender --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, sender%>"></asp:Literal>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" CssClass="form-control" ID="detailaction_sender" DataSourceID="DetailActionReceiverDrop" DataTextField="name" DataValueField="id">
                    <asp:ListItem Enabled="true" Selected="True" Text="None" Value=""></asp:ListItem>
                        </asp:DropDownList>
                    <asp:SqlDataSource ID="DetailActionSenderDrop" runat="server" ConnectionString="<%$ ConnectionStrings: Support %>" SelectCommand="SELECT m.id, p.lastname+p.firstname + '(' + o.name + ')'  as name FROM Member AS m INNER JOIN Person AS p ON m.person = p.id inner join org as o on m.org = o.id"></asp:SqlDataSource>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <%-- receiver --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, receiver%>"></asp:Literal>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList runat="server" CssClass="form-control" ID="detailaction_receiver" DataSourceID="DetailActionReceiverDrop" DataTextField="name" DataValueField="id">
                    <asp:ListItem Enabled="true" Selected="True" Text="None" Value=""></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="DetailActionReceiverDrop" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>" SelectCommand="SELECT m.id, p.lastname+p.firstname + '(' + o.name + ')'  as name FROM Member AS m INNER JOIN Person AS p ON m.person = p.id inner join org as o on m.org = o.id"></asp:SqlDataSource>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <%-- buttons --%>
    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
            <asp:Button runat="server" CssClass="btn btn-default" Text="<%$ Resources:general, cancel%>" OnClick="Unnamed2_Click"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, submit%>" OnClick="Unnamed3_Click"></asp:Button>
        </div>
    </div>

</asp:Content>

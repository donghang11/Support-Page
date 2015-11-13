<%@ Page Title="Case Action" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="DetailFile.aspx.cs" Inherits="SupportPage.DetailFile" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Table runat="server">
        <asp:TableRow>
            <asp:TableCell>
                <%-- name --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, name%>"></asp:Literal>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" CssClass="form-control" TextMode="SingleLine" Width="300" ID="detailfile_name" />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <%-- path --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, path%>"></asp:Literal>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox CssClass="form-control" TextMode="SingleLine" Width="300" runat="server" ID="detailfile_path"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <%-- note --%>
                <asp:Literal runat="server" Text="<%$ Resources:general, note%>"></asp:Literal>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox runat="server" CssClass="form-control" TextMode="MultiLine" Width="600" ID="detailfile_note"></asp:TextBox>
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

<%@ Page Title="Case Detail" Language="C#" MasterPageFile="~/MainSite.Master" EnableEventValidation="false" AutoEventWireup="true" CodeBehind="DetailCase2.aspx.cs" Inherits="SupportPage.DetailCase2" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <script src="JS/jquery-1.7.1.js"></script>
    <script src="JS/jquery-1.7.1.min.js"></script>
    <script src="ajax.googleapis.com/ajax/libs/jquery/2.1.1/jquery.min.js"></script>
    <link href="Select2/select2.css" rel="stylesheet">
    <script src="Select2/select2.js"></script>
    <br />
    <div>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
        </asp:SiteMapPath>
    </div>
    <br />


    <script>
        $(document).ready(function () {
            $("#" + "<%=detailcase2_cord.ClientID%>").select2(
                {
                    placeholder: "select..."
                }
                );

        });
    </script>

    <table>
        <tr>
            <td>
                <label style="color: #8C4510;">INTERFACE</label>
            </td>
            <td>
                <label style="color: #8C4510;">CORD</label>
            </td>
            <td>
                <label style="color: #8C4510;">DRAFTER</label>
            </td>
            <td>
                <label style="color: #8C4510;">DATE</label>
            </td>
            <td>
                <label style="color: #8C4510;">HANDLER</label>
            </td>
            <td>
                <label style="color: #8C4510;">PARENT</label>
            </td>
        </tr>
        <tr>
            <td>
                <%-- interface --%>
                <asp:DropDownList ID="detailcase2_interface" AutoPostBack="true" runat="server" CssClass="select" ForeColor="Blue" BorderStyle="None" OnSelectedIndexChanged="detailcase2_interface_SelectedIndexChanged">
                    <%--<asp:ListItem Text="--Interface--" Value="-1" Selected="True"></asp:ListItem>--%>
                    <asp:ListItem Text="Any" Value="9" Selected="True"></asp:ListItem>
                    <asp:ListItem Text="GigE" Value="1"></asp:ListItem>
                    <asp:ListItem Text="USB2" Value="2"></asp:ListItem>
                    <asp:ListItem Text="USB3" Value="3"></asp:ListItem>
                    <asp:ListItem Text="Camera Link" Value="4"></asp:ListItem>
                    <asp:ListItem Text="DVI/SDI" Value="5"></asp:ListItem>
                    <asp:ListItem Text="Analog" Value="6"></asp:ListItem>
                    <asp:ListItem Text="TV Format" Value="7"></asp:ListItem>
                    <asp:ListItem Text="Industry" Value="8"></asp:ListItem>
                </asp:DropDownList>
            </td>
            <td>
                <%-- cord --%>
                <asp:DropDownList ID="detailcase2_cord" AutoPostBack="true" runat="server" CssClass="select" ForeColor="Blue" BorderStyle="None" Enabled="False" OnSelectedIndexChanged="detailcase2_cord_SelectedIndexChanged">
                    <asp:ListItem Text="--Cord--" Value="" Enabled="false"></asp:ListItem>
                </asp:DropDownList>
                <%--<asp:TextBox ID="detailcase2_cord" runat="server" OnTextChanged=""></asp:TextBox>--%>
            </td>
            <td><%-- drafter --%>
                <asp:Label ID="detailcase2_drafter" runat="server" BorderStyle="None" Width="100px"></asp:Label></td>
            <td><%-- report date --%>
                <asp:Label ID="detailcase2_reportdate" runat="server" ForeColor="Green" BorderStyle="None" Width="100px"></asp:Label>
            </td>
            <td><%-- handler --%>
                <asp:DropDownList ID="detailcase2_handler" CssClass="select" runat="server" AutoPostBack="True" ForeColor="Indigo" BorderStyle="None" Width="200px" DataSourceID="HandlerSqlDataSource" DataTextField="name" DataValueField="id" OnSelectedIndexChanged="detailcase2_handler_SelectedIndexChanged">
                    <asp:ListItem Selected="True" Text="--handler--" Value=""></asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="HandlerSqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>" SelectCommand="select m.id, p.lastname+p.firstname + '(' + o.name + ')' as name from person p join member m on p.id = m.person join org o on m.org = o.id"></asp:SqlDataSource>
            </td>
            <td><%-- parent --%>
                <asp:Label ID="detailcase2_parent" runat="server" ForeColor="Purple" BorderStyle="None"></asp:Label></td>
        </tr>
    </table>
    <br />





    <style type="text/css">
        .Initial {
            display: block;
            padding: 4px 18px 4px 18px;
            float: left;
            background-color: #FFF7E7;
            color: #8C4510;
            font-weight: bold;
        }

            .Initial:hover {
                color: black;
            }

        .Clicked {
            float: left;
            display: block;
            padding: 4px 18px 4px 18px;
            font-weight: bold;
            background-color: #FFF7E7;
            color: black;
        }

        .select {
            border: none;
            -webkit-appearance: none;
        }

        .bselected {
            font-weight: bolder;
            color: #335588;
            text-decoration: none;
        }

        .bunselected {
            font-weight: normal;
            text-decoration: underline;
        }
    </style>

    <%-- buttons back, edit, submit and cancel 
    <div class="form-group">
        <div class="col-lg-10 col-lg-offset-2">
            <asp:Button ID="detailcase2_btn_back" runat="server" CssClass="btn btn-primary" Visible="false" Text="<%$ Resources:general, back%>" OnClick="Unnamed1_Click"></asp:Button>
            <asp:Button runat="server" CssClass="btn btn-primary" Text="<%$ Resources:general, edit%>" Visible="false" OnClick="Unnamed4_Click"></asp:Button>
            <asp:Button runat="server" ID="detailcase2_submit" CssClass="btn btn-primary" Text="<%$ Resources:general, submit%>" Visible="false" OnClick="detailcase2_submit_Click"></asp:Button>
            <asp:Button runat="server" ID="detailcase2_cancel" CssClass="btn btn-primary" Text="<%$ Resources:general, cancel%>" Visible="false" OnClick="detailcase2_cancel_Click"></asp:Button>
        </div>
    </div>
    --%>

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

    <%-- do not resize --%>
    <style type="text/css">
        textarea {
            resize: none;
        }
    </style>

    <table style="align-content: center">
        <tr>
            <td>
                <asp:Label runat="server" ForeColor="#8C4510" Font-Bold="true" Text="<%$Resources:Case, description %>"></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <%-- description --%>
                <asp:TextBox BackColor="White" BorderStyle="Solid" ForeColor="Black" Rows="12" Width="1000" TextMode="MultiLine" ID="detailcase2_desc" runat="server" ReadOnly="false" AutoPostBack="True" OnTextChanged="detailcase2_desc_TextChanged"></asp:TextBox>
            </td>
        </tr>
    </table>

    <table style="align-content: center">
        <tr>
            <td>
                <%-- action list --%>
                <div id="detailcase2_solution" style="text-align: justify; text-justify: auto">
                    <asp:Label runat="server" Font-Bold="true" ForeColor="#8C4510" Text="<%$Resources:Case, solution %>"></asp:Label>
                    <asp:ImageButton ID="detailcase2_addsolution" CssClass="btn btn-primary" runat="server" BackColor="Transparent" BorderStyle="None" ImageUrl="~/Images/plus_mark2.png" AlternateText="ADD" OnClick="detailcase2_addsolution_Click" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="detailcase2_action_gridview" runat="server" AutoGenerateColumns="False" Width="1000px" CssClass="table table-striped table-hover " PageSize="2" AllowPaging="True" ShowHeader="False" AllowSorting="True" DataSourceID="ActionDataSource" DataKeyNames="id" EmptyDataText="There is no solution available now." OnRowCommand="detailcase2_action_gridview_RowCommand" OnRowDataBound="detailcase2_action_gridview_RowDataBound" BackColor="#DEBA84" BorderColor="#DEBA84" BorderStyle="None" BorderWidth="1px" CellPadding="3" CellSpacing="2">
                    <Columns>
                        <asp:TemplateField ShowHeader="False" Visible="False">
                            <ItemTemplate>
                                <asp:LinkButton ID="DetailCaseActionDBClick" runat="server" CausesValidation="false" CommandName="DoubleClick" Text="DoubleClick" CommandArgument='<%# Eval("id") %>' OnClientClick="document.forms[0].target ='_blank';"></asp:LinkButton>
                            </ItemTemplate>
                        </asp:TemplateField>

                        <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" InsertVisible="False" ReadOnly="True" Visible="true" />

                        <asp:BoundField DataField="description" HeaderText="description" SortExpression="description" />
                        <asp:BoundField DataField="sender" HeaderText="sender" SortExpression="description" />
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
                <asp:SqlDataSource ID="ActionDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Support%>"
                    SelectCommand="SELECT id, description, sender FROM Action a WHERE a.incident = @id">
                    <SelectParameters>
                        <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </td>
        </tr>
    </table>

    <table style="width: 1000px; align-self: center">
        <tr>
            <td>
                <asp:Button Text="Other" runat="server" BorderStyle="None" ID="Other_Tab" CssClass="Initial" OnClick="Other_Tab_Click" ForeColor="#8C4510" BackColor="#FFF7E7" />
                <asp:Button Text="Report and Action" runat="server" BorderStyle="None" ID="Report_Tab" CssClass="Initial" OnClick="Report_Tab_Click" ForeColor="#8C4510" BackColor="#FFF7E7" />
                <asp:Button Text="Files" runat="server" BorderStyle="None" ID="Files_Tab" CssClass="Initial" OnClick="Files_Tab_Click" ForeColor="#8C4510" BackColor="#FFF7E7" />
                <asp:Button Text="Children" runat="server" BorderStyle="None" ID="Children_Tab" CssClass="Initial" OnClick="Children_Tab_Click" ForeColor="#8C4510" BackColor="#FFF7E7" />
                <asp:Button Text="Customer" runat="server" BorderStyle="None" ID="Customer_Tab" CssClass="Initial" OnClick="Customer_Tab_Click" ForeColor="#8C4510" BackColor="#FFF7E7" />
                <asp:MultiView runat="server" ID="MainView">
                    <asp:View ID="Other_View" runat="server">
                        <table style="width: 1000px; border-width: 1px; border-color: #666; border-style: solid">
                            <tr>
                                <td>
                                    <asp:TextBox BorderStyle="None" CssClass="form-control" BackColor="White" ForeColor="Black" TextMode="MultiLine" ID="detailcase2_other" runat="server" Rows="4" ReadOnly="false" OnTextChanged="detailcase2_other_TextChanged" AutoPostBack="True"></asp:TextBox>
                                </td>
                            </tr>
                        </table>
                    </asp:View>

                    <asp:View ID="Report_View" runat="server">
                        <table style="width: 1000px; border-width: 1px; border-color: #666; border-style: solid">
                            <tr>
                                <td>
                                    <%-- sales --%>
                                    <div class="form-group" style="margin-left: 10px">
                                        <asp:Label runat="server" Width="100" Text="<%$Resources:Case,  inform_sales%>"></asp:Label>
                                        <asp:RadioButtonList ID="detailcase2_sales_rb" runat="server" AutoPostBack="false" BorderStyle="None">
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>

                                        <%--                                        <asp:DropDownList ID="detailcase2_sales_dp" runat="server" Enabled="true" CssClass="select">
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                                        </asp:DropDownList>--%>
                                    </div>
                                </td>
                                <td>


                                    <%-- support team --%>
                                    <div class="form-group">
                                        <asp:Label runat="server" Text="<%$Resources:Case,  inform_support%>"></asp:Label>

                                        <asp:RadioButtonList ID="detailcase2_supportteam_rb" runat="server" AutoPostBack="false" BorderStyle="None">
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>

                                        <%--                                        <asp:DropDownList ID="detailcase2_supportteam_dp" runat="server" Enabled="false">
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                                        </asp:DropDownList>--%>
                                    </div>
                                </td>
                                <td>


                                    <%-- technote --%>
                                    <div class="form-group">
                                        <asp:Label runat="server" Text="<%$Resources:Case, change_technote %>"></asp:Label>

                                        <asp:RadioButtonList ID="detailcase2_technote_rb" runat="server" AutoPostBack="false" BorderStyle="None">
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>

                                        <%--                                        <asp:dropdownlist id="detailcase2_technote_dp" runat="server" enabled="false">
                                            <asp:listitem enabled="true" text="<%$ resources:case, no_need%>" selected="true" value="0"></asp:listitem>
                                            <asp:listitem enabled="true" text="<%$ resources:case, not_yet_finished%>" value="1"></asp:listitem>
                                            <asp:listitem enabled="true" text="<%$ resources:case, finished%>" value="2"></asp:listitem>
                                        </asp:dropdownlist>--%>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%-- instruction --%>
                                    <div class="form-group" style="margin-left: 10px">
                                        <asp:Label runat="server" Text="<%$Resources:Case, change_instruction %>"></asp:Label>

                                        <asp:RadioButtonList ID="detailcase2_inst_rb" runat="server" AutoPostBack="false" BorderStyle="None">
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>

                                        <%--                                        <asp:DropDownList ID="detailcase2_inst_dp" runat="server" Enabled="false">
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                                        </asp:DropDownList>--%>
                                    </div>
                                </td>
                                <td>

                                    <%-- faq --%>
                                    <div class="form-group">
                                        <asp:Label runat="server" Text="<%$Resources:Case, change_faq %>"></asp:Label>

                                        <asp:RadioButtonList ID="detailcase2_faq_rb" runat="server" AutoPostBack="false" BorderStyle="None">
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>

                                        <%--                                        <asp:DropDownList ID="detailcase2_faq_dp" runat="server" Enabled="false">
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                                        </asp:DropDownList>--%>
                                    </div>
                                </td>
                                <td>
                                    <%-- all company --%>
                                    <div class="form-group">
                                        <asp:Label runat="server" Text="<%$Resources:Case, inform_allcompany %>"></asp:Label>

                                        <asp:RadioButtonList ID="detailcase2_allcompany_rb" runat="server" AutoPostBack="false" BorderStyle="None">
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                                        </asp:RadioButtonList>

                                        <%--                                        <asp:DropDownList ID="detailcase2_allcompany_dp" runat="server" Enabled="false">
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                                            <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                                        </asp:DropDownList>--%>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <div style="text-align: left; align-content: center; margin-left: 10px">
                                        <%-- delete --%>
                                        <asp:Button runat="server" BorderStyle="Outset" ID="detailcase2_btn_report_confirm" Text="Confirm" BackColor="#FFF7E7" Font-Bold="true" ForeColor="#8C4510" Visible="true" OnClick="detailcase2_btn_report_confirm_Click"></asp:Button>
                                    </div>
                                </td>
                                <td></td>
                                <td></td>
                            </tr>
                        </table>
                    </asp:View>

                    <asp:View ID="Files_View" runat="server">
                        <table style="width: 1000px; border-width: 1px; border-color: #666; border-style: solid">
                            <tr>
                                <td>
                                    <asp:GridView ID="detailcase2_file_gridview" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover " PageSize="2" AllowPaging="True" ShowHeader="False" AllowSorting="True" DataSourceID="FileDataSource" DataKeyNames="id" EmptyDataText="There is no file available now." OnRowCommand="detailcase2_file_gridview_RowCommand" OnRowDataBound="detailcase2_file_gridview_RowDataBound">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False" Visible="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="DetailCaseFileDBClick" runat="server" CausesValidation="false" CommandName="DoubleClick" Text="DoubleClick" CommandArgument='<%# Eval("id") %>' OnClientClick="document.forms[0].target ='_blank';"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" InsertVisible="False" ReadOnly="True" Visible="false" />
                                            <asp:BoundField DataField="name" HeaderText="name" SortExpression="name" />
                                            <asp:BoundField DataField="fpath" HeaderText="path" SortExpression="fpath" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="FileDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>"
                                        SelectCommand="SELECT name, id, fpath FROM Files f WHERE f.incident = @id">
                                        <SelectParameters>
                                            <asp:QueryStringParameter Name="id" QueryStringField="id" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>

                    <asp:View ID="Children_View" runat="server">
                        <table style="width: 1000px; border-width: 1px; border-color: #666; border-style: solid">
                            <tr>
                                <td>
                                    <asp:Button runat="server" BorderStyle="Outset" ID="detailcase2_children_add" Text="Add" BackColor="#FFF7E7" Font-Bold="true" ForeColor="#8C4510" Visible="true" OnClick="detailcase2_children_add_Click"></asp:Button>
                                    <asp:GridView ID="detailcase2_children_gridview" runat="server" AutoGenerateColumns="False" CssClass="table table-striped table-hover " PageSize="2" AllowPaging="True" ShowHeader="False" AllowSorting="True" DataSourceID="ChildrenDataSource" DataKeyNames="id" EmptyDataText="There is no children available now." OnRowDataBound="ChildrenGridView_RowDataBound" OnRowCommand="ChildrenGridView_RowCommand">
                                        <Columns>
                                            <asp:TemplateField ShowHeader="False" Visible="False">
                                                <ItemTemplate>
                                                    <asp:LinkButton ID="DetailCaseChildrenDBClick" runat="server" CausesValidation="false" CommandName="DoubleClick" Text="DoubleClick" CommandArgument='<%# Eval("id") %>' OnClientClick="document.forms[0].target ='_blank';"></asp:LinkButton>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="id" HeaderText="id" SortExpression="id" InsertVisible="False" ReadOnly="True" />
                                            <asp:BoundField DataField="description" Visible="true" HeaderText="description" SortExpression="description" />
                                            <asp:TemplateField HeaderText="solution" Visible="false">
                                                <EditItemTemplate>
                                                    <asp:TextBox ID="DetailCase2Tb2" runat="server"></asp:TextBox>
                                                </EditItemTemplate>
                                                <ItemTemplate>
                                                    <asp:Label ID="DetailCase2Lb2" runat="server"></asp:Label>
                                                </ItemTemplate>
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                    <asp:SqlDataSource ID="ChildrenDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>"
                                        SelectCommand="SELECT [id], [description] FROM [Incident] WHERE ([parent] = @parent)">
                                        <SelectParameters>
                                            <asp:QueryStringParameter Name="parent" QueryStringField="id" Type="Int32" />
                                        </SelectParameters>
                                    </asp:SqlDataSource>
                                </td>
                            </tr>
                        </table>
                    </asp:View>

                    <asp:View ID="Customer_View" runat="server">
                        <table style="width: 1000px; border-width: 1px; border-color: #666; border-style: solid">
                            <tr>
                                <td style="width: 200px">
                                    <label style="color: #8C4510;">Customer Company</label>
                                    <br />
                                </td>
                                <td>
                                    <%-- customer company --%>
                                    (<asp:TextBox ID="detailcase2_cuscom" runat="server" AutoPostBack="false" BorderStyle="None" Width="600px"></asp:TextBox>)
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 200px">
                                    <label style="color: #8C4510;">Customer Name</label>
                                    <br />
                                </td>
                                <td><%-- customer name --%>
                                    (<asp:TextBox ID="detailcase2_cusname" runat="server" AutoPostBack="false" BorderStyle="None" Width="600px"></asp:TextBox>)
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td style="width: 200px">
                                    <label style="color: #8C4510;">Distributor</label>
                                    <br />
                                    <td><%-- distrabution company --%>
                                    (<asp:TextBox ID="detailcase2_discom" runat="server" AutoPostBack="false" BorderStyle="None" Width="600px"></asp:TextBox>)
                                    <br />
                                    </td>
                            </tr>
                            <tr>
                                <td style="width: 200px">
                                    <label style="color: #8C4510;">Distrributor person</label>
                                    <br />
                                </td>
                                <td><%-- distrabution name --%>
                                    (<asp:TextBox ID="detailcase2_disname" runat="server" AutoPostBack="false" BorderStyle="None" Width="600px"></asp:TextBox>)
                                    <br />
                                </td>
                            </tr>
                            <tr>
                                <td></td>
                                <td>
                                    <div style="text-align: left; align-content: center; margin-left: 350px">

                                        <asp:Button runat="server" BorderStyle="Outset" ID="detailcase2_btn_customer_confirm_Click" Text="Confirm" BackColor="#FFF7E7" Font-Bold="true" ForeColor="#8C4510" Visible="true" OnClick="detailcase2_btn_customer_confirm_Click_Click"></asp:Button>
                                    </div>
                                </td>
                            </tr>
                        </table>
                    </asp:View>
                </asp:MultiView>
            </td>
        </tr>
    </table>
    <br />
    <br />

    <%--    <ajaxToolkit:ToggleButtonExtender runat="server"
        id="detailcase2_isclosed_tb"
        TargetControlID="detailcase2_isclosed_cb"
        ImageHeight="30"
        ImageWidth="19"
        CheckedImageUrl="~/Images/switch-on-icon.png"
        UncheckedImageUrl="~/Images/switch-off-icon.png"
        CheckedImageAlternateText="closed"
        UncheckedImageAlternateText="not closed"
        />--%>

    <div style="text-align: left; align-content: center; margin-left: 10px">
        <%-- is closed --%>
        <asp:CheckBox runat="server" ID="detailcase2_isclosed_cb" OnCheckedChanged="detailcase2_isclosed_cb_CheckedChanged" AutoPostBack="true" Text="Is Case Closed"></asp:CheckBox>
    </div>

    <div style="text-align: right; align-content: center; margin-right: 10px">
        <%-- delete --%>
        <asp:Button runat="server" ID="detailcase2_delete" CssClass="btn btn-primary" Text="Delete" BackColor="Red" Visible="true" OnClientClick="return confirmation();" OnClick="detailcase2_delete_Click"></asp:Button>
    </div>
    <%--
            <asp:Table runat="server" BorderColor="LightBlue" BorderStyle="Ridge" Width="900">
        <asp:TableRow>
            <asp:TableCell BorderColor="LightBlue" VerticalAlign="Top" BorderStyle="Ridge" Width="300">
                    
            </asp:TableCell>

            <asp:TableCell BorderColor="LightBlue" VerticalAlign="Top" BorderStyle="Ridge" Width="300">

                <div>
                    <asp:Label runat="server" ForeColor="Green" Text="<%$Resources:Case, file %>"></asp:Label>
                    <asp:ImageButton ID="detailcase2_addfile" CssClass="btn btn-primary" runat="server" BackColor="Transparent" BorderStyle="None" ImageUrl="~/Images/plus_mark2.png" AlternateText="ADD" OnClick="detailcase2_addfile_Click" />
                </div>


            </asp:TableCell>

            <asp:TableCell BorderColor="LightBlue" VerticalAlign="Top" BorderStyle="Ridge" Width="300">

                <div style="align-content: space-between">
                    <asp:Label runat="server" ForeColor="Green" Text="<%$Resources:Case, child %>"></asp:Label>
                    <asp:ImageButton ID="detailcase2_addchild" CssClass="btn btn-primary" runat="server" BackColor="Transparent" BorderStyle="None" ImageUrl="~/Images/plus_mark2.png" AlternateText="ADD" OnClick="detailcase2_addchild_Click" />
                </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table runat="server" Width="900">
        <asp:TableRow>
            <asp:TableCell>
                    <br />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableHeaderRow>
            <asp:TableCell BorderStyle="None">
                    <asp:Label runat="server" ForeColor="Green" Text="<%$Resources:Case, report_and_action %>"></asp:Label>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow BorderStyle="Ridge" BorderColor="LightBlue">
            <asp:TableCell>

                <div class="form-group">
                    <asp:Label runat="server" Width="100" Text="<%$Resources:Case,  inform_sales%>"></asp:Label>

                    <asp:DropDownList ID="detailcase2_sales_dp" runat="server" Enabled="false">
                        <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                        <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                        <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                    </asp:DropDownList>

                </div>
            </asp:TableCell>
            <asp:TableCell>
        
                <div class="form-group">
                    <asp:Label runat="server" Text="<%$Resources:Case,  inform_support%>"></asp:Label>
                    <asp:DropDownList ID="detailcase2_supportteam_dp" runat="server" Enabled="false">
                        <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                        <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                        <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </asp:TableCell>
            <asp:TableCell>

                <div class="form-group">
                    <asp:Label runat="server" Text="<%$Resources:Case, change_technote %>"></asp:Label>
                    <asp:DropDownList ID="detailcase2_technote_dp" runat="server" Enabled="false">
                        <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                        <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                        <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow BorderStyle="Ridge" BorderColor="LightBlue">
            <asp:TableCell>
    
                <div class="form-group">
                    <asp:Label runat="server" Text="<%$Resources:Case, change_instruction %>"></asp:Label>
                    <asp:DropDownList ID="detailcase2_inst_dp" runat="server" Enabled="false">
                        <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                        <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                        <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                    </asp:DropDownList>

                </div>
            </asp:TableCell>
            <asp:TableCell>
    
                <div class="form-group">
                    <asp:Label runat="server" Text="<%$Resources:Case, change_faq %>"></asp:Label>

                    <asp:DropDownList ID="detailcase2_faq_dp" runat="server" Enabled="false">
                        <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                        <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                        <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                    </asp:DropDownList>

                </div>
            </asp:TableCell>
            <asp:TableCell>

                <div class="form-group">
                    <asp:Label runat="server" Text="<%$Resources:Case, inform_allcompany %>"></asp:Label>

                    <asp:DropDownList ID="detailcase2_allcompany_dp" runat="server" Enabled="false">
                        <asp:ListItem Enabled="true" Text="<%$ Resources:Case, no_need%>" Selected="True" Value="0"></asp:ListItem>
                        <asp:ListItem Enabled="true" Text="<%$ Resources:Case, not_yet_finished%>" Value="1"></asp:ListItem>
                        <asp:ListItem Enabled="true" Text="<%$ Resources:Case, finished%>" Value="2"></asp:ListItem>
                    </asp:DropDownList>

                </div>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>

    <asp:Table runat="server" Width="900">
        <asp:TableRow>
            <asp:TableCell>
                    <br />
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableHeaderRow>
            <asp:TableCell BorderStyle="None">
                    <asp:Label runat="server" ForeColor="Green" Text="<%$Resources:Case,  other%>"></asp:Label>
            </asp:TableCell>
        </asp:TableHeaderRow>
        <asp:TableRow BorderColor="LightBlue" BorderStyle="Ridge">
            <asp:TableCell>
       
                <div class="form-group">
                    <asp:Label runat="server" ForeColor="Green" Text="<%$Resources:Case, handler %>"></asp:Label>
                    <asp:DropDownList runat="server" Width="200" Enabled="false" CssClass="form-control" ID="detailcase2_handler" DataTextField="name" DataValueField="id" DataSourceID="SqlDataSource1">
                        <asp:ListItem Enabled="true" Text="<%$ Resources:general, none%>" Selected="True" Value=""></asp:ListItem>
                    </asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>" SelectCommand="select m.id, p.lastname+p.firstname + '(' + o.name + ')' as name from person p join member m on p.id = m.person join org o on m.org = o.id"></asp:SqlDataSource>
                </div>
            </asp:TableCell>
            <asp:TableCell>

                <div class="form-group">
                    <asp:Label runat="server" ForeColor="Green" Text="<%$Resources:Case, parent %>"></asp:Label>
                    <asp:Label ID="detailcase2_parent" runat="server"></asp:Label>
                </div>
            </asp:TableCell>
        </asp:TableRow>
     <asp:TableRow BorderColor="LightBlue" BorderStyle="Ridge" HorizontalAlign="Left">
            <asp:TableCell>
           
                    <asp:Label runat="server" Width="300" CssClass="col-md-2 control-label" Text="<%$Resources: Case, other %>"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox BorderStyle="None" CssClass="form-control" BackColor="White" ForeColor="Black" TextMode="MultiLine" ID="detailcase2_other" runat="server" Rows="4" ReadOnly="false"></asp:TextBox>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
    --%>
</asp:Content>

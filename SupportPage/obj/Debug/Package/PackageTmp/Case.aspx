<%@ Page Title="Cases" Language="C#" MasterPageFile="~/MainSite.Master" AutoEventWireup="true" CodeBehind="Case.aspx.cs" Inherits="SupportPage._Default" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <br />
    <div>
        <asp:SiteMapPath ID="SiteMapPath1" runat="server">
        </asp:SiteMapPath>
    </div>
    <br />
    <div>
        <ul class="nav nav-pills">
            <li>
                <asp:Button ID="def_but_add" runat="server" Text="<%$ Resources:general, add%>" CssClass="btn btn-primary" OnClick="def_but_add_Click" OnClientClick="document.forms[0].target = '_blank'" />
            </li>
            <%--<li>
                <asp:Button ID="def_but_generate_xml_file" runat="server" CssClass="btn btn-primary" Visible="false" Text="<%$ Resources:Case, excel%>" OnClick="def_but_generate_xml_file_Click" />
            </li>--%>
            <li>
                <div style="text-align: right">
                    <asp:DropDownList runat="server" ID="Case_pageSize" CssClass="btn btn-default dropdown-toggle" OnSelectedIndexChanged="Case_pageSize_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Selected="True" Text="50" Value="50"></asp:ListItem>
                        <asp:ListItem Text="100" Value="100"></asp:ListItem>
                        <asp:ListItem Text="200" Value="200"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </li>
        </ul>
    </div>
    <asp:CheckBox ID="Default_checkbox_show_only_unclosed" runat="server" CssClass="checkbox" Font-Bold="True" Font-Size="Large" ForeColor="#008CBA" Text="<%$ Resources:Case, showonly%>" OnCheckedChanged="Default_checkbox_show_only_unclosed_CheckedChanged" AutoPostBack="True" />
    <%-- <asp:CheckBox runat="server" Text="<%$ Resources:Case, sales%>" Checked="false" ID="showsales" AutoPostBack="true" OnCheckedChanged="showsales_CheckedChanged" />
    <asp:CheckBox runat="server" Text="<%$ Resources:Case, supportteam%>" Checked="false" ID="showsupportteam" AutoPostBack="true" OnCheckedChanged="showsupportteam_CheckedChanged" />
    <asp:CheckBox runat="server" Text="<%$ Resources:Case, technote%>" Checked="false" ID="showtechnote" AutoPostBack="true" OnCheckedChanged="showtechnote_CheckedChanged" />
    <asp:CheckBox runat="server" Text="<%$ Resources:Case, instruction%>" Checked="false" ID="showinstruction" AutoPostBack="true" OnCheckedChanged="showinstruction_CheckedChanged" />
    <asp:CheckBox runat="server" Text="<%$ Resources:Case, faq%>" Checked="false" ID="showfaq" AutoPostBack="true" OnCheckedChanged="showfaq_CheckedChanged" />
    <asp:CheckBox runat="server" Text="<%$ Resources:Case, allcompany%>" Checked="false" ID="showallcompany" AutoPostBack="true" OnCheckedChanged="showallcompany_CheckedChanged" />
    <asp:CheckBox runat="server" Text="<%$ Resources:Case, other%>" Checked="false" ID="showother" AutoPostBack="true" OnCheckedChanged="showother_CheckedChanged" />--%>

    <div style="margin-left: 0px;">
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" GridLines="None" PageSize="50" HeaderStyle-BorderStyle="None" DataKeyNames="id" DataSourceID="SqlDataSource1" CssClass="table table-striped table-hover" AllowPaging="True" AllowSorting="True" OnRowDataBound="GridView1_RowDataBound" OnRowCommand="GridView1_RowCommand" OnSelectedIndexChanged="GridView1_SelectedIndexChanged1">
            <Columns>
                <%-- 0 --%>
                <asp:TemplateField ShowHeader="false" Visible="False">
                    <ItemTemplate>
                        <asp:LinkButton ID="CaseDoubleClick" runat="server" CausesValidation="false" CommandName="DoubleClick" Text="DoubleClick" CommandArgument='<%# Eval("id") %>'></asp:LinkButton>
                    </ItemTemplate>
                </asp:TemplateField>
                <%-- 1 --%>
                <asp:BoundField DataField="id" HeaderText="id" InsertVisible="False" ReadOnly="True" SortExpression="id" />
                <%--            <asp:BoundField DataField="interface" HeaderText="<%$ Resources:Case, interface_name%>" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" SortExpression="interface">
                    <HeaderStyle Wrap="False"></HeaderStyle>
                    <ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>--%>

                <asp:TemplateField HeaderStyle-ForeColor="#008cba" HeaderText="Interface">
                    <ItemTemplate>
                        <asp:Image runat="server" ID="ImageInterface" />
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderStyle-ForeColor="#008cba" HeaderText="Cord">
                    <ItemTemplate>
                        <asp:Label ID="TextBoxCord" runat="server"></asp:Label>
                    </ItemTemplate>
                </asp:TemplateField>

                <asp:TemplateField HeaderText="<%$ Resources:Case, description%>" HeaderStyle-ForeColor="#008cba" ItemStyle-Width="450px">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox2" runat="server" Text='<%# Bind("description") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 450px">
                            <asp:Label ID="Label2" runat="server" Text='<%# Bind("description") %>'></asp:Label>
                        </div>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="false" />
                </asp:TemplateField>

                <%-- drafter --%>
                <asp:BoundField DataField="drafter" HeaderText="<%$ Resources:Case, drafter%>" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" SortExpression="drafter">
                    <HeaderStyle Wrap="False"></HeaderStyle>
                    <ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="reportdate" HeaderText="<%$ Resources:Case, reportdate%>" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" SortExpression="reportdate" DataFormatString="{0:MM/dd/yyyy}">
                    <HeaderStyle Wrap="False"></HeaderStyle>

                    <ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>

                <%--                <asp:CheckBoxField DataField="isclosed" HeaderText="<%$ Resources:Case, isclosed%>" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" SortExpression="isclosed">
                    <HeaderStyle Wrap="False"></HeaderStyle>

                    <ItemStyle Wrap="False"></ItemStyle>
                </asp:CheckBoxField>--%>

                <%-- <asp:BoundField DataField="sales" HeaderText="<%$ Resources:Case, sales%>" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" SortExpression="sales">
                    <HeaderStyle Wrap="False"></HeaderStyle>

                    <ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="supportteam" HeaderText="<%$ Resources:Case, supportteam%>" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" SortExpression="supportteam">
                    <HeaderStyle Wrap="False"></HeaderStyle>

                    <ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="technote" HeaderText="<%$ Resources:Case, technote%>" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" SortExpression="technote">
                    <HeaderStyle Wrap="False"></HeaderStyle>

                    <ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="instruction" HeaderText="<%$ Resources:Case, instruction%>" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" SortExpression="instruction">
                    <HeaderStyle Wrap="False"></HeaderStyle>

                    <ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="faq" HeaderText="<%$ Resources:Case, faq%>" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" SortExpression="faq">
                    <HeaderStyle Wrap="False"></HeaderStyle>

                    <ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>

                <asp:BoundField DataField="allcompany" HeaderText="<%$ Resources:Case, allcompany%>" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" SortExpression="allcompany">
                    <HeaderStyle Wrap="False"></HeaderStyle>

                    <ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>--%>

                <%--                <asp:BoundField DataField="other" HeaderText="<%$ Resources:Case, other%>" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" SortExpression="other">
                    <HeaderStyle Wrap="False"></HeaderStyle>
                    <ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>--%>

                <%--                <asp:BoundField DataField="attachment" HeaderStyle-ForeColor="#008cba" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" HeaderText="<%$ Resources:Case, file%>">
                    <HeaderStyle Wrap="False" ForeColor="#008CBA"></HeaderStyle>

                    <ItemStyle Wrap="False"></ItemStyle>
                </asp:BoundField>--%>

                <asp:TemplateField HeaderStyle-ForeColor="#008cba" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" HeaderText="<%$ Resources:Case, solution%>">
                    <EditItemTemplate>
                        <asp:TextBox ID="CaseActionTb" runat="server"></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="CaseActionLb" runat="server"></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" ForeColor="#008CBA"></HeaderStyle>
                    <ItemStyle Wrap="False"></ItemStyle>
                </asp:TemplateField>

                <%--                <asp:TemplateField HeaderText="<%$ Resources:Case, handler%>" ItemStyle-Wrap="false" HeaderStyle-Wrap="false" SortExpression="handler">
                    <EditItemTemplate>
                        <asp:TextBox ID="TextBox1" runat="server" Text='<%# Bind("handler") %>'></asp:TextBox>
                    </EditItemTemplate>
                    <ItemTemplate>
                        <asp:Label ID="Label1" runat="server" Text='<%# Bind("handler") %>'></asp:Label>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False"></HeaderStyle>
                    <ItemStyle Wrap="False"></ItemStyle>
                </asp:TemplateField>--%>

                <%--                <asp:BoundField DataField="enddate" HeaderText="enddate" SortExpression="enddate" Visible="false" />

                <asp:BoundField DataField="lastupdatedate" HeaderText="lastupdatedate" SortExpression="lastupdatedate" Visible="false" />--%>

                <asp:TemplateField HeaderText="Report" HeaderStyle-ForeColor="#008cba" ItemStyle-Width="80px">
                    <ItemTemplate>
                        <div style="overflow: hidden; text-overflow: ellipsis; white-space: nowrap; width: 80px">
                            <asp:Label ID="list_allcompany" runat="server" Text='社' Visible="false"></asp:Label>
                            <asp:Label ID="list_sales" runat="server" Text='営' Visible="false"></asp:Label>
                            <asp:Label ID="list_instruction" runat="server" Text='仕' Visible="false"></asp:Label>
                            <asp:Label ID="list_technote" runat="server" Text='T' Visible="false"></asp:Label>
                            <asp:Label ID="list_supportteam" runat="server" Text='S' Visible="false"></asp:Label>
                            <asp:Label ID="list_faq" runat="server" Text='F' Visible="false"></asp:Label>
                        </div>
                    </ItemTemplate>
                    <HeaderStyle Wrap="False" />
                    <ItemStyle Wrap="false" />
                </asp:TemplateField>

            </Columns>

            <HeaderStyle BorderStyle="None"></HeaderStyle>
        </asp:GridView>

        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Support %>"
            SelectCommand="
                            with cte(id, 
                            parent,
                            description, 
                            level, 
                            model, 
                            drafter, 
                            reportdate, 
                            sales,
                            supportteam, 
                            technote, 
                            instruction, 
                            faq,
                            allcompany, 
                            other,
                            handler,
                            enddate,
                            lastupdatedate,
                            cusname,
                            discom,
                            cuscom,
                            dispname,
                            sort)
                            as (
                            select id, 
                            parent,
                            description, 
                            1 level, 
                            model, 
                            drafter, 
                            reportdate, 
                            sales,
                            supportteam, 
                            technote, 
                            instruction, 
                            faq,
                            allcompany, 
                            other,
                            handler,
                            enddate,
                            lastupdatedate,
                            cusname,
                            discom,
                            cuscom,
                            dispname,
                            description 
                            from Incident a WHERE a.parent is null
                            union ALL
                            select 
                            b.id, 
                            b.parent,
                            REPLICATE ('|-   ' , level) + b.description, 
                            level+1, 
                            b.model,
                            b.drafter,
                            b.reportdate, 
                            b.sales,
                            b.supportteam, 
                            b.technote, 
                            b.instruction, 
                            b.faq,
                            b.allcompany, 
                            b.other,
                            b.handler,
                            b.enddate,
                            b.lastupdatedate,
                            b.cusname,
                            b.discom,
                            b.cuscom,
                            b.dispname,
                            RTRIM(sort) + '|- ' + b.description
                            from Incident b 
                            join cte c on b.parent = c.id)
                            select
                            id, 
                            parent,
                            description, 
                            model, 
                            drafter, 
                            reportdate, 
                            sales,
                            supportteam, 
                            technote, 
                            instruction, 
                            faq,
                            allcompany, 
                            other,
                            handler,
                            enddate,
                            lastupdatedate,
                            cusname,
                            discom,
                            cuscom,
                            dispname from cte order by sort, reportdate desc"></asp:SqlDataSource>
    </div>
</asp:Content>

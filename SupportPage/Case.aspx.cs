using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;
using SupportPage.Models;
using System.Web.Security;
using System.Collections.Generic;
using System.Drawing;


namespace SupportPage
{
    public partial class Case : Page
    {
        static Dictionary<int, int> actnum;

        protected void Page_Load(object sender, EventArgs e)
        {

            Support s = new Support();
            actnum = new Dictionary<int, int>();

            foreach (Incident i in s.Incidents.ToList())
            {
                foreach (action_model a in s.Actions.ToList())
                {
                    if (a.incident == i.id)
                    {
                        if (actnum.Keys.Contains(i.id))
                        {
                            actnum[i.id] += 1;
                        }
                        else
                        {
                            actnum.Add(i.id, +1);
                        }
                    }
                }
            }
            //actnum.Keys.ToList().ForEach(x => Response.Write(x + "|"));
            //Response.Write("\n");
            //actnum.Values.ToList().ForEach(x => Response.Write(x + "|"));

            List<Incident> inc = s.Incidents.ToList();
            inc.Reverse(); 
            foreach (Incident i in inc)
            {
                if (i.parent != null)
                {
                    if (actnum.ContainsKey(i.parent.Value) && actnum.ContainsKey(i.id))
                    {
                        //Response.Write("parent");
                        actnum[i.parent.Value] += actnum[i.id];
                    }
                }
            }

            //actnum.ToList().ForEach(x => Response.Write(x.Key + ":" + x.Value + " "));

            if (Request.Cookies["user"] != null)
            {
                string decoded_username = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["username"]), "ProtectCookieUsername"));
                string decoded_role = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["role"]), "ProtectCookieRole"));

                if (decoded_role == "admin" || decoded_role == "support")
                {

                }

                else
                {
                    Response.Redirect("~/");
                }
            }

            else
            {
                Response.Redirect("~/");
            }
        }

        protected override void InitializeCulture()
        {

            try
            {
                if (Request.Cookies["Language"] != null)
                {
                    //string decoded_lang = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["Language"]["lang"]), "ProtectCookieLanguage"));
                    string decoded_lang = Request.Cookies["Language"].Value;
                    UICulture = decoded_lang;
                    Culture = Request.UserLanguages[0];
                }
                base.InitializeCulture();
            }

            catch
            {

            }

        }

        protected void def_but_add_Click(object sender, EventArgs e)
        {
            var res = base.Response;
            res.Redirect("~/Detail/DetailCase2.aspx?new=1");
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            GridViewRow row = GridView1.SelectedRow;
            try
            {

                DataKey key = GridView1.DataKeys[row.DataItemIndex];
                if (GridView1.SelectedIndex >= 0)
                {
                    int selected_id = GridView1.SelectedIndex;
                    int id = (int)GridView1.DataKeys[selected_id].Value;
                    Response.Redirect("Detail/DetailCase2.aspx?id=" + id);
                }
            }

            catch
            {
                Response.Write(GridView1.SelectedIndex + "  " + row.DataItemIndex);
            }
        }

        //generate excel file
        //protected void def_but_generate_xml_file_Click(object sender, EventArgs e)
        //{

        //    ExportExcel export = new ExportExcel();

        //    export.ChangeControlsToValue(GridView1);

        //    //Response.ClearContent();
        //    //Response.AddHeader("content-disposition", "attachment;filename=MyExcelFile.xls");
        //    //Response.ContentType = "application/excel";
        //    //StringWriter sw = new StringWriter();
        //    //HtmlTextWriter htw = new HtmlTextWriter(sw);
        //    //GridView1.RenderControl(htw);
        //    //Response.Write(sw.ToString());
        //    //Response.End();


        //    Microsoft.Office.Interop.Excel.Application excel = new Microsoft.Office.Interop.Excel.Application();

        //    excel.Application.Workbooks.Add(true);
        //    excel.Visible = true;

        //    for (int i = 1; i < GridView1.Columns.Count - 2; i++)
        //    {
        //        excel.Cells[1, i] = GridView1.Columns[i].HeaderText;
        //    }

        //    for (int i = 0; i < GridView1.Rows.Count; i++)
        //    {
        //        for (int j = 1; j < GridView1.Columns.Count - 2; j++)
        //        {
        //            excel.Cells[i + 2, j] = GridView1.Rows[i].Cells[j].Text;
        //        }
        //    }
        //}

        public override void VerifyRenderingInServerForm(Control control)
        {

        }

        //show closed
        protected void Default_checkbox_show_only_unclosed_CheckedChanged(object sender, EventArgs e)
        {

            if (Default_checkbox_show_only_unclosed.Checked)
            {
                utils u = new utils();
                SqlDataSource1.SelectCommand = u.caselistquery + " WHERE reportdate = enddate" + " order by sort";
                //Response.Write(SqlDataSource1.SelectCommand.ToString());
                GridView1.DataBind();
            }
            else if (!Default_checkbox_show_only_unclosed.Checked)
            {
                GridView1.DataBind();
            }

        }


        protected void LinkButton2_Command(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            try
            {
                if (id >= 0)
                {
                    Response.Redirect("Detail/DetailCase2.aspx?id=" + id);
                }
            }

            catch
            {
                Response.Write(GridView1.SelectedIndex + "  " + id);
            }
        }

        //Edit
        protected void LinkButton3_Command(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            try
            {
                if (id >= 0)
                {
                    Response.Redirect("Detail/DetailCaseEdit.aspx?id=" + id);
                }
            }

            catch
            {
                Response.Write(GridView1.SelectedIndex + "  " + id);
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                /*
                //Get the LinkButton control in the first cell
                LinkButton _doubleClickButton = (LinkButton)e.Row.Cells[0].Controls[0].FindControl("CaseDoubleClick");
                //Get the javascript which is assigned to this LinkButton
                string _jsDouble =
                ClientScript.GetPostBackClientHyperlink(_doubleClickButton, "");
                //Add this JavaScript to the ondblclick Attribute of the row
                e.Row.Attributes["ondblclick"] = _jsDouble;
                */

                //if (!String.IsNullOrEmpty(e.Row.Cells[7].Text))
                //{
                //    int num = Convert.ToInt32(e.Row.Cells[7].Text);
                //    e.Row.Cells[7].Text = workstatus(num);
                //    e.Row.Cells[7].BackColor = statusColor(num);
                //}

                //if (!String.IsNullOrEmpty(e.Row.Cells[8].Text))
                //{
                //    int num = Convert.ToInt32(e.Row.Cells[8].Text);
                //    e.Row.Cells[8].Text = workstatus(num);
                //    e.Row.Cells[8].BackColor = statusColor(num);
                //}

                //if (!String.IsNullOrEmpty(e.Row.Cells[9].Text))
                //{
                //    int num = Convert.ToInt32(e.Row.Cells[9].Text);
                //    e.Row.Cells[9].Text = workstatus(num);
                //    e.Row.Cells[9].BackColor = statusColor(num);
                //}

                //if (!String.IsNullOrEmpty(e.Row.Cells[10].Text))
                //{
                //    int num = Convert.ToInt32(e.Row.Cells[10].Text);
                //    e.Row.Cells[10].Text = workstatus(num);
                //    e.Row.Cells[10].BackColor = statusColor(num);
                //}

                //if (!String.IsNullOrEmpty(e.Row.Cells[11].Text))
                //{
                //    int num = Convert.ToInt32(e.Row.Cells[11].Text);
                //    e.Row.Cells[11].Text = workstatus(num);
                //    e.Row.Cells[11].BackColor = statusColor(num);
                //}

                //if (!String.IsNullOrEmpty(e.Row.Cells[12].Text))
                //{
                //    int num = Convert.ToInt32(e.Row.Cells[12].Text);
                //    e.Row.Cells[12].Text = workstatus(num);
                //    e.Row.Cells[12].BackColor = statusColor(num);
                //}

                //Response.Write(e.Row.Cells[8].Text +"c8");
                //Response.Write(e.Row.Cells[9].Text +"c9");

                //the checked box item

                //if (showtechnote.Checked == false)
                //    GridView1.Columns[9].Visible = false;
                //else if (showtechnote.Checked == true)
                //    GridView1.Columns[9].Visible = true;

                //if (showsales.Checked == false)
                //    GridView1.Columns[7].Visible = false;
                //else if (showsales.Checked == true)
                //    GridView1.Columns[7].Visible = true;


                //if (showsupportteam.Checked == false)
                //    GridView1.Columns[8].Visible = false;
                //else if (showsupportteam.Checked == true)
                //    GridView1.Columns[8].Visible = true;


                //if (showinstruction.Checked == false)
                //    GridView1.Columns[10].Visible = false;
                //else if (showinstruction.Checked == true)
                //    GridView1.Columns[10].Visible = true;

                //if (showfaq.Checked == false)
                //    GridView1.Columns[11].Visible = false;
                //else if (showfaq.Checked == true)
                //    GridView1.Columns[11].Visible = true;

                //if (showallcompany.Checked == false)
                //    GridView1.Columns[12].Visible = false;
                //else if (showallcompany.Checked == true)
                //    GridView1.Columns[12].Visible = true;

                //if (showother.Checked == false)
                //    GridView1.Columns[13].Visible = false;
                //else if (showother.Checked == true)
                //    GridView1.Columns[13].Visible = true;

                //Response.Write(e.Row.Cells[1].Text);
                string QueryString = "~/Detail/DetailCase2.aspx?id=" + e.Row.Cells[1].Text;
                string NavigateURL = ResolveUrl(QueryString);
                e.Row.Attributes.Add("onClick", string.Format("window.open('{0}')", NavigateURL));
                e.Row.Style.Add("cursor", "pointer");

                try
                {
                    Support support = new Support();
                    Support personnel = new Support();
                    int rid = Convert.ToInt32(e.Row.Cells[1].Text);
                    var cases = from c in support.Incidents
                                where c.id == rid
                                select new
                                {
                                    c.allcompany,
                                    c.model,
                                    c.description,
                                    c.enddate,
                                    c.faq,
                                    c.instruction,
                                    c.lastupdatedate,
                                    c.other,
                                    c.reportdate,
                                    c.sales,
                                    c.supportteam,
                                    c.technote,
                                    c.handler,
                                    c.drafter,
                                    c.parent,
                                };
                    //description
                    if (cases.FirstOrDefault().description != null)
                    {
                        //if (Encoding.GetEncoding("utf-8").GetBytes(cases.FirstOrDefault().description).Length > 30)
                        //{
                        //    e.Row.Cells[3].Text = cases.FirstOrDefault().description.Substring(0, 30) + "...";
                        //}
                    }
                    if (cases.FirstOrDefault().model != null)
                    {
                        //interface and cord
                        using (Support mod = new Support())
                        {
                            var par = (from c in support.Incidents
                                       where c.id == cases.FirstOrDefault().parent
                                       select c).FirstOrDefault();

                            if (par != null)
                            {
                                using (Support s = new Support())
                                {
                                    int par_mod = par.model.Value;

                                    var target = (from x in s.models
                                                  where x.id == par_mod
                                                  select x).FirstOrDefault();

                                    var ca = (from c in s.Incidents
                                              where c.id == rid
                                              select c).FirstOrDefault();

                                    if (ca.model != par_mod)
                                    {
                                        ca.model = par_mod;
                                        s.SaveChanges();
                                    }
                                }
                            }

                            System.Web.UI.WebControls.Image img = e.Row.FindControl("ImageInterface") as System.Web.UI.WebControls.Image;
                            var option = (from o in support.models
                                          where o.id == cases.FirstOrDefault().model
                                          select o).FirstOrDefault();
                            utils u = new utils();

                            img.ImageUrl = u.interfaceUntil(option._interface);

                            Label lbCord = e.Row.FindControl("TextBoxCord") as Label;
                            lbCord.Text = option.cord;
                        }
                    }
                    //drafter
                    List<int> all_person = (from x in personnel.people select x.id).ToList();
                    if (!all_person.Contains(Convert.ToInt32(cases.FirstOrDefault().drafter.ToString())))
                    {
                        e.Row.Cells[5].Text = "No drafter...";
                    }
                    else
                    {
                        int d = cases.FirstOrDefault().drafter;
                        var p_query = from p in personnel.people where p.id == d select p;
                        e.Row.Cells[5].Text = p_query.FirstOrDefault().lastname + " " + p_query.FirstOrDefault().firstname;
                    }

                    //report
                    //all company
                    if (cases.FirstOrDefault().allcompany == 1)
                    {
                        (e.Row.Cells[6].FindControl("list_allcompany") as Label).Visible = true;
                        (e.Row.Cells[6].FindControl("list_allcompany") as Label).ForeColor = statusColor(1);
                    }
                    else if (cases.FirstOrDefault().allcompany == 2)
                    {
                        (e.Row.Cells[6].FindControl("list_allcompany") as Label).Visible = true;
                        (e.Row.Cells[6].FindControl("list_allcompany") as Label).ForeColor = statusColor(2);
                    }
                    //all company
                    if (cases.FirstOrDefault().sales == 1)
                    {
                        (e.Row.Cells[6].FindControl("list_sales") as Label).Visible = true;
                        (e.Row.Cells[6].FindControl("list_sales") as Label).ForeColor = statusColor(1);
                    }
                    else if (cases.FirstOrDefault().sales == 2)
                    {
                        (e.Row.Cells[6].FindControl("list_sales") as Label).Visible = true;
                        (e.Row.Cells[6].FindControl("list_sales") as Label).ForeColor = statusColor(2);
                    }
                    //instruction
                    if (cases.FirstOrDefault().instruction == 1)
                    {
                        (e.Row.Cells[6].FindControl("list_instruction") as Label).Visible = true;
                        (e.Row.Cells[6].FindControl("list_instruction") as Label).ForeColor = statusColor(1);
                    }
                    else if (cases.FirstOrDefault().instruction == 2)
                    {
                        (e.Row.Cells[6].FindControl("list_instruction") as Label).Visible = true;
                        (e.Row.Cells[6].FindControl("list_instruction") as Label).ForeColor = statusColor(2);
                    }

                    //tech note
                    if (cases.FirstOrDefault().technote == 1)
                    {
                        (e.Row.Cells[6].FindControl("list_technote") as Label).Visible = true;
                        (e.Row.Cells[6].FindControl("list_technote") as Label).ForeColor = statusColor(1);
                    }
                    else if (cases.FirstOrDefault().technote == 2)
                    {
                        (e.Row.Cells[6].FindControl("list_technote") as Label).Visible = true;
                        (e.Row.Cells[6].FindControl("list_technote") as Label).ForeColor = statusColor(2);
                    }

                    //support team
                    if (cases.FirstOrDefault().supportteam == 1)
                    {
                        (e.Row.Cells[6].FindControl("list_supportteam") as Label).Visible = true;
                        (e.Row.Cells[6].FindControl("list_supportteam") as Label).ForeColor = statusColor(1);
                    }
                    else if (cases.FirstOrDefault().supportteam == 2)
                    {
                        (e.Row.Cells[6].FindControl("list_supportteam") as Label).Visible = true;
                        (e.Row.Cells[6].FindControl("list_supportteam") as Label).ForeColor = statusColor(2);
                    }
                    //faq
                    if (cases.FirstOrDefault().faq == 1)
                    {
                        (e.Row.Cells[6].FindControl("list_faq") as Label).Visible = true;
                        (e.Row.Cells[6].FindControl("list_faq") as Label).ForeColor = statusColor(1);
                    }
                    else if (cases.FirstOrDefault().faq == 2)
                    {
                        (e.Row.Cells[6].FindControl("list_faq") as Label).Visible = true;
                        (e.Row.Cells[6].FindControl("list_faq") as Label).ForeColor = statusColor(2);
                    }

                    if(cases.FirstOrDefault().enddate > cases.FirstOrDefault().reportdate)
                    {
                        e.Row.BorderStyle = BorderStyle.Solid;
                        e.Row.BorderColor = Color.DarkGray;
                    }

                    //if (!String.IsNullOrEmpty(e.Row.Cells[8].Text))
                    //{
                    //    int num = Convert.ToInt32(e.Row.Cells[8].Text);
                    //    e.Row.Cells[8].Text = workstatus(num);
                    //    e.Row.Cells[8].BackColor = statusColor(num);
                    //}

                    //if (!String.IsNullOrEmpty(e.Row.Cells[9].Text))
                    //{
                    //    int num = Convert.ToInt32(e.Row.Cells[9].Text);
                    //    e.Row.Cells[9].Text = workstatus(num);
                    //    e.Row.Cells[9].BackColor = statusColor(num);
                    //}

                    //if (!String.IsNullOrEmpty(e.Row.Cells[10].Text))
                    //{
                    //    int num = Convert.ToInt32(e.Row.Cells[10].Text);
                    //    e.Row.Cells[10].Text = workstatus(num);
                    //    e.Row.Cells[10].BackColor = statusColor(num);
                    //}

                    //if (!String.IsNullOrEmpty(e.Row.Cells[11].Text))
                    //{
                    //    int num = Convert.ToInt32(e.Row.Cells[11].Text);
                    //    e.Row.Cells[11].Text = workstatus(num);
                    //    e.Row.Cells[11].BackColor = statusColor(num);
                    //}

                    //if (!String.IsNullOrEmpty(e.Row.Cells[12].Text))
                    //{
                    //    int num = Convert.ToInt32(e.Row.Cells[12].Text);
                    //    e.Row.Cells[12].Text = workstatus(num);
                    //    e.Row.Cells[12].BackColor = statusColor(num);

                    /*
                    //handler
                    List<int> all_members = (from x in personnel.members select x.id).ToList();
                    if (cases.FirstOrDefault().handler != null)
                    {
                        if (!all_members.Contains(Convert.ToInt32(cases.FirstOrDefault().handler.ToString())))
                        {
                            e.Row.Cells[7].Text = "No handler";
                        }
                        else
                        {
                            int mem = Convert.ToInt32(cases.FirstOrDefault().handler.ToString());
                            var m_query = from me in personnel.people
                                          join m in personnel.members
                                              on me.id equals m.person
                                          where m.id == mem
                                          select me;
                            e.Row.Cells[7].Text = m_query.FirstOrDefault().lastname + " " + m_query.FirstOrDefault().firstname; ;
                        }
                    }
                    else
                    {
                        e.Row.Cells[7].Text = "No handler...";
                    }
                    */

                    ////files
                    //List<int> all_files = (from x in support.Files select x.incident).ToList();
                    //if (!all_files.Contains(Convert.ToInt32(rid)))
                    //{
                    //    e.Row.Cells[14].Text = "No attachment";
                    //}
                    //else
                    //{
                    //    var f_query = from f in support.Files
                    //                  where f.incident == rid
                    //                  select f.name;
                    //    e.Row.Cells[14].Text = f_query.FirstOrDefault().ToString();
                    //}

                    //action
                    if (!actnum.ContainsKey(Convert.ToInt32(rid)))
                    {
                        e.Row.Cells[7].Text = "N/A";
                    }
                    else
                    {
                        e.Row.Cells[7].Text = actnum[rid].ToString();
                    }

                    e.Row.Cells[1].Visible = false;
                }


                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView _gridView = (GridView)sender;
            GridViewRow row = GridView1.SelectedRow;

            // Get the selected index and the command name
            string _commandName = e.CommandName;

            if (_commandName == "DoubleClick")
            {
                int id = Int32.Parse(e.CommandArgument.ToString());
                try
                {
                    if (id >= 0)
                    {

                        Response.Redirect("~/Detail/DetailCase2.aspx?id=" + id);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('~/Detail/DetailRole2.aspx?id='" + id + ",'_newtab');", true);
                    }
                }

                catch
                {
                    Response.Write(GridView1.SelectedIndex + "  " + id);
                }
            }
        }


        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow r in GridView1.Rows)
            {
                if (r.RowType == DataControlRowType.DataRow)
                {
                    Page.ClientScript.RegisterForEventValidation
                            (r.UniqueID + "$ctl01");
                }
            }

            base.Render(writer);
        }

        private string workstatus(int option)
        {
            switch (option)
            {
                case 0:
                    return "no need";
                case 1:
                    return "not yet finished";
                case 2:
                    return "finished";
                default:
                    return "wrong value";
            }
        }

        private Color statusColor(int option)
        {
            switch (option)
            {
                case 0:
                    return Color.White;
                case 1:
                    return Color.Brown;
                case 2:
                    return Color.ForestGreen;
                default:
                    return Color.White;
            }
        }

        //protected void showtechnote_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (showtechnote.Checked == false)
        //        GridView1.Columns[9].Visible = false;
        //    else if (showtechnote.Checked == true)
        //        GridView1.Columns[9].Visible = true;
        //}

        //protected void showsales_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (showsales.Checked == false)
        //        GridView1.Columns[7].Visible = false;
        //    else if (showsales.Checked == true)
        //        GridView1.Columns[7].Visible = true;
        //}

        //protected void showsupportteam_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (showsupportteam.Checked == false)
        //        GridView1.Columns[8].Visible = false;
        //    else if (showsupportteam.Checked == true)
        //        GridView1.Columns[8].Visible = true;
        //}

        //protected void showinstruction_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (showinstruction.Checked == false)
        //        GridView1.Columns[10].Visible = false;
        //    else if (showinstruction.Checked == true)
        //        GridView1.Columns[10].Visible = true;
        //}

        //protected void showfaq_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (showfaq.Checked == false)
        //        GridView1.Columns[11].Visible = false;
        //    else if (showfaq.Checked == true)
        //        GridView1.Columns[11].Visible = true;
        //}

        //protected void showallcompany_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (showallcompany.Checked == false)
        //        GridView1.Columns[12].Visible = false;
        //    else if (showallcompany.Checked == true)
        //        GridView1.Columns[12].Visible = true;
        //}

        //protected void showother_CheckedChanged(object sender, EventArgs e)
        //{
        //    if (showother.Checked == false)
        //        GridView1.Columns[13].Visible = false;
        //    else if (showother.Checked == true)
        //        GridView1.Columns[13].Visible = true;
        //}

        protected void Case_pageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Case_pageSize.SelectedValue == "50")
            {
                GridView1.PageSize = 50;
            }
            else if (Case_pageSize.SelectedValue == "100")
            {
                GridView1.PageSize = 100;
            }
            else if (Case_pageSize.SelectedValue == "200")
            {
                GridView1.PageSize = 200;
            }
        }

        private float GetWidthOfString(string str)
        {
            Bitmap objBitmap = default(Bitmap);
            Graphics objGraphics = default(Graphics);

            objBitmap = new Bitmap(500, 200);
            objGraphics = Graphics.FromImage(objBitmap);

            SizeF stringSize = objGraphics.MeasureString(str, new Font("Arial", 12));

            objBitmap.Dispose();
            objGraphics.Dispose();
            return stringSize.Width;
        }

        protected void GridView1_SelectedIndexChanged1(object sender, EventArgs e)
        {

        }

        //protected void GridView1_Sorting(object sender, GridViewSortEventArgs e)
        //{
        //    // Cancel the sorting operation if the user attempts
        //    // to sort by address.
        //    if (e.SortExpression == "interface")
        //    {
        //        SqlDataSource1.SelectCommand = "SELECT * FROM [Incident] as i WHERE i.reportdate = i.enddate ORDER BY [reportdate] DESC";
        //        GridView1.DataBind();

        //    }
        //    else
        //    {

        //    }
        //}
    }
}
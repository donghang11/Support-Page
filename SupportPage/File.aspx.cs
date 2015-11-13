using SupportPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SupportPage
{
    public partial class File : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                if (Request.Cookies["Language"]["lang"] != null)
                {
                    string decoded_lang = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["Language"]["lang"]), "ProtectCookieLanguage"));
                    UICulture = decoded_lang;
                    Culture = Request.UserLanguages[0];
                }
                base.InitializeCulture();
            }

            catch
            {

            }

        }


        protected void FileSelect_Command(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            try
            {
                if (id >= 0)
                {
                    Response.Redirect("Detail/DetailFile2.aspx?id=" + id);
                }
            }

            catch
            {
                Response.Write(File_gridview.SelectedIndex + "  " + id);
            }
        }

        protected void File_gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView _gridView = (GridView)sender;
            GridViewRow row = File_gridview.SelectedRow;

            // Get the selected index and the command name
            string _commandName = e.CommandName;

            if (_commandName == "DoubleClick")
            {
                int id = Int32.Parse(e.CommandArgument.ToString());
                try
                {
                    if (id >= 0)
                    {

                        Response.Redirect("~/Detail/DetailFile2.aspx?id=" + id);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('~/Detail/DetailRole2.aspx?id='" + id + ",'_newtab');", true);
                    }
                }

                catch
                {
                    Response.Write(File_gridview.SelectedIndex + "  " + id);
                }
            }
        }

        protected void File_gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Get the LinkButton control in the first cell
                LinkButton _doubleClickButton = (LinkButton)e.Row.Cells[0].Controls[0].FindControl("FileDoubleClick");
                //Get the javascript which is assigned to this LinkButton
                string _jsDouble =
                ClientScript.GetPostBackClientHyperlink(_doubleClickButton, "");
                //Add this JavaScript to the ondblclick Attribute of the row
                e.Row.Attributes["ondblclick"] = _jsDouble;

                try
                {
                    Support support = new Support();
                    Support personnel = new Support();
                    int rid = Convert.ToInt32(e.Row.Cells[1].Text);
                    var files = from c in support.Files
                                where c.id == rid
                                select new
                                {
                                    c.incident,
                                    c.sender
                                };

                    //incident
                    List<int> all_files = (from x in support.Incidents select x.id).ToList();
                    if (!all_files.Contains(Convert.ToInt32(files.FirstOrDefault().incident.ToString())))
                    {
                        e.Row.Cells[3].Text = "No incidents...";
                    }
                    else
                    {
                        int i = files.FirstOrDefault().incident;
                        var p_query = from p in support.Incidents where p.id == i select p;
                        e.Row.Cells[3].Text = p_query.FirstOrDefault().description;
                    }

                    //handler
                    List<int> all_members = (from x in personnel.members select x.id).ToList();

                    if (!all_members.Contains(Convert.ToInt32(files.FirstOrDefault().sender.ToString())))
                    {
                        e.Row.Cells[4].Text = "No handler";
                    }
                    else
                    {
                        int mem = Convert.ToInt32(files.FirstOrDefault().sender.ToString());
                        var m_query = from me in personnel.people
                                      join m in personnel.members
                                          on me.id equals m.person
                                      where m.id == mem
                                      select me;
                        e.Row.Cells[4].Text = m_query.FirstOrDefault().lastname + " " + m_query.FirstOrDefault().firstname; ;
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

        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow r in File_gridview.Rows)
            {
                if (r.RowType == DataControlRowType.DataRow)
                {
                    Page.ClientScript.RegisterForEventValidation
                            (r.UniqueID + "$ctl20");
                }
            }

            base.Render(writer);
        }

        protected void File_pageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (File_pageSize.SelectedValue == "10")
            {
                 File_gridview.PageSize = 10;
            }
            else if (File_pageSize.SelectedValue == "20")
            {
                File_gridview.PageSize = 20;
            }
            else if (File_pageSize.SelectedValue == "100")
            {
                File_gridview.PageSize = 100;
            }
        }
    }
}
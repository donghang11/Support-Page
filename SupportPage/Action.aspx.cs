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
    public partial class Action : System.Web.UI.Page
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

        protected void act_but_add_Click(object sender, EventArgs e)
        {
            var res = base.Response;
            res.Redirect("~/Detail/DetailAction.aspx");
        }

        protected void ActionSelect_Command(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            try
            {
                if (id >= 0)
                {
                    Response.Redirect("Detail/DetailAction2.aspx?id=" + id);
                }
            }

            catch
            {
                Response.Write(Action_gridview.SelectedIndex + "  " + id);
            }
        }

        protected void ActionEdit_Command(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            try
            {
                if (id >= 0)
                {
                    Response.Redirect("Detail/DetailActionEdit.aspx?id=" + id);
                }
            }

            catch
            {
                Response.Write(Action_gridview.SelectedIndex + "  " + id);
            }
        }

        protected void Action_gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView _gridView = (GridView)sender;
            GridViewRow row = Action_gridview.SelectedRow;

            // Get the selected index and the command name
            string _commandName = e.CommandName;

            if (_commandName == "DoubleClick")
            {
                int id = Int32.Parse(e.CommandArgument.ToString());
                try
                {
                    if (id >= 0)
                    {

                        Response.Redirect("~/Detail/DetailAction2.aspx?id=" + id);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('~/Detail/DetailRole2.aspx?id='" + id + ",'_newtab');", true);
                    }
                }

                catch
                {
                    Response.Write(Action_gridview.SelectedIndex + "  " + id);
                }
            }
        }

        protected void Action_gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Get the LinkButton control in the first cell
                LinkButton _doubleClickButton = (LinkButton)e.Row.Cells[0].Controls[0].FindControl("ActionDoubleClick");
                //Get the javascript which is assigned to this LinkButton
                string _jsDouble =
                ClientScript.GetPostBackClientHyperlink(_doubleClickButton, "");
                //Add this JavaScript to the ondblclick Attribute of the row
                e.Row.Attributes["ondblclick"] = _jsDouble;

                try
                {
                    Support support = new Support();
                    int rid = Convert.ToInt32(e.Row.Cells[1].Text);
                    var actions = from a in support.Actions
                                where a.id == rid
                                select new
                                {
                                    a.incident
                                };

                    //incident
                    List<int> all_incidents = (from x in support.Incidents select x.id).ToList();
                    if (!all_incidents.Contains(Convert.ToInt32(actions.FirstOrDefault().incident.ToString())))
                    {
                        e.Row.Cells[3].Text = "No incidents...";
                    }
                    else
                    {
                        int i = actions.FirstOrDefault().incident;
                        var p_query = from p in support.Incidents where p.id == i select p;
                        e.Row.Cells[3].Text = p_query.FirstOrDefault().description;
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
            foreach (GridViewRow r in Action_gridview.Rows)
            {
                if (r.RowType == DataControlRowType.DataRow)
                {
                    Page.ClientScript.RegisterForEventValidation
                            (r.UniqueID + "$ctl20");
                }
            }

            base.Render(writer);
        }

        protected void Action_pageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Action_pageSize.SelectedValue == "10")
            {
                Action_gridview.PageSize = 10;
            }
            else if (Action_pageSize.SelectedValue == "20")
            {
                Action_gridview.PageSize = 20;
            }
            else if (Action_pageSize.SelectedValue == "100")
            {
                Action_gridview.PageSize = 100;
            }
        }
    }
}
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
    public partial class Role : System.Web.UI.Page
    {
        static string prevPage = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] != null)
            {
                string decoded_username = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["username"]), "ProtectCookieUsername"));
                string decoded_role = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["role"]), "ProtectCookieRole"));

                if (decoded_role == "admin")
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


            if (!IsPostBack)
            {
                if (prevPage == String.Empty)
                {
                    prevPage = Request.UrlReferrer.ToString();
                }
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

        protected void role_but_add_Click(object sender, EventArgs e)
        {
            var res = base.Response;
            res.Redirect("~/Detail/DetailRole.aspx");
        }

        protected void RoleSelect_Command(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            try
            {
                if (id >= 0)
                {
                    Response.Redirect("~/Detail/DetailRole2.aspx?id=" + id);
                }
            }

            catch
            {
                Response.Write(role_gridview.SelectedIndex + "  " + id);
            }
        }

        protected void RoleEdit_Command(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            try
            {
                if (id >= 0)
                {
                    Response.Redirect("~/Detail/DetailRoleEdit.aspx?id=" + id);
                }
            }

            catch
            {
                Response.Write(role_gridview.SelectedIndex + "  " + id);
            }
        }

        protected void role_gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Get the LinkButton control in the first cell
                LinkButton _doubleClickButton = (LinkButton)e.Row.Cells[0].Controls[0].FindControl("RoleDoubleClick");
                //Get the javascript which is assigned to this LinkButton
                string _jsDouble =
                ClientScript.GetPostBackClientHyperlink(_doubleClickButton, "");
                //Add this JavaScript to the ondblclick Attribute of the row
                e.Row.Attributes["ondblclick"] = _jsDouble;
            }
        }

        protected void role_gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView _gridView = (GridView)sender;
            GridViewRow row = role_gridview.SelectedRow;

            // Get the selected index and the command name
            string _commandName = e.CommandName;

            if (_commandName == "DoubleClick")
            {
                int id = Int32.Parse(e.CommandArgument.ToString());
                try
                {
                    if (id >= 0)
                    {

                        Response.Redirect("~/Detail/DetailRole2.aspx?id=" + id);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('~/Detail/DetailRole2.aspx?id='" + id + ",'_newtab');", true);
                    }
                }

                catch
                {
                    Response.Write(role_gridview.SelectedIndex + "  " + id);
                }
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow r in role_gridview.Rows)
            {
                if (r.RowType == DataControlRowType.DataRow)
                {
                    Page.ClientScript.RegisterForEventValidation
                            (r.UniqueID + "$ctl01");
                }
            }

            base.Render(writer);
        }

        protected void role_but_back_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        protected void Role_pageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Role_pageSize.SelectedValue == "10")
            {
                role_gridview.PageSize = 10;
            }
            else if (Role_pageSize.SelectedValue == "20")
            {
                role_gridview.PageSize = 20;
            }
            else if (Role_pageSize.SelectedValue == "100")
            {
                role_gridview.PageSize = 100;
            }
        }

    }
}
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
    public partial class Person : System.Web.UI.Page
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

        protected void person_but_add_Click(object sender, EventArgs e)
        {
            var res = base.Response;
            res.Redirect("~/Detail/DetailPerson.aspx");
        }

        protected void PersonSelect_Command(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            try
            {
                if (id >= 0)
                {
                    Response.Redirect("Detail/DetailPerson2.aspx?id=" + id);
                }
            }

            catch
            {
                Response.Write(person_gridview.SelectedIndex + "  " + id);
            }
        }

        protected void PersonEdit_Command(object sender, CommandEventArgs e)
        {
            int id = Int32.Parse(e.CommandArgument.ToString());
            try
            {
                if (id >= 0)
                {
                    Response.Redirect("Detail/DetailPersonEdit.aspx?id=" + id);
                }
            }

            catch
            {
                Response.Write(person_gridview.SelectedIndex + "  " + id);
            }
        }

        protected void person_gridview_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void person_gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Get the LinkButton control in the first cell
                LinkButton _doubleClickButton = (LinkButton)e.Row.Cells[0].Controls[0].FindControl("PersonDoubleClick");
                //Get the javascript which is assigned to this LinkButton
                string _jsDouble =
                ClientScript.GetPostBackClientHyperlink(_doubleClickButton, "");
                //Add this JavaScript to the ondblclick Attribute of the row
                e.Row.Attributes["ondblclick"] = _jsDouble;
            }
        }

        protected void person_gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView _gridView = (GridView)sender;
            GridViewRow row = person_gridview.SelectedRow;

            // Get the selected index and the command name
            string _commandName = e.CommandName;

            if (_commandName == "DoubleClick")
            {
                int id = Int32.Parse(e.CommandArgument.ToString());
                try
                {
                    if (id >= 0)
                    {

                        Response.Redirect("~/Detail/DetailPerson2.aspx?id=" + id);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('~/Detail/DetailRole2.aspx?id='" + id + ",'_newtab');", true);
                    }
                }

                catch
                {
                    Response.Write(person_gridview.SelectedIndex + "  " + id);
                }
            }
        }

        protected override void Render(HtmlTextWriter writer)
        {
            foreach (GridViewRow r in person_gridview.Rows)
            {
                if (r.RowType == DataControlRowType.DataRow)
                {
                    Page.ClientScript.RegisterForEventValidation
                            (r.UniqueID + "$ctl02");
                }
            }

            base.Render(writer);
        }

        protected void person_but_back_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        protected void Person_pageSize_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Person_pageSize.SelectedValue == "10")
            {
                person_gridview.PageSize = 10;
            }
            else if (Person_pageSize.SelectedValue == "20")
            {
                person_gridview.PageSize = 20;
            }
            else if (Person_pageSize.SelectedValue == "100")
            {
                person_gridview.PageSize = 100;
            }
        }

        protected void PersonShowOnlyActive_CheckedChanged(object sender, EventArgs e)
        {
            if (PersonShowOnlyActive.Checked == false)
            {
                person_gridview.DataBind();
            }
            else if (PersonShowOnlyActive.Checked == true)
            {
                PersonDataSource.SelectCommand = "SELECT  [id], [lastname], [firstname], [phone], [email] FROM [person] as p where p.ed > CURRENT_TIMESTAMP";
                person_gridview.DataBind();                
            }
        }


    }
}
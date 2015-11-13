using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseUtils;
using SupportPage.Models;
using System.Web.Security;
using System.Text;

namespace SupportPage
{
    public partial class DetailRole2 : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        static string name = null;
        static string desc = null;
        int id;

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

            id = Convert.ToInt32(Request.QueryString["id"]);



            if (!IsPostBack)
            {
                if (prevPage == String.Empty)
                {
                    prevPage = Request.UrlReferrer.ToString();
                }

                try
                {
                    Support personnel = new Support();
                    var roles = from r in personnel.roles
                                where r.id == id
                                select new
                                {
                                    r.name,
                                    r.description,                                    
                                };


                    //name
                    if (roles.FirstOrDefault().name != null)
                    {
                        name = roles.FirstOrDefault().name.ToString();
                        detailrole2_name.Text = name;
                    }
                    else
                    {
                        detailrole2_name.Text = "No name...";
                        name = "No name...";
                    }

                    //description
                    if (roles.FirstOrDefault().description != null)
                    {
                        desc = roles.FirstOrDefault().description.ToString();
                        detailrole2_description.Text = desc;
                    }
                    else
                    {
                        detailrole2_description.Text = "No description...";
                        desc = "No description...";
                    }

                }
                catch (Exception ex)
                {
                    Response.Write(ex);
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

        protected void detailcase2_btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

//        //Edit
//        protected void Unnamed1_Click(object sender, EventArgs e)
//        {
//            detailrole2_name.ReadOnly = false;
//            detailrole2_description.ReadOnly = false;
//            detailrole2_submit.Visible = true;
//            detailrole2_cancel.Visible = true;
//        }

//        //Submit
//        protected void Unnamed_Click(object sender, EventArgs e)
//        {

//            try
//            {
//                using (Support personnel = new Support())
//                {
//                    role target = (from x in personnel.roles
//                                         where x.id == id
//                                         select x).FirstOrDefault();
////Response.Write(detailrole2_name.Text + detailrole2_description.Text);

//                    target.name = detailrole2_name.Text;
//                    target.description = detailrole2_description.Text;
//                    personnel.SaveChanges();

//                }

////Response.Write(detailrole2_name.Text + detailrole2_description.Text);

//                detailrole2_name.ReadOnly = true;
//                detailrole2_description.ReadOnly = true;
//                detailrole2_submit.Visible = false;
//                detailrole2_cancel.Visible = false;
//            }
//            catch (System.Exception ex)
//            {
//                Response.Write(ex);
//            }

//        }

//        //cancel
//        protected void detailrole2_cancel_Click(object sender, EventArgs e)
//        {
//            detailrole2_name.ReadOnly = true;
//            detailrole2_description.ReadOnly = true;
//            detailrole2_submit.Visible = false;
//            detailrole2_cancel.Visible = false;
//            detailrole2_name.Text = name;
//            detailrole2_description.Text = desc;

//        }

        protected void detailrole2_delete_Click(object sender, EventArgs e)
        {
            using (Support p = new Support())
            {
                var target = (from x in p.roles
                              where x.id == id
                              select x).FirstOrDefault();
                p.roles.Remove(target);
                p.SaveChanges();
            }
            Response.Redirect(prevPage);
        }

        protected void detailrole2_member_gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView _gridView = (GridView)sender;
            GridViewRow row = detailrole2_member_gridview.SelectedRow;

            // Get the selected index and the command name
            string _commandName = e.CommandName;

            if (_commandName == "DoubleClick")
            {
                int member_id = Int32.Parse(e.CommandArgument.ToString());
                try
                {
                    if (id >= 0)
                    {

                        Response.Redirect("~/Detail/DetailMember2.aspx?id=" + member_id);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('~/Detail/DetailRole2.aspx?id='" + id + ",'_newtab');", true);
                    }
                }

                catch
                {
                    Response.Write(detailrole2_member_gridview.SelectedIndex + "  " + member_id);
                }
            }
        }

        protected void detailrole2_member_gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Get the LinkButton control in the first cell
                LinkButton _doubleClickButton = (LinkButton)e.Row.Cells[0].Controls[0].FindControl("DetailRoleMemberDBClick");
                //Get the javascript which is assigned to this LinkButton
                string _jsDouble =
                ClientScript.GetPostBackClientHyperlink(_doubleClickButton, "");
                //Add this JavaScript to the ondblclick Attribute of the row
                e.Row.Attributes["ondblclick"] = _jsDouble;

                e.Row.Cells[1].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }
        }

        protected void detailrole2_name_TextChanged(object sender, EventArgs e)
        {
              try
              {
                using (Support personnel = new Support())
                {
                    role target = (from x in personnel.roles
                                         where x.id == id
                                         select x).FirstOrDefault();

                    target.name = detailrole2_name.Text;
                    personnel.SaveChanges();

                }
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void detailrole2_description_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (Support personnel = new Support())
                {
                    role target = (from x in personnel.roles
                                   where x.id == id
                                   select x).FirstOrDefault();

                    target.description = detailrole2_description.Text;
                    personnel.SaveChanges();

                }
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }

    }
}
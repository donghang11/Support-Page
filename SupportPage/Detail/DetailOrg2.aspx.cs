using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseUtils;
using SupportPage.Models;
using System.Text;
using System.Web.Security;

namespace SupportPage
{
    public partial class DetailOrg2 : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        static int id;
        static string name = null;
        static string desc = null;

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
                    var orgs = from o in personnel.orgs
                               where o.id == id
                               select new
                               {
                                   o.name,
                                   o.parent,
                                   o.description
                               };

                    //name              
                    if (!String.IsNullOrEmpty(orgs.FirstOrDefault().name))
                    {
                        name = orgs.FirstOrDefault().name.ToString();
                        detailorg2_name.Text = name;
                    }
                    else
                    {
                    }


                    //desc              
                    if (!String.IsNullOrEmpty(orgs.FirstOrDefault().description))
                    {
                        desc = orgs.FirstOrDefault().description.ToString();
                        detailorg2_desc.Text = desc;
                    }
                    else
                    {
         
         ;
                    }

                    //parent
                    if (orgs.FirstOrDefault().parent != null)
                    {
                        var parent = from p in personnel.orgs
                                     where p.id == (int)orgs.FirstOrDefault().parent
                                     select p;
                        detailorg2_parent.Text = parent.FirstOrDefault().name.ToString();
                    }
                    else
                    {
                        detailorg2_parent.Text = "No parent...";
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
                if (Request.Cookies["Language"]!= null)
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

        protected void detailorg2_btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        ////edit
        //protected void Unnamed_Click(object sender, EventArgs e)
        //{
        //    detailorg2_submit.Visible = true;
        //    detailorg2_cancel.Visible = true;
        //    detailorg2_name.ReadOnly = false;
        //    detailorg2_desc.ReadOnly = false;
        //}

        ////submit
        //protected void detailorg2_submit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        using (Support personnel = new Support())
        //        {
        //            org target = (from x in personnel.orgs
        //                                where x.id == id
        //                                select x).FirstOrDefault();


        //            target.name = detailorg2_name.Text;
        //            target.description = detailorg2_desc.Text;

        //            personnel.SaveChanges();
        //        }

        //        detailorg2_name.ReadOnly = true;
        //        detailorg2_desc.ReadOnly = true;
        //        detailorg2_submit.Visible = false;
        //        detailorg2_cancel.Visible = false;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Response.Write(ex);
        //    }
        //}

        ////cancel
        //protected void detailorg2_cancel_Click(object sender, EventArgs e)
        //{
        //    detailorg2_name.ReadOnly = true;
        //    detailorg2_desc.ReadOnly = true;
        //    detailorg2_submit.Visible = false;
        //    detailorg2_cancel.Visible = false;
        //    detailorg2_name.Text = name;
        //    detailorg2_desc.Text = desc;
        //}

        protected void detailorg2_delete_Click(object sender, EventArgs e)
        {
            using (Support p = new Support())
            {
                List<org> orgs = p.orgs.ToList();

                var target = (from x in p.orgs
                              where x.id == id
                              select x).FirstOrDefault();
                foreach(org o in orgs)
                {
                    if (o.parent == target.id)
                    {
                        Response.Write("This department has child department, to delete, please delete child department first...");
                        return;
                    }
                }
                p.orgs.Remove(target);
                p.SaveChanges();
            }
            Response.Redirect(prevPage);
        }

        protected void detailorg2_addchild_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Detail/detailorg?parent=" + id);
        }

        protected void detailorg2_member_gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView _gridView = (GridView)sender;
            GridViewRow row = detailorg2_member_gridview.SelectedRow;

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
                    Response.Write(detailorg2_member_gridview.SelectedIndex + "  " + member_id);
                }
            }
        }

        protected void detailorg2_member_gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                //Get the LinkButton control in the first cell
                LinkButton _doubleClickButton = (LinkButton)e.Row.Cells[0].Controls[0].FindControl("DetailOrgMemberDBClick");
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

        protected void detailorg2_desc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (Support personnel = new Support())
                {
                    org target = (from x in personnel.orgs
                                  where x.id == id
                                  select x).FirstOrDefault();


                    target.name = detailorg2_name.Text;                 
                    personnel.SaveChanges();
                }              
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void detailorg2_name_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (Support personnel = new Support())
                {
                    org target = (from x in personnel.orgs
                                  where x.id == id
                                  select x).FirstOrDefault();

                    target.description = detailorg2_desc.Text;
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
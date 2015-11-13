using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseUtils;
using SupportPage.Models;
using System.Globalization;
using System.Text;
using System.Web.Security;

namespace SupportPage
{
    public partial class DetailMember2 : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        static int id;

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
                    var member = from m in personnel.members
                                 where m.id == id
                                 select new
                                 {
                                     m.person,
                                     m.org,
                                     m.role,
                                     m.sd,
                                     m.ed
                                 };

                    List<int> all_person = (from x in personnel.people select x.id).ToList();
                    List<int> all_roles = (from x in personnel.roles select x.id).ToList();
                    List<int> all_orgs = (from x in personnel.orgs select x.id).ToList();

                    //start date
                    if (!DBNull.Value.Equals(member.FirstOrDefault().sd))
                    {
                        detailmember2_start_date.Text = member.FirstOrDefault().sd.ToString("D", CultureInfo.CreateSpecificCulture("ja-JP"));
                    }
                    else
                    {
                        detailmember2_start_date.Text = "";
                    }

                    //last name

                    if (!all_person.Contains(Convert.ToInt32(member.FirstOrDefault().person.ToString())))
                    {
                        detailmember2_lastname.Text = "";
                    }
                    else
                    {
                        var p_query = from p in personnel.people where p.id == member.FirstOrDefault().person select p;
                        detailmember2_lastname.Text = p_query.FirstOrDefault().lastname.ToString();
                    }


                    //first name

                    if (!all_person.Contains(Convert.ToInt32(member.FirstOrDefault().person.ToString())))
                    {
                        detailmember2_firstname.Text = "";
                    }
                    else
                    {
                        var p_query = from p in personnel.people where p.id == member.FirstOrDefault().person select p;
                        detailmember2_firstname.Text = p_query.FirstOrDefault().firstname.ToString();
                    }


                    //role

                    if (!all_roles.Contains(Convert.ToInt32(member.FirstOrDefault().role.ToString())))
                    {
                    }
                    else
                    {
                        var p_query = from p in personnel.roles where p.id == member.FirstOrDefault().role select p;
                        detailmember2_role.SelectedValue = p_query.FirstOrDefault().id.ToString();
                    }


                    //org

                    if (!all_orgs.Contains(Convert.ToInt32(member.FirstOrDefault().org.ToString())))
                    {
                    }
                    else
                    {
                        var p_query = from p in personnel.orgs where p.id == member.FirstOrDefault().org select p;
                        detailmember2_org.SelectedValue = p_query.FirstOrDefault().id.ToString();
                    }


                    //detactive
                    if (member.FirstOrDefault().ed < DateTime.Now)
                    {
                        detailmember2_active.SelectedValue = "1";
                    }
                    else
                    {
                        detailmember2_active.SelectedValue = "0";
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

        protected void detailmember2_btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        ////edit
        //protected void Unnamed_Click(object sender, EventArgs e)
        //{
        //    detailmember2_submit.Visible = true;
        //    detailmember2_cancel.Visible = true;
        //}

        ////submit
        //protected void detailmember2_submit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        using (Support personnel = new Support())
        //        {
        //            member target = (from x in personnel.members
        //                                where x.id == id
        //                                select x).FirstOrDefault();



        //            personnel.SaveChanges();
        //        }

        //        detailmember2_submit.Visible = false;
        //        detailmember2_cancel.Visible = false;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Response.Write(ex);
        //    }
        //}
        ////cancel
        //protected void detailmember2_cancel_Click(object sender, EventArgs e)
        //{

        //    detailmember2_submit.Visible = false;
        //    detailmember2_cancel.Visible = false;
        //}

        protected void detailMember2_delete_Click(object sender, EventArgs e)
        {
            using (Support p = new Support())
            {
                var target = (from x in p.members
                              where x.id == id
                              select x).FirstOrDefault();
                p.members.Remove(target);
                p.SaveChanges();
            }
            Response.Redirect(prevPage);
        }

        protected void detailmember2_active_SelectedIndexChanged(object sender, EventArgs e)
        {
            using (Support personnel = new Support())
            {
                member target = (from x in personnel.members
                                       where x.id == id
                                       select x).FirstOrDefault();

                if (detailmember2_active.SelectedValue == "0")
                {
                    target.ed = new DateTime(3000, 1, 1);
                }
                else if (detailmember2_active.SelectedValue == "1")
                {
                    target.ed = DateTime.Now;
                }

                personnel.SaveChanges();
            }
        }

        protected void detailmember2_org_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (Support personnel = new Support())
                {
                    member target = (from x in personnel.members
                                     where x.id == id
                                     select x).FirstOrDefault();

                    target.org = Convert.ToInt32(detailmember2_org.SelectedValue.ToString());
                    personnel.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void detailmember2_role_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                using (Support personnel = new Support())
                {
                    member target = (from x in personnel.members
                                     where x.id == id
                                     select x).FirstOrDefault();

                    target.role = Convert.ToInt32(detailmember2_role.SelectedValue.ToString());
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
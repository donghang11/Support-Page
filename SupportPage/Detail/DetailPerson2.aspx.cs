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
using System.Web.Security;
using System.Text;

namespace SupportPage
{
    public partial class DetailPerson2 : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        static string lastname = null;
        static string firstname = null;
        static string phone = null;
        static string email = null;
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
                    var person = from p in personnel.people
                                 where p.id == id
                                 select new
                                 {
                                     p.firstname,
                                     p.sd,
                                     p.ed,
                                     p.lastname,
                                     p.phone,
                                     p.email
                                 };

                    //last name
                    if (!String.IsNullOrEmpty(person.FirstOrDefault().lastname))
                    {
                        lastname = person.FirstOrDefault().lastname.ToString();
                        detailperson2_lastname.Text = lastname;
                    }
                    else
                    {
                        detailperson2_lastname.Text = "No name...";
                    }

                    //first name
                    if (!String.IsNullOrEmpty(person.FirstOrDefault().firstname))
                    {
                        firstname = person.FirstOrDefault().firstname.ToString();
                        detailperson2_firstname.Text = firstname;
                    }
                    else
                    {
                        detailperson2_firstname.Text = "No name...";
                    }

                    //Phone
                    if (!String.IsNullOrEmpty(person.FirstOrDefault().phone))
                    {
                        phone = person.FirstOrDefault().phone.ToString();
                        detailperson2_phone.Text = phone;
                    }
                    else
                    {
                        phone = "No phone...";
                        detailperson2_phone.Text = phone;
                    }

                    //Email
                    if (!String.IsNullOrEmpty(person.FirstOrDefault().email))
                    {
                        email = person.FirstOrDefault().email.ToString();
                        detailperson2_email.Text = email;
                    }
                    else
                    {
                        email = "No email...";
                        detailperson2_email.Text = email;
                    }

                    //start date
                    if (person.FirstOrDefault().sd != null)
                    {
                        detailperson2_start_date.Text = person.FirstOrDefault().sd.ToString("MM/dd/yyyy");
                    }
                    else
                    {
                        detailperson2_start_date.Text = "No...";
                    }


                    //detactive
                    if (person.FirstOrDefault().ed < DateTime.Now)
                    {
                        detailperson2_active.SelectedValue = "1";
                    }
                    else
                    {
                        detailperson2_active.SelectedValue = "0";
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

        protected void detailperson2_btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        ////edit
        //protected void Unnamed1_Click(object sender, EventArgs e)
        //{
        //    detailperson2_submit.Visible = true;
        //    detailperson2_cancel.Visible = true;
        //    detailperson2_lastname.ReadOnly = false;
        //    detailperson2_firstname.ReadOnly = false;
        //    detailperson2_email.ReadOnly = false;
        //    detailperson2_phone.ReadOnly = false;
        //}

        ////submit
        //protected void detailperson2_submit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        using (Support personnel = new Support())
        //        {
        //            person target = (from x in personnel.people
        //                                   where x.id == id
        //                                   select x).FirstOrDefault();

        //            target.firstname = detailperson2_firstname.Text;
        //            target.email = detailperson2_email.Text;
        //            target.lastname = detailperson2_lastname.Text;
        //            target.phone = detailperson2_phone.Text;

        //            personnel.SaveChanges();
        //        }

        //        detailperson2_submit.Visible = false;
        //        detailperson2_cancel.Visible = false;
        //        detailperson2_lastname.ReadOnly = true;
        //        detailperson2_firstname.ReadOnly = true;
        //        detailperson2_email.ReadOnly = true;
        //        detailperson2_phone.ReadOnly = true;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Response.Write(ex);
        //    }
        //}

        ////cancel
        //protected void detailperson2_cancel_Click(object sender, EventArgs e)
        //{
        //    detailperson2_lastname.ReadOnly = true;
        //    detailperson2_firstname.ReadOnly = true;
        //    detailperson2_email.ReadOnly = true;
        //    detailperson2_phone.ReadOnly = true;
        //    detailperson2_submit.Visible = false;
        //    detailperson2_cancel.Visible = false;
        //    detailperson2_firstname.Text = firstname;
        //    detailperson2_lastname.Text = lastname;
        //    detailperson2_phone.Text = phone;
        //    detailperson2_email.Text = email;

        //}

        //set member
        protected void Unnamed_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Detail/DetailMember.aspx?person=" + id);
        }

        protected void detailperson2_delete_Click(object sender, EventArgs e)
        {
            using (Support p = new Support())
            {
                var target = (from x in p.people
                              where x.id == id
                              select x).FirstOrDefault();
                p.people.Remove(target);
                p.SaveChanges();
            }
            Response.Redirect(prevPage);
        }

        //active
        protected void detailperson2_active_SelectedIndexChanged(object sender, EventArgs e)
        {

            using (Support personnel = new Support())
            {
                person target = (from x in personnel.people
                                 where x.id == id
                                 select x).FirstOrDefault();

                if (detailperson2_active.SelectedValue == "0")
                {
                    target.ed = new DateTime(3000, 1, 1);
                }
                else if (detailperson2_active.SelectedValue == "1")
                {
                    target.ed = DateTime.Now;
                }

                personnel.SaveChanges();
            }
        }

        protected void detailperson2_lastname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (Support personnel = new Support())
                {
                    person target = (from x in personnel.people
                                     where x.id == id
                                     select x).FirstOrDefault();

                    target.lastname = detailperson2_lastname.Text;
                    personnel.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void detailperson2_firstname_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (Support personnel = new Support())
                {
                    person target = (from x in personnel.people
                                     where x.id == id
                                     select x).FirstOrDefault();

                    target.firstname = detailperson2_firstname.Text;
                    personnel.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void detailperson2_phone_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (Support personnel = new Support())
                {
                    person target = (from x in personnel.people
                                     where x.id == id
                                     select x).FirstOrDefault();

                    target.phone = detailperson2_phone.Text;
                    personnel.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void detailperson2_email_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (Support personnel = new Support())
                {
                    person target = (from x in personnel.people
                                     where x.id == id
                                     select x).FirstOrDefault();

                    target.email = detailperson2_email.Text;
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
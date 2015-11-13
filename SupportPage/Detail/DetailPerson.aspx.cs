using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SupportPage.Models;
using System.Text;
using System.Web.Security;

namespace SupportPage
{
    public partial class DetailPerson : System.Web.UI.Page
    {

        static string prevPage = String.Empty;
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

        //back
        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        //submit
        protected void Unnamed4_Click(object sender, EventArgs e)
        {

            TextBox startDate = detailperson_startdate;

            try
            {
                person person = new person()
                {
                    lastname = detailperson_lastname.Text,
                    firstname = detailperson_firstname.Text,
                    phone = detailperson_phone.Text,
                    email = detailperson_email.Text,
                    sd = DateTime.Parse(startDate.Text),
                    ed = new DateTime(3000, 1, 1)
                };

                Support p = new Support();
                p.people.Add(person);
                p.SaveChanges();

                Response.Redirect(prevPage);
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }

    }
}
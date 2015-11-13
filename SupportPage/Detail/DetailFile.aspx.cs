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

    public partial class DetailFile : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        static string person_id;
        static int case_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] != null)
            {
                case_id = Convert.ToInt32(Request.QueryString["case_id"]);
                string decoded_username = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["username"]), "ProtectCookieUsername"));
                string decoded_role = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["role"]), "ProtectCookieRole"));
                person_id = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["person"]), "ProtectCookiePerson"));

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

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {

            try
            {
                file_model file = new file_model()
                {
                    name = detailfile_name.Text,
                    fpath = detailfile_path.Text,
                    dt = DateTime.Now,
                    sender = Convert.ToInt32(person_id), 
                    incident = case_id,
                    note = detailfile_note.Text          
                };

                Support s = new Support();
                s.Files.Add(file);
                s.SaveChanges();

                Response.Redirect(prevPage);
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}
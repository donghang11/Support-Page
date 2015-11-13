using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SupportPage.Models;
using System.Text;
using System.Web.Security;
using System.Collections.Generic;

namespace SupportPage.Account
{
    public partial class ResetPassword : Page
    {
        static string decoded_username;
        protected string StatusMessage
        {
            get;
            private set;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] != null)
            {
                decoded_username = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["username"]), "ProtectCookieUsername"));
                reset_username.Text = "User name: " + decoded_username;
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

        protected void Reset_Click(object sender, EventArgs e)
        {
            user users = new user();

            Support user_model = new Support();

            List<string> all_users = (from x in user_model.users select x.username).ToList();
            var valid = (from v in user_model.users
                         where v.username == decoded_username
                         select v).FirstOrDefault();

            if (valid.password == Password.Text)
            {

                if (NewPassword.Text == ConfirmPassword.Text)
                {

                    valid.password = ConfirmPassword.Text;
                    user_model.SaveChanges();
                    if (HttpContext.Current.Request.Cookies["user"] != null)
                    {
                        HttpCookie aCookie = HttpContext.Current.Request.Cookies["user"];
                        aCookie.Expires = DateTime.Now.AddDays(-10);
                        aCookie.Value = "";
                        HttpContext.Current.Response.Cookies.Add(aCookie);
                    }
                    Response.Redirect("~/Account/ResetPasswordConfirmation");
                    return;
                }
            }
            else
            {
                ErrorMessage.Text = "Wrong Password";
            }

        }
    }
}
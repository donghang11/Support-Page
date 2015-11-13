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
    public partial class Language : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    string decoded_lang = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["Language"]["lang"]), "ProtectCookieLanguage"));
                    lang.SelectedValue = decoded_lang;
                }

                catch
                {

                }
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


        protected void lang_submit_Click(object sender, EventArgs e)
        {
//Response.Write(lang.SelectedValue);
            var encoded_lang = Convert.ToBase64String(MachineKey.Protect(Encoding.UTF8.GetBytes(lang.SelectedValue), "ProtectCookieLanguage"));

            if (HttpContext.Current.Request.Cookies["Language"] != null)
            {
                HttpCookie aCookie = HttpContext.Current.Request.Cookies["Language"];
                aCookie["lang"] = encoded_lang;
                HttpContext.Current.Response.Cookies.Add(aCookie);
            }
            else
            {
                HttpCookie cookie = new HttpCookie("Language");
                cookie.Expires = DateTime.Now.AddDays(1000);
                cookie["lang"] = encoded_lang;
                Response.Cookies.Add(cookie);
            }
            //refresh page
            Response.Redirect(Request.RawUrl);
        }
    }
}
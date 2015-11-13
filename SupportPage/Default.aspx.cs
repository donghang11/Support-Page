using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;
using SupportPage.Models;
using System.Web.Security;

namespace SupportPage
{
    public partial class Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                string decoded_username = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["username"]), "ProtectCookieUsername"));
                string decoded_role = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["role"]), "ProtectCookieRole"));

                if (decoded_role == "support")
                {
                    if (Request.QueryString["home"] == "1")
                    {

                    }
                    else if (Request.QueryString["fromcase"] == null)
                    {
                        Response.Redirect("Case.aspx");
                    }
                }
            }
            catch
            {
                //if (HttpContext.Current.Request.Cookies["user"] != null)
                //{
                //    //Response.Write("inside if");
                //    HttpCookie aCookie = HttpContext.Current.Request.Cookies["user"];
                //    aCookie.Expires = DateTime.Now.AddDays(-10);
                //    aCookie.Value = "";
                //    HttpContext.Current.Response.Cookies.Add(aCookie);
                //}
                //Response.Redirect("~/");
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

    }
}
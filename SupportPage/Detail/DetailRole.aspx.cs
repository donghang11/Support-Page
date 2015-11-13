using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SupportPage.Models;
using System.Data.SqlClient;
using System.Web.Security;
using System.Text;

namespace SupportPage
{
    public partial class DetailRole : System.Web.UI.Page
    {
        static string prevPage = String.Empty;

        protected void Page_Load(object sender, EventArgs e)
        {
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

        //submit
        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            try
            {
                role role = new role()
               {
                   name = detailrole_name.Text,
                   description = detailrole_desc.Text,

               };

                Support p = new Support();
                p.roles.Add(role);
                p.SaveChanges();

                Response.Redirect(prevPage);
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }

        //cancel
        protected void Unnamed1_Click1(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }
    }
}
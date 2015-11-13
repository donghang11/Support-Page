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
    public partial class DetailMember : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        static int person_id;

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

            person_id = Convert.ToInt32(Request.QueryString["person"]);

            //to avoid duplication in dropdown lists
            if (IsPostBack)
            {
                detailmember_role.DataSourceID = "";
                Items.Clear();

                detailmember_org.DataSourceID = "";
                Items.Clear();
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

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Detail/DetailPerson2?id=" + person_id);
        }

        //submit
        protected void Unnamed4_Click(object sender, EventArgs e)
        {
            DateTime startDate = DateTime.Parse(detailmember_startdate.Text);
            DateTime endDate = new DateTime(3000, 1, 1);
            Support support = new Support();

            try
            {
                member member = new member()
                {
                    person = person_id,
                    sd = startDate,
                    ed = endDate,
                    org = Convert.ToInt32(detailmember_org.SelectedValue.ToString()),
                    role = Convert.ToInt32(detailmember_role.SelectedValue.ToString())
                };

                Support p = new Support();
                p.members.Add(member);
                p.SaveChanges();

                Response.Redirect("~/Admin/Member");
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }
    }
}
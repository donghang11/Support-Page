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

    public partial class DetailAction : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        static int case_id;
        static string person_id;
        protected void Page_Load(object sender, EventArgs e)
        {
            case_id = Convert.ToInt32(Request.QueryString["case_id"]);

            if (Request.Cookies["user"] != null)
            {
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

            //to avoid duplication in dropdown lists
            if (IsPostBack)
            {
                detailaction_receiver.DataSourceID = "";
                detailaction_sender.DataSourceID = "";
                Items.Clear();
            }

            if (!IsPostBack)
            {
                if (prevPage == String.Empty)
                {
                    prevPage = Request.UrlReferrer.ToString();
                }

            }

            detailaction_sender.AppendDataBoundItems = true;
            detailaction_receiver.AppendDataBoundItems = true;

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

        //cancel
        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        //submit
        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            try
            {
                action_model action = new action_model()
                {
                    dt = DateTime.Now,
                    incident = case_id,
                    description = detailaction_desc.Text,
                };

                if (detailaction_receiver.SelectedValue != "")
                {
                    action.sender = Convert.ToInt32(detailaction_sender.SelectedValue.ToString());
                }

                //if (detailaction_receiver.SelectedValue != "")
                //{
                //    action.receiver = Convert.ToInt32(detailaction_receiver.SelectedValue.ToString());
                //}

                Support s = new Support();
                s.Actions.Add(action);
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
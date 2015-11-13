using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SupportPage.Models;
using System.Web.Security;
using System.Text;

namespace SupportPage
{
    public partial class DetailOrg : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        static int? parent_id = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            //to avoid duplication in dropdown lists
            //if (IsPostBack)
            //{
            //    detailorg_parent.DataSourceID = "";
            //    Items.Clear();
            //}

            if (!IsPostBack)
            {
                if (prevPage == String.Empty)
                {
                    prevPage = Request.UrlReferrer.ToString();
                }
            }

            if (Request.QueryString["parent"] != null)
            {
                parent_id = Convert.ToInt32(Request.QueryString["parent"]);
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

        //cancel
        protected void Unnamed1_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        //submit
        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            //int  parent;
            //Support s = new Support();

            //      if (detailorg_parent.SelectedValue == "")            
            //      {
            //          try
            //          {
            //              org_model orgs = new org_model()
            //              {
            //                  name = detailorg_name.Text,
            //                  parent = null
            //              };

            //   //s.orgs.Add(orgs);
            //              s.SaveChanges();

            //              Response.Redirect(prevPage);
            //          }
            //          catch (System.Exception ex)
            //          {
            //              Response.Write(ex);
            //          }
            //      }

            //      else
            //      {
            //          parent = Convert.ToInt32(detailorg_parent.SelectedValue);
            //          try
            //          {
            //              org_model orgs = new org_model()
            //              {
            //                  name = detailorg_name.Text,
            //                  parent = parent
            //              };

            ////s.orgs.Add(orgs);
            //              s.SaveChanges();

            //              Response.Redirect(prevPage);
            //          }
            //          catch (System.Exception ex)
            //          {
            //              Response.Write(ex);
            //          }
            //      }

            Support p = new Support();
            if (!String.IsNullOrEmpty(detailorg_name.Text))
            {
                try
                {
                    org newOrg = new org()
                    {
                        name = detailorg_name.Text,
                        description = detailorg_desc.Text
                    };

                    if (parent_id != null)
                    {
                        newOrg.parent = parent_id;
                    }

                    p.orgs.Add(newOrg);
                    p.SaveChanges();

                    Response.Redirect("~/Admin/org.aspx");
                }
                catch (System.Exception ex)
                {
                    Response.Write(ex);
                }
            }


        }
    }
}
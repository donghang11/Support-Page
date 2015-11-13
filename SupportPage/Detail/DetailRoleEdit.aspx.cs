using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SupportPage.Models;
using System.Data.SqlClient;

namespace SupportPage
{
    public partial class DetailRoleEdit : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
       static int id;

       protected void Page_Load(object sender, EventArgs e)
       {
           id = Convert.ToInt32(Request.QueryString["id"]);

           if (!IsPostBack)
           {
               if (prevPage == String.Empty)
               {
                   prevPage = Request.UrlReferrer.ToString();
               }
               try
               {
                   Support support = new Support();
                   //var roles = from r in support.Roles
                   //            where r.id == id
                   //            select new
                   //            {
                   //                r.descrpition,
                   //                r.note,
                   //            };


                   ////name
                   //if (!String.IsNullOrEmpty(roles.FirstOrDefault().descrpition))
                   //{
                   //    detailrole_edit_desc.Text = roles.FirstOrDefault().descrpition.ToString();
                   //}
                   //else
                   //{
                   //    detailrole_edit_desc.Text = "No description...";
                   //}

                   ////name
                   //if (!String.IsNullOrEmpty(roles.FirstOrDefault().note))
                   //{
                   //    detailrole_edit_note.Text = roles.FirstOrDefault().note.ToString();
                   //}
                   //else
                   //{
                   //    detailrole_edit_desc.Text = "No note...";
                   //}

                  }
               catch (Exception ex)
               {
                   Response.Write(ex);
               }
           }
       }
        //submit
        protected void Unnamed2_Click(object sender, EventArgs e)
        {


            try
            {
                using (Support support = new Support())
                {
                    //role_model target = (from x in support.Roles
                    //                    where x.id == id
                    //                    select x).FirstOrDefault();

                    //desc = detailrole_edit_desc.Text;
                    //note = detailrole_edit_note.Text;

                    //target.descrpition = desc;
                    //target.note = note;

                    //support.SaveChanges();
                }

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
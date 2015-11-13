using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SupportPage.Models;
using System.Configuration;

namespace SupportPage
{
    public partial class DetailOrgEdit : System.Web.UI.Page
    {
        static string prevPage = String.Empty;

        static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);

            //to avoid duplication in dropdown lists
            if (IsPostBack)
            {
                detailorg_edit_parent.DataSourceID = "";
                Items.Clear();
            }

            if (!IsPostBack)
            {
                if (prevPage == String.Empty)
                {
                    prevPage = Request.UrlReferrer.ToString();
                }
                try
                {
                    Support support = new Support();
                    //var orgs = from o in support.orgs
                    //            where o.id == id
                    //            select new
                    //            {
                    //                o.name,
                    //                o.parent,      
                    //            };

                    ////add 'none' to some dropdown list to enable none selection             
                    //detailorg_edit_parent.AppendDataBoundItems = true;

                    ////name
                    //if (!String.IsNullOrEmpty(orgs.FirstOrDefault().name))
                    //{
                    //    detailorg_edit_name.Text = orgs.FirstOrDefault().name.ToString();
                    //}
                    //else
                    //{
                    //    detailorg_edit_name.Text = "No Name...";
                    //}

                    ////parent 
                    ////before doing other operations, check if the parent still exists.
                    //List<int> all_orgs = (from x in support.orgs select x.id).ToList();
                    //if (orgs.FirstOrDefault().parent != null)
                    //{
                    //    if (all_orgs.Contains(Convert.ToInt32(orgs.FirstOrDefault().parent.ToString())))
                    //    {
                    //        detailorg_edit_parent.Text = orgs.FirstOrDefault().parent.ToString();
                    //    }
                    //    else
                    //    {
                    //        detailorg_edit_parent.SelectedValue = "";
                    //    }
                    //}
                    //else
                    //{
                    //    detailorg_edit_parent.SelectedValue = "";
                    //}


                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }

        }

        //cancel    
        protected void DetailOrgEditCancel(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        //Submit
        protected void DetailOrgEditSubmit(object sender, EventArgs e)
        {

            //try
            //{
            //    //using (Support support = new Support())
            //    //{
            //    //    org_model target = (from x in support.orgs
            //    //                       where x.id == id
            //    //                       select x).FirstOrDefault();



            //    //    name = detailorg_edit_name.Text;

            //    //    target.name = name;

            //    //    if (detailorg_edit_parent.SelectedValue == "")
            //    //    {
            //    //        target.parent = null;
            //    //    }
            //    //    else 
            //    //    {
            //    //        target.parent = Convert.ToInt32(detailorg_edit_parent.SelectedValue.ToString()); ;
            //    //    }

            //    //    support.SaveChanges();
            //    }

            //    Response.Redirect(prevPage);
            //}
            //catch (System.Exception ex)
            //{
            //    Response.Write(ex);
            //}
        }

        protected void detailorg_edit_parent_DataBound(object sender, EventArgs e)
        {

        }
    }
}
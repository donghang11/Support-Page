using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SupportPage.Models;

namespace SupportPage
{
    public partial class DetailPersonEdit : System.Web.UI.Page
    {

        static string prevPage = String.Empty;
        static int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);

            detailperson_edit_organization.AppendDataBoundItems = true;
            detailperson_edit_prev_person.AppendDataBoundItems = true;

            //to avoid duplication in dropdown lists
            if (IsPostBack)
            {
                detailperson_edit_organization.DataSourceID = "";
                Items.Clear();
                detailperson_edit_prev_person.DataSourceID = "";
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
                    //var person = from c in support.People
                    //             where c.id == id
                    //             select new
                    //             {
                    //                 c.name,
                    //                 c.sd,
                    //                 c.ed,
                    //                 c.org,
                    //                 c.prev
                    //             };

                    ////get all actions for later use
                    //List<int> all_orgs = (from x in support.orgs select x.id).ToList();
                    //List<int> all_person = (from x in support.People select x.id).ToList();

                    ////name
                    //if (!String.IsNullOrEmpty(person.FirstOrDefault().name))
                    //{
                    //    detailperson_edit_name.Text = person.FirstOrDefault().name.ToString();
                    //}
                    //else
                    //{
                    //    detailperson_edit_name.Text = "No name...";
                    //}

                    ////start date
                    //if (person.FirstOrDefault().sd.HasValue)
                    //{
                    //    detailperson_edit_startdate.SelectedDate = DateTime.Parse(person.FirstOrDefault().sd.ToString());
                    //    detailperson_edit_startdate.VisibleDate = DateTime.Parse(person.FirstOrDefault().sd.ToString());
                    //}
                    //else
                    //{
                    //    detailperson_edit_startdate.SelectedDate = DateTime.Now;
                    //    detailperson_edit_startdate.VisibleDate = DateTime.Now;
                    //}

                    ////end date
                    //if (person.FirstOrDefault().ed.HasValue)
                    //{
                    //    detailperson_edit_enddate.SelectedDate = DateTime.Parse(person.FirstOrDefault().ed.ToString());
                    //    detailperson_edit_enddate.VisibleDate = DateTime.Parse(person.FirstOrDefault().ed.ToString());
                    //}
                    //else
                    //{
                    //    detailperson_edit_enddate.SelectedDate = DateTime.Now;
                    //    detailperson_edit_enddate.VisibleDate = DateTime.Now;
                    //}

                    ////org
                    //if (person.FirstOrDefault().org != null)
                    //{
                    //    if (!all_orgs.Contains(Convert.ToInt32(person.FirstOrDefault().org.ToString())))
                    //    {
                    //        detailperson_edit_organization.Text = "";
                    //    }
                    //    else
                    //    {
                    //        detailperson_edit_organization.SelectedValue = person.FirstOrDefault().org.ToString();
                    //    }
                    //}
                    //else
                    //{
                    //    detailperson_edit_organization.Text = "";
                    //}

                    ////parent
                    //if (person.FirstOrDefault().prev != null)
                    //{
                    //    if (!all_person.Contains(Convert.ToInt32(person.FirstOrDefault().prev.ToString())))
                    //    {
                    //        detailperson_edit_prev_person.Text = "";
                    //    }
                    //    else
                    //    {
                    //        detailperson_edit_prev_person.SelectedValue = person.FirstOrDefault().prev.ToString();
                    //    }
                    //}
                    //else
                    //{
                    //    detailperson_edit_prev_person.Text = "";
                    //}

                    ////phone
                    //if (!String.IsNullOrEmpty(person.FirstOrDefault().name))
                    //{
                    //    detailperson_edit_name.Text = person.FirstOrDefault().name.ToString();
                    //}
                    //else
                    //{
                    //    detailperson_edit_name.Text = "No name...";
                    //}

                    ////email
                    //if (!String.IsNullOrEmpty(person.FirstOrDefault().name))
                    //{
                    //    detailperson_edit_name.Text = person.FirstOrDefault().name.ToString();
                    //}
                    //else
                    //{
                    //    detailperson_edit_name.Text = "No name...";
                    //}

                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }

        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        protected void Unnamed4_Click(object sender, EventArgs e)
        {

            try
            {
                using (Support support = new Support())
                {
                    //person_model target = (from x in support.People
                    //                       where x.id == id
                    //                       select x).FirstOrDefault();

                    //target.name = detailperson_edit_name.Text;
                    //target.sd = detailperson_edit_startdate.SelectedDate;
                    //target.ed = detailperson_edit_enddate.SelectedDate;


                    //if (detailperson_edit_organization.SelectedValue == "")
                    //{
                    //    target.org = null;
                    //}
                    //else
                    //{
                    //    target.org = Convert.ToInt32(detailperson_edit_organization.SelectedValue.ToString());
                    //}

                    //if (detailperson_edit_prev_person.SelectedValue == "")
                    //{
                    //    target.prev = null;
                    //}
                    //else
                    //{
                    //    target.prev = Convert.ToInt32(detailperson_edit_prev_person.SelectedValue.ToString());
                    //}


                    //support.SaveChanges();
                }

                Response.Redirect(prevPage);
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }

    }
}
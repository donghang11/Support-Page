using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SupportPage.Models;

namespace SupportPage
{
    public partial class DetailMemberEdit : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        static int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);

            detailmember_edit_role.AppendDataBoundItems = true;

            //to avoid duplication in dropdown lists
            if (IsPostBack)
            {
                detailmember_edit_role.DataSourceID = "";
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
                    //var members = from c in support.Members
                    //             where c.id == id
                    //             select new
                    //             {
                    //                 c.person,
                    //                 c.sd,
                    //                 c.ed,
                    //                 c.role,
                    //                 c.incident
                    //             };

                    ////get all actions for later use
                    //List<int> all_cases = (from x in support.Incidents select x.Id).ToList();
                    //List<int> all_person = (from x in support.People select x.id).ToList();
                    //List<int> all_roles = (from x in support.Roles select x.id).ToList();

                    ////person
                    //if (members.FirstOrDefault().person != null)
                    //{
                    //    if (!all_person.Contains(Convert.ToInt32(members.FirstOrDefault().person.ToString())))                        
                    //    {
                    //        detailmember_edit_person.Text = "";
                    //    }
                    //    else
                    //    {
                    //        detailmember_edit_person.SelectedValue = members.FirstOrDefault().person.ToString();
                    //    }
                    //}
                    //else
                    //{
                    //    detailmember_edit_person.Text = "";
                    //}

                    ////start date
                    //if (members.FirstOrDefault().sd.HasValue)
                    //{
                    //    detailmember_edit_startdate.SelectedDate = DateTime.Parse(members.FirstOrDefault().sd.ToString());
                    //    detailmember_edit_startdate.VisibleDate = DateTime.Parse(members.FirstOrDefault().sd.ToString());
                    //}
                    //else
                    //{
                    //    detailmember_edit_startdate.SelectedDate = DateTime.Now;
                    //    detailmember_edit_startdate.VisibleDate = DateTime.Now;
                    //}

                    ////end date
                    //if (members.FirstOrDefault().ed.HasValue)
                    //{
                    //    detailmember_edit_enddate.SelectedDate = DateTime.Parse(members.FirstOrDefault().ed.ToString());
                    //    detailmember_edit_enddate.VisibleDate = DateTime.Parse(members.FirstOrDefault().ed.ToString());
                    //}
                    //else
                    //{
                    //    detailmember_edit_enddate.SelectedDate = DateTime.Now;
                    //    detailmember_edit_enddate.VisibleDate = DateTime.Now;
                    //}

                    ////role
                    //if (members.FirstOrDefault().role != null)
                    //{
                    //    if (!all_person.Contains(Convert.ToInt32(members.FirstOrDefault().role.ToString())))
                    //    {
                    //        detailmember_edit_role.Text = "";
                    //    }
                    //    else
                    //    {
                    //        detailmember_edit_role.SelectedValue = members.FirstOrDefault().role.ToString();
                    //    }
                    //}
                    //else
                    //{
                    //    detailmember_edit_role.Text = "";
                    //}

                    ////case
                    //if (members.FirstOrDefault().incident != null)
                    //{
                    //    if (!all_cases.Contains(Convert.ToInt32(members.FirstOrDefault().incident.ToString())))
                    //    {
                    //        detailmember_edit_case.Text = "";
                    //    }
                    //    else
                    //    {
                    //        detailmember_edit_case.SelectedValue = members.FirstOrDefault().incident.ToString();
                    //    }
                    //}
                    //else
                    //{
                    //    detailmember_edit_case.Text = "";
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

        //cancel
        protected void Unnamed3_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        //submit
        protected void Unnamed4_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    //using (Support support = new Support())
            //    //{
            //    //    member_model target = (from x in support.Members
            //    //                           where x.id == id
            //    //                           select x).FirstOrDefault();

            //    //    target.person = Convert.ToInt32(detailmember_edit_person.Text);
            //    //    target.sd = detailmember_edit_startdate.SelectedDate;
            //    //    target.ed = detailmember_edit_enddate.SelectedDate;

            //    //    //if (detailmember_edit_role.Text != "")
            //    //    //{
            //    //    //    target.role = Convert.ToInt32(detailmember_edit_role.Text);
            //    //    //}
            //    //    //else
            //    //    //{
            //    //    //    target.role = null;
            //    //    //}
            //    //    //target.incident = Convert.ToInt32(detailmember_edit_case.Text);


            //    //    support.SaveChanges();
            //    }

            //    Response.Redirect(prevPage);
            //}
            //catch (System.Exception ex)
            //{
            //    Response.Write(ex);
            //}
        }
    }
}
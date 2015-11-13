using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SupportPage.Models;

namespace SupportPage
{

    public partial class DetailActionEdit : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        static int id;

        protected void Page_Load(object sender, EventArgs e)
        {
            id = Convert.ToInt32(Request.QueryString["id"]);

            detailaction_edit_case.AppendDataBoundItems = true;
            detailaction_edit_sender.AppendDataBoundItems = true;
            detailaction_edit_receiver.AppendDataBoundItems = true;

            //to avoid duplication in dropdown lists
            if (IsPostBack)
            {
                detailaction_edit_case.DataSourceID = "";
                Items.Clear();
                detailaction_edit_sender.DataSourceID = "";
                Items.Clear();
                detailaction_edit_receiver.DataSourceID = "";
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
               //     Support support = new Support();
               //     var acts = from c in support.Actions
               //                where c.id == id
               //                select new
               //                {
               //                    c.sub,
               //                    c.dt,
               //                    c.description,
               //                    c.note,
               //                    c.sender,
               //                    c.receiver,
               //                    c.incident
               //                };
               //     //get all actions for later use
               //     List<int> all_acts = (from x in support.Actions select x.id).ToList();
               //// List<int> all_members = (from x in support.Members select x.id).ToList();             
               //     List<int> all_cases = (from x in support.Incidents select x.Id).ToList();

               //     //name
               //     if (!String.IsNullOrEmpty(acts.FirstOrDefault().sub))
               //     {
               //         detailaction_edit_name.Text = acts.FirstOrDefault().sub.ToString();
               //     }
               //     else
               //     {
               //         detailaction_edit_name.Text = "No name...";
               //     }

               //     //date
               //     if (acts.FirstOrDefault().dt.HasValue)
               //     {
               //         detailaction_edit_date.SelectedDate = DateTime.Parse(acts.FirstOrDefault().dt.ToString());
               //         detailaction_edit_date.VisibleDate = DateTime.Parse(acts.FirstOrDefault().dt.ToString());
               //     }
               //     else
               //     {
               //         detailaction_edit_date.SelectedDate = DateTime.Now;
               //         detailaction_edit_date.VisibleDate = DateTime.Now;
               //     }

               //     //decription
               //     if (!String.IsNullOrEmpty(acts.FirstOrDefault().description))
               //     {
               //         detailaction_edit_desc.Text = acts.FirstOrDefault().description.ToString();
               //     }
               //     else
               //     {
               //         detailaction_edit_desc.Text = "No description...";
               //     }

               //     //note
               //     if (!String.IsNullOrEmpty(acts.FirstOrDefault().note))
               //     {
               //         detailaction_edit_note.Text = acts.FirstOrDefault().note.ToString();
               //     }
               //     else
               //     {
               //         detailaction_edit_note.Text = "No note...";
               //     }

                    ////sender
                    //if (acts.FirstOrDefault().sender != null)
                    //{
                    //    if (!all_members.Contains(Convert.ToInt32(acts.FirstOrDefault().sender.ToString())))
                    //    {
                    //        detailaction_edit_sender.SelectedValue = "";
                    //    }
                    //    else
                    //    {
                    //        detailaction_edit_sender.SelectedValue = acts.FirstOrDefault().sender.ToString();
                    //    }
                    //}
                    //else
                    //{
                    //    detailaction_edit_sender.SelectedValue = "";
                    //}

                    ////receiver
                    //if (acts.FirstOrDefault().receiver != null)
                    //{
                    //    if (!all_members.Contains(Convert.ToInt32(acts.FirstOrDefault().receiver.ToString())))
                    //    {
                    //        detailaction_edit_receiver.SelectedValue = "";
                    //    }
                    //    else
                    //    {
                    //        detailaction_edit_receiver.SelectedValue = acts.FirstOrDefault().receiver.ToString();
                    //    }
                    //}
                    //else
                    //{
                    //    detailaction_edit_receiver.SelectedValue = "";
                    //}

                    //case
                    //if (acts.FirstOrDefault().incident != null)
                    //{
                    //    if (!all_cases.Contains(Convert.ToInt32(acts.FirstOrDefault().incident.ToString())))
                    //    {
                    //        detailaction_edit_case.SelectedValue = "";
                    //    }
                    //    else
                    //    {
                    //        detailaction_edit_case.SelectedValue = acts.FirstOrDefault().incident.ToString();
                    //    }
                    //}
                    //else
                    //{
                    //    detailaction_edit_case.SelectedValue = "";
                    //}



                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }

        }

        protected void Unnamed2_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        protected void Unnamed3_Click(object sender, EventArgs e)
        {

            //try
            //{
            //    using (Support support = new Support())
            //    {
            //        action_model target = (from x in support.Actions
            //                               where x.id == id
            //                               select x).FirstOrDefault();

            //        target.de = detailaction_edit_name.Text;
            //        target.dt = detailaction_edit_date.SelectedDate;
            //        target.description = detailaction_edit_desc.Text;
            //        target.note = detailaction_edit_note.Text;

            //        if (detailaction_edit_sender.SelectedValue != "")
            //        {
            //            target.sender = Convert.ToInt32(detailaction_edit_sender.SelectedValue.ToString());
            //        }
            //        else
            //        {
            //            target.sender = null;
            //        }

            //        if (detailaction_edit_receiver.SelectedValue != "")
            //        {
            //            target.receiver = Convert.ToInt32(detailaction_edit_receiver.SelectedValue.ToString());
            //        }
            //        else
            //        {
            //            target.receiver = null;
            //        }

            //        if (detailaction_edit_case.SelectedValue != "")
            //        {
            //            target.incident = Convert.ToInt32(detailaction_edit_case.SelectedValue.ToString());
            //        }
            //        else
            //        {
            //            target.incident = null;
            //        }

            //        target.sender = Convert.ToInt32(detailaction_edit_sender.Text);
            //        target.receiver = Convert.ToInt32(detailaction_edit_receiver.Text);
            //        target.incident = Convert.ToInt32(detailaction_edit_case.Text);

            //        support.SaveChanges();
                }




            //    Response.Redirect(prevPage);
            //}
            //catch (System.Exception ex)
            //{
            //    Response.Write(ex);
            //}
       // }
    }
}

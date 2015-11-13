using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SupportPage.Models;
using System.Configuration;

namespace SupportPage
{
    public partial class DetailCaseEdit : System.Web.UI.Page
    {
        static string prevPage = String.Empty;

        //static int id;
        protected void Page_Load(object sender, EventArgs e)
        {
            //id = Convert.ToInt32(Request.QueryString["id"]);

            ////to avoid duplication in dropdown lists
            //if (IsPostBack)
            //{
            //    detailcase_edit_drafter.DataSourceID = "";
            //    Items.Clear();
            //    detailcase_edit_handler.DataSourceID = "";
            //    Items.Clear();
            //    detailcase_edit_parent.DataSourceID = "";
            //    Items.Clear();
            //}

            //if (!IsPostBack)
            //{

            //    if (prevPage == String.Empty)
            //    {
            //        prevPage = Request.UrlReferrer.ToString();
            //    }
            //    try
            //    {
            //        Support support = new Support();
            //        var cases = from c in support.Incidents
            //                    where c.Id == id
            //                    select new
            //                    {
            //                        c.parent,
            //                        c.sub,
            //                        c.handler,
            //                        c.drafter,
            //                        c.sd,
            //                        c.ed,
            //                        c.description,
            //                        c.note
            //                    };

            //        //add 'none' to some dropdown list to enable none selection             
            //        detailcase_edit_parent.AppendDataBoundItems = true;
            //        detailcase_edit_drafter.AppendDataBoundItems = true;
            //        detailcase_edit_handler.AppendDataBoundItems = true;

            //        //parent
            //        //before doing other operations, check if the parent still exists.
            //        List<int> all_cases = (from x in support.Incidents select x.Id).ToList();
            //        if (cases.FirstOrDefault().parent != null)
            //        {
            //            if (!all_cases.Contains(Convert.ToInt32(cases.FirstOrDefault().parent.ToString())))
            //                detailcase_edit_parent.SelectedValue = "";
            //            else
            //            {
            //                detailcase_edit_parent.SelectedValue = cases.FirstOrDefault().parent.ToString();
            //            }
            //        }
            //        else
            //        {
            //            detailcase_edit_parent.SelectedValue = "";
            //        }

            //        //title
            //        if (!String.IsNullOrEmpty(cases.FirstOrDefault().sub))
            //        {
            //            detailcase_edit_title.Text = cases.FirstOrDefault().sub.ToString();
            //        }
            //        else
            //        {
            //            detailcase_edit_title.Text = "No...";
            //        }

            //        //start date
            //        if (cases.FirstOrDefault().sd.HasValue)
            //        {
            //            detailcase_edit_startdate.SelectedDate = DateTime.Parse(cases.FirstOrDefault().sd.ToString());
            //            detailcase_edit_startdate.VisibleDate = DateTime.Parse(cases.FirstOrDefault().sd.ToString());
            //        }
            //        else
            //        {
            //            detailcase_edit_startdate.SelectedDate = DateTime.Now;
            //            detailcase_edit_startdate.VisibleDate = DateTime.Now;
            //        }

            //        //end date
            //        if (cases.FirstOrDefault().ed.HasValue)
            //        {
            //            detailcase_edit_enddate.SelectedDate = DateTime.Parse(cases.FirstOrDefault().ed.ToString());
            //            detailcase_edit_enddate.VisibleDate = DateTime.Parse(cases.FirstOrDefault().ed.ToString());
            //        }
            //        else
            //        {
            //            detailcase_edit_enddate.SelectedDate = DateTime.Now;
            //            detailcase_edit_enddate.VisibleDate = DateTime.Now;
            //        }

            //        //decription
            //        if (!String.IsNullOrEmpty(cases.FirstOrDefault().description))
            //        {
            //            detailcase_edit_desc.Text = cases.FirstOrDefault().description.ToString();
            //        }
            //        else
            //        {
            //            detailcase_edit_desc.Text = "No...";
            //        }

            //        //note
            //        if (!String.IsNullOrEmpty(cases.FirstOrDefault().note))
            //        {
            //            detailcase_edit_note.Text = cases.FirstOrDefault().note.ToString();
            //        }
            //        else
            //        {
            //            detailcase_edit_note.Text = "No...";
            //        }

                    //drafter       
                    //before doing other operations, check if the drafter still exists.
                    //List<int> all_person = (from x in support.People select x.id).ToList();
                    //if (cases.FirstOrDefault().drafter != null)
                    //{
                    //    if (!all_person.Contains(Convert.ToInt32(cases.FirstOrDefault().drafter.ToString())))
                    //        detailcase_edit_drafter.SelectedValue = "";
                    //    else
                    //    {
                    //        detailcase_edit_drafter.SelectedValue = cases.FirstOrDefault().drafter.ToString();
                    //    }
                    //}
                    //else
                    //{
                    //    detailcase_edit_drafter.SelectedValue = "";
                    //}

                    ////handler
                    ////before doing other operations, check if the member still exists.
                    //List<int> all_member = (from x in support.Members select x.id).ToList();
                    //if (cases.FirstOrDefault().handler != null)
                    //{
                    //    if (!all_member.Contains(Convert.ToInt32(cases.FirstOrDefault().handler.ToString())))
                    //        detailcase_edit_handler.SelectedValue = "";
                    //    else
                    //    {
                    //        Response.Write("eher");
                    //        Response.Write(!all_member.Contains(Convert.ToInt32(cases.FirstOrDefault().handler.ToString())));
                    //        detailcase_edit_handler.SelectedValue = cases.FirstOrDefault().handler.ToString();
                    //    }
                    //}
                    //else
                    //{
                    //    detailcase_edit_handler.SelectedValue = "";
                    //}


        //        }
        //        catch (Exception ex)
        //        {
        //            Response.Write(ex);
        //        }
        //    }

        //}

        ////cancel    
        //protected void DetailCaseEditCancel(object sender, EventArgs e)
        //{
        //    Response.Redirect(prevPage);
        //}

        ////Submit
        //protected void DetailCaseEditSubmit(object sender, EventArgs e)
        //{
        //    string title, Desc, Note;

        //    try
        //    {
        //        //using (Support support = new Support())
                //{
                //    Incident target = (from x in support.Incidents
                //                       where x.Id == id
                //                       select x).FirstOrDefault();

                //    DateTime startDate = detailcase_edit_startdate.SelectedDate;
                //    DateTime endDate = detailcase_edit_enddate.SelectedDate;
                //    title = detailcase_edit_title.Text;
                //    Note = detailcase_edit_note.Text;
                //    Desc = detailcase_edit_desc.Text;



                //    target.sub = title;
                //    target.ed = endDate;
                //    target.sd = startDate;
                //    target.description = Desc;
                //    target.note = Note;

                //    if (detailcase_edit_drafter.SelectedValue == "")
                //    {
                //        target.drafter = null;
                //    }
                //    else
                //    {
                //        target.drafter = Convert.ToInt32(detailcase_edit_drafter.SelectedValue.ToString());
                //    }

                //    if (detailcase_edit_handler.SelectedValue == "")
                //    {
                //        target.handler = null;
                //    }
                //    else
                //    {
                //        target.handler = Convert.ToInt32(detailcase_edit_handler.SelectedValue.ToString());
                //    }

                //    if (detailcase_edit_parent.SelectedValue == "")
                //    {
                //        target.parent = null;
                //    }
                //    else
                //    {
                //        target.parent = Convert.ToInt32(detailcase_edit_parent.SelectedValue.ToString());
                //    }

                //    support.SaveChanges();
                //}

                //Response.Redirect(prevPage);
            }
    //        catch (System.Exception ex)
    //        {
    //            Response.Write(ex);
    //        }
    //    }


    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseUtils;
using SupportPage.Models;
using System.Globalization;
using System.Text;
using System.Web.Security;

namespace SupportPage
{
    public partial class DetailAction2 : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        static int id;
        static string desc = null;
        static int person_id;
        static int case_id;

        protected void Page_Load(object sender, EventArgs e)
        {
            //to avoid duplication in dropdown lists
            if (IsPostBack)
            {
                detailaction2_sender.DataSourceID = "";
                Items.Clear();
            }

            if (Request.Cookies["user"] != null)
            {
                string decoded_username = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["username"]), "ProtectCookieUsername"));
                string decoded_role = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["role"]), "ProtectCookieRole"));
                person_id = Convert.ToInt32(Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["person"]), "ProtectCookiePerson")));
                case_id = Convert.ToInt32(Request.QueryString["case_id"]);

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

            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
            }

            int isNew = Convert.ToInt32(Request.QueryString["new"]);

            if (!IsPostBack)
            {

                SiteMap.SiteMapResolve += new SiteMapResolveEventHandler(SiteMap_SiteMapResolve);
                if (isNew == 1)
                {
                    action_model action = new action_model()
                    {
                        dt = DateTime.Now,
                        incident = case_id,
                        description = "default"
                    };

                    Support s = new Support();
                    s.Actions.Add(action);
                    s.SaveChanges();
                    id = action.id;
                    detailaction2_date.Text = action.dt.ToString("MM/dd/yyyy");

                    Support support = new Support();
                    var p_query = from p in support.Incidents where p.id == action.incident select p;
                    detailaction2_case.Text = p_query.FirstOrDefault().description;
                }
                else
                {
                    try
                    {
                        Support support = new Support();
                        Support personnel = new Support();
                        var action = from a in support.Actions
                                     where a.id == id
                                     select new
                                     {
                                         a.incident,
                                         a.receiver,
                                         a.sender,
                                         a.description,
                                         a.dt
                                     };

                        //date
                        if (action.FirstOrDefault().dt != null)
                        {
                            detailaction2_date.Text = action.FirstOrDefault().dt.ToString("MM/dd/yyyy");
                        }
                        else
                        {
                            detailaction2_date.Text = "No date...";
                        }

                        //description
                        if (String.IsNullOrEmpty(action.FirstOrDefault().description) || action.FirstOrDefault().description == "default")
                        {
                            detailaction2_desc.Text = "";
                        }
                        else
                        {
                            desc = action.FirstOrDefault().description.ToString();
                            detailaction2_desc.Text = desc;
                        }

                        //case
                        List<int> all_cases = (from x in support.Incidents select x.id).ToList();
                        if (!all_cases.Contains(Convert.ToInt32(action.FirstOrDefault().incident.ToString())))
                        {
                            detailaction2_case.Text = "No case...";
                        }
                        else
                        {
                            var p_query = from p in support.Incidents where p.id == action.FirstOrDefault().incident select p;
                            detailaction2_case.Text = p_query.FirstOrDefault().description;
                        }

                        //sender
                        List<int> all_members = (from x in personnel.members select x.id).ToList();
                        if (!all_members.Contains(Convert.ToInt32(action.FirstOrDefault().sender.ToString())))
                        {
                            detailaction2_sender.SelectedValue = "";
                        }
                        else
                        {
                            int s = Convert.ToInt32(action.FirstOrDefault().sender.ToString());
                            detailaction2_sender.SelectedValue = action.FirstOrDefault().sender.ToString();
                        }


                        //receiver
                        if (!String.IsNullOrEmpty(action.FirstOrDefault().receiver))
                        {
                            detailaction2_receiver.Text = action.FirstOrDefault().receiver.ToString();
                        }
                        else
                        {
                            // detailaction2_desc.Text = desc;
                        }

                        ////receiver
                        //if (!all_members.Contains(Convert.ToInt32(action.FirstOrDefault().receiver.ToString())))
                        //{
                        //    detailaction2_receiver.Text = "No receiver...";
                        //}
                        //else
                        //{
                        //    int s = Convert.ToInt32(action.FirstOrDefault().receiver.ToString());
                        //    var rename = from r in personnel.people
                        //                 join m in personnel.members
                        //                 on r.id equals m.person
                        //                 where m.id == s
                        //                 select r;
                        //    detailaction2_receiver.Text = rename.FirstOrDefault().lastname + " " + rename.FirstOrDefault().firstname;
                        //}

                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }
                }

            }
            detailaction2_sender.AppendDataBoundItems = true;
        }

        SiteMapNode SiteMap_SiteMapResolve(object sender, SiteMapResolveEventArgs e)
        {
            SiteMapNode currentNode = SiteMap.CurrentNode.Clone(true);
            if (currentNode.Url == "/")
            {
                return currentNode;
            }

            currentNode.ParentNode.Url += "?id=" + case_id;

            return currentNode;
        }

        protected void detailaction2_addfile_Click(object sender, EventArgs e)
        {
            int _sender;
            //Response.Write(Convert.ToInt32(detailaction2_sender.SelectedValue.ToString()));
            if (detailaction2_sender.SelectedValue.ToString() != "")
            {
                _sender = Convert.ToInt32(detailaction2_sender.SelectedValue.ToString());
                string URI = "/Detail/DetailFile2?new=1&action=" + id + "&incident=" + case_id + "&sender=" + _sender;
                //detailaction2_addfile.Attributes.Add("onClick", string.Format("window.open('{0}')", URI));
                Response.Redirect(URI);
            }
            else
            {
                Response.Write("Please select send then add a new file!");
                return;
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

        protected void detailaction2_btn_back_Click(object sender, EventArgs e)
        {
            Response.Redirect(prevPage);
        }

        ////edit
        //protected void Unnamed_Click(object sender, EventArgs e)
        //{
        //    detailaction2_cancel.Visible = true;
        //    detailaction2_submit.Visible = true;
        //    detailaction2_desc.ReadOnly = false;
        //}

        //submit
        //protected void detailaction2_submit_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        using (Support support = new Support())
        //        {
        //            action_model target = (from x in support.Actions
        //                                 where x.id == id
        //                                 select x).FirstOrDefault();

        //            target.description = detailaction2_desc.Text;
        //            support.SaveChanges();

        //        }
        //        detailaction2_desc.ReadOnly = true;
        //        detailaction2_submit.Visible = false;
        //        detailaction2_cancel.Visible = false;
        //    }
        //    catch (System.Exception ex)
        //    {
        //        Response.Write(ex);
        //    }
        //}

        ////cancel
        //protected void detailaction2_cancel_Click(object sender, EventArgs e)
        //{
        //    detailaction2_desc.ReadOnly = true;
        //    detailaction2_submit.Visible = false;
        //    detailaction2_cancel.Visible = false;
        //    detailaction2_desc.Text = desc;
        //}

        //delete
        protected void detailaction2_delete_Click(object sender, EventArgs e)
        {
            using (Support s = new Support())
            {
                var target = (from x in s.Actions
                              where x.id == id
                              select x).FirstOrDefault();
                s.Actions.Remove(target);
                s.SaveChanges();
            }

            SiteMapNode currentNode = SiteMap.CurrentNode.Clone(true);
            string parentURL = currentNode.ParentNode.Url;
            Response.Redirect(parentURL);
        }

        protected void detailaction2_desc_TextChanged(object sender, EventArgs e)
        {
            try
            {
                //Response.Write(id);
                using (Support support = new Support())
                {
                    var desc = (from c in support.Actions
                                where c.id == id
                                select c).FirstOrDefault();
                    desc.description = detailaction2_desc.Text;
                    support.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void detailaction2_receiver_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (Support support = new Support())
                {
                    var receiver = (from c in support.Actions
                                    where c.id == id
                                    select c).FirstOrDefault();
                    receiver.receiver = detailaction2_receiver.Text;
                    support.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void detailaction2_file_gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                string QueryString = "~/Detail/DetailFile2.aspx?id=" + e.Row.Cells[1].Text;
                string NavigateURL = ResolveUrl(QueryString);
                e.Row.Attributes.Add("onClick", string.Format("window.open('{0}')", NavigateURL));
                e.Row.Style.Add("cursor", "pointer");

                int s = Convert.ToInt32(e.Row.Cells[3].Text);

                //Response.Write(s);
                try
                {
                    using (Support support = new Support())
                    {
                        List<int> all_members = (from x in support.members select x.id).ToList();
                        if (all_members.Contains(s))
                        {
                            var sen = (from p in support.people
                                       join m in support.members
                                       on p.id equals m.person
                                       where m.id == s
                                       select p).FirstOrDefault();
                            e.Row.Cells[3].Text = sen.lastname + sen.firstname;
                            //Response.Write(sen.lastname);
                        }
                    }
                }
                catch (System.Exception ex)
                {
                    Response.Write(ex);
                }

                e.Row.Cells[1].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        protected void detailAction2_sender_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (detailaction2_sender.SelectedValue == "")
            {
                return;
            }

            try
            {
                using (Support support = new Support())
                {
                    var se = (from c in support.Actions
                              where c.id == id
                              select c).FirstOrDefault();
                    se.sender = Convert.ToInt32(detailaction2_sender.SelectedValue.ToString());
                    support.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }

        //protected void Page_Unload(object sender, EventArgs e)
        //{
        //    SiteMap.SiteMapResolve -= new SiteMapResolveEventHandler(SiteMap_SiteMapResolve);
        //}

    }
}
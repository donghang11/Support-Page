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
    public partial class DetailFile2 : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        static int id;
        static string name;
        static string path;
        static string note;
        static int _incident;
        static int _action;
        static int _sender;

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

            int isNew = Convert.ToInt32(Request.QueryString["new"]);
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                //Response.Write(id);
            }
            _incident = Convert.ToInt32(Request.QueryString["incident"]);
            _action = Convert.ToInt32(Request.QueryString["action"]);
            _sender = Convert.ToInt32(Request.QueryString["sender"]);


            if (!IsPostBack)
            {

                if (prevPage == String.Empty)
                {
                    prevPage = Request.UrlReferrer.ToString();
                }

                SiteMap.SiteMapResolve += new SiteMapResolveEventHandler(SiteMap_File);
                if (isNew == 1)
                {
                    file_model fi = new file_model()
                    {
                        action = _action,
                        incident = _incident,
                        sender = _sender,
                        dt = DateTime.Now,
                        name = "change it",
                    };

                    Support s = new Support();
                    s.Files.Add(fi);
                    s.SaveChanges();
                    id = fi.id;
                    detailfile2_date.Text = fi.dt.ToString("MM/dd/yyyy");
                    Support support = new Support();
                    var sen = (from p in support.people
                               join m in support.members
                               on p.id equals m.person
                               where m.id == fi.sender
                               select p).FirstOrDefault();
                    detailfile2_sender.Text = sen.lastname + sen.firstname;
                    var p_query = from p in support.Incidents where p.id == fi.incident select p;
                    detailfile2_case.Text = p_query.FirstOrDefault().description;
                }
                else
                {


                    try
                    {
                        Support support = new Support();
                        Support personnel = new Support();
                        var file = from a in support.Files
                                   where a.id == id
                                   select new
                                   {
                                       a.incident,
                                       a.name,
                                       a.sender,
                                       a.fpath,
                                       a.note,
                                       a.dt,
                                       a.action
                                   };

                        _action = file.FirstOrDefault().action;
                        _incident = file.FirstOrDefault().incident;
                        //date
                        if (file.FirstOrDefault().dt != null)
                        {
                            detailfile2_date.Text = file.FirstOrDefault().dt.ToString("MM/dd/yyyy");
                        }
                        else
                        {
                            detailfile2_date.Text = "No date...";
                        }

                        //name
                        if (!String.IsNullOrEmpty(file.FirstOrDefault().name))
                        {
                            name = file.FirstOrDefault().name.ToString();
                            detailfile2_name.Text = name;
                        }
                        else
                        {
                            name = "No name...";
                            detailfile2_name.Text = name;
                        }

                        //case
                        List<int> all_cases = (from x in support.Incidents select x.id).ToList();
                        if (!all_cases.Contains(Convert.ToInt32(file.FirstOrDefault().incident.ToString())))
                        {
                            detailfile2_case.Text = "No case...";
                        }
                        else
                        {
                            var p_query = from p in support.Incidents where p.id == file.FirstOrDefault().incident select p;
                            detailfile2_case.Text = p_query.FirstOrDefault().description;
                        }

                        //sender
                        List<int> all_members = (from x in personnel.members select x.id).ToList();
                        if (!all_members.Contains(Convert.ToInt32(file.FirstOrDefault().sender.ToString())))
                        {
                            detailfile2_sender.Text = "No sender...";
                        }
                        else
                        {
                            int s = Convert.ToInt32(file.FirstOrDefault().sender.ToString());
                            var sename = from r in personnel.people
                                         join m in personnel.members
                                         on r.id equals m.person
                                         where m.id == s
                                         select r;
                            detailfile2_sender.Text = sename.FirstOrDefault().lastname + " " + sename.FirstOrDefault().firstname;
                        }

                        //path
                        if (!String.IsNullOrEmpty(file.FirstOrDefault().fpath))
                        {
                            path = file.FirstOrDefault().fpath.ToString();
                            detailfile2_path.Text = path;
                        }
                        else
                        {
                            path = "No path...";
                            detailfile2_path.Text = path;
                        }

                        //note
                        if (!String.IsNullOrEmpty(file.FirstOrDefault().note))
                        {
                            note = file.FirstOrDefault().note.ToString();
                            detailfile2_note.Text = note;
                        }
                        else
                        {
                            note = "No note...";
                            detailfile2_note.Text = note;
                        }

                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }
                }
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

        SiteMapNode SiteMap_File (object sender, SiteMapResolveEventArgs e)
        {
            SiteMapNode currentNode = SiteMap.CurrentNode.Clone(true);
            if (currentNode.Url == "/")
            {
                return currentNode;
            }

            using (Support s = new Support())
            {
                var target = (from x in s.Files
                              where x.id == id
                              select x).FirstOrDefault();


                currentNode.ParentNode.Url = "/Detail/DetailAction2" + "?id=" + _action + "&case_id=" + _incident;
                //Response.Write(currentNode.ParentNode.Url);
                return currentNode;
            }
        }

        //delete
        protected void detailafile2_delete_Click(object sender, EventArgs e)
        {
            using (Support s = new Support())
            {
                var target = (from x in s.Files
                              where x.id == id
                              select x).FirstOrDefault();
                s.Files.Remove(target);
                s.SaveChanges();
            }

            //SiteMapNode currentNode = SiteMap.CurrentNode.Clone(true);
            //string parentURL = currentNode.ParentNode.Url;
            //using (Support s = new Support())
            //{
            //    var target = (from x in s.Files
            //                  where x.id == id
            //                  select x).FirstOrDefault();

            //    Response.Redirect("/Detail/DetailAction2" + "?id=" + _action + "&case_id=" + _incident);
            //}
            Response.Redirect(prevPage);
        }

        protected void detailfile2_note_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (Support support = new Support())
                {
                    var note = (from c in support.Files
                                where c.id == id
                                select c).FirstOrDefault();
                    note.note = detailfile2_note.Text;
                    support.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void detailfile2_path_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (Support support = new Support())
                {
                    var fpath = (from c in support.Files
                                 where c.id == id
                                 select c).FirstOrDefault();
                    fpath.fpath = detailfile2_path.Text;
                    support.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void detailfile2_name_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (Support support = new Support())
                {
                    var name = (from c in support.Files
                                where c.id == id
                                select c).FirstOrDefault();
                    name.name = detailfile2_name.Text;
                    support.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            Support support = new Support();
            var file = from a in support.Files
                       where a.id == id
                       select new
                       {
                           a.incident,
                           a.action
                       };

            int ac = file.FirstOrDefault().action;
            int inc = file.FirstOrDefault().incident;
            Response.Redirect("/Detail/DetailAction2" + "?id=" + ac + "&case_id=" + inc);
        }

        //protected void Page_Unload(object sender, EventArgs e)
        //{
        //    SiteMap.SiteMapResolve -= new SiteMapResolveEventHandler(SiteMap_File);
        //}

    }
}
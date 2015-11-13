using System;
using System.Collections;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text;
using System.Web.UI.HtmlControls;
using SupportPage.Models;
using System.Web.Security;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using SupportPage.ActNum;

namespace SupportPage
{
    public partial class SupportMain : Page
    {

        //private int getActNum(Incident incident, List<int> acts, int ii)
        //{
        //    int counter = 0;
        //    if(incident.p)
        //    foreach (int num in acts)
        //    {
        //        if (num == incident.id)
        //            counter++;
        //    }

        //    return counter;
        //}

        static Dictionary<int, int> actnum;
        static Dictionary<int, int> actnum2;

        protected void Page_Load(object sender, EventArgs e)
        {
            //Support s = new Support();
            //List<int> acts = new List<int>();
            //foreach (action_model a in s.Actions)
            //{
            //    acts.Add(a.incident);
            //}

            Support s = new Support();
            actnum = new Dictionary<int, int>();
            actnum2 = new Dictionary<int, int>();

            var caselist = (from c in s.Incidents
                            orderby c.reportdate descending
                            select
                                c).Take(5).ToList();

            var caselist2 = (from c in s.Incidents
                             orderby c.lastupdatedate descending
                             select
                                 c).Take(5).ToList();

            foreach (Incident i in caselist)
            {
                foreach (action_model a in s.Actions.ToList())
                {
                    if (a.incident == i.id)
                    {
                        if (actnum.Keys.Contains(i.id))
                        {
                            actnum[i.id] += 1;
                        }
                        else
                        {
                            actnum.Add(i.id, +1);
                        }
                    }
                }
            }
            //actnum.Keys.ToList().ForEach(x => Response.Write(x + "|"));

            List<Incident> inc = s.Incidents.ToList();
            inc.Reverse();
            foreach (Incident i in inc)
            {
                if (i.parent != null)
                {
                    if (actnum.ContainsKey(i.parent.Value) && actnum.ContainsKey(i.id))
                    {
                        //Response.Write("parent");
                        actnum[i.parent.Value] += actnum[i.id];
                    }
                }
            }

            //lastupdatedate
            foreach (Incident i in caselist2)
            {
                foreach (action_model a in s.Actions.ToList())
                {
                    if (a.incident == i.id)
                    {
                        if (actnum2.Keys.Contains(i.id))
                        {
                            actnum2[i.id] += 1;
                        }
                        else
                        {
                            actnum2.Add(i.id, +1);
                        }
                    }
                }
            }
            //actnum.Keys.ToList().ForEach(x => Response.Write(x + "|"));

            List<Incident> inc2 = s.Incidents.ToList();
            inc2.Reverse();
            foreach (Incident i in inc2)
            {
                if (i.parent != null)
                {
                    if (actnum2.ContainsKey(i.parent.Value) && actnum2.ContainsKey(i.id))
                    {
                        //Response.Write("parent");
                        actnum2[i.parent.Value] += actnum2[i.id];
                    }
                }
            }

            ConnectionStringSettings settings;

            if (Request.Cookies["user"] != null)
            {
                try
                {
                    string decoded_username = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["username"]), "ProtectCookieUsername"));
                    string decoded_role = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["role"]), "ProtectCookieRole"));

                    if (decoded_role == "admin" || decoded_role == "support")
                    {
                        if (decoded_role == "admin")
                        {
                            settings = System.Configuration.ConfigurationManager.ConnectionStrings["SupportConnectionStringAdmin"];
                            string connectionString = settings.ConnectionString;

                            SqlDataSource1.ConnectionString = connectionString;
                        }
                        else if (decoded_role == "support")
                        {
                            settings = System.Configuration.ConfigurationManager.ConnectionStrings["SupportConnectionStringUser"];
                            string connectionString = settings.ConnectionString;

                            SqlDataSource1.ConnectionString = connectionString;
                        }
                    }
                }
                catch
                {

                }
            }

            if (!IsPostBack)
            {
                try
                {

                }
                catch
                {

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

        protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                try
                {
                    Support support = new Support();
                    int rid = Convert.ToInt32(e.Row.Cells[0].Text);

                    if (Request.Cookies["user"] != null)
                    {
                        string QueryString = "~/Detail/DetailCase2.aspx?id=" + rid;
                        string NavigateURL = ResolveUrl(QueryString);
                        e.Row.Attributes.Add("onClick", string.Format("window.open('{0}')", NavigateURL));
                        e.Row.Style.Add("cursor", "pointer");
                    }
                   //actnum2.ToList().ForEach(x => Response.Write(x.Key + ":" + x.Value + " "));

                    //action
                    //List<int> all_actions = (from x in support.Actions select x.incident).ToList();
                    if (!actnum2.ContainsKey(rid))
                    {
                        e.Row.Cells[4].Text = "N/A";
                    }
                    else
                    {
                        e.Row.Cells[4].Text = actnum2[rid].ToString();
                    }

                    e.Row.Cells[0].Visible = false;
                }


                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }
        }

        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                try
                {
                    Support support = new Support();
                    int rid = Convert.ToInt32(e.Row.Cells[0].Text);

                    if (Request.Cookies["user"] != null)
                    {
                        string QueryString = "~/Detail/DetailCase2.aspx?id=" + rid;
                        string NavigateURL = ResolveUrl(QueryString);
                        e.Row.Attributes.Add("onClick", string.Format("window.open('{0}', '_newtab')", NavigateURL));
                        e.Row.Style.Add("cursor", "pointer");
                    }
                    //actnum.ToList().ForEach(x => Response.Write(x.Key + ":" + x.Value + " "));
                    //action
                    //Response.Write(rid);
                    //List<int> all_actions = (from x in support.Actions select x.incident).ToList();
                    if (!actnum.ContainsKey(rid))
                    {
                        e.Row.Cells[4].Text = "N/A";
                    }
                    else
                    {
                        e.Row.Cells[4].Text = actnum[rid].ToString();
                    }

                    e.Row.Cells[0].Visible = false;
                }


                catch (Exception ex)
                {
                    Response.Write(ex);
                }
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[0].Visible = false;
            }
        }

    }
}
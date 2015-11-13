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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace SupportPage
{
    public partial class DetailCase2 : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        static int id;
        static string other = null;

        int drafter_id;
        /*a flag to store if a case is a child or not
         * 0 means it is not a child; 
         * 1 means it is a child;   
         */
        int parent_id;

        /*a flag to store if a case is a new case or not
         * 0 means it is not a new case; 
         * 1 means it is a new case;
         *initially set to 0       
         */
        int isNew = 0;


        protected void Page_Load(object sender, EventArgs e)
        {
            //get the id of the case
            if (!String.IsNullOrEmpty(Request.QueryString["id"]))
            {
                id = Convert.ToInt32(Request.QueryString["id"]);
                //Response.Write(id);
            }

            //check if user cookie exists, means if a user logged in
            if (Request.Cookies["user"] != null)
            {
                string decoded_username = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["username"]), "ProtectCookieUsername"));
                string decoded_role = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["role"]), "ProtectCookieRole"));
                drafter_id = Convert.ToInt32(Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["person"]), "ProtectCookiePerson")));

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


            //string SolutionURI = "DetailAction2?case_id=" + id + "&new=1";
            //detailcase2_addsolution.Attributes.Add("onClick", string.Format("window.open('{0}'),'_self'", SolutionURI));

            string ChildURI = "DetailCase2?new=1&parent=" + id;
            detailcase2_children_add.Attributes.Add("onClick", string.Format("window.open('{0},'_self)", ChildURI));

            //set the multiview initially shows other panel
            Other_Tab.CssClass = "Clicked";
            Report_Tab.CssClass = "Initial";
            Files_Tab.CssClass = "Initial";
            Children_Tab.CssClass = "Initial";
            Customer_Tab.CssClass = "Initial";
            MainView.ActiveViewIndex = 0;


            //to avoid duplication in dropdown lists
            if (IsPostBack)
            {
                detailcase2_handler.DataSourceID = "";
                Items.Clear();
            }

            //add 'none' to some dropdown lists to enable none selection             
            detailcase2_handler.AppendDataBoundItems = true;


            //check if it is a new case
            if (!String.IsNullOrEmpty(Request.QueryString["new"]))
            {
                isNew = Convert.ToInt32(Request.QueryString["new"]);
            }
            //check if this case is a child of another case
            if (Request.QueryString["parent"] != null && Convert.ToInt32(Request.QueryString["parent"]) != 0)
            {
                parent_id = Convert.ToInt32(Request.QueryString["parent"]);
            }

            //detailcase2_interface.Items.Insert(0, new ListItem("--Select Department--", "-1"));  
            //Response.Write(parent_id);
            DateTime lastupdatedDate = new DateTime(1970, 1, 1);
            if (!IsPostBack)
            {
                //ListItem itemToRemove = detailcase2_interface.Items.FindByText("--Interface--");
                //if (itemToRemove != null)
                //{
                //    itemToRemove.Attributes.Add("style", "color:gray;");
                //    itemToRemove.Attributes.Add("disabled", "true");
                //    itemToRemove.Value = "-1";
                //}

                //ListItem itemToRemove2 = detailcase2_handler.Items.FindByText("");
                //if (itemToRemove != null)
                //{
                //    itemToRemove2.Enabled = false;
                //}

                detailcase2_interface.AppendDataBoundItems = true;


                if (isNew == 1)
                {
                    Support s = new Support();
                    Incident newCase = new Incident()
                    {
                        reportdate = DateTime.Now,
                        lastupdatedate = lastupdatedDate,
                        enddate = DateTime.Now,
                        sales = 0,
                        supportteam = 0,
                        technote = 0,
                        instruction = 0,
                        faq = 0,
                        allcompany = 0,
                        drafter = drafter_id,
                        description = "default",
                        model = 19 
                    };

                    s.Incidents.Add(newCase);

                    //load parent
                    if (parent_id != 0)
                    {
                        newCase.parent = parent_id;
                        //before doing other operations, check if the parent still exists.
                        List<int> all_cases = (from x in s.Incidents select x.id).ToList();
                        if (newCase.parent != null)
                        {
                            if (!all_cases.Contains(Convert.ToInt32(newCase.parent.ToString())))
                            {
                                //  detailcase2_parent.Text = "No parent...";
                            }

                            else
                            {
                                var qparent = from p in s.Incidents
                                              where p.id == (int)newCase.parent
                                              select p;
                                if (qparent.FirstOrDefault().description.Length > 10)
                                {
                                    detailcase2_parent.Text = qparent.FirstOrDefault().description.Substring(0, 10);
                                }
                                else
                                {
                                    detailcase2_parent.Text = qparent.FirstOrDefault().description;
                                }

                                //inherited parent's model
                                newCase.model = qparent.FirstOrDefault().model;

                                var mo = (from m in s.models
                                          where m.id == newCase.model
                                          select m).FirstOrDefault();
                                detailcase2_interface.SelectedValue = mo._interface.ToString();
                                String strConnString = ConfigurationManager
                                    .ConnectionStrings["SupportConnectionString"].ConnectionString;
                                String strQuery = "SELECT [cord] FROM [model] WHERE ([interface] = @interface)";
                                SqlConnection con = new SqlConnection(strConnString);
                                SqlCommand cmd = new SqlCommand();
                                cmd.Parameters.AddWithValue("@interface",
                                    Convert.ToInt32(detailcase2_interface.SelectedItem.Value.ToString()));
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = strQuery;
                                cmd.Connection = con;
                                try
                                {
                                    con.Open();
                                    detailcase2_cord.DataSource = cmd.ExecuteReader();
                                    detailcase2_cord.DataTextField = "cord";
                                    detailcase2_cord.DataValueField = "cord";
                                    detailcase2_cord.DataBind();
                                }
                                catch (Exception ex)
                                {
                                    Response.Write(ex);
                                }
                                finally
                                {
                                    con.Close();
                                    con.Dispose();
                                }
                                detailcase2_cord.SelectedValue = mo.cord.ToString();

                                detailcase2_interface.Enabled = false;
                                detailcase2_cord.Enabled = false;
                            }
                        }
                        else
                        {
                            detailcase2_parent.Text = "No parent...";
                        }
                    }
                    s.SaveChanges();
                    id = newCase.id;

                    detailcase2_reportdate.Text = newCase.reportdate.ToString("MM/dd/yyyy");
                    var p_query = from p in s.people where p.id == newCase.drafter select p;
                    detailcase2_drafter.Text = p_query.FirstOrDefault().lastname + " " + p_query.FirstOrDefault().firstname;
                    //Response.Write(id);
                }
                else
                {
                    try
                    {
                        Support support = new Support();
                        Support personnel = new Support();
                        var cases = (from c in support.Incidents
                                     where c.id == id
                                     select new
                                     {
                                         c.allcompany,
                                         c.description,
                                         c.enddate,
                                         c.faq,
                                         c.instruction,
                                         c.lastupdatedate,
                                         c.other,
                                         c.reportdate,
                                         c.sales,
                                         c.supportteam,
                                         c.technote,
                                         c.handler,
                                         c.drafter,
                                         c.parent,
                                         c.cuscom,
                                         c.cusname,
                                         c.discom,
                                         c.dispname,
                                         c.model
                                     }).FirstOrDefault();

                        //parent
                        //before doing other operations, check if the parent still exists.
                        List<int> all_cases = (from x in support.Incidents select x.id).ToList();
                        if (cases.parent != null)
                        {
                            if (!all_cases.Contains(Convert.ToInt32(cases.parent.ToString())))
                            {
                                detailcase2_parent.Text = "N/A";
                            }

                            else
                            {
                                var qparent = from p in support.Incidents
                                              where p.id == (int)cases.parent
                                              select p;
                                if (qparent.FirstOrDefault().description.Length > 10)
                                {
                                    detailcase2_parent.Text = qparent.FirstOrDefault().description.Substring(0, 10);
                                }
                                else
                                {
                                    detailcase2_parent.Text = qparent.FirstOrDefault().description;
                                }
                            }
                        }
                        else
                        {
                            detailcase2_parent.Text = "N/A";
                        }

                        //customer name
                        if (!String.IsNullOrEmpty(cases.cusname))
                        {
                            detailcase2_cusname.Text = "" + cases.cusname.ToString();
                        }
                        else
                        {
                            detailcase2_cusname.Text = "";
                        }

                        //customer company
                        if (!String.IsNullOrEmpty(cases.cusname))
                        {
                            detailcase2_cuscom.Text = "" + cases.cuscom.ToString();
                        }
                        else
                        {
                            detailcase2_cuscom.Text = "";
                        }

                        //distrabution company
                        if (!String.IsNullOrEmpty(cases.discom))
                        {
                            detailcase2_discom.Text = "" + cases.discom.ToString();
                        }
                        else
                        {
                            detailcase2_discom.Text = "";
                        }


                        //distributor 
                        if (!String.IsNullOrEmpty(cases.cusname))
                        {
                            detailcase2_disname.Text = "" + cases.dispname.ToString();
                        }
                        else
                        {
                            detailcase2_disname.Text = "";
                        }

                        //before doing other operations, check if the model still exists.
                        List<int> all_models = (from x in support.models select x.id).ToList();
                        if (cases.model != null)
                        {
                            var par = (from c in support.Incidents
                                       where c.id == cases.parent
                                       select c).FirstOrDefault();

                            int mod = Convert.ToInt32(cases.model.ToString());
                            if (all_models.Contains(mod))
                            {
                                using (Support s = new Support())
                                {
                                    var target = (from x in s.models
                                                  where x.id == mod
                                                  select x).FirstOrDefault();
                                    detailcase2_interface.SelectedValue = target._interface.ToString();
                                }
                                detailcase2_cord.Items.Clear();

                                detailcase2_cord.AppendDataBoundItems = true;
                                String strConnString = ConfigurationManager
                                    .ConnectionStrings["SupportConnectionString"].ConnectionString;
                                String strQuery = "SELECT [cord] FROM [model] WHERE model.interface = @interface";
                                SqlConnection con = new SqlConnection(strConnString);
                                SqlCommand cmd = new SqlCommand();
                                cmd.Parameters.AddWithValue("@interface",
                                    Convert.ToInt32(detailcase2_interface.SelectedItem.Value.ToString()));
                                cmd.CommandType = CommandType.Text;
                                cmd.CommandText = strQuery;
                                cmd.Connection = con;
                                try
                                {
                                    con.Open();
                                    detailcase2_cord.DataSource = cmd.ExecuteReader();
                                    detailcase2_cord.DataTextField = "cord";
                                    detailcase2_cord.DataValueField = "cord";
                                    detailcase2_cord.DataBind();
                                    if (detailcase2_cord.Items.Count >= 1)
                                    {
                                        //Response.Write("haha");
                                        detailcase2_cord.Enabled = true;

                                        if (par != null)
                                        {
                                            //Response.Write("hoho");
                                            using (Support s = new Support())
                                            {
                                                int par_mod = par.model.Value;

                                                var target = (from x in s.models
                                                              where x.id == par_mod
                                                              select x).FirstOrDefault();
                                                detailcase2_interface.SelectedValue = target._interface.ToString();
                                                detailcase2_cord.Text = target.cord.ToString();

                                                detailcase2_interface.Enabled = false;
                                                detailcase2_cord.Enabled = false;

                                                var ca = (from c in s.Incidents
                                                          where c.id == id
                                                          select c).FirstOrDefault();

                                                if (ca.model != par_mod)
                                                {
                                                    //Response.Write("hehe");
                                                    ca.model = par_mod;
                                                    s.SaveChanges();
                                                }
                                            }
                                        }

                                        else
                                        {
                                            using (Support s = new Support())
                                            {
                                                //Response.Write("hiahia");
                                                var target = (from x in s.models
                                                              where x.id == mod
                                                              select x).FirstOrDefault();
                                                detailcase2_cord.SelectedValue = target.cord.ToString();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        detailcase2_cord.Enabled = false;
                                    }
                                }
                                catch (Exception ex)
                                {
                                    Response.Write(ex);
                                }
                                finally
                                {
                                    con.Close();
                                    con.Dispose();
                                }
                            }
                        }

                        //report date
                        if (cases.reportdate != null)
                        {
                            detailcase2_reportdate.Text = "" + cases.reportdate.ToString("MM/dd/yyyy");
                        }
                        else
                        {
                            detailcase2_reportdate.Text = "";
                        }

                        //decription
                        if (String.IsNullOrEmpty(cases.description) || cases.description == "default")
                        {
                            detailcase2_desc.Text = "";
                        }
                        else
                        {
                            detailcase2_desc.Text = cases.description.ToString();

                        }

                        //is closed
                        if (cases.enddate > cases.reportdate)
                        {
                            detailcase2_isclosed_cb.Checked = true;
                        }
                        else
                        {
                            detailcase2_isclosed_cb.Checked = false;
                        }

                        //sales
                        if (cases.sales.HasValue)
                        {
                            detailcase2_sales_rb.SelectedIndex = cases.sales.Value;
                        }
                        else
                        {
                            detailcase2_sales_rb.SelectedIndex = 0;
                        }

                        //support team
                        if (cases.supportteam.HasValue)
                        {
                            detailcase2_supportteam_rb.SelectedIndex = cases.supportteam.Value;
                        }
                        else
                        {
                            detailcase2_supportteam_rb.SelectedIndex = 0;
                        }

                        //tech note
                        if (cases.technote.HasValue)
                        {
                            detailcase2_technote_rb.SelectedIndex = cases.technote.Value;
                        }
                        else
                        {
                            detailcase2_technote_rb.SelectedIndex = 0;
                        }

                        //instruction
                        if (cases.instruction.HasValue)
                        {
                            detailcase2_inst_rb.SelectedIndex = cases.instruction.Value;
                        }
                        else
                        {
                            detailcase2_inst_rb.SelectedIndex = 0;
                        }

                        //faq
                        if (cases.faq.HasValue)
                        {
                            detailcase2_faq_rb.SelectedIndex = cases.faq.Value;
                        }
                        else
                        {
                            detailcase2_faq_rb.SelectedIndex = 0;
                        }

                        //all company
                        if (cases.allcompany.HasValue)
                        {
                            detailcase2_allcompany_rb.SelectedIndex = cases.allcompany.Value;
                        }
                        else
                        {
                            detailcase2_allcompany_rb.SelectedIndex = 0;
                        }

                        //detailcase2_sales_dp.SelectedValue = cases.sales.ToString();
                        //detailcase2_supportteam_dp.SelectedValue = cases.supportteam.ToString();
                        //detailcase2_technote_dp.SelectedValue = cases.technote.ToString();
                        //detailcase2_allcompany_dp.SelectedValue = cases.allcompany.ToString();
                        //detailcase2_faq_dp.SelectedValue = cases.faq.ToString();
                        //detailcase2_inst_dp.SelectedValue = cases.instruction.ToString();

                        //other
                        if (!String.IsNullOrEmpty(cases.other))
                        {
                            other = cases.other.ToString();
                            detailcase2_other.Text = other;
                        }
                        else
                        {
                            detailcase2_other.Text = "";
                        }

                        //drafter
                        List<int> all_person = (from x in personnel.people select x.id).ToList();
                        if (!all_person.Contains(Convert.ToInt32(cases.drafter.ToString())))
                        {
                            detailcase2_drafter.Text = "";
                        }
                        else
                        {
                            int d = cases.drafter;
                            var p_query = from p in personnel.people where p.id == d select p;
                            detailcase2_drafter.Text = "" + p_query.FirstOrDefault().lastname + " " + p_query.FirstOrDefault().firstname;
                        }

                        //handler
                        List<int> all_members = (from x in personnel.members select x.id).ToList();
                        if (cases.handler != null)
                        {
                            if (all_members.Contains(Convert.ToInt32(cases.handler.ToString())))
                            {
                                detailcase2_handler.SelectedValue = cases.handler.ToString();
                            }
                            else
                            {
                                detailcase2_handler.SelectedValue = "";
                            }
                        }
                        else
                        {
                            detailcase2_handler.SelectedValue = "";
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
                    string decoded_lang = Request.Cookies["Language"].Value;
                    //string decoded_lang = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["Language"]["lang"]), "ProtectCookieLanguage"));
                    UICulture = decoded_lang;
                    Culture = Request.UserLanguages[0];
                }
                base.InitializeCulture();
            }

            catch
            {

            }
        }

        ////edit
        //protected void Unnamed4_Click(object sender, EventArgs e)
        //{
        //    detailcase2_cancel.Visible = true;
        //    detailcase2_submit.Visible = true;

        //    //detailcase2_isclosed_dp.Enabled = true;
        //    //detailcase2_sales_dp.Enabled = true;
        //    detailcase2_supportteam_dp.Enabled = true;
        //    detailcase2_technote_dp.Enabled = true;
        //    detailcase2_allcompany_dp.Enabled = true;
        //    detailcase2_faq_dp.Enabled = true;
        //    detailcase2_inst_dp.Enabled = true;
        //    //  detailcase2_handler.Enabled = true;

        //    //detailcase2_isclosed_dp.BorderColor = System.Drawing.Color.Red;
        //    //detailcase2_sales_dp.BorderColor = System.Drawing.Color.Red;
        //    detailcase2_supportteam_dp.BorderColor = System.Drawing.Color.Red;
        //    detailcase2_technote_dp.BorderColor = System.Drawing.Color.Red;
        //    detailcase2_allcompany_dp.BorderColor = System.Drawing.Color.Red;
        //    detailcase2_faq_dp.BorderColor = System.Drawing.Color.Red;
        //    detailcase2_inst_dp.BorderColor = System.Drawing.Color.Red;
        //    // detailcase2_handler.BorderColor = System.Drawing.Color.Red;


        //    Support support = new Support();

        //    var cases = (from c in support.Incidents
        //                 where c.id == id
        //                 select c).FirstOrDefault();


        //    //detailcase2_sales_dp.SelectedValue = cases.sales.ToString();
        //    detailcase2_supportteam_dp.SelectedValue = cases.supportteam.ToString();
        //    detailcase2_technote_dp.SelectedValue = cases.technote.ToString();
        //    detailcase2_allcompany_dp.SelectedValue = cases.allcompany.ToString();
        //    detailcase2_faq_dp.SelectedValue = cases.faq.ToString();
        //    detailcase2_inst_dp.SelectedValue = cases.instruction.ToString();
        //    // detailcase2_handler.SelectedValue = cases.handler.ToString();

        //    detailcase2_other.ReadOnly = false;
        //    detailcase2_desc.ReadOnly = false;
        //    detailcase2_other.ForeColor = System.Drawing.Color.Red;
        //    detailcase2_desc.ForeColor = System.Drawing.Color.Red;
        //}

        ////go back
        //protected void Unnamed1_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect(prevPage);
        //}

        //submit
        protected void detailcase2_submit_Click(object sender, EventArgs e)
        {
            try
            {
                using (Support support = new Support())
                {
                    var cases = (from c in support.Incidents
                                 where c.id == id
                                 select c).FirstOrDefault();

                    List<int> all_cases = (from x in support.Incidents select x.id).ToList();

                    List<Incident> children = new List<Incident>();

                    foreach (Incident i in support.Incidents)
                    {
                        if (i.parent == id)
                        {
                            children.Add(i);
                        }
                    }

                    //do not close the current case if there is a child which is not closed
                    //if (detailcase2_isclosed_dp.SelectedValue == "1")
                    //{
                    //    if (children.Count == 0)
                    //    {
                    //        cases.isclosed = Convert.ToBoolean((Convert.ToInt32(detailcase2_isclosed_dp.SelectedValue)));
                    //    }
                    //    else
                    //    {
                    //        int count = 0;

                    //        foreach (Incident c in children)
                    //        {
                    //            if (c.isclosed == true)
                    //            {
                    //                count++;

                    //            }
                    //        }

                    //        if (count < children.Count)
                    //        {
                    //            Response.Write("can not close this case, because its child is still active!");
                    //        }
                    //        else
                    //        {
                    //            cases.isclosed = Convert.ToBoolean((Convert.ToInt32(detailcase2_isclosed_dp.SelectedValue)));
                    //        }

                    //    }

                    //}
                    //else
                    //{
                    //    cases.isclosed = Convert.ToBoolean((Convert.ToInt32(detailcase2_isclosed_dp.SelectedValue)));
                    //}

                    // cases.sales = Convert.ToInt32(detailcase2_sales_dp.SelectedValue.ToString());
                    //cases.supportteam = Convert.ToInt32(detailcase2_supportteam_dp.SelectedValue.ToString());
                    //cases.technote = Convert.ToInt32(detailcase2_technote_dp.SelectedValue.ToString());
                    //cases.allcompany = Convert.ToInt32(detailcase2_allcompany_dp.SelectedValue.ToString());
                    //cases.faq = Convert.ToInt32(detailcase2_faq_dp.SelectedValue.ToString());
                    //cases.instruction = Convert.ToInt32(detailcase2_inst_dp.SelectedValue.ToString());

                    //if (detailcase2_handler.SelectedValue != "")
                    //{
                    //    cases.handler = Convert.ToInt32(detailcase2_handler.SelectedValue.ToString());

                    //}

                    cases.description = detailcase2_desc.Text;
                    cases.other = detailcase2_other.Text;

                    cases.lastupdatedate = DateTime.Now;
                    support.SaveChanges();
                }

                // detailcase2_cancel.Visible = false;
                // detailcase2_submit.Visible = false;
                //// detailcase2_isclosed_dp.Enabled = false;
                // //detailcase2_sales_dp.Enabled = false;
                // detailcase2_supportteam_dp.Enabled = false;
                // detailcase2_technote_dp.Enabled = false;
                // detailcase2_allcompany_dp.Enabled = false;
                // // detailcase2_handler.Enabled = false;
                // detailcase2_faq_dp.Enabled = false;
                // detailcase2_inst_dp.Enabled = false;
                // detailcase2_other.ReadOnly = true;
                // detailcase2_desc.ReadOnly = true;

                // //detailcase2_isclosed_dp.BorderColor = System.Drawing.Color.LightGray;
                // //detailcase2_sales_dp.BorderColor = System.Drawing.Color.LightGray;
                // detailcase2_supportteam_dp.BorderColor = System.Drawing.Color.LightGray;
                // detailcase2_technote_dp.BorderColor = System.Drawing.Color.LightGray;
                // detailcase2_allcompany_dp.BorderColor = System.Drawing.Color.LightGray;
                // detailcase2_faq_dp.BorderColor = System.Drawing.Color.LightGray;
                // detailcase2_inst_dp.BorderColor = System.Drawing.Color.LightGray;
                //  detailcase2_handler.BorderColor = System.Drawing.Color.LightGray;

                //detailcase2_other.ForeColor = System.Drawing.Color.Black;
                //detailcase2_desc.ForeColor = System.Drawing.Color.Black;
            }

            catch (System.Exception ex)
            {
                Response.Write(ex);
            }



        }

        //cancel
        protected void detailcase2_cancel_Click(object sender, EventArgs e)
        {
            //detailcase2_cancel.Visible = false;
            //detailcase2_submit.Visible = false;

            // detailcase2_isclosed_dp.Enabled = false;
            //detailcase2_sales_dp.Enabled = false;
            //detailcase2_supportteam_dp.Enabled = false;
            //detailcase2_technote_dp.Enabled = false;
            //detailcase2_allcompany_dp.Enabled = false;
            //detailcase2_faq_dp.Enabled = false;
            //detailcase2_inst_dp.Enabled = false;
            //detailcase2_other.ReadOnly = true;
            //detailcase2_desc.ReadOnly = true;
            //detailcase2_other.Text = other;
            //detailcase2_desc.Text = desc;

            //detailcase2_isclosed_dp.BorderColor = System.Drawing.Color.LightGray;
            //detailcase2_sales_dp.BorderColor = System.Drawing.Color.LightGray;
            //detailcase2_supportteam_dp.BorderColor = System.Drawing.Color.LightGray;
            //detailcase2_technote_dp.BorderColor = System.Drawing.Color.LightGray;
            //detailcase2_allcompany_dp.BorderColor = System.Drawing.Color.LightGray;
            //detailcase2_faq_dp.BorderColor = System.Drawing.Color.LightGray;
            //detailcase2_inst_dp.BorderColor = System.Drawing.Color.LightGray;
            //detailcase2_other.BorderColor = System.Drawing.Color.LightGray;
            //detailcase2_desc.BorderColor = System.Drawing.Color.LightGray;
            //     detailcase2_handler.BorderColor = System.Drawing.Color.LightGray;

            detailcase2_other.ForeColor = System.Drawing.Color.Black;
            detailcase2_desc.ForeColor = System.Drawing.Color.Black;
        }



        //delete
        protected void detailcase2_delete_Click(object sender, EventArgs e)
        {
            using (Support s = new Support())
            {
                var target = (from x in s.Incidents
                              where x.id == id
                              select x).FirstOrDefault();

                List<Incident> all_cases = s.Incidents.ToList();
                foreach (Incident cc in all_cases)
                {
                    if (cc.parent == target.id)
                    {
                        Response.Write("Due to one of this case's children is still available, this case can not be deleted!");
                        return;
                    }
                }

                s.Incidents.Remove(target);
                s.SaveChanges();
            }
            Response.Redirect("~/Case");
        }

        ////add solution
        //protected void detailcase2_addsolution_Click(object sender, EventArgs e)
        //{

        //}

        //add file
        protected void detailcase2_addfile_Click(object sender, EventArgs e)
        {
            using (Support support = new Support())
            {
                var cases = (from c in support.Incidents
                             where c.id == id
                             select c).FirstOrDefault();

                if (isNew == 0)
                {
                    cases.lastupdatedate = DateTime.Now;
                }
                support.SaveChanges();
            }
            Response.Redirect("~/Detail/DetailFile?case_id=" + id);
        }

        //protected void detailcase2_addchild_Click(object sender, EventArgs e)
        //{
        //    string URI = "~/Detail/detailcase?parent=" + id + "&interface=" + detailcase2_interface.Text + "&desc=" + detailcase2_desc.Text.Replace("\n", "");
        //    Response.Redirect(URI);
        //}



        protected void detailcase2_action_gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ////Get the LinkButton control in the first cell
                //LinkButton _doubleClickButton = (LinkButton)e.Row.Cells[0].Controls[0].FindControl("DetailCaseActionDBClick");
                ////Get the javascript which is assigned to this LinkButton
                //string _jsDouble =
                //ClientScript.GetPostBackClientHyperlink(_doubleClickButton, "");
                ////Add this JavaScript to the ondblclick Attribute of the row
                //e.Row.Attributes["ondblclick"] = _jsDouble;
                //Response.Write(e.Row.Cells[1].Text);
                string QueryString = "~/Detail/DetailAction2.aspx?id=" + e.Row.Cells[1].Text + "&case_id=" + id;
                string NavigateURL = ResolveUrl(QueryString);
                e.Row.Attributes.Add("onClick", string.Format("window.open('{0}')", NavigateURL));
                e.Row.Style.Add("cursor", "pointer");

                //get the id
                try
                {
                    Support support = new Support();
                    int rid = Convert.ToInt32(e.Row.Cells[1].Text);

                    var person = from c in support.Actions
                                 where c.id == rid
                                 select new
                                 {
                                     c.id,
                                     c.sender
                                 };

                    List<int> all_person = (from x in support.people select x.id).ToList();
                    if (!all_person.Contains(Convert.ToInt32(person.FirstOrDefault().sender.ToString())))
                    {
                        e.Row.Cells[3].Text = "";
                    }
                    else
                    {
                        int d = person.FirstOrDefault().sender;
                        var p_query = from p in support.people where p.id == d select p;
                        e.Row.Cells[3].Text = p_query.FirstOrDefault().lastname + " " + p_query.FirstOrDefault().firstname;
                    }


                }
                catch (Exception ex)
                {
                    Response.Write(ex);
                }

                e.Row.Cells[1].Visible = false;

            }
        }

        protected void detailcase2_action_gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridViewRow row = detailcase2_action_gridview.SelectedRow;

            // Get the selected index and the command name
            string _commandName = e.CommandName;

            if (_commandName == "DoubleClick")
            {
                int action_id = Int32.Parse(e.CommandArgument.ToString());
                try
                {
                    if (action_id >= 0)
                    {
                        Response.Redirect("~/Detail/DetailAction2.aspx?id=" + action_id);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('~/Detail/DetailRole2.aspx?id='" + id + ",'_newtab');", true);
                    }
                }

                catch
                {
                    Response.Write(detailcase2_action_gridview.SelectedIndex + "  " + action_id);
                }
            }
        }

        protected void detailcase2_file_gridview_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                ////Get the LinkButton control in the first cell
                //LinkButton _doubleClickButton = (LinkButton)e.Row.Cells[0].Controls[0].FindControl("DetailCaseFileDBClick");
                ////Get the javascript which is assigned to this LinkButton
                //string _jsDouble =
                //ClientScript.GetPostBackClientHyperlink(_doubleClickButton, "");
                ////Add this JavaScript to the ondblclick Attribute of the row
                //e.Row.Attributes["ondblclick"] = _jsDouble;

                ////length of name
                //string text_name = e.Row.Cells[2].Text.ToString();
                //if (text_name.Length >= 12)
                //{
                //    e.Row.Cells[2].Text = text_name.Substring(0, 12) + "...";
                //}
                //else
                //{
                //    e.Row.Cells[2].Text = text_name;
                //}

                ////length of path
                //string text_path = e.Row.Cells[3].Text.ToString();
                //if (text_path.Length >= 12)
                //{
                //    e.Row.Cells[3].Text = text_path.Substring(0, 12) + "...";
                //}
                //else
                //{
                //    e.Row.Cells[3].Text = text_path;
                //}
            }
        }

        protected void detailcase2_file_gridview_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView _gridView = (GridView)sender;
            GridViewRow row = detailcase2_file_gridview.SelectedRow;

            // Get the selected index and the command name
            string _commandName = e.CommandName;

            if (_commandName == "DoubleClick")
            {
                int file_id = Int32.Parse(e.CommandArgument.ToString());
                try
                {
                    if (file_id >= 0)
                    {

                        Response.Redirect("~/Detail/DetailFile2.aspx?id=" + file_id);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('~/Detail/DetailRole2.aspx?id='" + id + ",'_newtab');", true);
                    }
                }

                catch
                {
                    Response.Write(detailcase2_file_gridview.SelectedIndex + "  " + file_id);
                }
            }
        }

        protected void ChildrenGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                /*
                //Get the LinkButton control in the first cell
                LinkButton _doubleClickButton = (LinkButton)e.Row.Cells[0].Controls[0].FindControl("DetailCaseChildrenDBClick");
                //Get the javascript which is assigned to this LinkButton
                string _jsDouble =
                ClientScript.GetPostBackClientHyperlink(_doubleClickButton, "");
                //Add this JavaScript to the ondblclick Attribute of the row
                e.Row.Attributes["ondblclick"] = _jsDouble;
                */

                if ((e.Row.RowType == DataControlRowType.DataRow))
                {
                    //string QueryString = DataBinder.Eval(e.Row.DataItem, "QueryString").ToString;
                    //string NavigateURL = ResolveUrl(("~/URL.aspx?QueryString=" + QueryString));
                    string NavigateURL = "/Detail/DetailCase2.aspx?id=" + e.Row.Cells[1].Text;
                    e.Row.Attributes.Add("onClick", string.Format("window.open('{0}')", NavigateURL));
                    e.Row.Style.Add("cursor", "pointer");
                }

              

                e.Row.Cells[1].Visible = false;
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                e.Row.Cells[1].Visible = false;
            }
        }

        protected void ChildrenGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            GridView _gridView = (GridView)sender;
            GridViewRow row = detailcase2_children_gridview.SelectedRow;

            // Get the selected index and the command name
            string _commandName = e.CommandName;

            if (_commandName == "DoubleClick")
            {
                int case_id = Int32.Parse(e.CommandArgument.ToString());
                try
                {
                    if (id >= 0)
                    {
                        Response.Redirect("~/Detail/DetailCase2.aspx?id=" + case_id);
                        //Page.ClientScript.RegisterStartupScript(this.GetType(), "OpenWindow", "window.open('~/Detail/DetailRole2.aspx?id='" + id + ",'_newtab');", true);
                    }
                }

                catch
                {
                    Response.Write(detailcase2_children_gridview.SelectedIndex + "  " + case_id);
                }
            }
        }


        //protected override void Render(HtmlTextWriter writer)
        //{
        //    //foreach (GridViewRow r in detailcase2_action_gridview.Rows)
        //    //{
        //    //    if (r.RowType == DataControlRowType.DataRow)
        //    //    {
        //    //        Page.ClientScript.RegisterForEventValidation
        //    //                (r.UniqueID + "$ctl50");
        //    //    }
        //    //}

        //    //base.Render(writer);
        //}

        protected void detailcase2_desc_TextChanged(object sender, EventArgs e)
        {
            //detailcase2_desc.ForeColor = System.Drawing.Color.Orange;
            try
            {
                //Response.Write(id);
                using (Support support = new Support())
                {
                    var cases = (from c in support.Incidents
                                 where c.id == id
                                 select c).FirstOrDefault();
                    cases.description = detailcase2_desc.Text;
                    if (isNew == 0)
                    {
                        cases.lastupdatedate = DateTime.Now;
                    }
                    support.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void Other_Tab_Click(object sender, EventArgs e)
        {
            Other_Tab.CssClass = "Clicked";
            Report_Tab.CssClass = "Initial";
            Files_Tab.CssClass = "Initial";
            Children_Tab.CssClass = "Initial";
            MainView.ActiveViewIndex = 0;
        }

        protected void Report_Tab_Click(object sender, EventArgs e)
        {
            Other_Tab.CssClass = "Initial";
            Report_Tab.CssClass = "Clicked";
            Files_Tab.CssClass = "Initial";
            Children_Tab.CssClass = "Initial";
            MainView.ActiveViewIndex = 1;
        }

        protected void Files_Tab_Click(object sender, EventArgs e)
        {
            Other_Tab.CssClass = "Initial";
            Report_Tab.CssClass = "Initial";
            Files_Tab.CssClass = "Clicked";
            Children_Tab.CssClass = "Initial";
            MainView.ActiveViewIndex = 2;
        }

        protected void Children_Tab_Click(object sender, EventArgs e)
        {
            Other_Tab.CssClass = "Initial";
            Report_Tab.CssClass = "Initial";
            Files_Tab.CssClass = "Initial";
            Children_Tab.CssClass = "Clicked";
            MainView.ActiveViewIndex = 3;
        }

        protected void detailcase2_other_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (Support support = new Support())
                {
                    var cases = (from c in support.Incidents
                                 where c.id == id
                                 select c).FirstOrDefault();
                    cases.other = detailcase2_other.Text;
                    if (isNew == 0)
                    {
                        cases.lastupdatedate = DateTime.Now;
                    }
                    support.SaveChanges();
                }
            }
            catch (System.Exception ex)
            {
                Response.Write(ex);
            }
        }

        protected void detailcase2_isclosed_cb_CheckedChanged(object sender, EventArgs e)
        {
            using (Support support = new Support())
            {
                var cases = (from c in support.Incidents
                             where c.id == id
                             select c).FirstOrDefault();

                if (detailcase2_isclosed_cb.Checked)
                {
                    List<Incident> all_cases = support.Incidents.ToList();
                    foreach (Incident cc in all_cases)
                    {
                        if (cc.parent == cases.id)
                        {
                            if (cc.enddate == cc.reportdate)
                            {
                                detailcase2_isclosed_cb.Checked = false;
                                Response.Write("Due to one of this case's children is still enable, this case can not be closed!");
                                return;
                            }
                        }
                    }
                    if (!(cases.enddate > cases.reportdate))
                    {
                        cases.enddate = DateTime.Now;
                    }

                }

                else if (!detailcase2_isclosed_cb.Checked)
                {
                    if (cases.enddate > cases.reportdate)
                    {
                        cases.enddate = cases.reportdate;
                        //var par = (from c in support.Incidents
                        //           where c.id == cases.parent
                        //           select c).FirstOrDefault();

                        Incident p = support.Incidents.Where(x => x.id == cases.id).FirstOrDefault();
                        //Response.Write(p.id);
                        enableParents(cases);
                    }
                }

                if (isNew == 0)
                {
                    cases.lastupdatedate = DateTime.Now;
                }

                support.SaveChanges();
            }
        }

        protected void Customer_Tab_Click(object sender, EventArgs e)
        {
            Other_Tab.CssClass = "Initial";
            Report_Tab.CssClass = "Initial";
            Files_Tab.CssClass = "Initial";
            Children_Tab.CssClass = "Initial";
            Customer_Tab.CssClass = "Clicked";
            MainView.ActiveViewIndex = 4;
        }



        protected void detailcase2_handler_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (detailcase2_handler.SelectedValue == "")
            {
                return;
            }

            using (Support support = new Support())
            {
                var cases = (from c in support.Incidents
                             where c.id == id
                             select c).FirstOrDefault();

                cases.handler = Convert.ToInt32(detailcase2_handler.SelectedValue.ToString());



                if (isNew == 0)
                {
                    cases.lastupdatedate = DateTime.Now;
                }

                support.SaveChanges();
            }
        }

        protected void detailcase2_btn_report_confirm_Click(object sender, EventArgs e)
        {
            using (Support support = new Support())
            {
                var cases = (from c in support.Incidents
                             where c.id == id
                             select c).FirstOrDefault();

                cases.allcompany = detailcase2_allcompany_rb.SelectedIndex;
                cases.faq = detailcase2_faq_rb.SelectedIndex;
                cases.sales = detailcase2_sales_rb.SelectedIndex;
                cases.supportteam = detailcase2_supportteam_rb.SelectedIndex;
                cases.technote = detailcase2_technote_rb.SelectedIndex;
                cases.instruction = detailcase2_inst_rb.SelectedIndex;

                if (isNew == 0)
                {
                    cases.lastupdatedate = DateTime.Now;
                }

                support.SaveChanges();
            }
        }

        protected void detailcase2_btn_customer_confirm_Click_Click(object sender, EventArgs e)
        {
            using (Support support = new Support())
            {
                var cases = (from c in support.Incidents
                             where c.id == id
                             select c).FirstOrDefault();

                cases.cuscom = detailcase2_cuscom.Text;
                cases.cusname = detailcase2_cusname.Text;
                cases.discom = detailcase2_discom.Text;
                cases.dispname = detailcase2_disname.Text;

                if (isNew == 0)
                {
                    cases.lastupdatedate = DateTime.Now;
                }

                support.SaveChanges();
            }
        }

        //add children
        protected void detailcase2_children_add_Click(object sender, EventArgs e)
        {
            using (Support support = new Support())
            {
                var cases = (from c in support.Incidents
                             where c.id == id
                             select c).FirstOrDefault();

                if (isNew == 0)
                {
                    cases.lastupdatedate = DateTime.Now;
                    support.SaveChanges();
                }
            }

            string URI = "DetailCase2?new=1&parent=" + id;
            Response.Redirect(URI);
        }

        protected void detailcase2_cord_SelectedIndexChanged(object sender, EventArgs e)
        {
            string cord = detailcase2_cord.SelectedValue;
            //Response.Write(cord);
            using (Support support = new Support())
            {
                var cases = (from c in support.Incidents
                             where c.id == id
                             select c).FirstOrDefault();

                var _interface = (from i in support.models
                                  where i.id == cases.model
                                  select i).FirstOrDefault()._interface;

                var model = (from c in support.models
                             where c.cord == cord & c._interface == _interface
                             select c).FirstOrDefault();

                cases.model = model.id;

                if (isNew == 0)
                {
                    cases.lastupdatedate = DateTime.Now;
                }

                support.SaveChanges();
            }
        }

        protected void detailcase2_interface_SelectedIndexChanged(object sender, EventArgs e)
        {

            detailcase2_cord.Items.Clear();

            detailcase2_cord.AppendDataBoundItems = true;
            String strConnString = ConfigurationManager
                .ConnectionStrings["SupportConnectionString"].ConnectionString;
            String strQuery = "SELECT [cord] FROM [model] WHERE ([interface] = @interface)";
            SqlConnection con = new SqlConnection(strConnString);
            SqlCommand cmd = new SqlCommand();

            int _incident = Convert.ToInt32(detailcase2_interface.SelectedItem.Value.ToString());

            cmd.Parameters.AddWithValue("@interface", _incident);
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                detailcase2_cord.DataSource = cmd.ExecuteReader();
                detailcase2_cord.DataTextField = "cord";
                detailcase2_cord.DataValueField = "cord";
                detailcase2_cord.DataBind();
                if (detailcase2_cord.Items.Count >= 1)
                {
                    detailcase2_cord.Enabled = true;

                    string cord = detailcase2_cord.SelectedValue;
                    //Response.Write(cord);
                    using (Support support = new Support())
                    {
                        var model = (from c in support.models
                                     where c.cord == cord & c._interface == _incident
                                     select c).FirstOrDefault();

                        var cases = (from c in support.Incidents
                                     where c.id == id
                                     select c).FirstOrDefault();

                        cases.model = model.id;

                        if (isNew == 0)
                        {
                            cases.lastupdatedate = DateTime.Now;
                        }

                        support.SaveChanges();
                    }
                }
                else
                {
                    detailcase2_cord.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                Response.Write(ex);
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        private void enableParents(Incident i)
        {
            if (i.parent == null)
            {
                return;
            }
            else
            {

                Support support = new Support();
                var par = (from c in support.Incidents
                           where c.id == i.parent
                           select c).FirstOrDefault();

                if (par != null)
                {
                    if (par.enddate > par.reportdate)
                    {
                        //Response.Write("haha| ");
                        par.enddate = par.reportdate;
                    }
                    support.SaveChanges();
                    Incident p = support.Incidents.Where(x => x.id == par.id).FirstOrDefault();
                    enableParents(p);
                }
            }
        }

        protected void detailcase2_addsolution_Click(object sender, ImageClickEventArgs e)
        {
            using (Support support = new Support())
            {
                var cases = (from c in support.Incidents
                             where c.id == id
                             select c).FirstOrDefault();

                if (isNew == 0)
                {
                    cases.lastupdatedate = DateTime.Now;
                    support.SaveChanges();
                }
            }     

            string URI = "~/Detail/DetailAction2?case_id=" + id + "&new=1";

            Response.Redirect(URI);
        }
    }

}
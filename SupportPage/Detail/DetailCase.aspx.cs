//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Threading.Tasks;
//using System.Data;
//using System.Data.SqlClient;
//using SupportPage.Models;
//using System.Text;
//using System.Web.Security;

//namespace SupportPage
//{
//    public partial class DetailCase : System.Web.UI.Page
//    {
//        static string prevPage = String.Empty;
//        static int drafter_id;
//        static int? parent_id = null;
//        //static string desc;
//        static string _interface;

//        protected void Page_Load(object sender, EventArgs e)
//        {
//            if (Request.Cookies["user"] != null)
//            {
//                string decoded_username = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["username"]), "ProtectCookieUsername"));
//                string decoded_role = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["role"]), "ProtectCookieRole"));
//                drafter_id = Convert.ToInt32(Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["person"]), "ProtectCookiePerson")));

//                if (decoded_role == "admin" || decoded_role == "support")
//                {

//                }

//                else
//                {
//                    Response.Redirect("~/");
//                }
//            }

//            else
//            {
//                Response.Redirect("~/");
//            }

//            if (Request.QueryString["interface"] != null)
//            {
//                _interface = Request.QueryString["interface"];
//                detailcase_interface.Text = _interface; 
//            }

//            //if (Request.QueryString["desc"] != null)
//            //{
//            //    desc = Request.QueryString["desc"];
//            //    detailcase_desc.Text = desc;
//            //}

//            //to avoid duplication in dropdown lists
//            if (IsPostBack)
//            {
//                detailcase_handler.DataSourceID = "";
//                Items.Clear();
//            }

//            if (!IsPostBack)
//            {
//                if (prevPage == String.Empty)
//                {
//                    prevPage = Request.UrlReferrer.ToString();
//                }
//            }

//            if (Request.QueryString["parent"] != null)
//            {
//                parent_id = Convert.ToInt32(Request.QueryString["parent"]);
//            } 

//            //add 'none' to some dropdown lists to enable none selection             
//            detailcase_handler.AppendDataBoundItems = true;
//        }

//        protected override void InitializeCulture()
//        {
//            try
//            {
//                if (Request.Cookies["Language"]["lang"] != null)
//                {
//                    string decoded_lang = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["Language"]["lang"]), "ProtectCookieLanguage"));
//                    UICulture = decoded_lang;
//                    Culture = Request.UserLanguages[0];
//                }
//                base.InitializeCulture();
//            }

//            catch
//            {

//            }
//        }

//        //submit
//        protected void Unnamed4_Click(object sender, EventArgs e)
//        {
//            ////validation: if end date is earlier than start date, an alert show up
//            //if (endDate < startDate)
//            //{
//            //    string message = "The end date could not be eariler than start date!";
//            //    System.Text.StringBuilder sb = new System.Text.StringBuilder();
//            //    sb.Append("<script type = 'text/javascript'>");
//            //    sb.Append("window.onload=function(){");
//            //    sb.Append("alert('");
//            //    sb.Append(message);
//            //    sb.Append("')};");
//            //    sb.Append("</script>");
//            //    ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
//            //}
//            //else
//            //{

//            Personnel personnel = new Personnel();
//            Person person = new Person();

//            try
//            {

//                Incident cases = new Incident()
//                {
//                    _interface = detailcase_interface.Text,
//                    description = detailcase_desc.Text,
//                    reportdate = DateTime.Now,
//                    isclosed = false,
//                    sales = Convert.ToInt32(detailcase_sales.SelectedValue),
//                    supportteam = Convert.ToInt32(detailcase_supportteam.SelectedValue),
//                    technote = Convert.ToInt32(detailcase_teahnote.SelectedValue),
//                    instruction = Convert.ToInt32(detailcase_inst.SelectedValue),
//                    faq = Convert.ToInt32(detailcase_faq.SelectedValue),
//                    allcompany = Convert.ToInt32(detailcase_allcompany.SelectedValue),
//                    other = detailcase_other.Text,
//                    enddate = new DateTime(3000,1,1),
//                    lastupdatedate = DateTime.Now,
//                    drafter = drafter_id,
//                    cusname = detailcase_cusname.Text,
//                    discom = detailcase_discom.Text
//                };

//                if (detailcase_handler.SelectedValue != "")
//                {
//                    cases.handler = Convert.ToInt32(detailcase_handler.SelectedValue);
//                }

//                if (parent_id != null)
//                {
//                    cases.parent = parent_id;
//                }

//                Support s = new Support();
//                s.Incidents.Add(cases);
//                s.SaveChanges();

//                Response.Redirect("~/case.aspx");
//            }
//            catch (System.Exception ex)
//            {
//                Response.Write(ex);
//            }
//        }

//        //cancel then go back
//        protected void Unnamed1_Click(object sender, EventArgs e)
//        {
//            Response.Redirect(prevPage);
//        }

//        protected void detailcase_sales_SelectedIndexChanged(object sender, EventArgs e)
//        {

//        }

//    }
//}
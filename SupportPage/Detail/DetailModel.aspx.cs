using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DatabaseUtils;
using SupportPage.Models;
using System.Text;
using System.Web.Security;

namespace SupportPage
{
    public partial class DetailModel : System.Web.UI.Page
    {
        static string prevPage = String.Empty;
        static int id;
        static string name = null;
        static string desc = null;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Cookies["user"] != null)
            {
                string decoded_username = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["username"]), "ProtectCookieUsername"));
                string decoded_role = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["role"]), "ProtectCookieRole"));

                if (decoded_role == "admin")
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
                if (isNew == 1)
                {
                        model NewModel = new model()
                        {
                            _interface=1,
                            cord = "this is a new item"
                        };

                        Support s = new Support();
                        s.models.Add(NewModel);
                        s.SaveChanges();
                        id = NewModel.id;
                }
                else
                {
                    try
                    {
                        Support support = new Support();
                        var model = from m in support.models
                                    where m.id == id
                                    select new
                                    {
                                        m.name,
                                        m._interface,
                                        m.cord
                                    };

                        //name              
                        if (!String.IsNullOrEmpty(model.FirstOrDefault().name))
                        {
                            name = model.FirstOrDefault().name.ToString();
                            detailmodel_name.Text = name;
                        }
                        else
                        {
                            name = "No name...";
                        }


                        //cord             
                        desc = model.FirstOrDefault().cord.ToString();
                        detailmodel_cord.Text = desc;

                        utils u = new utils();

                        //interface
                        detailmodel_interface.Text = u.interfaceUntil(model.FirstOrDefault()._interface);

                    }
                    catch (Exception ex)
                    {
                        Response.Write(ex);
                    }

                    using (Support s = new Support())
                    {
                        var target = (from x in s.models
                                      where x.id == id
                                      select x).FirstOrDefault();
                        detailmodel_interface.SelectedValue = target._interface.ToString();
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

        protected void detailmodel_delete_Click(object sender, EventArgs e)
        {
            using (Support s = new Support())
            {
                var target = (from x in s.models
                              where x.id == id
                              select x).FirstOrDefault();
                s.models.Remove(target);
                s.SaveChanges();
            }

            Response.Redirect("~/Admin/Model");
        }

        protected void detailmodel_cord_TextChanged(object sender, EventArgs e)
        {
            Support support = new Support();
            var model = (from m in support.models
                         where m.id == id
                         select m).FirstOrDefault();
            if (!String.IsNullOrEmpty(detailmodel_cord.Text))
            {
                model.cord = detailmodel_cord.Text;
                support.SaveChanges();
            }
        }

        protected void detailmodel_name_TextChanged(object sender, EventArgs e)
        {
            Support support = new Support();
            var model = (from m in support.models
                         where m.id == id
                         select m).FirstOrDefault();
            model.name = detailmodel_name.Text;
            support.SaveChanges();
        }

        protected void detailmodel_interface_SelectedIndexChanged(object sender, EventArgs e)
        {
            Support support = new Support();
            var model = (from m in support.models
                         where m.id == id
                         select m).FirstOrDefault();

            model._interface = Convert.ToInt32(detailmodel_interface.Text);
            support.SaveChanges();

        }
    }
}
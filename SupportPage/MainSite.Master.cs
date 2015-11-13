using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;

namespace SupportPage
{
    public partial class MainSiteMaster : MasterPage
    {
        private const string AntiXsrfTokenKey = "__AntiXsrfToken";
        private const string AntiXsrfUserNameKey = "__AntiXsrfUserName";
        private string _antiXsrfTokenValue;

        protected void Page_Init(object sender, EventArgs e)
        {
            // 以下代码可帮助防御 XSRF 攻击
            var requestCookie = Request.Cookies[AntiXsrfTokenKey];
            Guid requestCookieGuidValue;
            if (requestCookie != null && Guid.TryParse(requestCookie.Value, out requestCookieGuidValue))
            {
                // 使用 Cookie 中的 Anti-XSRF 令牌
                _antiXsrfTokenValue = requestCookie.Value;
                Page.ViewStateUserKey = _antiXsrfTokenValue;
            }
            else
            {
                // 生成新的 Anti-XSRF 令牌并保存到 Cookie
                _antiXsrfTokenValue = Guid.NewGuid().ToString("N");
                Page.ViewStateUserKey = _antiXsrfTokenValue;

                var responseCookie = new HttpCookie(AntiXsrfTokenKey)
                {
                    HttpOnly = true,
                    Value = _antiXsrfTokenValue
                };
                if (FormsAuthentication.RequireSSL && Request.IsSecureConnection)
                {
                    responseCookie.Secure = true;
                }
                Response.Cookies.Set(responseCookie);
            }

            Page.PreLoad += master_Page_PreLoad;
        }

        protected void master_Page_PreLoad(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // 设置 Anti-XSRF 令牌
                ViewState[AntiXsrfTokenKey] = Page.ViewStateUserKey;
                ViewState[AntiXsrfUserNameKey] = Context.User.Identity.Name ?? String.Empty;
            }
            else
            {
                // 验证 Anti-XSRF 令牌
                if ((string)ViewState[AntiXsrfTokenKey] != _antiXsrfTokenValue
                    || (string)ViewState[AntiXsrfUserNameKey] != (Context.User.Identity.Name ?? String.Empty))
                {
                    throw new InvalidOperationException("Anti-XSRF 令牌验证失败。");
                }
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (Request.Cookies["user"] != null)
            {
                //Response.Write(Request.Cookies["user"].Value);
                //Response.Write(Request.Cookies["role"].Value);
                login.Visible = false;
                loggedin.Visible = true;
                logoff.Visible = true;
                //loggedin.InnerText = "Welcome " + Request.Cookies["user"]["username"];
                try
                {
                    string decoded_username = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["username"]), "ProtectCookieUsername"));
                    string decoded_role = Encoding.UTF8.GetString(MachineKey.Unprotect(Convert.FromBase64String(Request.Cookies["user"]["role"]), "ProtectCookieRole"));

                    loggedin.InnerText = decoded_username;
                    loggedin.HRef = "~/Account/ResetPassword.aspx";

                    if (decoded_role == "admin")
                    {
                        main_site_master_nav_admin.Visible = true;
                    }
                }
                catch 
                {
                    HttpCookie aCookie = HttpContext.Current.Request.Cookies["user"];
                    aCookie.Expires = DateTime.Now.AddDays(-10);
                    aCookie.Value = "";
                    HttpContext.Current.Response.Cookies.Add(aCookie);
                }
            }

            
        }

        protected void logoff_LoggedOut(object sender, EventArgs e)
        {
            //Response.Write("here log off");
            if (HttpContext.Current.Request.Cookies["user"] != null)
            {
                //Response.Write("inside if");
                HttpCookie aCookie = HttpContext.Current.Request.Cookies["user"];
                aCookie.Expires = DateTime.Now.AddDays(-10);
                aCookie.Value = "";
                HttpContext.Current.Response.Cookies.Add(aCookie);
            }
            Response.Redirect("~/");
        }
    }

}

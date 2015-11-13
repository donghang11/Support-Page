using System;
using System.Web;
using System.Web.UI;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Owin;
using SupportPage.Models;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Collections.Generic;

namespace SupportPage.Account
{
    public partial class Login : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected override void InitializeCulture()
        {

            try
            {
                if (Request.Cookies["Language"]!= null)
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

        protected void LogIn(object sender, EventArgs e)
        {
            user users = new user();

            Support user_model = new Support();        

            List<string> all_users = (from x in user_model.users select x.username).ToList();

//string test = (from x in user_model.users select x.username).FirstOrDefault().ToString();

//Response.Write(test);          

            if (all_users.Contains(Email.Text))
            {
                //valid = valid user information
                var valid = (from v in user_model.users
                             where v.username == Email.Text
                             select v).FirstOrDefault();

                if (valid.password == Password.Text)
                {
                    //got the user's role
                    var role = from r in user_model.acctypes
                               where r.id == valid.acctype
                               select r;

                    var person_id = from p in user_model.users
                                    where p.id == valid.id
                                    select p;
                    HttpCookie cookie = new HttpCookie("user");
                    cookie.Expires = DateTime.Now.AddDays(30);
                    var encoded_username = Convert.ToBase64String(MachineKey.Protect(Encoding.UTF8.GetBytes(Email.Text), "ProtectCookieUsername"));
                    var encoded_role = Convert.ToBase64String(MachineKey.Protect(Encoding.UTF8.GetBytes(role.FirstOrDefault().name.ToString()), "ProtectCookieRole"));
                    var encoded_person = Convert.ToBase64String(MachineKey.Protect(Encoding.UTF8.GetBytes(person_id.FirstOrDefault().person.ToString()), "ProtectCookiePerson"));

                    cookie["username"] = encoded_username;
                    cookie["role"] = encoded_role;
                    cookie["person"] = encoded_person;
                    Response.Cookies.Add(cookie);
                    Response.Redirect("~/");
                }

                else
                {
                    Response.Write("Wrong password!");
                }
            }
            else
            {
                Response.Write("Wrong email!");
            }
            //if (IsValid)
            //{
            //    // 验证用户密码
            //    var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            //    var signinManager = Context.GetOwinContext().GetUserManager<ApplicationSignInManager>();

            //    // 这不会计入到为执行帐户锁定而统计的登录失败次数中
            //    // 若要在多次输入错误密码的情况下触发锁定，请更改为 shouldLockout: true
            //    var result = signinManager.PasswordSignIn(Email.Text, Password.Text, RememberMe.Checked, shouldLockout: false);

            //    switch (result)
            //    {
            //        case SignInStatus.Success:
            //            IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            //            break;
            //        case SignInStatus.LockedOut:
            //            Response.Redirect("/Account/Lockout");
            //            break;
            //        case SignInStatus.RequiresVerification:
            //            Response.Redirect(String.Format("/Account/TwoFactorAuthenticationSignIn?ReturnUrl={0}&RememberMe={1}", 
            //                                            Request.QueryString["ReturnUrl"],
            //                                            RememberMe.Checked),
            //                              true);
            //            break;
            //        case SignInStatus.Failure:
            //        default:
            //            FailureText.Text = "无效的登录尝试";
            //            ErrorMessage.Visible = true;
            //            break;
            //    }
            //}
        }
    }
}
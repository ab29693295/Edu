using Edu.Models;
using Edu.Service;
using Edu.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Edu.Web.Controllers
{
    public class LoginController : BaseControl
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(LoginModel login)
        {
            if (string.IsNullOrEmpty(login.Account))
            {
             
                return Json(new { r = false, m = "用户名不能为空" }, JsonRequestBehavior.AllowGet);
            }
            if (string.IsNullOrEmpty(login.Password))
            {
               
                return Json(new { r = false, m = "密码不能为空" }, JsonRequestBehavior.AllowGet);
            }
            var loginuser = unitOfWork.DUserInfo.Get(p => p.UserName == login.Account).FirstOrDefault();
            if (loginuser != null)
            {

                DateTime expiration = DateTime.Now.AddDays(7);
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(loginuser.ID.ToString(), true, 30000);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, FormsAuthentication.Encrypt(ticket));
                Response.Cookies.Set(cookie);

                return Json(new { r = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { r = false,m="用户名或者密码错误" }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
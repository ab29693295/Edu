using Edu.Models;
using Edu.Service;
using Edu.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

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
                return Content("用户名不能为空。");
            }
            if (string.IsNullOrEmpty(login.Password))
            {
                return Content("密码不能为空。"); 
            }
            var loginuser = unitOfWork.DUserInfo.Get(p => p.UserName == login.Account).FirstOrDefault();
            if (loginuser != null)
            {

            }
            return RedirectToAction("Index","Home");
        }
    }
}
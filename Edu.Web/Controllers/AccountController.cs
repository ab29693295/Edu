using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using Edu.Entity;
using Edu.Models;
using Edu.Service;
using Edu.Tools;
namespace Edu.Web.Controllers
{
    public class AccountController : UserBaseController
    {

        #region 管理员登录
        // GET: Account
        public ActionResult Admin_login()
        {
            FormsAuthentication.SignOut();
            return View();
        }
        [HttpPost]
        public ActionResult Admin_login(LoginModel model)
        {

            AccountService As = new AccountService();
            Result r = As.Login(model);
            if (!r.R)
            {
                ModelState.AddModelError("", r.M);
                return View(model);
            }
            if (string.IsNullOrEmpty(model.ReturnUrl))
            {
                return RedirectToAction("index", "Home", new { area = "admin" });
            }
            else
            {
                return Redirect(model.ReturnUrl);
            }


        }
        #endregion

        #region 普通用户登录
        public ActionResult Login(string ReturnUrl = "")
        {
            FormsAuthentication.SignOut();
            ViewBag.ReturnUrl = ReturnUrl;
            return View();

        }
        [HttpPost]
        public ActionResult Login(LoginModel user1)
        {
            string ReturnUrl = this.Request.Form["ReturnUrl"].ToString();
            ViewBag.ReturnUrl = ReturnUrl;

            if (Request.Cookies["ValidateCode"] == null || Request.Cookies["ValidateCode"].Value != this.Request.Form["txtValidateCode"].ToString())
            {
                ModelState.AddModelError("", "请输入正确验证码 ！" + Request.Cookies["ValidateCode"].Value);
                return View(user1);
            }

            AccountService As = new AccountService();
            Result r = As.Login(user1);
            if (!r.R)
            {
                ModelState.AddModelError("", r.M);
                return View(user1);
            }
            if (!string.IsNullOrEmpty(ReturnUrl.Trim()))
            {
                return Redirect(ReturnUrl);

            }
            return RedirectToAction("index", "Home");
        }
        #endregion
        #region 注册

        public ActionResult Register()
        {
            return View("Register");
        }
        [HttpPost]
        public ActionResult Register(UserInfo user1)
        {
            try
            {
                if (Request.Cookies["ValidateCode"] == null || Request.Cookies["ValidateCode"].Value != this.Request.Form["txtValidateCode"].ToString())
                {
                    ModelState.AddModelError("", "请输入正确验证码 ！" + Request.Cookies["ValidateCode"].Value);
                    return View(user1);
                }
            }
            catch { }
            AccountService As = new AccountService();
        
            return RedirectToAction("Index", "Home");

        }
        #endregion
        #region 注销
        public ActionResult logout()
        {
           
            FormsAuthentication.SignOut();
            ViewBag.alert = "注销成功";
            ViewBag.Url = Request.ApplicationPath.TrimEnd('/') + "/Account/Login";
            return PartialView("_JsAlertUrl");
        }
        #endregion
        #region 其他
        public ActionResult GetValidateCode()
        {
            AccountService As = new AccountService();
            byte[] bytes = As.GetValidateCode();
            return File(bytes, @"image/jpeg");
        }
        #endregion
    }
}
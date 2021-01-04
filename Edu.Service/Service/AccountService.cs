using Edu.Entity;
using Edu.Models;
using Edu.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Security;
using System.Web;
using System.Text.RegularExpressions;

namespace Edu.Service
{
    public class AccountService : CoreServiceBase
    {
        public Result Login(LoginModel model)
        {
            Result result = new Result();
            if (string.IsNullOrEmpty(model.Account))
            {
                result.R = false;
                result.M = "用户名不能为空";
                return result;
            }
            if (string.IsNullOrEmpty(model.Password))
            {
                result.R = false;
                result.M = "密码不能为空";
                return result;
            }
            var loginUser = unitOfWork.DUserInfo.Get(p => p.UserName == model.Account).FirstOrDefault();
            if (loginUser == null)
            {
                result.R = false;
                result.M = "指定账号的用户不存在";
                return result;
            }
           
            if (loginUser.PassWord != Edu.Tools.SecureHelper.MD5(model.Password) && loginUser.PassWord != model.Password)
            {
                result.R = false;
                result.M = "登录密码不正确";
                return result;
            }
            FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(loginUser.ID.ToString(), true, 300);
            string encryptticket = FormsAuthentication.Encrypt(ticket);
          
            HttpContext.Current.Response.Cookies.Add(new HttpCookie(FormsAuthentication.FormsCookieName, encryptticket));
            result.R = true;

            return result; ;
        }
  

        public byte[] GetValidateCode()
        {
            ValidateCode vCode = new ValidateCode();
            string code = vCode.CreateValidateCode(5);
            if (HttpContext.Current.Request.Cookies["ValidateCode"] != null && HttpContext.Current.Request.Cookies["ValidateCode"].Value != "")
            {
                HttpContext.Current.Request.Cookies["ValidateCode"].Expires = DateTime.Now.AddMinutes(-5);
            }
            HttpCookie hcookie = new HttpCookie("ValidateCode", code);
            hcookie.Expires = DateTime.Now.AddMinutes(1);
            HttpContext.Current.Response.Cookies.Add(hcookie);
            byte[] bytes = vCode.CreateValidateGraphic(code);
            return bytes;
        }
    }
}

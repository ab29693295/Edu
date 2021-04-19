using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Security;
using Edu.Tools;
using Edu.Data;
using Edu.Entity;

namespace Edu.Service
{
    public class LoginUserService
    {
        public static int UserID
        {
            get
            {
                if (HttpContext.Current.User.Identity.IsAuthenticated)
                {

                    string cookieName = FormsAuthentication.FormsCookieName;
                    HttpCookie authCookie = HttpContext.Current.Request.Cookies[cookieName];
                    if (authCookie != null && authCookie.Value != "")
                    {
                        FormsAuthenticationTicket authTicket = null;
                        authTicket = FormsAuthentication.Decrypt(authCookie.Value);
                        return int.Parse(authTicket.Name);
                    }
                    else return 0;
                }
                return 0;
            }

        }
        /// <summary>
        /// 读取当前登录用户 如果缓存中存在直接读取缓存 不存在读数据库
        /// </summary>
        public static UserInfo User
        {
            get
            {
                if (UserID ==0)
                {
                    return null;
                }
                var old = CacheHelper.GetCache("UserInfo" + UserID);
                if (old == null)
                {
                    UserInfo user;
                    user = new UnitOfWork().DUserInfo.GetByID(UserID);
            
                   CacheHelper.SetCache("UserInfo" + UserID, user);
                    return user;
                }
                else
                {
                    return old as UserInfo;
                }
            }
        }
        public static int RoleID
        {
            get
            {
                if (UserID == 0)
                {
                    return 0;
                }
                else
                {
                    UserInfo user = new UnitOfWork().DUserInfo.GetByID(UserID);
                    if (user == null)
                    {
                        return 0;
                    }
                    else
                    {
                        int roleID = Convert.ToInt32(user.RoleID);
                        return roleID;
                    }
                 
                }
               
            }
        }
    }
}

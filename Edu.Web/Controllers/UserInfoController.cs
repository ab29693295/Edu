using Edu.Service;
using Edu.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edu.Web.Controllers
{
    public class UserInfoController : BaseControl
    {
        // GET: UserInfo
        public ActionResult Index(string sn = "", int pageNo = 1)
        {
            Paging paging = new Paging();
            paging.PageNumber = pageNo;
            var query = unitOfWork.DUserInfo.GetIQueryable(p => p.UserName.Contains(sn) || p.Number.Contains(sn), q => q.OrderBy(p => p.ID));

            paging.Amount = query.Count();
            paging.EntityList = query.Skip(paging.PageSiz * paging.PageNumber).Take(paging.PageSiz).ToList();




            ViewBag.sn = sn;
            ViewBag.Amount = query.Count();
            ViewBag.PageNo = pageNo;//页码
            ViewBag.PageCount = paging.PageCount;//总页数
            return View(paging.EntityList);
        }
    }
}
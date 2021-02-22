using Edu.Entity;
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
            var query = unitOfWork.DUserInfo.GetIQueryable(p => p.UserName.Contains(sn) || p.TrueName.Contains(sn)&&p.Status==1, q => q.OrderBy(p => p.ID));

            paging.Amount = query.Count();
            paging.EntityList = query.Skip(paging.PageSiz * paging.PageNumber).Take(paging.PageSiz).ToList();




            ViewBag.sn = sn;
            ViewBag.Amount = query.Count();
            ViewBag.PageNo = pageNo;//页码
            ViewBag.PageCount = paging.PageCount;//总页数
            return View(paging.EntityList);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <returns></returns>
        public ActionResult Add(int? id)
        {
            var user = unitOfWork.DUserInfo.GetByID(id);

            return View(user);
        }

        [HttpPost]
        public ActionResult Mody(UserInfo user)
        {
            OperationResult result = null;
            var old = unitOfWork.DUserInfo.GetByID(user.ID);

            if (old == null)
            {
                user.Status = 1;
                user.CreatDate = DateTime.Now;
                unitOfWork.DUserInfo.Insert(user);

                result = unitOfWork.Save();
           
            }
            else
            {
             


                unitOfWork.DUserInfo.Update(old, user, new List<string>(this.Request.Form.AllKeys.AsEnumerable()));
                result = unitOfWork.Save();
              
            }
            if (result.ResultType == OperationResultType.Success)
            {
                return Json(new { r = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { r = false, m = "操作失败\n" + result.Message }, JsonRequestBehavior.AllowGet);

            }
        }

    }
}
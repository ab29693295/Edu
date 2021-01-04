using Edu.Tools;
using Edu.Entity;
using Edu.Models;
using Edu.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace Edu.Web.Areas.Admin.Controllers
{
    public class UserInfoController : AdminBaseController
    {
        public ActionResult Index(int? roleID, int? state, DateTime? startT, DateTime? endT, string sn = "", int pageNo = 1)
        {
          
            return View();
        }
        public ActionResult ModyOp(int? id)
        {
            var old = unitOfWork.DUserInfo.GetByID(id);
            List<SelectListItem> LsRole = new List<SelectListItem>();
            var userroles = unitOfWork.DRoleInfo.GetAll();
            if (old != null)
            {
                LsRole.AddRange(new SelectList(userroles, "ID", "NAME", old.RoleID));
            }
            else
            {
                LsRole.AddRange(new SelectList(userroles, "ID", "NAME"));
            }
            ViewBag.RoleID = LsRole;
            return View(old);
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult User_Op(UserInfo user)
        {
        
                return Json(new { r = true }, JsonRequestBehavior.AllowGet);
          
        }
        public ActionResult DeleteOp(int userid)
        {

            var old = unitOfWork.DUserInfo.GetByID(userid);
          
            unitOfWork.DUserInfo.Delete(old);
            var result = unitOfWork.Save();

            if (result.ResultType == OperationResultType.Success)
            {
                return Json(new { r = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { r = false, m = "操作失败\n" + result.Message }, JsonRequestBehavior.AllowGet);

            }
        }
        public ActionResult GetIsUserName(string userName)
        {
            var user = unitOfWork.DUserInfo.Get(p => p.UserName == userName).FirstOrDefault();
            if (user == null)
            {
                return Json("False", JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json("True", JsonRequestBehavior.AllowGet);
            }
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        public ActionResult GetModyPwd(int userid)
        {
            ViewBag.refUrl = Request.UrlReferrer;//修改后返回上层url
            var user = unitOfWork.DUserInfo.GetByID(userid);
            return PartialView("_ModyPwd", user);
        }

        public ActionResult ModyPwd(UserInfo user)
        {
            OperationResult result = null;
            var old = unitOfWork.DUserInfo.GetByID(user.ID);
            old.PassWord = SecureHelper.MD5(user.PassWord);
            unitOfWork.DUserInfo.Update(old);
            result = unitOfWork.Save();
         
            if (result.ResultType == OperationResultType.Success)
            {
                return Json(new { r = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { r = false, m = "操作失败\n" + result.Message }, JsonRequestBehavior.AllowGet);

            }
        }

        public ActionResult LoadSearch(int? roleID, int? state, DateTime? startT, DateTime? endT, string sn = "")
        {
            ViewBag.sn = sn;
            ViewBag.state = state;
            ViewBag.startT = startT;
            ViewBag.endT = endT;
            List<SelectListItem> LsRole = new List<SelectListItem>();
            var userroles = unitOfWork.DRoleInfo.GetAll();
            LsRole.AddRange(new SelectList(userroles, "ID", "NAME", roleID));
            ViewBag.roleID = LsRole;
            return PartialView("_Search");
        }

        public ActionResult ChangeStates(string ids, YesNo _state)
        {

            var Intid = StringHelper.GetListInt(ids.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries));
            foreach (int item in Intid)
            {
                var query = unitOfWork.DUserInfo.GetByID(item);
               
                unitOfWork.DUserInfo.Update(query);
            }
            OperationResult result = unitOfWork.Save();
       
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
﻿using Edu.Tools;
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
    public class UserRoleController : AdminBaseController
    {
        #region 列表
        // GET: Admin/UserRole
        public ActionResult Index()
        {
            var query = unitOfWork.DRoleInfo.GetAll();
            return View(query);
        }
        #endregion

        #region 增加修改
        public ActionResult GetOp(int? id)
        {
            var query = unitOfWork.DRoleInfo.GetByID(id);
            return PartialView("_Op", query);
        }
        public ActionResult Mody(RoleInfo entity)
        {
            OperationResult result = null;
            var old = unitOfWork.DRoleInfo.GetByID(entity.ID);
            if (old == null)
            {
               
                unitOfWork.DRoleInfo.Insert(entity);
                result = unitOfWork.Save();
            
            }
            else
            {
             
                unitOfWork.DRoleInfo.Update(old, entity, new List<string>(this.Request.Form.AllKeys.AsEnumerable()));
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
        #endregion

        #region 删除
        public ActionResult DeleteOp(int id)
        {


            var old = unitOfWork.DRoleInfo.GetByID(id);
            
            unitOfWork.DRoleInfo.Delete(old);
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
        #endregion
    }
}
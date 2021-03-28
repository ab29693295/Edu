using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Edu.Entity;
using Edu.Models;
using Edu.Service;
using Edu.Tools;

namespace Edu.Web.Controllers
{
    public class EquipmentController : UserBaseController
    {
        // GET: Equipment
        public ActionResult Index(string sn="" ,int pageNo=1)
        {
            Paging paging = new Paging();
            paging.PageNumber = pageNo;
            var query = unitOfWork.DEquipment.GetIQueryable(p => p.EqName.Contains(sn) || p.Address.Contains(sn), q => q.OrderBy(p => p.ID));

            paging.Amount = query.Count();
            paging.EntityList = query.Skip(paging.PageSiz * paging.PageNumber).Take(paging.PageSiz).ToList();

            ViewBag.sn = sn;
            ViewBag.Amount = query.Count();
            ViewBag.PageNo = pageNo;//页码
            ViewBag.PageCount = paging.PageCount;//总页数
            return View(paging.EntityList);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult EquipMB(int? id)
        {
            var Equip = unitOfWork.DEquipment.GetByID(id);

            ViewBag.EquipID = Equip.EqCode;

            return View();
        }

        /// <summary>
        /// 添加设备
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult EquipMBMody(EquipMB equipment)
        {
            OperationResult result = null;
            var old = unitOfWork.DEquipMB.GetByID(equipment.ID);

            if (old == null)
            {
              
                unitOfWork.DEquipMB.Insert(equipment);

                result = unitOfWork.Save();

            }
            else
            {



                unitOfWork.DEquipMB.Update(old, equipment, new List<string>(this.Request.Form.AllKeys.AsEnumerable()));
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
        /// <summary>
        /// 添加设备
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Add(int? id)
        {
            var equipMent = unitOfWork.DEquipment.GetByID(id);
            string EqCode = Edu.Tools.CombHelper.ShortStr().ToUpper();

            if (equipMent != null)
            {
                EqCode = equipMent.EqCode;
            }

            var userList = unitOfWork.DUserInfo.GetAll().OrderByDescending(p => p.ID).ToList();

            ViewBag.UserList = userList;

            ViewBag.EqCode = EqCode;
            return View(equipMent);
        }
        /// <summary>
        /// 添加设备
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Mody(Equipment equipment)
        {
            OperationResult result = null;
            var old = unitOfWork.DEquipment.GetByID(equipment.ID);

            if (old == null)
            {
                equipment.EqRunStatus = 1;
                equipment.EqStatus = 0;
                equipment.CreatDate = DateTime.Now;
                unitOfWork.DEquipment.Insert(equipment);

                result = unitOfWork.Save();

            }
            else
            {



                unitOfWork.DEquipment.Update(old, equipment, new List<string>(this.Request.Form.AllKeys.AsEnumerable()));
                result = unitOfWork.Save();

            }
            if (result.ResultType == OperationResultType.Success)
            {
                EuipmentService.AddEquipMBMeal(equipment);

                return Json(new { r = true }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { r = false, m = "操作失败\n" + result.Message }, JsonRequestBehavior.AllowGet);

            }
        }


        /// <summary>
        /// 删除设备
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public ActionResult DeleteOp(int rid)
        {
            unitOfWork.DEquipment.Delete(rid);
            OperationResult result = unitOfWork.Save();
            if (result.ResultType == OperationResultType.Success)
            {
                return Json(new { r = true, m = "" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { r = false, m = result.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 批量删除设备
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public ActionResult DeleteAll(string rids)
        {
            string[] ridArr = rids.Split(',');
            foreach (var id in ridArr)
            {
                int rid = Convert.ToInt32(id);
                unitOfWork.DEquipment.Delete(rid);
            }


            OperationResult result = unitOfWork.Save();
            if (result.ResultType == OperationResultType.Success)
            {
                return Json(new { r = true, m = "" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { r = false, m = result.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
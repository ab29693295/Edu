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
    public class EquipMealController : UserBaseController
    {
        // GET: EquipMeal
        public ActionResult Index(int EqID=0,string sn = "", int pageNo = 1)
        {
            Paging paging = new Paging();
            paging.PageNumber = pageNo;
            var query = unitOfWork.DEquipMeal.GetIQueryable(p => p.MealName.Contains(sn) , q => q.OrderBy(p => p.ID));
            if (EqID != 0)
            {
                query = query.Where(p => p.EqID == EqID);
            }
            paging.Amount = query.Count();
            paging.EntityList = query.Skip(paging.PageSiz * paging.PageNumber).Take(paging.PageSiz).ToList();




            ViewBag.sn = sn;
            ViewBag.Amount = query.Count();
            ViewBag.PageNo = pageNo;//页码
            ViewBag.PageCount = paging.PageCount;//总页数
            return View(paging.EntityList);
        }


        /// <summary>
        /// 添加套餐
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Add(int? id)
        {
            var equipMent = unitOfWork.DEquipMeal.GetByID(id);
        

            var EquipList = unitOfWork.DEquipment.GetAll().OrderByDescending(p => p.ID).ToList();

            ViewBag.EquipList = EquipList;

           
            return View(equipMent);
        }
        /// <summary>
        /// 添加设备
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult Mody(EquipMeal equipmeal)
        {
            OperationResult result = null;
            var old = unitOfWork.DEquipMeal.GetByID(equipmeal.ID);

            if (old == null)
            {

                if (equipmeal.EqID != null)
                {
                    var equip = unitOfWork.DEquipment.GetByID(equipmeal.EqID);
                    equipmeal.EqCode = equip.EqCode;
                }
                equipmeal.Status =1;
                equipmeal.CreatDate = DateTime.Now;
                unitOfWork.DEquipMeal.Insert(equipmeal);

                result = unitOfWork.Save();

            }
            else
            {



                unitOfWork.DEquipMeal.Update(old, equipmeal, new List<string>(this.Request.Form.AllKeys.AsEnumerable()));
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
        /// 删除套餐
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public ActionResult DeleteOp(int rid)
        {
            unitOfWork.DEquipMeal.Delete(rid);
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
        /// 批量删除套餐
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public ActionResult DeleteAll(string rids)
        {
            string[] ridArr = rids.Split(',');
            foreach (var id in ridArr)
            {
                int rid = Convert.ToInt32(id);
                unitOfWork.DEquipMeal.Delete(rid);
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
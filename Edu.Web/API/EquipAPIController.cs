using Edu.Entity;
using Edu.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Edu.Web.API
{
    public class EquipAPIController : BaseAPIController
    {
        [HttpGet]
        /// <summary>
        /// 注册设备
        /// </summary>
        /// <param name="EqCode"></param>
        /// <returns></returns>
        public IHttpActionResult LoginEquip(string EqCode)
        {
            try
            {
                var equip = unitOfWork.DEquipment.Get(p=>p.EqCode== EqCode).FirstOrDefault();
                if (equip != null)
                {
                    equip.EqStatus = 1;

                    unitOfWork.DEquipment.Update(equip);

                    unitOfWork.Save();


                    return Json(new { R = true, ID=equip.ID });
                }
                else
                {
                    return Json(new { R = false, ID = 0, m = "设备不存在！" });
                }
                
            }
            catch (Exception ex)
            {
                return Json(new { R = false, ID = 0, m = ex.ToString() });
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="EqCode"></param>
        /// <returns></returns>
        public IHttpActionResult GetEquipPrice(int  EqID,int type)
        {
            try
            {
                var equip = unitOfWork.DEquipMeal.Get(p => p.EqID == EqID);
                EquipMeal eq = new EquipMeal();
                if (type == 1)
                {
                    eq = equip.FirstOrDefault();
                }
                else
                {
                     eq = equip.LastOrDefault();
                }
                if (eq != null)
                {

                    return Json(new { R = true, Price = eq.MealPrice });
                }
                else
                {
                    return Json(new { R = false, ID = 0, m = "设备不存在！" });
                }

            }
            catch (Exception ex)
            {
                return Json(new { R = false, ID = 0, m = ex.ToString() });
            }
        }


        [HttpGet]
        /// <summary>
        /// 检查机器是否正常在线
        /// </summary>
        /// <param name="EqCode"></param>
        /// <returns></returns>
        public IHttpActionResult CheckEquip(string EqCode)
        {
            try
            {
                var equip = unitOfWork.DEquipment.Get(p => p.EqCode == EqCode).FirstOrDefault();

                if (equip != null)
                {
                    equip.LoginDate = DateTime.Now;
                    equip.EqRunStatus = 1;

                    unitOfWork.DEquipment.Update(equip);

                    unitOfWork.Save();

                    return Json(new { R = true });
                }
                else
                {
                    return Json(new { R = false, m = "设备不存在！" });
                }
                
            }
            catch (Exception ex)
            {
                return Json(new { R = false, m = ex.ToString() });
            }
        }

    }
}

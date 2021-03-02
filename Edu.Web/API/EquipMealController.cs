using Edu.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Edu.Web.API
{
    public class EquipMealController : BaseAPIController
    {

        [HttpGet]
        /// <summary>
        /// 获取美白信息
        /// </summary>
        /// <param name="EqCode"></param>
        /// <returns></returns>
        public IHttpActionResult GetEquipMeal(string EqCode)
        {
            try
            {
                var equip = unitOfWork.DEquipMeal.Get(p => p.EqCode == EqCode);

                if (equip != null)
                {
                    return Json(new { R = true, Data = equip });
                }
                else
                {
                    return Json(new { R = false, m = "设备不存在！", Data = "" });
                }

            }
            catch (Exception ex)
            {
                return Json(new { R = false, m = ex.ToString(), Data = "" });
            }
        }
    }
}

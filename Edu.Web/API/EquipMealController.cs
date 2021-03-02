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
                var mealData = unitOfWork.DEquipMeal.Get(p => p.EqCode == EqCode).Take(2);

                if (mealData != null)
                {
                    return Json(new { R = true, Data = mealData });
                }
                else
                {
                    return Json(new { R = false, m = "套餐不存在！", Data = "" });
                }

            }
            catch (Exception ex)
            {
                return Json(new { R = false, m = ex.ToString(), Data = "" });
            }
        }
    }
}

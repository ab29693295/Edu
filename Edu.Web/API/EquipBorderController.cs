using Edu.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Edu.Web.API
{
    public class EquipBorderController : BaseAPIController
    {

        [HttpGet]
        /// <summary>
        /// 注册设备
        /// </summary>
        /// <param name="EqCode"></param>
        /// <returns></returns>
        public IHttpActionResult Get(string EqCode)
        {
            try
            {
                var BorderList = unitOfWork.DPhotoBorder.Get(p => p.EqCode == EqCode).FirstOrDefault();
                if (BorderList != null)
                {
                  
                    return Json(new { R = true, Data = BorderList, m = "获取成功" });
                }
                else
                {
                    return Json(new { R = false, m = "获取失败" });
                }

            }
            catch (Exception ex)
            {
                return Json(new { R = false, m = ex.ToString() });
            }
        }
    }
}

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
                var equip = unitOfWork.DPhotoBorder.Get(p => p.EqCode == EqCode).FirstOrDefault();
                if (equip != null)
                {
                    equip.EqStatus = 1;

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

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

using Edu.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edu.Web.Controllers
{
    public class WelComeController : UserBaseController
    {
        // GET: WelCome
        public ActionResult Index()
        {

            string timeStr = DateTime.Now.ToString();
            ViewBag.TimeStr = timeStr;

            int OrderCount = unitOfWork.DOrder.GetAllCount();

            int EquipCOunt = unitOfWork.DEquipment.GetAllCount();

            int UserCount = unitOfWork.DUserInfo.GetAllCount();


            ViewBag.OrderCount = OrderCount;
            ViewBag.EquipCOunt = EquipCOunt;
            ViewBag.UserCount = UserCount;
            return View();
        }

        /// <summary>
        /// 按天统计最近两个月订单数量
        /// </summary>
        /// <param name="cid"></param>       
        /// <returns></returns>
        public ActionResult GetOrders()
        {
            DateTime dt = DateTime.Now.AddDays(-60);
            var list = unitOfWork.DOrder.Get(p => p.CreatDate > dt);
            var dd = list
               // 先进行了时间字段变更为String字段，切只保留到天
               // 采用拼接的方式
               .Select(n => new { Data = n, Time = Convert.ToDateTime(n.CreatDate).ToShortDateString() })
               // 分类
               .GroupBy(n => n.Time)
               // 返回汇总样式
               .Select(n => new { Time = n.Key, Datas = n.ToList() }).ToList();
            var categories = dd.Select(p => p.Time);

            var data = dd.Select(p => p.Datas.Count());
            var json = new { categories = categories, data = data };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 按天统计最近两个月设备数量
        /// </summary>
        /// <param name="cid"></param>       
        /// <returns></returns>
        public ActionResult GetEquip()
        {
            DateTime dt = DateTime.Now.AddDays(-60);
            var list = unitOfWork.DEquipment.Get(p => p.CreatDate > dt);
            var dd = list
               // 先进行了时间字段变更为String字段，切只保留到天
               // 采用拼接的方式
               .Select(n => new { Data = n, Time = Convert.ToDateTime(n.CreatDate).ToShortDateString() })
               // 分类
               .GroupBy(n => n.Time)
               // 返回汇总样式
               .Select(n => new { Time = n.Key, Datas = n.ToList() }).ToList();
            var categories = dd.Select(p => p.Time);

            var data = dd.Select(p => p.Datas.Count());
            var json = new { categories = categories, data = data };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 按天统计最近两个月用户数量
        /// </summary>
        /// <param name="cid"></param>       
        /// <returns></returns>
        public ActionResult GetUsers()
        {
            DateTime dt = DateTime.Now.AddDays(-60);
            var list = unitOfWork.DUserInfo.Get(p => p.CreatDate > dt);
            var dd = list
               // 先进行了时间字段变更为String字段，切只保留到天
               // 采用拼接的方式
               .Select(n => new { Data = n, Time = Convert.ToDateTime(n.CreatDate).ToShortDateString() })
               // 分类
               .GroupBy(n => n.Time)
               // 返回汇总样式
               .Select(n => new { Time = n.Key, Datas = n.ToList() }).ToList();
            var categories = dd.Select(p => p.Time);

            var data = dd.Select(p => p.Datas.Count());
            var json = new { categories = categories, data = data };
            return Json(json, JsonRequestBehavior.AllowGet);
        }
    }
}
using Edu.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edu.Web.Controllers
{
    public class HomeController : BaseControl
    {
        public ActionResult Index()
        {
            var user = unitOfWork.DUserInfo.GetAll();
            string a = user.FirstOrDefault().UserName;
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test()
        {
            return View();
        }
        /// <summary>
        /// 抽奖
        /// </summary>
        /// <returns></returns>
        public ActionResult ChouJ()
        {

            var PrizeList = unitOfWork.DPrize.GetAll();
            return View(PrizeList);
        }
    }
}
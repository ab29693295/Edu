using Edu.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edu.Web.Controllers
{
    public class TestController : BaseControl
    {
        // GET: Test
        public ActionResult Index()
        {

            Edu.Tools.LogHelper.Info("我想看看有没有日志！");
            return View();
        }
    }
}
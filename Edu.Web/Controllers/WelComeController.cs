using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edu.Web.Controllers
{
    public class WelComeController : Controller
    {
        // GET: WelCome
        public ActionResult Index()
        {
            return View();
        }
    }
}
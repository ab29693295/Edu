using Edu.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edu.Web.Controllers
{
    public class BorderController : UserBaseController
    {
        // GET: Border
        public ActionResult Index()
        {
            return View();
        }
    }
}
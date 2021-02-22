using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Edu.Entity;
using Edu.Models;
using Edu.Service;
using Edu.Tools;

namespace Edu.Web.Controllers
{
    public class EquipmentController : BaseControl
    {
        // GET: Equipment
        public ActionResult Index()
        {
            return View();
        }
    }
}
using Edu.Service;
using Edu.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edu.Web.Controllers
{
    public class OrderController : BaseControl
    {
        // GET: Order
        public ActionResult Index(string startDt="",string endDt="",int payStatus=2,string sn = "", int pageNo = 1)
        {
            Paging paging = new Paging();
            paging.PageNumber = pageNo;
            var query = unitOfWork.DOrder.GetIQueryable(p => p.OrderID.Contains(sn)||p.EquipID.Contains(sn), q => q.OrderByDescending(p => p.ID));
            if (!string.IsNullOrEmpty(startDt))
            {
                DateTime sDt = Convert.ToDateTime(startDt);
                query = query.Where(p=>p.CreatDate> sDt);
            }
            if (!string.IsNullOrEmpty(endDt))
            {
                DateTime eDt = Convert.ToDateTime(endDt);
                query = query.Where(p => p.CreatDate < eDt);
            }
            if(payStatus!=2)
            {
                query = query.Where(p => p.PayStatus ==payStatus);
            }

            paging.Amount = query.Count();
            paging.EntityList = query.Skip(paging.PageSiz * paging.PageNumber).Take(paging.PageSiz).ToList();

            ViewBag.sn = sn;
            ViewBag.Amount = query.Count();
            ViewBag.PageNo = pageNo;//页码
            ViewBag.PageCount = paging.PageCount;//总页数
            return View(paging.EntityList);
        }
    }
}
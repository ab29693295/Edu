using Edu.Service;
using Edu.Tools;
using Edu.Web.Pay.WX;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edu.Web.Controllers
{
    public class OrderController : UserBaseController
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
            if (Edu.Service.LoginUserService.RoleID != 1)
            {
                int userID = Edu.Service.LoginUserService.UserID;
                query = query.Where(p=>p.EqUserID==userID);
            }

            paging.Amount = query.Count();
            paging.EntityList = query.Skip(paging.PageSiz * paging.PageNumber).Take(paging.PageSiz).ToList();

            ViewBag.sn = sn;
            ViewBag.Amount = query.Count();
            ViewBag.PageNo = pageNo;//页码
            ViewBag.PageCount = paging.PageCount;//总页数
            return View(paging.EntityList);
        }


        /// <summary>
        /// 订单退款
        /// </summary>
        /// <param name="transaction_id"></param>
        /// <param name="out_trade_no"></param>
        /// <param name="price"></param>
        /// <returns></returns>
        public ActionResult Order_Refund(int ID,string transaction_id,string out_trade_no,double  price)
        {
            var order = unitOfWork.DOrder.GetByID(ID);

            order.PayStatus = 3;

            unitOfWork.DOrder.Update(order);

            OperationResult result = unitOfWork.Save();
            try
            {
                string resultRefund = Refund.Run(transaction_id, out_trade_no, (price * 100).ToString(), (price * 100).ToString());
            }
            catch (Exception ex)
            {
                LogHelper.Info("退款失败日志：" + ex.ToString());
            }
           
         
            if (result.ResultType == OperationResultType.Success)
            {
                return Json(new { r = true, m = "" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { r = false, m = result.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}
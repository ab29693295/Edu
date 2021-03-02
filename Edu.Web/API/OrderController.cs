using Edu.Entity;
using Edu.Service;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Xml;

namespace Edu.Web.API
{
    public class OrderController : BaseAPIController
    {
        [HttpPost]
        // POST api/<controller>
        public IHttpActionResult AddOrder()
        {
           

            Stream postData = HttpContext.Current.Request.InputStream;
            StreamReader stream = new StreamReader(postData);

            string postContent = stream.ReadToEnd();
            stream.Close();
            try
            {

                XmlDocument xx = new XmlDocument();
                xx.LoadXml(postContent);//加载xml
                XmlNodeList xxList = xx.GetElementsByTagName("xml"); //取得节点名为row的XmlNode集合
                Order _order = new Order();

                foreach (XmlNode xxNode in xxList)
                {
                    XmlNodeList childList = xxNode.ChildNodes; //取得row下的子节点集合
                    foreach (XmlNode child in childList)
                    {
                        if (child.Name == "OrderID")//订单ID
                        {
                            _order.OrderID= child.InnerText;
                        }
                        if (child.Name == "MealType")//套餐ID
                        {
                            _order.MealType =Convert.ToInt32( child.InnerText);
                        }
                        if (child.Name == "MealName")//套餐类型
                        {
                            _order.MealName = child.InnerText;
                        }
                        if (child.Name == "Price")//价格
                        {
                            _order.Price =Convert.ToDouble(child.InnerText);
                        }
                        if (child.Name == "PayStatus")//支付状态
                        {
                            _order.PayStatus = Convert.ToInt32(child.InnerText);
                        }
                        if (child.Name == "Status")//订单状态
                        {
                            _order.EquipID = child.InnerText;
                        }
                        if (child.Name == "EqID")//设备ID
                        {
                            _order.EqID = Convert.ToInt32(child.InnerText);
                        }
                       
                        if (child.Name == "out_trade_no")
                        {
                            _order.out_trade_no = child.InnerText;
                        }
                    }

                }
                _order.CreatDate = DateTime.Now;
                unitOfWork.DOrder.Insert(_order);
                var isSave = unitOfWork.SaveRMsg();
                if (isSave == "True")
                {
                    return Json(new { R = true ,OrderID= _order.ID});
                }
                else
                {
                    return Json(new { R = false,OrderID=0 });
                }

            }
            catch (Exception ex)
            {
                Edu.Tools.LogHelper.Info(ex.ToString());
                return Json(new { R = false, OrderID = 0 });
            }

        }
        /// <summary>
        /// 获取订单信息
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetOrder(int ID)
        {
            var order = unitOfWork.DOrder.GetByID(ID);
            return Json(new { R = true,Data=order });
        }
        /// <summary>
        /// 获取订单支付状态
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult GetOrderPayStatus(int ID)
        {

            var order = unitOfWork.DOrder.GetByID(ID);
            if (order != null)
            {
                return Json(new { R = true, PayStatus = order.PayStatus });
            }
            else
            {
                return Json(new { R = true, PayStatus = 0 });
            }
          
        }
    }
}
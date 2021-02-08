using Edu.Entity;
using Edu.Service;
using Edu.Tools;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edu.Web.Controllers
{
    public class FileUpLoadController : BaseControl
    {
        [ValidateInput(false)]
        public JsonResult AddOrderPhoto(int OrderID, string PhotoPath, string EqupID)
        {
            if (Request.Files.Count > 0)
            {

                string ImageName = CombHelper.GenerateOrderNumber() + ".png";
                //传过来的图片
                var file = Request.Files[0];
                string fPath = "/File/" + OrderID.ToString() ;//+"/" + ImageName
                //保存到本地或服务器

                if (!Directory.Exists(System.Web.HttpContext.Current.Server.MapPath(fPath)))
                {
                    FileHelper.CreateDirectory(System.Web.HttpContext.Current.Server.MapPath(fPath));
                }
                var uploadsPath = Path.Combine(fPath, CombHelper.GenerateNumber());
                string extraName = file.FileName.Substring(file.FileName.LastIndexOf(".") + 1);
                string fName = file.FileName;
                string filepath = uploadsPath + "." + extraName;
                file.SaveAs(System.Web.HttpContext.Current.Server.MapPath(filepath));

                OrderPhoto odphoto = new OrderPhoto();
                odphoto.OrderID = OrderID.ToString();
                odphoto.PhotoPath = PhotoPath;
                odphoto.PhotoServerPath = ConfigHelper.GetConfigString("HttpUlr") + fPath;
                odphoto.CreatDate = DateTime.Now.ToString();
                odphoto.EqID = EqupID;
                unitOfWork.DOrderPhoto.Insert(odphoto);
                var isSave = unitOfWork.SaveRMsg();
                if (isSave == "True")
                {
                    return Json(new { R = true, ID = odphoto.ID }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new { R = false, ID = 0 }, JsonRequestBehavior.AllowGet);
                }


            }
            else
            {
                return Json(new { R = false, ID = 0 }, JsonRequestBehavior.AllowGet);
            }
          
        }
    }
}
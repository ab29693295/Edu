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
    public class BorderController : UserBaseController
    {
        // GET: Border

        public ActionResult Index(string sn = "", int pageNo = 1)
        {
            Paging paging = new Paging();
            paging.PageNumber = pageNo;
            var query = unitOfWork.DPhotoBorder.GetIQueryable(p => p.BorderName.Contains(sn), q => q.OrderBy(p => p.ID));

            paging.Amount = query.Count();
            paging.EntityList = query.Skip(paging.PageSiz * paging.PageNumber).Take(paging.PageSiz).ToList();




            ViewBag.sn = sn;
            ViewBag.Amount = query.Count();
            ViewBag.PageNo = pageNo;//页码
            ViewBag.PageCount = paging.PageCount;//总页数
            return View(paging.EntityList);
        }

        /// <summary>
        /// 上传图片
        /// </summary>
        /// <returns></returns>
        public ActionResult Mody()
        {
            try
            {

                //JSONHelper.ObjectToJson(postContent);
                //AddLive aLive= JSONHelper.Deserialize<AddLive>(postContent);

                string ImageNames = Request.Form["ImageNames"].ToString();//
                string Des = Request.Form["Des"].ToString();
                string BorderName = Request.Form["BorderName"].ToString();





                PhotoBorder sImage = new PhotoBorder();
                sImage.BorderName = BorderName;
                sImage.Des = Des;
                sImage.Status = 1;
                sImage.CreatDate = DateTime.Now;
                sImage.BorderPath ="http://www.zhuimengnanhai.com:666"+ "/File/Image/" + ImageNames;

                unitOfWork.DPhotoBorder.Insert(sImage);
                unitOfWork.Save();


                return Json(new { r = true });
            }
            catch (Exception ex)
            {
                return Json(new { r = false });
            }
        }


        [HttpPost]
        public ActionResult UpLoad()
        {
            if (System.Web.HttpContext.Current.Request.Files.Count > 0)
            {
                try
                {
                    //得到客户端上传的文件
                    var file = System.Web.HttpContext.Current.Request.Files[0];
                    string fPath = System.Web.HttpContext.Current.Server.MapPath("~/File/Image/");
                    //服务器端要保存的路径
                    if (!Directory.Exists(fPath))
                    {
                        FileHelper.CreateDirectory(fPath);
                    }
                    string filePath = fPath + file.FileName;
                    file.SaveAs(filePath);
                    return Json(new { R = true, fileName = file.FileName });
                }
                catch (Exception ex)
                {
                    return Json(new { R = ex.Message });
                }
            }
            else
            {
                return Json(new { res = "error" }); ;
                //Response.Write("Error1");
            }
        }


        /// <summary>
        /// 添加设备
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ActionResult Add(int? id)
        {
            var equipMent = unitOfWork.DPhotoBorder.GetByID(id);

            return View(equipMent);
        }

        /// <summary>
        /// 删除边框
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public ActionResult DeleteOp(int rid)
        {
            unitOfWork.DPhotoBorder.Delete(rid);
            OperationResult result = unitOfWork.Save();
            if (result.ResultType == OperationResultType.Success)
            {
                return Json(new { r = true, m = "" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { r = false, m = result.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        /// <summary>
        /// 批量删除边框
        /// </summary>
        /// <param name="rid"></param>
        /// <returns></returns>
        public ActionResult DeleteAll(string rids)
        {
            string[] ridArr = rids.Split(',');
            foreach (var id in ridArr)
            {
                int rid = Convert.ToInt32(id);
                unitOfWork.DPhotoBorder.Delete(rid);
            }


            OperationResult result = unitOfWork.Save();
            if (result.ResultType == OperationResultType.Success)
            {
                return Json(new { r = true, m = "" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { r = false, m = result.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        /// 更改用户状态
        /// </summary>
        /// <param name="rid"></param>
        /// <param name="status"></param>
        /// <returns></returns>

        public ActionResult UpdateStatus(int rid, int status)
        {
            var user = unitOfWork.DPhotoBorder.GetByID(rid);
            user.Status = status;
            unitOfWork.DPhotoBorder.Update(user);
            OperationResult result = unitOfWork.Save();
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
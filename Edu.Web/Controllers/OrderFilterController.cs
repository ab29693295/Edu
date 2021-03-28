using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Edu.Web.Controllers
{
    public class OrderFilterController : Controller
    {
        // GET: OrderFilter
        public ActionResult Index(int oID)
        {
            string fPath = "/File/" + oID.ToString() + "/Filter/";//+"/" + ImageName
                                                                  //保存到本地或服务器

           string FilePath= System.Web.HttpContext.Current.Server.MapPath(fPath);
            DirectoryInfo mydir = new DirectoryInfo(FilePath);
            foreach (FileSystemInfo fsi in mydir.GetFileSystemInfos())
            {
                if (fsi is FileInfo)
                {
                    FileInfo fi = (FileInfo)fsi;
                    string x = System.IO.Path.GetDirectoryName(fi.FullName);
                    Console.WriteLine(x);
                    string s = System.IO.Path.GetExtension(fi.FullName);
                    string y = System.IO.Path.GetFileNameWithoutExtension(fi.FullName);
                    Console.WriteLine(y);
                    if (s == ".png")
                    {
                        System.IO.File.Copy(fi.FullName, x + @"\oo" + fi.Name); //在原文件名前加上OO
                        System.IO.File.Delete(fi.FullName);
                    }
                }
            }

            return View();
        }
    }
}
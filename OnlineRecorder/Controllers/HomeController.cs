using OnlineRecorder.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineRecorder.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {            
            return View();
        }

        public ActionResult GetDatas()
        {
            List<AudioItem> list = AudioDao.GetAllItems();
            return Json(new { status =1,msg =$"共{list.Count}首歌曲",data = list},JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult Upload()
        {
            HttpPostedFileBase file = Request.Files["audio"];
            string filePath = string.Empty;
            string fileName = DateTime.Now.ToString("yyyy-MM-dd_hhmmsss");
            string audioName = fileName + Path.GetExtension(file.FileName);
            filePath = Path.Combine(HttpContext.Server.MapPath("~/Uploads/"), audioName);
            file.SaveAs(filePath);
            AudioDao.AddItem(new AudioItem(fileName, "/Uploads/"+ audioName));
            return Json(new { status = 1,msg = "上传成功！" });
        }
    }
}
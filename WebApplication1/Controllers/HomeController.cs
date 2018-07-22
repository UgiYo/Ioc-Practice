using NLog;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        // Logger
        private static Logger logger = NLog.LogManager.GetCurrentClassLogger();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        #region multi-file
        public ActionResult Upload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Upload(IEnumerable<HttpPostedFileBase> files)
        {
            foreach(var file in files)
            {
                if (file != null && file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/FileUploads"), fileName);
                    file.SaveAs(path);
                }
            }
            
            return RedirectToAction("Upload");
        }
        #endregion

        #region file with request
        public ActionResult FileUpload()
        {
            return View();
        }

        [HttpPost]
        public ActionResult FileUploads()
        {
            foreach (string file in Request.Files)
            {
                HttpPostedFileBase uploadFile = Request.Files[file] as HttpPostedFileBase;
                if (uploadFile != null && uploadFile.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(uploadFile.FileName);
                    var path = Path.Combine(Server.MapPath("~/FileUploads"), fileName);
                    uploadFile.SaveAs(path);
                }
            }
            return RedirectToAction("FileUpload");
        }
        #endregion
    }
}
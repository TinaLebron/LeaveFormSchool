using LeaveFormSchool.Application.Services;
using LeaveFormSchool.EntityFramework.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LeaveFormSchool.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            if (Session["page"] != null && Session["page"].ToString() == "page2")
            {

                ViewBag.LogonId = Session["sIDNo"].ToString();
                ViewBag.PasswordHash = Session["password"].ToString();

                Session["sIDNo"] = null;
                Session["password"] = null;
                Session["page"] = null;
                
                return View();
            }
            else if (Session["sIDNo"] != null)
            {
                return RedirectToAction("../LeaveForm/Index");
            }
            else
            {
                return View();
            }
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

        [HttpPost] 
        public JsonResult AccountLogin(string sIDNo, string password, bool rememberMe)
        {
            try
            {
                bool islogin = ApplicationUserServices.IsLoginBySIDNoAndPassword(sIDNo, password);
                if (!islogin) { throw new Exception("請確認帳號密碼是否正確!!!"); }

                string ESPMessage = ApplicationUserServices.ExcludeSpecialPersons(sIDNo);
                if (ESPMessage != null) { throw new Exception(ESPMessage); }

                Session["sIDNo"] = sIDNo;

                if (rememberMe)
                {
                    Session["password"] = password;
                    //登入為page1,首頁為page2
                    Session["page"] = "page1";

                }



                return Json(new { url = Url.Action("Index", "LeaveForm") });
            }
            catch (Exception ex)
            {
                return Json(new { message = ex.Message, error = false });
            }
        }
    }
}
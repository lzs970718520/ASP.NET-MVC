using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using System.Data;

namespace ASP.NET_MVC.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Registration
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ShowMsg(int current)
        {
            RegistrationBLL registration = RegistrationBLL.GetRegistrationBLL();
            List<RegistrationModel> list = registration.ShowMsg(current);
            int allpages = registration.GetAllPages();

            return Json(new { current = current, allpages = Math.Ceiling(allpages * 1.0 / 2), list = list });
        }
        [HttpPost]
        public ActionResult Add(RegistrationModel model)
        {
            RegistrationBLL registration = RegistrationBLL.GetRegistrationBLL();
            bool b = registration.AddRegistration(model);
            if (b)
            {
                return Json(new { status=200 });
            }
            else
            {
                return Json(new { status=500 });
            }
        }
    }
}
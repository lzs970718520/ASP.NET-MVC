using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using Common;

namespace ASP.NET_MVC.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View("Index");
        }
        [HttpPost]
        public ActionResult Login(string username,string password)
        {
            //调用BLL层方法
            AdminBLL adminBLL = AdminBLL.GetAdminBLL();
            AdminModel admin = adminBLL.EmpLogin(username, password);
            if (admin == null)
            {
                return Json(new { status = StatusCodes.登陆失败, msg = "登陆失败" });
            }
            else
            {
                return Json(new { status = StatusCodes.登陆成功, msg = "登陆成功" });
            }
        }
        [HttpPost]
        public ActionResult CheckUserName(string username)
        {
            //调用BLL层方法
            AdminBLL adminBLL = AdminBLL.GetAdminBLL();
            bool b = adminBLL.CheckUserName(username);
            if (b)
            {
                return Json(new { status = StatusCodes.用户名存在, msg = "用户名存在" });
            }
            else
            {
                return Json(new { status = StatusCodes.用户名不存在, msg = "用户名不存在" });
            }
        }
    }
}
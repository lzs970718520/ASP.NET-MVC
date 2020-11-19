using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using Newtonsoft.Json;
using Common;

namespace ASP.NET_MVC.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        public ActionResult Index(int pflag = 0, int current = 1)
        {
            return View();
        }
        [HttpPost]
        public ActionResult ShowMsg(int current, int pflag = 0)
        {
            int pagesize = 2;
            int total = 0;
            int totalpage = 0;

            DepartmenBLL department = DepartmenBLL.GetDepartmentBLL();
            List<DepartmenModel> list = department.GetDepartmentListByPage(current, pagesize, out total, out totalpage);
            if (current <= 1)
            {
                current = 1;
            }
            if (current >= totalpage)
            {
                current = totalpage;
            }
            //int previousPageIndex = current - 1 <= 0 ? 1 : current - 1;
            //int nextPageIndex = current + 1 >= totalpage ? totalpage : current + 1;
            return Json(JsonConvert.SerializeObject(new { status = StatusCodes.列表查询成功, allpages = totalpage, current = current, allcount = total, pagelist = list }), JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddDpt(string pname, string premark)
        {
            DepartmenBLL department = DepartmenBLL.GetDepartmentBLL();
            bool b = department.AddDpt(pname, premark);
            if (b)
            {
                return Json(JsonConvert.SerializeObject(new { status = StatusCodes.部门添加成功, msg = "部门添加成功" }), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(JsonConvert.SerializeObject(new { status = StatusCodes.部门添加失败, msg = "部门添加失败" }), JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult edtDpt(int pid, int state)
        {
            //1恢复部门 0撤销部门
            DepartmenBLL department = DepartmenBLL.GetDepartmentBLL();
            bool flag = department.EditDpt(pid, state);
            if (flag)
            {
                return Json(JsonConvert.SerializeObject(new { status = StatusCodes.部门修改成功, msg = "部门修改成功" }), JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(JsonConvert.SerializeObject(new { status = StatusCodes.部门修改失败, msg = "部门修改失败" }), JsonRequestBehavior.AllowGet);
            }
        }
    }
}
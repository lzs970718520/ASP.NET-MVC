using BLL;
using Common;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASP.NET_MVC.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Employee()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ShowDepartment(int current)
        {
            EmployeeBLL employee = EmployeeBLL.GetEmployeeBLL();
            //List<PositionModel> model = position.GetPositionMsgByPage(current);
            LinkedList<EmployeeModel> linked = employee.GetDepartmentMsgByPage(current);
            int count = employee.GetAllByPage();
            return Json(new { current = current, allpages = Math.Ceiling(count * 1.0 / 2) * 10, count = count, status = StatusCodes.角色查询成功, list = linked });
        }
        [HttpPost]
        public ActionResult GetAllPage()
        {
            EmployeeBLL employee = EmployeeBLL.GetEmployeeBLL();
            int count = employee.GetAllByPage();
            return Json(new { allpages = Math.Ceiling(count * 1.0 / 2)*10, status = StatusCodes.角色查询成功 });
        }
        [HttpPost]
        public ActionResult ShowOptions()
        {
            EmployeeBLL employee = EmployeeBLL.GetEmployeeBLL();
            List<EmployeeModel> jsList = employee.GetjsListOptions();
            List<EmployeeModel> deptList = employee.GetdeptListOptions();
            return Json(new { jsList= jsList, deptList= deptList, status = StatusCodes.角色查询成功 });
        }
        [HttpPost]
        public ActionResult addEmp(EmployeeModel model)
        {
            EmployeeBLL employee = EmployeeBLL.GetEmployeeBLL();
            bool b = employee.addEmp(model);
            if (b)
            {
                return Json(new { status = StatusCodes.角色查询成功 });
            }
            else
            {
                return null;
            }
        }
    }
}
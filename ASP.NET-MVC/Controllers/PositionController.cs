using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL;
using Model;
using System.Data;
using Common;
using System.Text;

namespace ASP.NET_MVC.Controllers
{
    public class PositionController : Controller
    {
        // GET: Position
        public ActionResult Position()
        {
            return View();
        }

        [HttpPost]
        public ActionResult ShowPosition(int current)
        {
            PositionBLL position = PositionBLL.GetPositionBLL();
            //List<PositionModel> model = position.GetPositionMsgByPage(current);
            LinkedList<PositionModel> linked = position.GetPositionMsgByPage(current);
            int count = position.GetAllByPage();
            return Json(new { current=current,allpages=Math.Ceiling(count*1.0/2),count=count,status=StatusCodes.角色查询成功,linked = linked });
        }
        [HttpPost]
        public ActionResult AddPosition(string pname)
        {
            PositionBLL position = PositionBLL.GetPositionBLL();
            bool b = position.AddPosition(pname);
            if (b)
            {
                return Json(new { Status = 1 });
            }
            else
            {
                return Json(new { Status = 0 });
            }
        }
        [HttpGet]
        public ActionResult UpdatePosition()
        {
            Encoding utf8 = Encoding.UTF8;
            ViewBag.jid = Convert.ToInt32(Request.QueryString["jid"]);
            ViewBag.Name = HttpUtility.UrlDecode(Request.QueryString["Name"],utf8);
            return View();
        }
        [HttpPost]
        public ActionResult updPosition(string jname,int jid)
        {
            PositionBLL position = PositionBLL.GetPositionBLL();
            bool b = position.updPosition(jname,jid);
            if (b)
            {
                return Json(new { Status = 1 });
            }
            else
            {
                return Json(new { Status = 0 });
            }
        }
    }
}
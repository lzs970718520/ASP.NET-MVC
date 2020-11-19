using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;
using System.Data;

namespace BLL
{
    public class DepartmenBLL
    {
        private static DepartmenBLL _DepartmenBLL = null;
        private DepartmenBLL() { }
        public static DepartmenBLL GetDepartmentBLL()
        {
            if (_DepartmenBLL == null)
            {
                _DepartmenBLL = new DepartmenBLL();
            }
            return _DepartmenBLL;
        }

        public List<DepartmenModel> GetDepartmentListByPage(int pageIndex, int pagesize, out int total, out int totalpage)
        {
            DepartmenDAL departmenDAL = DepartmenDAL.GetDepartmentDAL();
            total = departmenDAL.GetDepartmentTotal();
            totalpage = Convert.ToInt32(Math.Ceiling(total * 1.0 / pagesize));
            DataTable dt = departmenDAL.GetDepartmentListByPage((pageIndex - 1) * pagesize, pageIndex * pagesize);
            List<DepartmenModel> list = new List<DepartmenModel>();
            foreach (DataRow dr in dt.Rows)
            {
                DepartmenModel model = new DepartmenModel();
                model.PID = Convert.ToInt32(dr["PID"]);
                model.PNAME = dr["PNAME"].ToString();
                model.PFLAG = Convert.ToInt32(dr["PFLAG"]);
                model.PREMARK = dr["PREMARK"].ToString();
                list.Add(model);
            }
            return list;
        }
        
        public bool AddDpt(string pname, string premark)
        {
            DepartmenDAL department = DepartmenDAL.GetDepartmentDAL();
            return department.AddDpt(pname, premark) > 0 ? true : false;
        }

        public bool EditDpt(int pid, int state)
        {
            DepartmenDAL department = DepartmenDAL.GetDepartmentDAL();
            return department.EditDpt(pid, state) > 0 ? true : false;
        }
    }
}

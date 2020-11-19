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
    public class EmployeeBLL
    {
        private static EmployeeBLL _EmployeeBLL = null;
        private EmployeeBLL() { }
        public static EmployeeBLL GetEmployeeBLL()
        {
            if (_EmployeeBLL == null)
            {
                _EmployeeBLL = new EmployeeBLL();
            }
            return _EmployeeBLL;
        }

        public LinkedList<EmployeeModel> GetDepartmentMsgByPage(int current)
        {
            EmployeeDAL employee = EmployeeDAL.GetEmployeeDAL();
            LinkedList<EmployeeModel> linked = new LinkedList<EmployeeModel>();
            DataTable dt = employee.GetDepartmentMsgByPage(current);
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeModel model = new EmployeeModel();
                model.EID = Convert.ToInt32(dr["EID"]);
                model.JNAME = dr["JNAME"].ToString(); 
                model.pname = dr["pname"].ToString();
                model.ENAME = dr["ENAME"].ToString();
                model.EPSW = dr["EPSW"].ToString();
                model.EREALNAME = dr["EREALNAME"].ToString();
                model.ETEL = dr["ETEL"].ToString();
                model.EADDRESS = dr["EADDRESS"].ToString();
                model.EFLAG = Convert.ToInt32(dr["EFLAG"]);
                model.EREALNAME = dr["EREALNAME"].ToString();
                linked.AddLast(model);
            }
            return linked;
        }

        public List<EmployeeModel> GetdeptListOptions()
        {
            EmployeeDAL employee = EmployeeDAL.GetEmployeeDAL();
            DataTable dt = employee.GetdeptListOptions();
            List<EmployeeModel> list = new List<EmployeeModel>();
            foreach(DataRow dr in dt.Rows)
            {
                EmployeeModel model = new EmployeeModel();
                model.PID = Convert.ToInt32(dr["PID"]);
                model.pname = dr["PNAME"].ToString();
                list.Add(model);
            }
            return list;
        }

        public bool addEmp(EmployeeModel model)
        {
            EmployeeDAL employee = EmployeeDAL.GetEmployeeDAL();
            return employee.addEmp(model) > 0 ? true : false;
        }

        public List<EmployeeModel> GetjsListOptions()
        {
            EmployeeDAL employee = EmployeeDAL.GetEmployeeDAL();
            DataTable dt = employee.GetjsListOptions();
            List<EmployeeModel> list = new List<EmployeeModel>();
            foreach (DataRow dr in dt.Rows)
            {
                EmployeeModel model = new EmployeeModel();
                model.JID = Convert.ToInt32(dr["JID"]);
                model.JNAME = dr["JNAME"].ToString();
                list.Add(model);
            }
            return list;
        }

        public int GetAllByPage()
        {
            EmployeeDAL employee = EmployeeDAL.GetEmployeeDAL();
            return employee.GetAllByPage();
        }
    }
}

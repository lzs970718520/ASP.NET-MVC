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
    public class AdminBLL
    {
        //单例设计模式
        private static AdminBLL _AdminBLL = null;
        private AdminBLL() { }
        public static AdminBLL GetAdminBLL()
        {
            if (_AdminBLL == null)
            {
                _AdminBLL = new AdminBLL();
            }
            return _AdminBLL;
        }

        public AdminModel EmpLogin(string username, string password)
        {
            AdminDAL adminDAL = AdminDAL.GetAdminDAL();
            DataTable dt = adminDAL.EmpLogin(username, password);
            if (dt.Rows.Count <= 0)
            {
                return null;
            }
            else
            {
                AdminModel model = new AdminModel();
                model.ename = dt.Rows[0]["ename"].ToString();
                return model;
            } 
        }
        public bool CheckUserName(string username)
        {
            AdminDAL adminDAL = AdminDAL.GetAdminDAL();
            return adminDAL.CheckUserName(username).Rows.Count>0?true:false;
        }
    }
}

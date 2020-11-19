using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class RegistrationBLL
    {
        private static RegistrationBLL _RegistrationBLL = null;
        private RegistrationBLL() { }
        public static RegistrationBLL GetRegistrationBLL()
        {
            if (_RegistrationBLL == null)
            {
                _RegistrationBLL = new RegistrationBLL();
            }
            return _RegistrationBLL;
        }

        public List<RegistrationModel> ShowMsg(int current)
        {
            RegistrationDAL registration = RegistrationDAL.GetRegistrationDAL();
            DataTable dt = registration.ShowMsg(current);
            List<RegistrationModel> list = new List<RegistrationModel>();
            foreach (DataRow dr in dt.Rows)
            {
                RegistrationModel model = new RegistrationModel();
                model.BID = Convert.ToInt32(dr["BID"]);
                model.EID = Convert.ToInt32(dr["EID"]);
                model.HID = Convert.ToInt32(dr["HID"]);
                model.MTIME = dr["MTIME"].ToString();
                model.BREMARK = dr["BREMARK"].ToString();
                list.Add(model);
            }
            return list;
        }

        public bool AddRegistration(RegistrationModel model)
        {
            RegistrationDAL registration = RegistrationDAL.GetRegistrationDAL();
            return registration.AddRegistration(model) > 0 ? true : false;
        }

        public int GetAllPages()
        {
            RegistrationDAL registration = RegistrationDAL.GetRegistrationDAL();
            return registration.GetAllPages();
        }
    }
}

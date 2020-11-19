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
    public class PositionBLL
    {
        private static PositionBLL _PositionBLL = null;
        private PositionBLL() { }
        public static PositionBLL GetPositionBLL()
        {
            if (_PositionBLL == null)
            {
                _PositionBLL = new PositionBLL();
            }
            return _PositionBLL;
        }

        public LinkedList<PositionModel> GetPositionMsgByPage(int current)
        {
            PositionDAL position = PositionDAL.GetPositionDAL();
            DataTable dt = position.GetPositionMsgByPage(current);
            LinkedList<PositionModel> linked = new LinkedList<PositionModel>();
            foreach(DataRow dr in dt.Rows)
            {
                PositionModel model = new PositionModel();
                model.jid= Convert.ToInt32(dr["jid"]);
                model.jname= dr["jname"].ToString();
                linked.AddLast(model);
            }
            return linked;
        }

        public bool AddPosition(string pname)
        {
            PositionDAL position = PositionDAL.GetPositionDAL();
            return position.AddPosition(pname) > 0 ? true : false;
        }

        public int GetAllByPage()
        {
            PositionDAL position = PositionDAL.GetPositionDAL();
            return position.GetAllByPage();
        }

        public bool updPosition(string jname,int jid)
        {
            PositionDAL position = PositionDAL.GetPositionDAL();
            return position.updPosition(jname,jid) > 0 ? true : false;
        }

        //public List<PositionModel> GetPositionMsgByPage(int current)
        //{
        //    throw new NotImplementedException();
        //}
    }
}

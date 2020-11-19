using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PositionDAL
    {
        private static PositionDAL _PositionDAL = null;
        private PositionDAL() { }
        public static PositionDAL GetPositionDAL()
        {
            if (_PositionDAL == null)
            {
                _PositionDAL = new PositionDAL();
            }
            return _PositionDAL;
        }

        public DataTable GetPositionMsgByPage(int current)
        {
            using(SqlConnection sqlconnection = SqlHelper.GetSqlConnection())
            {
                string sql = @" select t.* from (select ROW_NUMBER()over(order by a.JID desc)as Rownum,a.* from myjs as a)as t where t.Rownum>=@star and t.Rownum<@end";
                return SqlHelper.GetDataQuery(sqlconnection, sql, new SqlParameter[]
                {
                    new SqlParameter("@star",(current*2-1)),
                    new SqlParameter("@end",(current*2+1))
                });
            }
        }

        public int GetAllByPage()
        {
            using (SqlConnection sqlconnection = SqlHelper.GetSqlConnection())
            {
                string sql = @" select count(*) from myjs";
                return Convert.ToInt32(SqlHelper.ExcuteScaler(sqlconnection, sql));
            }
        }

        public int AddPosition(string pname)
        {
            using (SqlConnection sqlconnection = SqlHelper.GetSqlConnection())
            {
                string sql = @" insert into myjs values(@pname)";
                return SqlHelper.ExcuteNonQuery(sqlconnection, sql, new SqlParameter[]
                {
                    new SqlParameter("@pname",pname)
                });
            }
        }

        public int updPosition(string jname,int jid)
        {
            using (SqlConnection sqlconnection = SqlHelper.GetSqlConnection())
            {
                string sql = @" update myjs set jname=@jname where jid=@jid";
                return SqlHelper.ExcuteNonQuery(sqlconnection, sql, new SqlParameter[]
                {
                    new SqlParameter("@jname",jname),
                    new SqlParameter("@jid",jid),
                });
            }
        }
    }
}

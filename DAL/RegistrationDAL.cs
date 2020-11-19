using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class RegistrationDAL
    {
        private static RegistrationDAL _RegistrationDAL = null;
        private RegistrationDAL() { }
        public static RegistrationDAL GetRegistrationDAL()
        {
            if (_RegistrationDAL == null)
            {
                _RegistrationDAL = new RegistrationDAL();
            }
            return _RegistrationDAL;
        }

        public DataTable ShowMsg(int current)
        {
            using(SqlConnection sqlconnection = SqlHelper.GetSqlConnection())
            {
                string sql = @"select t.* from (select ROW_NUMBER()over(order by a.BID desc)as Rownum,a.* from mybs as a)as t 
                                where t.Rownum >= @star and t.Rownum < @end";
                return SqlHelper.GetDataQuery(sqlconnection, sql, new SqlParameter[]
                 {
                    new SqlParameter("@star",(current*2-1)),
                    new SqlParameter("@end",(current*2+1))
                 });
            }
        }

        public int GetAllPages()
        {
            using (SqlConnection sqlconnection = SqlHelper.GetSqlConnection())
            {
                string sql = @"select count(*) from mybs ";
                return Convert.ToInt32(SqlHelper.ExcuteScaler(sqlconnection, sql));
            }
        }

        public int AddRegistration(RegistrationModel model)
        {
            using (SqlConnection sqlconnection = SqlHelper.GetSqlConnection())
            {
                string sql = @" insert into mybs values(1,getdate(),@BREMARK,1)";
                return SqlHelper.ExcuteNonQuery(sqlconnection, sql, new SqlParameter[]
                {
                    new SqlParameter("@BREMARK",model.BREMARK)
                });
            }
        }
    }
}

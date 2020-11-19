using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DepartmenDAL
    {
        private static DepartmenDAL _DepartmenDAL = null;
        private DepartmenDAL() { }
        public static DepartmenDAL GetDepartmentDAL()
        {
            if (_DepartmenDAL == null)
            {
                _DepartmenDAL = new DepartmenDAL();
            }
            return _DepartmenDAL;
        }
        

        public int GetDepartmentTotal()
        {
            using (SqlConnection sqlconnection = SqlHelper.GetSqlConnection()) {
                string sql = "select count(*) from mydept";
                return Convert.ToInt32(SqlHelper.ExcuteScaler(sqlconnection,sql));
            }
        }

        public DataTable GetDepartmentListByPage(int star, int end)
        {
            using (SqlConnection sqlconnection = SqlHelper.GetSqlConnection()) {
                string sql = @" select t.* from (select ROW_NUMBER()over(order by a.PID desc)as Rownum,a.* from mydept as a)as t where t.Rownum>@star and t.Rownum<=@end";
                return SqlHelper.GetDataQuery(sqlconnection, sql, new SqlParameter[]
                {
                    new SqlParameter("@star",star),
                    new SqlParameter("@end",end)
                });
            }
        }

        public int EditDpt(int pid, int state)
        {
            using(SqlConnection sqlconnection = SqlHelper.GetSqlConnection())
            {
                string sql = "update mydept set PFLAG=@PFLAG where PID=@PID";
                return SqlHelper.ExcuteNonQuery(sqlconnection, sql, new SqlParameter[]
                {
                    new SqlParameter("@PFLAG",state),
                    new SqlParameter("@PID",pid),
                });
            }
        }

        public int AddDpt(string pname, string premark)
        {
            using(SqlConnection sqlconnection = SqlHelper.GetSqlConnection())
            {
                string sql = " insert into mydept values(@pname,0,@premark)";
                return SqlHelper.ExcuteNonQuery(sqlconnection, sql, new SqlParameter[]
                {
                    new SqlParameter("@pname",pname),
                    new SqlParameter("@premark",premark)
                });
            }
        }
    }
}

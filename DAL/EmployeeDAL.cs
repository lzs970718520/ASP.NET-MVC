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
    public class EmployeeDAL
    {
        private static EmployeeDAL _EmployeeDAL = null;
        private EmployeeDAL() { }
        public static EmployeeDAL GetEmployeeDAL()
        {
            if (_EmployeeDAL == null)
            {
                _EmployeeDAL = new EmployeeDAL();
            }
            return _EmployeeDAL;
        }

        public DataTable GetDepartmentMsgByPage(int current)
        {
            using (SqlConnection sqlconnection = SqlHelper.GetSqlConnection())
            {
                string sql = @" select t.*,b.pname,c.JNAME from (select ROW_NUMBER()over(order by a.JID desc)as Rownum,a.* from myemp as a)as t 
                                  left join mydept b on b.PID=t.PID
                                  left join myjs c on c.JID=t.JID where t.Rownum>=@star and t.Rownum<@end";
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
                string sql = @" select count(*) from myemp ";
                return Convert.ToInt32(SqlHelper.ExcuteScaler(sqlconnection, sql));
            }
        }

        public DataTable GetdeptListOptions()
        {
            using (SqlConnection sqlConnection = SqlHelper.GetSqlConnection())
            {
                string sql = "select * from mydept";
                return SqlHelper.GetDataQuery(sqlConnection, sql);
            }
        }

        public DataTable GetjsListOptions()
        {
            using(SqlConnection sqlConnection = SqlHelper.GetSqlConnection())
            {
                string sql = "select * from myjs";
                return SqlHelper.GetDataQuery(sqlConnection, sql);
            }
        }

        public int addEmp(EmployeeModel model)
        {
            using(SqlConnection sqlconnection = SqlHelper.GetSqlConnection())
            {
                string sql = @"insert into myemp values(@PID,@JID,@ENAME,@EPSW,@EREALNAME,@ETEL,@EADDRESS,0,@EREMARK)";
                return SqlHelper.ExcuteNonQuery(sqlconnection, sql, new SqlParameter[]
                {
                    new SqlParameter("PID",model.PID),
                    new SqlParameter("JID",model.JID),
                    new SqlParameter("ENAME",model.ENAME),
                    new SqlParameter("EPSW",model.EPSW),
                    new SqlParameter("EREALNAME",model.EREALNAME),
                    new SqlParameter("ETEL",model.ETEL),
                    new SqlParameter("EADDRESS",model.EADDRESS),
                    new SqlParameter("EREMARK",model.EREMARK),
                });
            }
        }
    }
}

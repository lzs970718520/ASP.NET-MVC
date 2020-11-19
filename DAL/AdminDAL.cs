using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class AdminDAL
    {
        private static AdminDAL _AdminDAL = null;
        private AdminDAL() { }
        public static AdminDAL GetAdminDAL()
        {
            if (_AdminDAL == null)
            {
                _AdminDAL = new AdminDAL();
            }
            return _AdminDAL;
        }
        public DataTable EmpLogin(string username,string password)
        {
            using (SqlConnection sqlconnection = SqlHelper.GetSqlConnection())
            {
                string sql = "select * from myemp where EName = @EName and EPsw=@EPsw";
                return SqlHelper.GetDataQuery(sqlconnection, sql, new SqlParameter[]
                {
                    new SqlParameter("@EName",username),
                    new SqlParameter("@EPsw",password)
                });
            }
        }
        public DataTable CheckUserName(string username)
        {
            using (SqlConnection sqlconnection = SqlHelper.GetSqlConnection())
            {
                string sql = "select * from myemp where EName = @EName";
                return SqlHelper.GetDataQuery(sqlconnection, sql, new SqlParameter[]
                {
                    new SqlParameter("@EName",username)
                });
            }
        }
    }
}

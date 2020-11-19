using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class SqlHelper
    {
        public static readonly string connStr = ConfigurationManager.ConnectionStrings["connStr"].ConnectionString;

        public static SqlConnection GetSqlConnection()
        {
            SqlConnection sqlConnection = new SqlConnection(connStr);
            sqlConnection.Open();
            return sqlConnection;
        }
        /// <summary>
        /// 获取DataTable列表
        /// </summary>
        /// <param name="sqlconnection"></param>
        /// <param name="sql"></param>
        /// <param name="sqlParameters"></param>
        /// <returns></returns>
        public static object ExcuteScalar(SqlConnection sqlconnection, string sql, params SqlParameter[] sqlParameters)
        {
            DataTable dt = new DataTable();
            using (SqlCommand command = sqlconnection.CreateCommand())
            {
                command.CommandText = sql;
                command.Parameters.AddRange(sqlParameters);
                using (SqlDataReader reader = command.ExecuteReader()) {
                    dt.Load(reader);
                    return dt;
                }
            }
        }
        /// <summary>
        /// 返回由查询返回的结果集中的第一行的第一列
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static object ExcuteScaler(SqlConnection sqlConnection, string sql, params SqlParameter[] parameters)
        {
            using (SqlCommand command = sqlConnection.CreateCommand())
            {
                command.CommandText = sql;
                command.Parameters.AddRange(parameters);
                return command.ExecuteScalar();
            }
        }
        /// <summary>
        /// 封装返回影响行数的方法ExcuteNonQuery
        /// </summary>
        /// <param name="sqlConnection"></param>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExcuteNonQuery(SqlConnection sqlConnection, string sql, params SqlParameter[] parameters)
        {
            //创建Command对象  
            using (SqlCommand command = sqlConnection.CreateCommand())
            {
                command.CommandText = sql;
                command.Parameters.AddRange(parameters);
                return command.ExecuteNonQuery();
            }
        }
        public static DataTable GetDataQuery(SqlConnection sqlConnection, string sql, params SqlParameter[] parameters)
        {
            DataTable dt = new DataTable();
            using (SqlDataAdapter adapter = new SqlDataAdapter(sql, sqlConnection))
            {
                adapter.SelectCommand.Parameters.AddRange(parameters);
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}

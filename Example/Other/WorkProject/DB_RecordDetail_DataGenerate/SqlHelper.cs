using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;

namespace DB_RecordDetail_DataGenerate
{
    public static class OracleHelper
    {
        static OracleHelper()
        {
            _dbProvider = Oracle.ManagedDataAccess.Client.OracleClientFactory.Instance;
        }

        static DbProviderFactory _dbProvider;



        static string _ConnectionString = ConfigurationManager.ConnectionStrings["DB"].ConnectionString;

        public static int ExecuteNonQuery(string sql, CommandType type = CommandType.Text, params DbParameter[] parm)
        {
            using (DbConnection conn = _dbProvider.CreateConnection())
            {
                conn.ConnectionString = _ConnectionString;
                conn.Open();

                DbCommand cmd = conn.CreateCommand();

                cmd.CommandText = sql;

                if (parm != null && parm.Length > 0)
                    cmd.Parameters.AddRange(parm);

                cmd.CommandType = type;

                return cmd.ExecuteNonQuery();
            }

        }
        public static object ExecuteScalar(string sql, CommandType type = CommandType.Text, params DbParameter[] parm)
        {
            using (DbConnection conn = _dbProvider.CreateConnection())
            {
                conn.ConnectionString = _ConnectionString;
                conn.Open();

                DbCommand cmd = conn.CreateCommand();

                cmd.CommandText = sql;

                if (parm != null && parm.Length > 0)
                    cmd.Parameters.AddRange(parm);

                cmd.CommandType = type;

                return cmd.ExecuteScalar();
            }

        }
        public static DataTable ExecuteDataTable(string sql, CommandType type = CommandType.Text, params DbParameter[] parm)
        {
            using (DbConnection conn = _dbProvider.CreateConnection())
            {
                conn.ConnectionString = _ConnectionString;
                conn.Open();

                DbCommand cmd = conn.CreateCommand();

                cmd.CommandText = sql;

                if (parm != null && parm.Length > 0)
                    cmd.Parameters.AddRange(parm);
                cmd.CommandType = type;



                DbDataAdapter adapter = _dbProvider.CreateDataAdapter();
                adapter.SelectCommand = cmd;

                DataTable dt = new DataTable();

                adapter.Fill(dt);

                return dt;
            }

        }




    }
}

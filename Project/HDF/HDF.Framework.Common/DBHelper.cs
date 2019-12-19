using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;

namespace HDF.Framework.Common
{
    #region 非静态抽象继承

    /*
    public abstract class DBHelper
    {
        public DBHelper(string key)
        {
            this.ConnectionString = ConfigurationManager.ConnectionStrings[key].ConnectionString;
        }
        public abstract DbProviderFactory DbProviderFactory { get; }

        public string ConnectionString { get; }

        private T Execute<T>(Func<DbCommand, T> func, string sql, CommandType commandType, params DbParameter[] parameters)
        {
            try
            {
                using (DbConnection conn = DbProviderFactory.CreateConnection())
                {
                    conn.ConnectionString = ConnectionString;
                    if (conn.State != ConnectionState.Open) conn.Open();
                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.CommandType = commandType;
                        if (parameters != null && parameters.Length > 0)
                            cmd.Parameters.AddRange(parameters);
                        return func.Invoke(cmd);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int ExecuteNonQuery(string sql, CommandType commandType = CommandType.Text, params DbParameter[] parameters) => Execute<int>(cmd => cmd.ExecuteNonQuery(), sql, commandType, parameters);
        public object ExecuteScalar(string sql, CommandType commandType = CommandType.Text, params DbParameter[] parameters) => Execute<object>(cmd => cmd.ExecuteScalar(), sql, commandType, parameters);
        public DbDataReader ExecuteReader(string sql, CommandType commandType = CommandType.Text, params DbParameter[] parameters) => Execute<DbDataReader>(cmd => cmd.ExecuteReader(), sql, commandType, parameters);
        public DataTable ExecuteAdapter(string sql, CommandType commandType = CommandType.Text, params DbParameter[] parameters) => Execute<DataTable>(cmd =>
       {
           DataTable dt = new DataTable();
           DbProviderFactory.CreateDataAdapter().Fill(dt);
           return dt.Rows.Count <= 0 ? null : dt;
       }
        , sql, commandType, parameters);


        private T ExecuteInTran<T>(Func<DbCommand, T> func, Func<T, bool> isRollbackFunc, string sql, CommandType commandType, params DbParameter[] parameters)
        {
            DbTransaction transaction = null;
            try
            {
                using (DbConnection conn = DbProviderFactory.CreateConnection())
                {
                    conn.ConnectionString = this.ConnectionString;
                    if (conn.State != ConnectionState.Open) conn.Open();
                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        transaction = conn.BeginTransaction();

                        cmd.CommandText = sql;
                        cmd.CommandType = commandType;
                        if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                        T t = func.Invoke(cmd);

                        if (isRollbackFunc.Invoke(t))
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                        return t;
                    }
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public int ExecuteNonQueryInTran(string sql, Func<int, bool> isRollbackFunc, CommandType commandType = CommandType.Text, params DbParameter[] parameters)
        {
            return ExecuteInTran<int>(cmd => cmd.ExecuteNonQuery(), isRollbackFunc, sql, commandType, parameters);
        }


    }

    public class SqlServerHelper : DBHelper
    {
        public override DbProviderFactory DbProviderFactory { get; }

        public SqlServerHelper(string connectionString) : base(connectionString)
        {
            this.DbProviderFactory = SqlClientFactory.Instance;
        }
    }
    public class OracleHelper : DBHelper
    {
        public override DbProviderFactory DbProviderFactory { get; }
        public OracleHelper(string connectionString) : base(connectionString)
        {
            this.DbProviderFactory = OracleClientFactory.Instance;
        }
    }
    //......

    */

    #endregion



    public static class DBHelper<TProviderFactory> where TProviderFactory : DbProviderFactory
    {

        private static Dictionary<string, DbProviderFactory> _Connections = new Dictionary<string, DbProviderFactory>();



        static DBHelper()
        {
            DbProviderFactory = (TProviderFactory)Activator.CreateInstance(typeof(TProviderFactory));
        }
        public static TProviderFactory DbProviderFactory;

        public static string ConnectionString { get; }

        private static T Execute<T>(Func<DbCommand, T> func, string sql, CommandType commandType, params DbParameter[] parameters)
        {
            try
            {
                using (DbConnection conn = DbProviderFactory.CreateConnection())
                {
                    conn.ConnectionString = ConnectionString;
                    if (conn.State != ConnectionState.Open) conn.Open();
                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = sql;
                        cmd.CommandType = commandType;
                        if (parameters != null && parameters.Length > 0)
                            cmd.Parameters.AddRange(parameters);
                        return func.Invoke(cmd);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public static int ExecuteNonQuery(string sql, CommandType commandType = CommandType.Text, params DbParameter[] parameters) => Execute<int>(cmd => cmd.ExecuteNonQuery(), sql, commandType, parameters);
        public static object ExecuteScalar(string sql, CommandType commandType = CommandType.Text, params DbParameter[] parameters) => Execute<object>(cmd => cmd.ExecuteScalar(), sql, commandType, parameters);
        public static DbDataReader ExecuteReader(string sql, CommandType commandType = CommandType.Text, params DbParameter[] parameters) => Execute<DbDataReader>(cmd => cmd.ExecuteReader(), sql, commandType, parameters);
        public static DataTable ExecuteAdapter(string sql, CommandType commandType = CommandType.Text, params DbParameter[] parameters) => Execute<DataTable>(cmd =>
        {
            DataTable dt = new DataTable();
            DbProviderFactory.CreateDataAdapter().Fill(dt);
            return dt.Rows.Count <= 0 ? null : dt;
        }
        , sql, commandType, parameters);


        private static T ExecuteInTran<T>(Func<DbCommand, T> func, Func<T, bool> isRollbackFunc, string sql, CommandType commandType, params DbParameter[] parameters)
        {
            DbTransaction transaction = null;
            try
            {
                using (DbConnection conn = DbProviderFactory.CreateConnection())
                {
                    conn.ConnectionString = ConnectionString;
                    if (conn.State != ConnectionState.Open) conn.Open();
                    using (DbCommand cmd = conn.CreateCommand())
                    {
                        transaction = conn.BeginTransaction();

                        cmd.CommandText = sql;
                        cmd.CommandType = commandType;
                        if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);
                        T t = func.Invoke(cmd);

                        if (isRollbackFunc.Invoke(t))
                        {
                            transaction.Commit();
                        }
                        else
                        {
                            transaction.Rollback();
                        }
                        return t;
                    }
                }
            }
            catch (Exception)
            {
                transaction.Rollback();
                throw;
            }
        }

        public static int ExecuteNonQueryInTran(string sql, Func<int, bool> isRollbackFunc, CommandType commandType = CommandType.Text, params DbParameter[] parameters)
        {
            return ExecuteInTran<int>(cmd => cmd.ExecuteNonQuery(), isRollbackFunc, sql, commandType, parameters);
        }


    }

}

using System;
using System.Configuration;
using System.Data;
using System.Data.Common;

namespace HDF.Framework.Common
{
    /// <summary>
    /// 数据库操作帮助类--多库兼容版
    /// 使用前请调用Init方法初始化数据库连接
    /// </summary>
    public static class DBHelper
    {
        #region Public Property

        /// <summary>
        /// 表示一组方法用于创建数据源类的提供程序的实现。
        /// </summary>
        public static DbProviderFactory DbProviderFactory { get; set; }

        /// <summary>
        /// 数据库连接字符串
        /// </summary>
        public static string ConnectionString { get; set; }

        #endregion

        #region Init Method

        public static void Init(DbProviderFactory factory, string connectionString)
        {
            DbProviderFactory = factory;
            ConnectionString = connectionString;
        }
        public static void Init(string DBName)
        {
            try
            {
                ConnectionString = ConfigurationManager.ConnectionStrings[DBName].ConnectionString;
                DbProviderFactory = DbProviderFactories.GetFactory(ConfigurationManager.ConnectionStrings[DBName].ProviderName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        public static DbParameter CreateParameter(string name, string value)
        {
            DbParameter parameter = DbProviderFactory.CreateParameter();
            parameter.ParameterName = name;
            parameter.Value = value;
            return parameter;
        }

        #region Execute

        private static TResult Execute<TResult>(Func<DbCommand, TResult> func, string sql, CommandType commandType, params DbParameter[] parameters)
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
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public static int ExecuteNonQuery(string sql, CommandType commandType = CommandType.Text, params DbParameter[] parameters) => Execute<int>(cmd => cmd.ExecuteNonQuery(), sql, commandType, parameters);

        public static object ExecuteScalar(string sql, CommandType commandType = CommandType.Text, params DbParameter[] parameters) => Execute<object>(cmd => cmd.ExecuteScalar(), sql, commandType, parameters);

        public static DbDataReader ExecuteReader(string sql, CommandType commandType = CommandType.Text, params DbParameter[] parameters) => Execute<DbDataReader>(cmd => cmd.ExecuteReader(), sql, commandType, parameters);

        public static DataTable ExecuteAdapter(string sql, CommandType commandType = CommandType.Text, params DbParameter[] parameters)
        {
            return Execute<DataTable>(cmd =>
                                            {
                                                DataTable dt = new DataTable();
                                                DbDataAdapter adapter = DbProviderFactory.CreateDataAdapter();
                                                adapter.SelectCommand = cmd;
                                                adapter.Fill(dt);
                                                return dt;
                                            }
                                    , sql, commandType, parameters);
        }

        /// <summary>
        /// 更新DataTable到数据库
        /// </summary>
        /// <param name="sql">SelectQuery</param>
        /// <param name="data">DataSourse</param>
        /// <returns></returns>
        public static int AdapterUpdate(string sql, DataTable data)
        {
            return Execute<int>(cmd =>
                                    {
                                        DbDataAdapter adapter = DbProviderFactory.CreateDataAdapter();
                                        adapter.SelectCommand = cmd;

                                        DbCommandBuilder builder = DbProviderFactory.CreateCommandBuilder();
                                        builder.DataAdapter = adapter;

                                        return adapter.Update(data);
                                    }
                                    , sql, CommandType.Text);
        }

        #endregion

        #region ExecuteInTransaction

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
                        cmd.Transaction = transaction;
                        if (parameters != null && parameters.Length > 0) cmd.Parameters.AddRange(parameters);

                        T t = func.Invoke(cmd);

                        if (isRollbackFunc.Invoke(t))
                            transaction.Commit();
                        else
                            transaction.Rollback();

                        return t;
                    }
                }
            }
            catch (Exception ex)
            {
                transaction?.Rollback();
                throw ex;
            }
        }

        /// <summary>
        /// 在事务中执行并返回受影响行数
        /// </summary>
        /// <param name="sql">执行的sql或存储过程（多条sql使用分号间隔）</param>
        /// <param name="isRollbackFunc"></param>
        /// <param name="commandType"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static int ExecuteNonQueryInTran(string sql, Func<int, bool> isRollbackFunc, CommandType commandType = CommandType.Text, params DbParameter[] parameters)
        {
            return ExecuteInTran<int>(cmd => cmd.ExecuteNonQuery(), isRollbackFunc, sql, commandType, parameters);
        }

        #endregion

    }

}

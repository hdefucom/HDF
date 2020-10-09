using Dapper;
using HDF.Core.Dapper.DBModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace HDF.Core.Dapper.DBContext
{
    public class DapperHelper
    {
        static IDbConnection _dbConnection = new SqlConnection();

        public string ConnectionString => ConnectionOptions.ConnectionString;
        public IDbConnection DbConnection => _dbConnection;

        public DapperHelper()
        {
            _dbConnection.ConnectionString = ConnectionString;
        }


        #region sync

        public T QueryFirst<T>(string sql,
                               object param = null,
                               IDbTransaction transaction = null,
                               int? commandTimeout = null,
                               CommandType? commandType = null) where T : BaseEntity
            => _dbConnection.QueryFirst<T>(sql, param, transaction, commandTimeout, commandType);


        public IEnumerable<T> Query<T>(string sql,
                                       object param = null,
                                       IDbTransaction transaction = null,
                                       bool buffered = true,
                                       int? commandTimeout = null,
                                       CommandType? commandType = null) where T : BaseEntity
            => _dbConnection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);



        public int Execute(string sql,
                             object param = null,
                             Action<IDbTransaction, int> callBack = null,
                             int? commandTimeout = null,
                             CommandType? commandType = null)
        {
            try
            {
                if (callBack == null)
                    return _dbConnection.Execute(sql, param, null, commandTimeout, commandType);

                _dbConnection.Open();
                using (var tran = _dbConnection.BeginTransaction())
                {
                    int res = _dbConnection.Execute(sql, param, tran, commandTimeout, commandType);
                    callBack?.Invoke(tran, res);

                    return res;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion

        #region async

        public async Task<IEnumerable<T>> QueryAsync<T>(string sql,
                                                        object param = null,
                                                        IDbTransaction transaction = null,
                                                        int? commandTimeout = null,
                                                        CommandType? commandType = null) where T : BaseEntity
            => await _dbConnection.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);



        public async Task<T> QueryFirstAsync<T>(string sql,
                                                object param = null,
                                                IDbTransaction transaction = null,
                                                int? commandTimeout = null,
                                                CommandType? commandType = null) where T : BaseEntity
            => await _dbConnection.QueryFirstAsync<T>(sql, param, transaction, commandTimeout, commandType);



        public async Task<int> ExecuteAsync(string sql,
                                            object param = null,
                                            Action<IDbTransaction, int> callBack = null,
                                            int? commandTimeout = null,
                                            CommandType? commandType = null)
        {
            try
            {
                if (callBack == null)
                    await _dbConnection.ExecuteAsync(sql, param, null, commandTimeout, commandType);

                _dbConnection.Open();
                using (var tran = _dbConnection.BeginTransaction())
                {
                    int res = await _dbConnection.ExecuteAsync(sql, param, tran, commandTimeout, commandType);
                    callBack?.Invoke(tran, res);

                    return res;
                }
            }
            catch (Exception)
            {
                throw;
            }
        }


        #endregion















    }
}

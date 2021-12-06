using Dapper;
using System.Data;
using System.Data.SqlClient;
using System.Data.Common;
using System.Threading.Tasks;

namespace WXTool.Web.Common;

public class DapperHelper
{
    private readonly AppSettings _settings;
    private readonly DbProviderFactory _dbProviderFactory;

    public DapperHelper(AppSettings settings)
    {
        _settings = settings;
        _dbProviderFactory = SqlClientFactory.Instance;

    }

    private IDbConnection CreateConnection()
    {
        var connection = _dbProviderFactory.CreateConnection();
        connection.ConnectionString = _settings.ConnectionStrings["WXTool"];


        return connection;
    }


    public IEnumerable<T> Query<T>(string sql,
        object param = null,
        IDbTransaction transaction = null,
        bool buffered = true,
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var connection = CreateConnection())
        {
            return connection.Query<T>(sql, param, transaction, buffered, commandTimeout, commandType);
        }
    }

    public async Task<IEnumerable<T>> QueryAsync<T>(string sql,
        object param = null,
        IDbTransaction transaction = null,
        bool buffered = true,
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var connection = CreateConnection())
        {
            return await connection.QueryAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }
    }


    public T QueryFirstOrDefault<T>(string sql,
        object param = null,
        IDbTransaction transaction = null,
        bool buffered = true,
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var connection = CreateConnection())
        {
            return connection.QueryFirstOrDefault<T>(sql, param, transaction, commandTimeout, commandType);
        }
    }


    public async Task<T> QueryFirstOrDefaultAsync<T>(string sql,
        object param = null,
        IDbTransaction transaction = null,
        bool buffered = true,
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var connection = CreateConnection())
        {
            return await connection.QueryFirstOrDefaultAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }
    }


    public T QuerySingle<T>(string sql,
        object param = null,
        IDbTransaction transaction = null,
        bool buffered = true,
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var connection = CreateConnection())
        {
            return connection.QuerySingle<T>(sql, param, transaction, commandTimeout, commandType);
        }
    }


    public async Task<T> QuerySingleAsync<T>(string sql,
        object param = null,
        IDbTransaction transaction = null,
        bool buffered = true,
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var connection = CreateConnection())
        {
            return await connection.QuerySingleAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }
    }


    public int Execute(string sql,
        object param = null,
        IDbTransaction transaction = null,
        bool buffered = true,
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var connection = CreateConnection())
        {
            return connection.Execute(sql, param, transaction, commandTimeout, commandType);
        }
    }

    public async Task<int> ExecuteAsync(string sql,
        object param = null,
        IDbTransaction transaction = null,
        bool buffered = true,
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var connection = CreateConnection())
        {
            return await connection.ExecuteAsync(sql, param, transaction, commandTimeout, commandType);
        }
    }

    public async Task<T> ExecuteScalarAsync<T>(string sql,
        object param = null,
        IDbTransaction transaction = null,
        bool buffered = true,
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var connection = CreateConnection())
        {
            return await connection.ExecuteScalarAsync<T>(sql, param, transaction, commandTimeout, commandType);
        }
    }


    public T ExecuteScalar<T>(string sql,
        object param = null,
        IDbTransaction transaction = null,
        bool buffered = true,
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var connection = CreateConnection())
        {
            return connection.ExecuteScalar<T>(sql, param, transaction, commandTimeout, commandType);
        }
    }



    public SqlMapper.GridReader QueryMultiple(string sql,
        object param = null,
        IDbTransaction transaction = null,
        bool buffered = true,
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var connection = CreateConnection())
        {
            return connection.QueryMultiple(sql, param, transaction, commandTimeout, commandType);
        }
    }

    public async Task<T> QueryMultipleAsync<T>(string sql,
        Func<SqlMapper.GridReader, T> callback,
        object param = null,
        IDbTransaction transaction = null,
        bool buffered = true,
        int? commandTimeout = null,
        CommandType? commandType = null)
    {
        using (var connection = CreateConnection())
        {
            var res = await connection.QueryMultipleAsync(sql, param, transaction, commandTimeout, commandType);
            return callback.Invoke(res);
        }
    }











}

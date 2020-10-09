using HDF.Core.Dapper.DBContext;
using HDF.Core.Dapper.DBModel;
using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace HDF.Core.Dapper
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");


            DapperHelper helper = new DapperHelper();

            var res = Task.FromResult(helper.ExecuteAsync(
                sql: "update Users set  UserName='aa5aa' where UserId=2",
                callBack: (tran, i) =>
                {
                    if (i == 0) tran.Rollback();
                    else tran.Commit();
                }
               )).Result.Result;





            Console.ReadKey();
        }







    }
}

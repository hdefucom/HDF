using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace HDF.Core.Dapper.DBContext
{
    public class ConnectionOptions
    {
        private static string _connectionString = "Data Source=.;Initial Catalog=HDFTest;Integrated Security=True";
        

        public static string ConnectionString
        {
            get => _connectionString;
            set => _connectionString = value;
        }
       




    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace HDF.Core.Dapper.DBModel
{

    public class Users : BaseEntity
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserPwd { get; set; }
    }
}

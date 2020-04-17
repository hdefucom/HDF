using Microsoft.AspNetCore.Builder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HDF.Core.Web.MiddleWare
{
    public static class HDFTestMiddleWare
    {

        public static IApplicationBuilder UseHDFTest(this IApplicationBuilder builder)
        {
            Console.WriteLine("**********this is HDFTestMiddleWare**********");

            builder.UseMiddleware(typeof(HDFTestMiddleWare));

            return builder;
        }
    }
}

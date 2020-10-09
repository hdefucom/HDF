using System;

namespace HDF.Core.WebApi.Model
{
    public class ApiResult<T>
    {
        public readonly DateTime Time = DateTime.Now;

        public string Code { get; set; }

        public bool Success { get; set; }

        public T Data { get; set; }

        public string Message { get; set; }


        public ApiPageInfo Page { get; set; }
    }




}
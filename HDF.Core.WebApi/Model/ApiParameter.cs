using System;

namespace HDF.Core.WebApi.Model
{

    public class ApiParameter<T>
    {
        public readonly DateTime Time = DateTime.Now;

        public T Parameter { get; set; }


        public ApiPageInfo Page { get; set; }
    }







}
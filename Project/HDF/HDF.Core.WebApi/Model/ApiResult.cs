using System;

namespace HDF.Core.WebApi.Model
{
    public interface IApiResult<out T>
    {
        DateTime Time { get; }

        string Code { get; set; }

        bool Success { get; set; }

        //T Data { get; set; }

        string Message { get; set; }


        ApiPageInfo Page { get; set; }

    }


    public class ApiResult<T> : IApiResult<T>
    {
        public DateTime Time => DateTime.Now;

        public string Code { get; set; }

        public bool Success { get; set; }

        public T Data { get; set; }

        public string Message { get; set; }


        public ApiPageInfo Page { get; set; }
    }


    public class ApiResult
    {
        public static ApiResult<T> Success<T>(T data)
        {
            return new ApiResult<T>() { Success = true, Data = data };
        }

        public static ApiResult<object> Success(object data)
        {
            return new ApiResult<object>() { Success = true, Data = data };
        }



        public static ApiResult<T> Fail<T>(string msg)
        {
            return new ApiResult<T>() { Success = false, Message = msg };
        }

        public static ApiResult<T> Fail<T>(Exception ex)
        {
            return new ApiResult<T>() { Success = false, Message = ex.Message };
        }

        public static ApiResult<object> Fail(string msg)
        {
            return new ApiResult<object>() { Success = false, Message = msg };
        }

        public static ApiResult<object> Fail(Exception ex)
        {
            return new ApiResult<object>() { Success = false, Message = ex.Message };
        }



    }




}
using Microsoft.AspNetCore.Http;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.OpenApi.Extensions;

namespace HDF.Core.WebApi.Filter
{
    /// <summary>
    /// swagger文件过滤器
    /// </summary>
    //public class SwaggerFileUploadFilter : IOperationFilter
    //{
    //    /// <summary>
    //    /// swagger过滤器（此处的Apply会被swagger的每个接口都调用生成文档说明，所以在此处可以对每一个接口进行过滤操作）
    //    /// </summary>
    //    /// <param name="operation"></param>
    //    /// <param name="context"></param>
    //    public void Apply(OpenApiOperation operation, OperationFilterContext context)
    //    {
    //        if (!context.ApiDescription.HttpMethod.Equals("POST", StringComparison.OrdinalIgnoreCase) &&
    //            !context.ApiDescription.HttpMethod.Equals("PUT", StringComparison.OrdinalIgnoreCase))
    //        {
    //            return;
    //        }


    //        var fileParameters = context.ApiDescription.ActionDescriptor.Parameters.Where(n => n.ParameterType == typeof(IFormFile)).ToList();

    //        if (fileParameters.Count < 0)
    //        {
    //            return;
    //        }




    //        operation.Consumes.Add("multipart/form-data");

    //        foreach (var fileParameter in fileParameters)
    //        {
    //            var parameter = operation.Parameters.Single(n => n.Name == fileParameter.Name);
    //            operation.Parameters.Remove(parameter);
    //            operation.Parameters.Add(new NonBodyParameter
    //            {
    //                Name = parameter.Name,
    //                In = "formData",
    //                Description = parameter.Description,
    //                Required = parameter.Required,
    //                Type = "file"
    //            });
    //        }
    //    }




    //}
}
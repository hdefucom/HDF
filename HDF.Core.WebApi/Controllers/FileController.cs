using HDF.Core.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace HDF.Core.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FileController : ControllerBase
    {
        /// <summary>
        /// 文件上传
        /// </summary>
        /// <param name="formFile"></param>
        /// <returns></returns>
        [HttpPost]
        public bool FileUpload(IFormFile formFile)
        {

            UploadWriteFile(formFile.OpenReadStream(), $"E://{formFile.FileName}");

            return true;
        }

        /// <summary>
        /// 文件上传-入参泛型代理包装
        /// </summary>
        /// <param name="param"></param>
        /// <returns></returns>
        [HttpPost]
        public bool FileUpload_Parameter([FromForm] ApiParameter<IFormFile> param)
        {
            UploadWriteFile(param.Parameter.OpenReadStream(), $"E://{param.Parameter.FileName}");

            return true;
        }

        /// <summary>
        /// 文件集合上传
        /// </summary>
        /// <param name="formFileCollection"></param>
        /// <returns></returns>
        [HttpPost]
        public bool FileCollectionUpload([FromForm] IFormFileCollection formFileCollection)
        {

            return true;
        }

        ///// <summary>
        ///// 文件下载
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //public FileResult FileDownload()
        //{
        //    FileStream stream = System.IO.File.OpenRead("E://1.txt");
        //    var actionresult = new FileStreamResult(stream, new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream"));
        //    actionresult.FileDownloadName = "a.txt";
        //    return actionresult;
        //}

        /// <summary>
        /// 文件下载-异步
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("[controller]/FileDownloadAsync")]
        public async Task<FileResult> FileDownloadAsync()
        {
            FileStream stream = System.IO.File.OpenRead("E://1.txt");
            var actionresult = new FileStreamResult(stream, new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream"));
            actionresult.FileDownloadName = "a.txt";


            await Task.CompletedTask;

            return actionresult;
        }










        const int WRITE_FILE_SIZE = 1024 * 1024 * 2;
        private static double UploadWriteFile([NotNull] Stream stream, string path)
        {
            if (stream == null) throw new ArgumentNullException(nameof(stream));


            try
            {
                double writeCount = 0;
                using (FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite, WRITE_FILE_SIZE))
                {
                    Byte[] by = new byte[WRITE_FILE_SIZE];
                    int readCount = 0;
                    while ((readCount = stream.Read(by, 0, by.Length)) > 0)
                    {
                        fileStream.Write(by, 0, readCount);
                        writeCount += readCount;
                    }
                    return Math.Round((writeCount * 1.0 / (1024 * 1024)), 2);
                }
            }
            catch (Exception ex)
            {
                throw new Exception("发生异常：" + ex.Message);
            }
        }
    }
}

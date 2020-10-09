using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using HDF.Core.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HDF.Core.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    [Produces("application/json")]
    public class WeatherForecastController : ControllerBase
    {
        private List<int> _list = new List<int> { 1, 2, 3, 4, 5 };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }



        [HttpGet]
        public IEnumerable<int> GetList()
        {
            return _list;
        }

        [HttpPost]
        public bool Parameter_OneEntity([FromBody] int hdf, [FromForm] int i, [FromQuery] int j)
        {
            return hdf >= 18;
        }


        [HttpDelete]
        public bool DeleteTest([FromForm] int id)
        {
            return _list.Remove(id);
        }

        [HttpHead]
        public bool HeadTest(int id)
        {
            return _list.Contains(id);
        }

        [HttpPut]
        public bool PutTest(int id)
        {
            _list.Add(id);
            return true;
        }

        [HttpOptions]
        public bool OptionsTest()
        {

            return true;
        }


        [HttpPost]
        public bool FileUpload(IFormFile formFile)
        {

            UploadWriteFile(formFile.OpenReadStream(), $"E://{formFile.FileName}");

            return true;
        }

        [HttpPost]
        public bool FileUpload2([FromForm] ApiParameter<IFormFile> param)
        {
            UploadWriteFile(param.Parameter.OpenReadStream(), $"E://{param.Parameter.FileName}");

            return true;
        }

        [HttpPost]
        public bool FileCollectionUpload([FromForm] IFormFileCollection formFileCollection)
        {

            return true;
        }


        [HttpPost]
        [HttpGet]
        public FileResult FileDownload()
        {
            FileStream stream = System.IO.File.OpenRead("E://1.txt");

            var actionresult = new FileStreamResult(stream, new Microsoft.Net.Http.Headers.MediaTypeHeaderValue("application/octet-stream"));


            actionresult.FileDownloadName = "a.txt";

            return actionresult;

        }





        const int WRITE_FILE_SIZE = 1024 * 1024 * 2;
        public static double UploadWriteFile(Stream stream, string path)
        {
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

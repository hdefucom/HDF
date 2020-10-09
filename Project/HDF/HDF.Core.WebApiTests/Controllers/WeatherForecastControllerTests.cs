using Microsoft.VisualStudio.TestTools.UnitTesting;
using HDF.Core.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Text;

namespace HDF.Core.WebApi.Controllers.Tests
{
    [TestClass()]
    public class WeatherForecastControllerTests
    {
        [TestMethod()]
        public void FileDownloadTest()
        {
            new WeatherForecastController(null).FileDownload();
        }
    }
}
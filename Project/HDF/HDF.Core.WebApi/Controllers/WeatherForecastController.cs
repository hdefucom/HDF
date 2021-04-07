using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using HDF.Core.WebApi.Model;
using Masuit.Tools.Hardware;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HDF.Core.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    //[Produces("application/json")]
    public class WeatherForecastController : ControllerBase
    {
        private List<int> _list = new List<int> { 1, 2, 3, 4, 5 };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }



        [HttpGet]
        public string GetNoProtectedResources()
        {

            return "NoProtectedResources";
        }

        [HttpGet]
        [Authorize]
        public string GetProtectedResources()
        {
            var name = User.FindFirst(c => c.Type == ClaimTypes.Name).Value;

            return $"{name} --> ProtectedResources";
        }



































    }





}

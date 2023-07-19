using Microsoft.AspNetCore.Mvc;
using PaddleOCRSharp;
using System;

namespace HDF.Core.WebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        [HttpPost("DetectText")]
        public string DetectText([FromBody] string base64)
        {
            OCRResult result = PaddleOCRHelper.Instance.DetectTextBase64(base64);
            Console.WriteLine(result.Text);
            return result.Text;
        }
    }

    public static class PaddleOCRHelper
    {
        private static readonly object _Locker = new object();

        private static PaddleOCREngine _Instance;

        public static PaddleOCREngine Instance
        {
            get
            {
                if (_Instance == null)
                {
                    lock (_Locker)
                    {
                        if (_Instance == null)
                        {
                            OCRParameter oCRParameter = new OCRParameter();
                            oCRParameter.numThread = 4;
                            oCRParameter.Enable_mkldnn = 0;
                            oCRParameter.use_angle_cls = 0;
                            oCRParameter.det_db_score_mode = 1;
                            OCRModelConfig config = null;
                            _Instance = new PaddleOCREngine(config, oCRParameter);
                        }
                    }
                }
                return _Instance;
            }
        }
    }

}

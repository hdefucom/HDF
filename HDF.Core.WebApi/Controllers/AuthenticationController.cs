using HDF.Core.WebApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HDF.Core.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly TokenConfig _token;

        public AuthenticationController(TokenConfig token)
        {
            _token = token;


        }

        [HttpGet]
        public string Token([FromQuery] string id, [FromQuery] string pwd)
        {
            if (id != pwd)
                return null;
            var claims = new[]
            {
                new Claim(ClaimTypes.Name, id),
            };
            var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_token.Secret));

            var jwtToken = new JwtSecurityToken(
                issuer: _token.Issuer,
                audience: _token.Audience,
                claims: claims,
                notBefore: DateTime.Now,
                expires: DateTime.Now.AddMinutes(_token.AccessExpiration),
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);

        }



        [HttpPost]
        public async Task Test()
        {


            using var stream = HttpContext.Request.Body;

            StreamReader sr = new StreamReader(stream);
            var body = await sr.ReadToEndAsync();

            await SendAiResult(HttpContext, body);




        }




        static async Task SendAiResult(HttpContext context, string msg1)
        {


            var url = "https://dashscope.aliyuncs.com/compatible-mode/v1/chat/completions";
            //var key = "sk-92bb2c50f27449b0ad25211279b4176e";
            //var mode = "deepseek-r1-distill-llama-8b";


            using HttpClient client = new HttpClient();

            //using HttpContent content = new StringContent(JsonConvert.SerializeObject(new
            //{
            //    model = mode,
            //    messages = new object[] {
            //            new {
            //                role="user",
            //                //content="9.9和9.11谁大",
            //                content=msg1,
            //            },
            //        },
            //    stream = true,
            //    stream_options = new
            //    {
            //        include_usage = true,
            //    },
            //}), Encoding.UTF8, "application/json");

            using HttpContent content = new StringContent(msg1, Encoding.UTF8, "application/json");

            var msg = new HttpRequestMessage(HttpMethod.Post, url);
            msg.Content = content;
            //msg.Headers.Add("Authorization", "Bearer " + key);

            var aa = context.Request.Headers["Authorization"];
            if (!string.IsNullOrWhiteSpace(aa))
                msg.Headers.Add("Authorization", aa.ToArray());
            msg.Headers.Add("Accept", "text/event-stream");//流式输出


            var res = await client.SendAsync(msg, HttpCompletionOption.ResponseHeadersRead);


            res.EnsureSuccessStatusCode();

            var stream = await res.Content.ReadAsStreamAsync();

            using var streamReader = new StreamReader(stream);

            CancellationToken token = new CancellationToken();
            string line;
            string result = "";
            string result2 = "";



            var filename = DateTime.Now.ToString("yyyy-MM-dd");


            if (!Directory.Exists(AppDomain.CurrentDomain.BaseDirectory + "log"))
                Directory.CreateDirectory(AppDomain.CurrentDomain.BaseDirectory + "log");

            if (!System.IO.File.Exists(AppDomain.CurrentDomain.BaseDirectory + $"log\\{filename}.log"))
                System.IO.File.Create(AppDomain.CurrentDomain.BaseDirectory + $"log\\{filename}.log");




            while ((line = await streamReader.ReadLineAsync()) != null && !token.IsCancellationRequested)
            {
                try
                {
                    var bytes = Encoding.UTF8.GetBytes(line + "\n");
                    await context.Response.Body.WriteAsync(bytes, 0, bytes.Length);
                    //context.Response.OutputStream.Flush();
                }
                catch (HttpListenerException ex)
                {
                    // 处理异常，记录日志或采取必要的操作
                    Console.WriteLine($"HttpListenerException: {ex.Message}");

                    System.IO.File.AppendAllLines(AppDomain.CurrentDomain.BaseDirectory + $"log\\{filename}.log", new List<string> { DateTime.Now.ToString(), ex.ToString() });
                }


                // 处理每行数据，通常是 JSON 数据块，例如: "data: [{\"choices\":[{\"text\":\"Hello\"}]}]"
                if (line.StartsWith("data: ")) // 移除 "data: " 前缀并解析 JSON 数据块
                {
                    string data = line.Substring(6);
                    if (data == "[DONE]")
                    {
                        //结束标志
                        break;
                    }
                    var streamObject = JsonConvert.DeserializeObject<StreamObject>(data);
                    if (streamObject.choices.Length > 0)
                    {
                        var contentRes = streamObject.choices[0].delta.content;
                        //Console.Write(contentRes);
                        //result += contentRes;
                        //result2 += streamObject.choices[0].delta.reasoning_content;


                    }
                    if (streamObject.usage != null)
                    {
                        //    Console.WriteLine($"""


                        //                                Usage:
                        //                                prompt_tokens:{ streamObject.usage.prompt_tokens}
                        //completion_tokens: { streamObject.usage.completion_tokens}
                        //total_tokens: { streamObject.usage.total_tokens}
                        //    """);
                    }

                }
            }

            Console.WriteLine("结束********************************************");

        }






        class StreamObject
        {
            public ChoiceObject[] choices { get; set; } = new ChoiceObject[0];

            public int created { get; set; }
            public string model { get; set; }
            public string id { get; set; }

            public UsageObject usage { get; set; }








        }


        public class ChoiceObject
        {
            public DeltaObject delta { get; set; }

            public int index { get; set; }
            public string finish_reason { get; set; }

        }

        public class DeltaObject
        {
            public string content { get; set; }
            public string reasoning_content { get; set; }


        }
        public class UsageObject
        {
            public int prompt_tokens { get; set; }
            public int completion_tokens { get; set; }
            public int total_tokens { get; set; }


        }





    }





}

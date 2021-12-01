using System;
using System.Threading.Tasks;
using Wechaty.Module.Puppet.Schemas;
using Wechaty.User;

namespace WeChaty.Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {

            // 初始化一个bot
            var bot = new Wechaty.Wechaty(new PuppetOptions()
            {
                // 如何申请token，请看：https://github.com/juzibot/Welcome/wiki/Everything-about-Wechaty
                Token = "puppet_rock_4448d7e832fd436c9f2a1d33eea8e865",
                //PuppetService = "wechaty-puppet-service"
            });

            // 监听bot事件
            await bot
             .OnScan((string qrcode, ScanStatus status, string? data) => { })
             .OnLogin((ContactSelf user) => { })
             .OnHeartbeat((object data) => { })
             .Start();


            //var wechaty = new Wechaty(options, logger).onScan((qrcode, status) => {
            //    Console.WriteLine($"Scan QR Code to login: {status} https://wechaty.github.io/qrcode/{(qrcode)}`");
            //}).OnLogin(user => {
            //    Console.WriteLine("User {user} logined");
            //}).OnMessage(message => {
            //    Console.WriteLine($"Message: {message}");
            //}).Start();
        }
    }
}

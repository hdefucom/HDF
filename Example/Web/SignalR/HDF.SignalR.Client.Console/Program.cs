// See https://aka.ms/new-console-template for more information

using Microsoft.AspNetCore.SignalR.Client;

Console.WriteLine("Hello, World!");



var connection = new HubConnectionBuilder()
    .WithUrl(new Uri("http://localhost:5000/test"))
    .WithAutomaticReconnect()
    .Build();





connection.Closed += e => Task.Run(() => Console.WriteLine("Closed"));
connection.Reconnecting += e => Task.Run(() => Console.WriteLine("Reconnecting"));
connection.Reconnected += e => Task.Run(() => Console.WriteLine("Reconnected"));



//var hubProxy = connection.CreateHubProxy("test");

//hubProxy.On<string, string>("TestMessage", (s1, s2) => Console.WriteLine("hubProxy-->On"));


connection.On<string, string>("TestMessage", (s1, s2) => Console.WriteLine($"connection-->On:{s1},{s2}"));



await connection.StartAsync();





Console.WriteLine("Please type 'Y' key to rate");
var input = Console.ReadKey().Key;
while (input == ConsoleKey.Y)
{
    await connection.InvokeAsync("SendMessage", "hdf", DateTime.Now.ToString());

    input = Console.ReadKey().Key;
}








/*
 * Asp.Net SignalR 和 Asp.Net Core SignalR 不兼容
 * 但是 Asp.Net SignalR 的客户端可以支持 .NetFramework4.0 和 .NetStandard2.0
 * 所以 .Net6 的客户端可以连接 .NetFramework4.5 的 Service
 * 但是 .NetFramework4.0 的客户端任然无法连接 .Net6 的 Service ,
 * 因为 Asp.Net SignalR 并不只支持 .NetStandard2.0 

 */

/* 
 //*******************************************************************
 //          .NetFramework版本的SignalR客户端代码   
 //                  Asp.Net SignalR
 //*******************************************************************

HubConnection connection = new HubConnection("http://localhost:5000/test", false);


connection.ConnectionSlow += () => Console.WriteLine("ConnectionSlow");
connection.Closed += () => Console.WriteLine("Closed");
connection.Error += e => Console.WriteLine(e);
connection.Received += s => Console.WriteLine("Received:" + s);
connection.Reconnected += () => Console.WriteLine("Reconnected");
connection.Reconnecting += () => Console.WriteLine("Reconnecting");
connection.StateChanged += s => Console.WriteLine("StateChanged");



var hubProxy = connection.CreateHubProxy("test");

hubProxy.On<string, string>("TestMessage", (s1, s2) => Console.WriteLine("hubProxy-->On"));


await connection.Start();



Console.WriteLine("Please type 'Y' key to rate");
var input = Console.ReadKey().Key;
while (input == ConsoleKey.Y)
{
    await hubProxy.Invoke("SendMessage", "hdf", DateTime.Now.ToString());

    input = Console.ReadKey().Key;
}


*/









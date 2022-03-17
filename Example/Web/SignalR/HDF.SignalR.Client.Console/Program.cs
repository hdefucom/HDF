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
















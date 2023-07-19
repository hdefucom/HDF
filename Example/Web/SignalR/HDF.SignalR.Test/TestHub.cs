using Microsoft.AspNetCore.SignalR;

namespace HDF.SignalR.Test;

public class TestHub : Hub
{


    public async Task SendMessage(string user, string message)
    {
        Console.WriteLine($"Service:{user}:{message}");
        await Clients.All.SendAsync("TestMessage", "屮！" + user, message);
    }











}

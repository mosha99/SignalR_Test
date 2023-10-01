using Microsoft.AspNetCore.SignalR;
using SignalR_Test.DataAccess.Repository;
using System;

namespace SignalR_Test.Hubs;

public class TestHub : Hub
{
    private readonly IUserRepository _repository;

    public TestHub(IUserRepository repository)
    {
        _repository = repository;
    }

    public async Task InitUser(string UserName)
    {
        await _repository.SaveUser(UserName, Context.ConnectionId);
    }

    public async Task SendMessage(string ResiverName, string Message)
    {
        string connectionId = await _repository.GetConnectionId(ResiverName);

        string name = await _repository.GetUserName(Context.ConnectionId);

        await Clients.Client(connectionId).SendAsync("ReceiveMessage", name, Message);
    }

    public async Task SerchUser(string userName)
    {
        var list = await _repository.FindUserName(userName);

        await Clients.Client(Context.ConnectionId).SendAsync("SerchResult", list);
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await _repository.DeleteUser(Context.ConnectionId);
    }
}
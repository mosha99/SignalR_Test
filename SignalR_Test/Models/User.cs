using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace SignalR_Test.Models;

public class User
{
    public User()
    {
    }
    public User(string connectionId, string name, Guid instanseGuid)
    {
        ConnectionId = connectionId;
        Name = name;
        InstanseGuid = instanseGuid;
    }

    public Guid InstanseGuid { get; set; }
    public string ConnectionId { get; set; }
    public string Name { get; set; }
}
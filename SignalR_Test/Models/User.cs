using System.ComponentModel.DataAnnotations;

namespace SignalR_Test.Models;

public class User
{
    public User(){ }
    public User(string connectionId, string name)
    {
        ConnectionId = connectionId;
        Name = name;
    }

    [Key]
    public string ConnectionId { get; set; }
    public string Name { get; set; }
}
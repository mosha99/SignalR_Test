namespace SignalR_Test.DataAccess.Repository;

public interface IUserRepository
{

    public Task<List<string>> FindUserName(string userName);
    public Task SaveUser(string UserName, string ConnectionId);
    public Task<String> GetConnectionId(string UserName);
    public Task<String> GetUserName(string ConnectionId);
    public Task DeleteUser(string ConnectionId);

}
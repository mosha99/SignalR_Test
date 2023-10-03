using Microsoft.EntityFrameworkCore;
using SignalR_Test.DataAccess.Context;
using SignalR_Test.Models;

namespace SignalR_Test.DataAccess.Repository;

public class UserRepository : IUserRepository
{
    public MyContext Db { get; }

    static UserRepository()
    {
        InstansGuid = Guid.NewGuid();
    }

    public static Guid InstansGuid ;

    public UserRepository(MyContext Db)
    {
        Db.Database.EnsureCreated();
        this.Db = Db;
    }

    public async Task<List<string>> FindUserName(string userName)
    {
        List<string> findedUsers = await Db.Users.Where(x => x.Name.Contains(userName)).Select(x => x.Name).ToListAsync();
        return findedUsers;
    }

    public async Task SaveUser(string UserName, string ConnectionId)
    {
        if (await Db.Users.AnyAsync(x => x.Name == UserName)) throw new Exception("User Exist");

        await Db.AddAsync(new User(ConnectionId, UserName,InstansGuid));

        await Db.SaveChangesAsync();
    }
    
    public async Task<string> GetConnectionId(string UserName)
    {
        User user = await Db.Users.SingleOrDefaultAsync(x => x.Name.Equals(UserName) );
        return user?.ConnectionId;
    }
    public async Task<string> GetUserName(string ConnectionId)
    {
        User user = await Db.Users.SingleAsync(x => x.ConnectionId == ConnectionId);
        return user.Name;
    }
    public async Task DeleteUser(string ConnectionId)
    {
        await Db.Users.Where(x => x.ConnectionId == ConnectionId).ExecuteDeleteAsync();
        await Db.SaveChangesAsync();
    }
}

using Dapper;
using SocialMedia.Models;
using SocialMedia.Repositories;
using SocialMedia.Utilities;

namespace SocialMedia.Repositories;

public interface IUserRepository
{
    Task<User> Create(User Item);
    Task<bool> Update(User Item);
    Task<bool> Delete(long Id);
    Task<User> GetById(long Id);
    Task<List<User>> GetList();

}
public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<User> Create(User Item)
    {
        var query = $@"INSERT INTO ""{TableNames.users}"" 
        (user_name, password, email, followers, following) 
        VALUES (@UserName, @Password, @Email, @Followers, @Following) 
        RETURNING *";

        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<User>(query, Item);
            return res;
        }
    }

    

    public async Task<bool> Delete(long Id)
    {
        var query = $@"DELETE FROM ""{TableNames.users}"" 
        WHERE user_id = @UserId";

        using (var con = NewConnection)
        {
            var res = await con.ExecuteAsync(query, new { Id });
            return res > 0;
        }
    }

    public async Task<User> GetById(long UserId)
    {
        var query = $@"SELECT * FROM ""{TableNames.users}"" 
        WHERE user_id = @UserId";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<User>(query, new { UserId });
    }

    public async Task<List<User>> GetList()
    {
        // Query
        var query = $@"SELECT * FROM ""{TableNames.users}""";

        List<User> res;
        using (var con = NewConnection) 
            res = (await con.QueryAsync<User>(query)).AsList(); 
    
        return res;
    }

    
    

     public async Task<bool> Update(User Item)
     {
         var query = $@"UPDATE ""{TableNames.users}"" SET  user_name = @UserName, 
         password = @Password, email = @Email WHERE user_id = @UserId";
         

         using (var con = NewConnection)
         {
             var rowCount = await con.ExecuteAsync(query, Item);
             return rowCount == 1;
         }
     }
}
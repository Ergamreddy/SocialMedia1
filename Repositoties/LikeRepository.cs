using Dapper;
using SocialMedia.DTOs;
using SocialMedia.Models;
using SocialMedia.Utilities;

namespace SocialMedia.Repositories;

public interface ILikesRepository
{
    
    Task<Likes> Create(Likes Item);
    //Task Update(Post Item);
    Task Delete(long Id);
    Task<List<Likes>> GetAllForPost(long PostId);
    Task<List<Likes>>GetList();
    
    Task<Likes> GetById(int Id);
    

   // Task<Post> GetById(int Id);
    
}

public class LikesRepository : BaseRepository, ILikesRepository
{
    public LikesRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Likes> Create(Likes Item)
    {
        var query = $@"INSERT INTO {TableNames.likes} (created_at,post_id,user_id) VALUES (@CreatedAt, @PostId, @UserId) 
        RETURNING *";

        using (var con = NewConnection)
            return await con.QuerySingleAsync<Likes>(query, Item);
    }


    
    public async Task Delete(long Id)
    {
        var query = $@"DELETE FROM {TableNames.likes} WHERE id = @Id";

        using (var con = NewConnection)
            await con.ExecuteAsync(query, new { Id });
    }


    public async Task<List<Likes>> GetAllForPost(long PostId)
    {
        var query = $@"SELECT * FROM {TableNames.likes} 
        WHERE post_id = @PostId";

        using (var con = NewConnection)
            return (await con.QueryAsync<Likes>(query, new {PostId})).AsList();
    }


      public async Task<List<Likes>> GetList()
    {
        // Query
        var query = $@"SELECT * FROM ""{TableNames.likes}""";

        List<Likes> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<Likes>(query)).AsList(); // Execute the query
    
        return res;
    }
    public async Task<Likes> GetById(int Id)
    {
        var query = $@"SELECT * FROM {TableNames.posts} 
        WHERE id = @Id";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Likes>(query, new { Id });
    }






   

   
}
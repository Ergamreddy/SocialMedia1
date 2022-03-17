using Dapper;
using SocialMedia.DTOs;
using SocialMedia.Models;
using SocialMedia.Utilities;

namespace SocialMedia.Repositories;


public interface IPostRepository
{
    Task<Post> Create(Post Item);
    Task Delete(long Id);
    Task<List<Post>> GetAllForUser(long userId);
    Task<List<Post>> GetList();


    Task<Post> GetById(long Id);
    Task<List<Post>> GetAllForHashtag(long id);
}

public class PostRepository : BaseRepository, IPostRepository
{
    public PostRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Post> Create(Post Item)
    {
        var query = $@"INSERT INTO {TableNames.posts} (posted_at,type_of_post,user_id) VALUES (@PostedAt, @TypeOfPost, @UserId) 
        RETURNING *";

        using (var con = NewConnection)
            return await con.QuerySingleAsync<Post>(query, Item);
    }



    public async Task Delete(long Id)
    {
        var query = $@"DELETE FROM {TableNames.posts} WHERE id = @Id";

        using (var con = NewConnection)
            await con.ExecuteAsync(query, new { Id });
    }



    public async Task<List<Post>> GetAllForUser(long UserId)
    {
        var query = $@"SELECT * FROM {TableNames.posts} 
        WHERE user_id = @UserId";

        using (var con = NewConnection)
            return (await con.QueryAsync<Post>(query, new { UserId })).AsList();
    }


    public async Task<List<Post>> GetAllForHashtag(long HashtagId)
    {
        var query = $@"SELECT * FROM {TableNames.hash_post} hp
        LEFT JOIN {TableNames.posts} p ON p.post_id = hp.post_id 
        WHERE hash_id = @HashtagId";

        using (var con = NewConnection)
            return (await con.QueryAsync<Post>(query, new { HashtagId })).AsList();
    }

    public async Task<Post> GetById(long PostId)
    {
        var query = $@"SELECT * FROM {TableNames.posts} 
        WHERE post_id = @PostId";

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Post>(query, new { PostId });
    }


    public async Task<List<Post>> GetList()
    {
        // Query
        var query = $@"SELECT * FROM ""{TableNames.posts}""";

        List<Post> res;
        using (var con = NewConnection) // Open connection
            res = (await con.QueryAsync<Post>(query)).AsList();
        return res;
    }
}
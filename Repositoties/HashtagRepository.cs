

using Dapper;
using SocialMedia.DTOs;
using SocialMedia.Models;
using SocialMedia.Utilities;

namespace SocialMedia.Repositories;

public interface IHashtagRepository
{
    Task<Hashtag> Create(Hashtag Item);
    Task<bool> Update(Hashtag Item);
    Task<bool> Delete(long Id);
    Task<Hashtag> GetById(long Id);
    Task<List<Hashtag>> GetAllForPost(long PostId);


}

public class HashtagRepository : BaseRepository, IHashtagRepository
{
    public HashtagRepository(IConfiguration config) : base(config)
    {

    }

    public async Task<Hashtag> Create(Hashtag Item)
    {
        var query = $@"INSERT INTO ""{TableNames.hashtags}"" 
        (hashtag_name) VALUES (@HashtagName) RETURNING *";

        using (var con = NewConnection)
        {
            var res = await con.QuerySingleOrDefaultAsync<Hashtag>(query, Item);
            return res;
        }
    }

    public async Task<bool> Delete(long Id)
    {
        var query = $@"DELETE FROM ""{TableNames.hashtags}"" 
        WHERE hashtag_id = @HashtagId";

        using (var con = NewConnection)
        {
            var res = await con.ExecuteAsync(query, new { Id });
            return res > 0;
        }
    }



    public async Task<List<Hashtag>> GetAllForPost(long PostId)
    {
        var query = $@"SELECT * FROM {TableNames.hashtags} 
        WHERE post_id = @PostId";

        using (var con = NewConnection)
            return (await con.QueryAsync<Hashtag>(query, new { PostId })).AsList();
    }



    public async Task<Hashtag> GetById(long Id)
    {
        var query = $@"SELECT * FROM ""{TableNames.hashtags}"" 
        WHERE hashtag_id = @Id";
        // SQL-Injection

        using (var con = NewConnection)
            return await con.QuerySingleOrDefaultAsync<Hashtag>(query, new { Id });
    }



    public async Task<bool> Update(Hashtag Item)
    {
        var query = $@"UPDATE ""{TableNames.hashtags}"" SET  hashtag_name = @HashtagName WHERE hashtag_id = @HashtagId";


        using (var con = NewConnection)
        {
            var rowCount = await con.ExecuteAsync(query, Item);
            return rowCount == 1;
        }
    }



}



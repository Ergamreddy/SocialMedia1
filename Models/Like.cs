


using SocialMedia.DTOs;

namespace SocialMedia.Models;

public record Likes
{
    public long Id { get; set; }
    public long UserId { get; set; }
    public long PostId{ get; set; }
    public DateTimeOffset CreatedAt { get;set;}


     public LikesDTO asDto => new LikesDTO
    {
        Id = Id,
        UserId = UserId ,
        PostId = PostId ,
        CreatedAt = CreatedAt,


    
    };





}
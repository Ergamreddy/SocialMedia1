

using SocialMedia.DTOs;

namespace SocialMedia.Models;

public record Post
{
    public long PostId { get; set; }

    public string TypeOfPost { get; set; }

    public int UserId { get; set; }

    public DateTimeOffset PostedAt { get; set; }

    public PostDTO asDto => new PostDTO
    {
        PostId = PostId,
        TypeOfPost = TypeOfPost,
        UserId = UserId,
        PostedAt = PostedAt,


    };
}
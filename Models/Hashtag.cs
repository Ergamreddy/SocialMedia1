
using SocialMedia.DTOs;

namespace SocialMedia.Models;

public record Hashtag
{
    public long HashtagId { get; set; }
    public string HashtagName { get; set; }
    public long PostId { get; set; }


    public HashtagDTO asDto => new HashtagDTO
    {
        HashtagId = HashtagId,
        HashtagName = HashtagName,
        PostId = PostId,

    };
}
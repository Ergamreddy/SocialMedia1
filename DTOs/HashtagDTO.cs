


using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace SocialMedia.DTOs;

public record HashtagDTO
{
    

    [JsonPropertyName("hashtag_id")]
    public long HashtagId { get; set; }

    [JsonPropertyName("hashtag_name")]
    public string HashtagName { get; set; }

    [JsonPropertyName("post_id")]
    public long PostId { get; set; }

    [JsonPropertyName("posts")]

    public List<PostDTO> Post { get; internal set; }
}

public record HashtagCreateDTO
{
    [JsonPropertyName("hashtag_id")]
    [Required]
    public long HashtagId { get; set; }

    [JsonPropertyName("hashtag_name")]
    [Required]
    [MaxLength(50)]
    public string HashtagName { get; set; }

    [JsonPropertyName("post_id")]
    public long PostId { get; set; }
}

public record HashtagUpdateDTO
{


    [JsonPropertyName("hashtag_name")]
    [Required]
    [MaxLength(50)]
    public string HashtagName { get; set; }
}

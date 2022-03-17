

using System.Text.Json.Serialization;

namespace SocialMedia.DTOs;

public record LikesDTO
{
    internal object asDto;

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }

    [JsonPropertyName("comment")]
    public int Comment { get; set; }

    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    [JsonPropertyName("post_id")]
    public long PostId { get; set; }





}

public record LikesCreateDTO
{
    // internal object CreatedAt;

    [JsonPropertyName("id")]
    public long Id { get; set; }

    [JsonPropertyName("created_at")]
    public DateTimeOffset CreatedAt { get; set; }


    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    [JsonPropertyName("post_id")]
    public long PostId { get; set; }


}

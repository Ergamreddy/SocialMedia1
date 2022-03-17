

using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SocialMedia.DTOs;

namespace SocialMedia.DTOs;

public record PostDTO
{
    [JsonPropertyName("post_id")]
    public long PostId { get; set; }

     [JsonPropertyName("type_of_post")]
    public string TypeOfPost { get; set; } 

    [JsonPropertyName("user_id")]
    public int UserId { get; set; }

    [JsonPropertyName("posted_at")]
    public DateTimeOffset PostedAt { get; set; } 

    

    public List<LikesDTO> Likes { get; set; }



}

public record PostCreateDTO
{
    

    [JsonPropertyName("posted_at")]

    public DateTimeOffset PostedAt{ get; set; }

    [JsonPropertyName("type_of_post")]

    public string TypeOfPost { get; set; } 

    [JsonPropertyName("user_id")]
    [Required]
    public int UserId { get; set; }

}




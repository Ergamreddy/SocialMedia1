using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using SocialMedia.DTOs;
using SocialMedia.Models;

namespace SocialMedia.DTOs;
public record UserDTO
{
    [JsonPropertyName("user_id")]
    public long UserId { get; set; }

    [JsonPropertyName("user_name")]
    public string UserName { get; set; }

    [JsonPropertyName("password")]
    public string Password { get; set; }

    [JsonPropertyName("email")]
    public string Email { get; set; }

    [JsonPropertyName("followers")]
    public int Followers { get; set; }

    [JsonPropertyName("following")]
    public int Following { get; set; }

    [JsonPropertyName("posts")]
    public List<PostDTO> Post { get; set; }
}

public record UserCreateDTO
{

    [JsonPropertyName("user_name")]
    [Required]
    [MaxLength(50)]
    public string UserName { get; set; }
    [JsonPropertyName("password")]
    [Required]
    [MaxLength(50)]
    public string Password { get; set; }

    [JsonPropertyName("email")]
    [MaxLength(255)]
    public string Email { get; set; }

    [JsonPropertyName("followers")]
    [Required]
    public int Followers { get; set; }

    [JsonPropertyName("following")]
    [Required]
    public int Following { get; set; }

}


public record UserUpdateDTO
{


    [JsonPropertyName("user_name")]
    [Required]
    [MaxLength(50)]
    public string UserName { get; set; }

    [JsonPropertyName("password")]
    [Required]
    public string Password { get; set; }

    [JsonPropertyName("email")]
    [MaxLength(255)]
    public string Email { get; set; }

    public List<Post> Post { get; set; }

}




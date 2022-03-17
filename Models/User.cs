

using System;
using SocialMedia.DTOs;

namespace SocialMedia.Models;

public record User
{
    

    public long UserId { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public int Followers { get; set; }
    public int Following { get; set; }

    public UserDTO asDto => new UserDTO
    {
        UserId = UserId,
        UserName = UserName,
        Password = Password,
        Email = Email,
        Followers = Followers,
        Following = Following,
    };

}
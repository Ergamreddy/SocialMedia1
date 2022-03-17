
using Microsoft.AspNetCore.Mvc;
using SocialMedia.DTOs;
using SocialMedia.Models;
using SocialMedia.Repositories;

namespace SocialMedia.Controllers;


[ApiController]
[Route("api/user")]
public class UserController : ControllerBase 
{

    private readonly ILogger<UserController> _logger;
    private readonly IUserRepository _user;
    private readonly IPostRepository _post;

    public UserController(ILogger<UserController> logger,
    IUserRepository user,IPostRepository post)
    {
        _logger = logger;
        _user = user;
        _post = post;
    }
    


[HttpGet]

 public async Task<ActionResult<List<UserDTO>>> GetAllUser()
{
        var usersList = await _user.GetList();

        // User -> UserDTO
        var dtoList = usersList.Select(x => x.asDto);

        return Ok(dtoList);
}



    [HttpGet("{id}")]
    public async Task<ActionResult<UserDTO>> GetUserById([FromRoute] long id)
    {
        var user = await _user.GetById(id);

        if (user is null)
            return NotFound("No user found with given id");

        var dto = user.asDto;
        dto.Post = (await _post.GetAllForUser(id)).Select(x=>x.asDto).ToList();


        return Ok(dto);
    }
[HttpPost]
    public async Task<ActionResult<UserDTO>> CreateUser([FromBody] UserCreateDTO Data)
    {
       
        var toCreateUser = new User
        {
            UserName = Data.UserName,
            Password = Data.Password,
            Email = Data.Email,
            Followers = Data.Followers,
            Following = Data.Following,
        };

        var createdUser = await _user.Create(toCreateUser);

        return StatusCode(StatusCodes.Status201Created, createdUser.asDto);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateUser([FromRoute] long id,
    [FromBody] UserUpdateDTO Data)
    {
        var existing = await _user.GetById(id);
        if (existing is null)
            return NotFound("No user found with given id");

        var toUpdateUser = existing with
        {
            Email = Data.Email?.Trim()?.ToLower() ?? existing.Email,
            Password = Data.Password,
            UserName = Data.UserName,
            
        };

        var didUpdate = await _user.Update(toUpdateUser);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update user");

        return NoContent();
    }



 [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser([FromRoute] long id)
    {
        var existing = await _user.GetById(id);
        if (existing is null)
            return NotFound("No user found with given user name");

        var didDelete = await _user.Delete(id);

        return NoContent();
    }
}
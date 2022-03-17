using Microsoft.AspNetCore.Mvc;
using SocialMedia.DTOs;
using SocialMedia.Models;
using SocialMedia.Repositories;

namespace SocialMedia.Controllers;

[ApiController]
[Route("api/likes")]
public class LikesController : ControllerBase
{
    private readonly ILogger<PostController> _logger;
    private readonly IPostRepository _post;
    private readonly ILikesRepository _likes;

    public LikesController(ILogger<PostController> logger,
    ILikesRepository likes, IPostRepository post)
    {
        _logger = logger;
        _post = post;
        _likes = likes;
    }

    [HttpGet]

 public async Task<ActionResult<List<LikesDTO>>> GetAllUser()
{
        var usersList = await _likes.GetList();

        // User -> UserDTO
        var dtoList = usersList.Select(x => x.asDto);

        return Ok(dtoList);
}

 [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteLikes([FromRoute] int id)
    {
        var existing = await _likes.GetById(id);
        if (existing is null)
            return NotFound("No likes found with given id");

        await _likes.Delete(id);

        return NoContent();
    }


    [HttpPost]
    public async Task<ActionResult<LikesCreateDTO>> CreatePost([FromBody] LikesCreateDTO Data)
    {
        var post = await _post.GetById(Data.PostId);
        if (post is null)
            return NotFound("No user found with given user id");

        var toCreateLikes = new Likes
        {
            
            PostId = Data.PostId,
            UserId = Data.UserId,
            CreatedAt = Data.CreatedAt.UtcDateTime,
           

        };

        
        var createdLikes = await _likes.Create(toCreateLikes);

        return StatusCode(StatusCodes.Status201Created, createdLikes);
    }






}
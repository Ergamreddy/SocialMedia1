using Microsoft.AspNetCore.Mvc;
using SocialMedia.DTOs;
using SocialMedia.Models;
using SocialMedia.Repositories;

namespace SocialMedia.Controllers;

[ApiController]
[Route("api/post")]
public class PostController : ControllerBase
{
    private readonly ILogger<PostController> _logger;
    private readonly IPostRepository _post;
    private readonly IUserRepository _user;
    private readonly ILikesRepository _likes;


    public PostController(ILogger<PostController> logger,
    IPostRepository post, IUserRepository user,ILikesRepository likes)
    {
        _logger = logger;
        _post = post;
        _user = user;
        _likes = likes;
    }

    [HttpPost]
    public async Task<ActionResult<PostCreateDTO>> CreatePost([FromBody] PostCreateDTO Data)
    {
        var user = await _user.GetById(Data.UserId);
        if (user is null)
            return NotFound("No user found with given user id");

        var toCreatePost = new Post
        {
            TypeOfPost = Data.TypeOfPost.Trim(),
            UserId = Data.UserId,
            PostedAt = Data.PostedAt.UtcDateTime,
            

        };

        
        var createdPost = await _post.Create(toCreatePost);

        return StatusCode(StatusCodes.Status201Created, createdPost);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeletePost([FromRoute] int id)
    {
        var existing = await _post.GetById(id);
        if (existing is null)
            return NotFound("No post found with given id");

        await _post.Delete(id);

        return NoContent();
    }

    [HttpGet]

 public async Task<ActionResult<List<PostDTO>>> GetAllUsers()
{
        var postList = await _post.GetList();

        var dtoList = postList.Select(x => x.asDto);

        return Ok(dtoList);
}

  [HttpGet("{id}")]
    public async Task<ActionResult<PostDTO>> GetPostById([FromRoute] int id)
    {
        var post = await _post.GetById(id);

        if (post is null)
            return NotFound("No post found with given id");

        var dto = post.asDto;
        dto.Likes = (await _likes.GetAllForPost(id)).Select(x => x.asDto).ToList();



        return Ok(dto);
    }
}
using Microsoft.AspNetCore.Mvc;
using SocialMedia.DTOs;
using SocialMedia.Models;
using SocialMedia.Repositories;

namespace SocialMedia.Controllers;


[ApiController]
[Route("api/hashtags")]


public class HashtagController : ControllerBase
{

    private readonly ILogger<HashtagController> _logger;
    private readonly IHashtagRepository _hashtag;
    private readonly IPostRepository _post;

    public HashtagController(ILogger<HashtagController> logger,
    IHashtagRepository hashtags, IPostRepository post)
    {
        _logger = logger;
        _hashtag = hashtags;
        _post = post;
    }

    [HttpPost]
    public async Task<ActionResult<HashtagDTO>> CreateUser([FromBody] HashtagCreateDTO Data)
    {

        var post = await _post.GetById(Data.PostId);
        if (post is null)
            return NotFound("No post found with given post id");


        var toCreateHashtag = new Hashtag
        {
            HashtagName = Data.HashtagName,
            PostId = Data.PostId,

        };

        var createdHashtag = await _hashtag.Create(toCreateHashtag);

        return StatusCode(StatusCodes.Status201Created, createdHashtag.asDto);
    }



    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateHashtag([FromRoute] long id,
    [FromBody] HashtagUpdateDTO Data)
    {
        var existing = await _hashtag.GetById(id);
        if (existing is null)
            return NotFound("No user found with given id");

        var toUpdateHashtag = existing with
        {

            HashtagName = Data.HashtagName,

        };

        var didUpdate = await _hashtag.Update(toUpdateHashtag);

        if (!didUpdate)
            return StatusCode(StatusCodes.Status500InternalServerError, "Could not update name");

        return NoContent();
    }


    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteHashtag([FromRoute] long id)
    {
        var existing = await _hashtag.GetById(id);
        if (existing is null)
            return NotFound("No hashtag found with given  name");

        var didDelete = await _hashtag.Delete(id);

        return NoContent();
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<HashtagDTO>> GetHashtagById([FromRoute] int id)
    {
        var hashtag = await _hashtag.GetById(id);

        if (hashtag is null)
            return NotFound("No hashtag found with given id");

        var dto = hashtag.asDto;
        dto.Post = (await _post.GetAllForHashtag(id)).Select(x => x.asDto).ToList();



        return Ok(dto);
    }



}



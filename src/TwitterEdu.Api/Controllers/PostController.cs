using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NodaTime;
using TwitterEdu.Api.Models.Posts;
using TwitterEdu.Data;
using TwitterEdu.Data.Entities;

namespace TwitterEdu.Api.Controllers;

[ApiController]
public class PostController : ControllerBase
{
    private AppDbContext _dbContext;
    public PostController(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    [HttpPost("api/Post")]
    public async Task<IActionResult> Create([FromBody] CreatePostModel model)
    {
        var newEntity = new Post
        {
            Content = model.Content,
            CreatedAt = new Instant(),
        };

        _dbContext.Add(newEntity);
        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpGet("api/Post")]
    public async Task<IActionResult> GetList()
    {
        var dbEntities = _dbContext.Posts;
        return Ok(dbEntities);
    }
}

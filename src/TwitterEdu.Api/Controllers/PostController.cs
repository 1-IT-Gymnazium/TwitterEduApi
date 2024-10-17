using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using NodaTime.Text;
using TwitterEdu.Api.Models.Posts;
using TwitterEdu.Data;
using TwitterEdu.Data.Entities;

namespace TwitterEdu.Api.Controllers;

[ApiController]
public class PostController(IClock clock, AppDbContext dbContext) : ControllerBase
{
    private AppDbContext _dbContext = dbContext;
    private IClock _clock = clock;

    [HttpPost("api/Post")]
    public async Task<IActionResult> Create([FromBody] CreatePostModel model)
    {
        var newEntity = new Post
        {
            Content = model.Content,
            CreatedAt = _clock.GetCurrentInstant(),
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

    [HttpGet("api/Post/{id:guid}")]
    public async Task<IActionResult> Get([FromRoute] Guid id)
    {
        var dbEntity = await _dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
        if (dbEntity == null)
        {
            return NotFound();
        }

        var model = new DetailPostModel
        {
            Id = dbEntity.Id,
            Content = dbEntity.Content,
            CreatedAt = dbEntity.CreatedAt.ToString(),
            ModifiedAt = dbEntity.ModifiedAt.ToString(),
        };

        return Ok(model);
    }

    [HttpDelete("api/Post/{id:guid}")]
    public async Task<IActionResult> Delete([FromRoute] Guid id)
    {
        var dbEntity = await _dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
        if (dbEntity == null)
        {
            return NotFound();
        }

        _dbContext.Remove(dbEntity);
        await _dbContext.SaveChangesAsync();
        return NoContent();
    }
}

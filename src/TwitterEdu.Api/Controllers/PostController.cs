using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NodaTime;
using NodaTime.Text;
using TwitterEdu.Api.Models.Posts;
using TwitterEdu.Api.Utils;
using TwitterEdu.Data;
using TwitterEdu.Data.Entities;

namespace TwitterEdu.Api.Controllers;

[ApiController]
public class PostController(IClock clock, IApplicationMapper mapper, AppDbContext dbContext) : ControllerBase
{
    private AppDbContext _dbContext = dbContext;
    private IClock _clock = clock;
    private IApplicationMapper _mapper = mapper;

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

    [HttpPut("api/Post/{id:guid}")]
    public async Task<IActionResult> Update([FromRoute] Guid id, [FromBody] CreatePostModel model)
    {
        var dbEntity = await _dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
        if (dbEntity == null)
        {
            return NotFound();
        }

        dbEntity.Content = model.Content;
        dbEntity.ModifiedAt = _clock.GetCurrentInstant();

        await _dbContext.SaveChangesAsync();

        return Ok();
    }

    [HttpGet("api/Post/{id:guid}")]
    public async Task<ActionResult<DetailPostModel>> Get([FromRoute] Guid id)
    {
        var dbEntity = await _dbContext.Posts.FirstOrDefaultAsync(x => x.Id == id);
        if (dbEntity == null)
        {
            return NotFound();
        }

        return Ok(_mapper.ToDetail(dbEntity));
    }

    [HttpGet("api/Post")]
    public async Task<ActionResult<List<DetailPostModel>>> GetList()
    {
        var models = _dbContext
            .Posts
            .Select(_mapper.ToDetail);

        return Ok(models);
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

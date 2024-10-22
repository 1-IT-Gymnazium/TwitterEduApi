using TwitterEdu.Api.Utils;
using TwitterEdu.Data.Entities;

namespace TwitterEdu.Api.Models.Posts;

public class DetailPostModel
{
    public Guid Id { get; set; }
    public string Content { get; set; } = null!;
    public string CreatedAt { get; set; } = null!;
    public string ModifiedAt { get; set; } = null!;
}

public static class DetailPostModelExtensions
{
    public static DetailPostModel ToDetail(this IApplicationMapper mapper, Post source)
        => new()
        {
            Id = source.Id,
            Content = source.Content,
            CreatedAt = source.CreatedAt.ToString(),
            ModifiedAt = source.ModifiedAt.ToString(),
        };
}

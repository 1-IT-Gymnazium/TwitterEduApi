namespace TwitterEdu.Api.Models.Posts;

public class DetailPostModel
{
    public Guid Id { get; set; }
    public string Content { get; set; } = null!;
    public string CreatedAt { get; set; } = null!;
    public string ModifiedAt { get; set; } = null!;
}

using NodaTime;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TwitterEdu.Data.Entities.Identity;
using TwitterEdu.Data.Interfaces;

namespace TwitterEdu.Data.Entities;
[Table(nameof(Comment))]
public class Comment : ITrackable
{
    public Guid Id { get; set; }
    [MaxLength(250)]
    public string Content { get; set; } = null!;
    public Guid AuthorId { get; set; }
    public AppUser Author { get; set; } = null!;
    public Instant CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public Instant ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public Instant? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}

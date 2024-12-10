using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TwitterEdu.Data.Entities.Identity;
using TwitterEdu.Data.Interafaces;

namespace TwitterEdu.Data.Entities;
[Table(nameof(Post))]
public class Post : ITrackable
{
    public Guid Id { get; set; }
    public string Content { get; set; } = null!;

    public AppUser Author { get; set; } = null!;
    public Guid AuthorId { get; set; }

    public Instant CreatedAt { get; set; }
    public string CreatedBy { get; set; } = null!;
    public Instant ModifiedAt { get; set; }
    public string ModifiedBy { get; set; } = null!;
    public Instant? DeletedAt { get; set; }
    public string? DeletedBy { get; set; }
}

using NodaTime;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwitterEdu.Data.Entities;
[Table(nameof(Post))]
public class Post
{
    public Guid Id { get; set; }
    public string Content { get; set; } = null!;
    public Instant CreatedAt { get; set; }
    public Instant ModifiedAt { get; set; }
}

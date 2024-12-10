using System.ComponentModel.DataAnnotations;

namespace TwitterEdu.Api.Models.Posts;

public class CreatePostModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Příspěvek musí mít nějaký text!")]
    [MaxLength(250)]
    public string Content { get; set; } = null!;
}

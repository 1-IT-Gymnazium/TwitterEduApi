using System.ComponentModel.DataAnnotations;

namespace TwitterEdu.Api.Models.Posts;

public class CreatePostModel
{
    [Required(AllowEmptyStrings = false, ErrorMessage = "Příspěvek musí mít nějaký text!")]
    public string Content { get; set; } = null!;
}

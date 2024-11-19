using System.ComponentModel.DataAnnotations;

namespace TwitterEdu.Api.Models.Auth;

public class RegisterModel
{
    [Required]
    [EmailAddress]
    public string Email { get; set; } = null!;
    [Required]
    public string Password { get; set; } = null!;

    [Required]
    public string DisplayName { get; set; } = null!;
}

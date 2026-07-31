using System.ComponentModel.DataAnnotations;

namespace Quantify.ViewModels;
public class RegisterViewModel
{
    public string? Name {get;set;}
    public string? Surname {get;set;}

    [Required]
    [EmailAddress]
    public required string Email {get;set;}

    [Required]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "Nickname must contain at least 3 characters")]
    public required string NickName {get;set;}

    [Required]
    [DataType(DataType.Password)]
    [StringLength(100, MinimumLength = 8, ErrorMessage = "Password must contain at least 8 characters")]
    [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[^a-zA-Z0-9]).*$",ErrorMessage = "Password must contain at least one uppercase letter, one lowercase letter, one number and one special sign.")]
    public required string Password {get;set;}

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public required string PasswordToCompare {get;set;}

    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber {get;set;}

}
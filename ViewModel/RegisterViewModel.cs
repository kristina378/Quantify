using System.ComponentModel.DataAnnotations;

namespace Quantify.ViewModels;
public class RegisterViewModel
{
    [Required]
    public required string Name {get;set;}
    [Required]
    public required string Surname {get;set;}

    [Required]
    [EmailAddress]
    public required string Email {get;set;}

    [Required]
    [DataType(DataType.Password)]
    public required string Password {get;set;}

    [Required]
    [DataType(DataType.Password)]
    [Compare("Password")]
    public required string PasswordToCompare {get;set;}

    [Required]
    [DataType(DataType.PhoneNumber)]
    public required string PhoneNumber {get;set;}
}
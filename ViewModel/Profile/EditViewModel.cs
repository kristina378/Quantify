using System.ComponentModel.DataAnnotations;

namespace Quantify.ViewModels;

public class EditViewModel
{
    public string? Name {get;set;}
    public string? Surname {get;set;}

    [Required]
    [DataType(DataType.EmailAddress)]
    public required string Email {get;init;}
    
    [Required]
    [StringLength(40, MinimumLength = 3, ErrorMessage = "Nickname must contain at least 3 characters")]
    public required string NickName {get;init;}


    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber {get;set;}

}

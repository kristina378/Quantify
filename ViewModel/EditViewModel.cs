using System.ComponentModel.DataAnnotations;

namespace Quantify.ViewModels;

public class EditViewModel
{
    [Required]
    public required string Name{get;set;}
    [Required]
    public required string Surname{get;set;}

    [Required]
    [DataType(DataType.EmailAddress)]
    public required string Email {get; init;}

    [Required]
    [DataType(DataType.PhoneNumber)]
    public required string PhoneNumber{get;set;}

}

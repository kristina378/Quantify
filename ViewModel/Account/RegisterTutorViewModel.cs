using System.ComponentModel.DataAnnotations;

namespace Quantify.ViewModels;
public class RegisterTutorViewModel:RegisterViewModel
{
    public string? Experience {get;set;}
    public string? EmploymentPlace {get;set;}

    [Required]
    public required string AboutTutor {get;set;}
}
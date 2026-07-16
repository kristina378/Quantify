using System.ComponentModel.DataAnnotations;

namespace Quantify.ViewModels;

public class EditTutorViewModel: EditViewModel
{
    public string? Experience {get;set;}
    public string? EmploymentPlace {get;set;}
    public string? AboutTutor {get;set;}

    // need to add here:
    // => list of students for tutor for fast navigation
    //      for example: check student test and progress
}

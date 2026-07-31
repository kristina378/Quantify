using System.ComponentModel.DataAnnotations;

namespace Quantify.ViewModels;

public class AddModuleViewModel
{
    [Required]
    public required string Name {get; set;}
    public string? Description {get; set;}
    public List<AddTopicViewModel>? Topics {get; set;}
}
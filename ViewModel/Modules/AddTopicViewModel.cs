using System.ComponentModel.DataAnnotations;

namespace Quantify.ViewModels;

public class AddTopicViewModel()
{
    public long ModuleId { get; set; }

    [Required]
    public string? Name {get; set;}
    [Required]
    public string? Content {get; set;}
    public List<AddTaskViewModel>? Tasks {get; set;}
}
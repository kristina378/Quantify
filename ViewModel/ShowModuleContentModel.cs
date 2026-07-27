using System.ComponentModel.DataAnnotations;

namespace Quantify.ViewModels;

public class ShowModuleContentModel
{
    [Required]
    public required long ModuleId {get; set;}
    [Required]
    public required string Name {get; set;}
    public string? Description {get; set;}
    public List<ShowTopicContentModel>? Topics {get; set;}
}
using System.ComponentModel.DataAnnotations;

namespace Quantify.ViewModels;

public class ShowTopicContentModel
{
    [Required]
    public required long TopicId {get; set;}
    [Required]
    public required string Name {get; set;}
    [Required]
    public required string Content {get; set;}

    public List<ShowTaskContentModel>? Tasks {get; set;} = null;
}
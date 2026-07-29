using System.ComponentModel.DataAnnotations;

namespace Quantify.ViewModels;

// maybe author (link) feature?
public class AddTaskViewModel()
{   
    [Required]
    public int PointsCount{get; private set;}
    [Required]
    public int Level {get; init;}
    [Required]
    public int ExpReward{get; init;}
    [Required]
    public required string Contents {get; init;}
    
}
using System.ComponentModel.DataAnnotations;

namespace Quantify.ViewModels;

public class ShowTaskContentViewModel
{
    [Required]
    public required long TaskId {get; set;}
    [Required]
    public required string Contents {get; set;}

    [Required]
    public required int PointsCount {get; set;}
    [Required]
    public required int DifficultyLevel {get; set;}
    public int ExpReward{get; init;}
}
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Quantify.ViewModels;

// maybe author (link) feature?
public class AddTaskViewModel
{ 
    public long ModuleId { get; set; }
    public long TopicId { get; set; }

    [Required]
    public int PointsCount{get; set;}
    [Required]
    public int Level {get; set;}
    [Required]
    public int ExpReward{get; set;}

    [Required]
    public required string Contents {get; set;} = string.Empty;
    public List<AnswerViewModel>? AllAnswers {get;set;} = Answers();

    public static List<AnswerViewModel> Answers(){
        List<AnswerViewModel> answers = new List<AnswerViewModel>();
        for(int i = 0; i < 5; i++)
        {
            AnswerViewModel answerView = new AnswerViewModel()
            {
                Content = string.Empty
            };
            answers.Add(answerView);
        }
        return answers;
    }
    
}
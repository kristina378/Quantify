using System.Diagnostics.CodeAnalysis;
namespace Quantify.Core.Models;

public class Topic
{
    public long TopicId {get; init;}
    public long ModuleId {get; init;}
    public Module Module { get; init; } = null!;

    public required string Name {get; init;}
    public required string Content {get; set;}
    public List<LearningMaterials> AdditionalLearningMaterials {get; set;} = new List<LearningMaterials>();

    public List<MathTask> MathTasks {get; private set;} = new List<MathTask>();


    protected Topic(){}

    [SetsRequiredMembers]
    public Topic(string name, string content)
    {
        Name = name;
        Content = content;
    }

    public void AddNewTask(int points, DifficultyLevel level, string content, List<Answer> rightAnswer, int expReward = 1)
    {
        MathTask newTask = new MathTask(points, level, content, rightAnswer, this, expReward);
        MathTasks.Add(newTask);
    }
    public void AddAdditionalLearningMaterials(string link)
    {
        AdditionalLearningMaterials.Add(new LearningMaterials(link));
    }
}
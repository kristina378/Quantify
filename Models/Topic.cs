namespace Quantify.Core.Models;

public class Topic
{
    public long TopicId {get; init;}
    public long ModuleId {get; init;}
    public Module Module { get; init; }

    public string Name {get; private set;}
    public string Content {get; set;}
    public List<LearningMaterials> AdditionalLearningMaterials {get; set;}

    public List<MathTask> MathTasks {get; private set;}


    public Topic(){}
    public Topic(string name, string content)
    {
        Name = name;
        Content = content;

        AdditionalLearningMaterials = new List<LearningMaterials>();
        MathTasks = new List<MathTask>();
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
namespace Quantify.Core.Models;

public class Module
{
    public long ModuleId {get; init;}

    public required string Name{get; init;}
    public string? Description {get; set;}

    public List<Topic> Topics {get; private set;} = new List<Topic>();

    public Module(){}
    public Module(string moduleName, string moduleDescription)
    {
        Name = moduleName;
        Description = moduleDescription;
    }

    public void AddNewTopic(string topicName, string topicContent)
    {
        Topic newTopic = new Topic()
        {
            Name = topicName,
            Content = topicContent
        };
        
        Topics.Add(newTopic);
    }
}
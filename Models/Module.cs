namespace Quantify.Core.Models;

public class Module
{
    public long ModuleId {get; init;}

    public string Name{get; private set;}
    public string Description {get; set;}

    public List<Topic> Topics {get; private set;}

    public Module(){}
    public Module(string moduleName, string moduleDescription)
    {
        Name = moduleName;
        Description = moduleDescription;

        Topics = new List<Topic>();
    }

    public void AddNewTopic(string topicName, string topicContent)
    {
        Topic newTopic = new Topic(topicName, topicContent);
        Topics.Add(newTopic);
    }
}
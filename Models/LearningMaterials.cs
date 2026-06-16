namespace Quantify.Core.Models;

public class LearningMaterials
{
    public long MaterialId {get; init;}
    public required string Link {get; set;}

    public LearningMaterials(){}
    public LearningMaterials(string link)
    {
        Link = link;
    }
}
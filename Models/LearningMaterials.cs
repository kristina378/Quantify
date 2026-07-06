using System.Diagnostics.CodeAnalysis;

namespace Quantify.Core.Models;

public class LearningMaterials
{
    public long MaterialId {get; init;}
    public required string Link {get; set;}

    protected LearningMaterials(){}

    [SetsRequiredMembers]
    public LearningMaterials(string link)
    {
        Link = link;
    }
}
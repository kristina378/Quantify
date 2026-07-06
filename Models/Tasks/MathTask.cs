using Quantify.Core.Users;
using System.Diagnostics.CodeAnalysis;

namespace Quantify.Core.Models;

public enum DifficultyLevel
{
    EasyPeasy = 0,
    Easy = 1,
    Intermediate = 2,
    UpperIntermediate = 3,
    Hard = 4,
    UltraHard = 5
};

public class MathTask
{
    public long TaskId {get; init;}

    public long TopicId{get; init;}
    public Topic BelongsToTopic { get; init; } = null!;

    public int PointsCount{get; private set;}
    public DifficultyLevel Level {get; init;}
    public int ExpReward{get; init;}

    public required string Contents {get; init;}
    public User? Author{get; private set;}
    public long? AuthorId { get; init; }
    public required List<Answer> RightAnswer{get; init;}

    protected MathTask(){}

    [SetsRequiredMembers]
    public MathTask(int points, DifficultyLevel level, string content, List<Answer> rightAnswer, Topic topic, int expReward = 1)
    {
        PointsCount = points;
        Level = level;
        Contents = content;
        RightAnswer = rightAnswer;
        ExpReward = expReward * ((int)level + 1);

        TopicId = topic.TopicId;
        BelongsToTopic = topic;
    }
}
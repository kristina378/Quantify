namespace Quantify.Core.Models;

public enum PossibleAnswers
{
    A, B, C, D, E
}

public class Answer
{
    public int AnswerId { get; init; }

    public long MathTaskId {get; init;}
    public PossibleAnswers CurrentAnswer {get; init;}
}
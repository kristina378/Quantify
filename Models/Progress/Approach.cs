using System.Linq;

namespace Quantify.Core.Models;

public class LimitApproachCountException: Exception{}
public class Approach
{
    public long ApproachId {get; init;}

    public DateTime TimeStarted{get; private set;}
    public long StudentTaskProgressId { get; init; }

    public bool Passed {get; private set;}= false;

    public StudentTaskProgress? Progress { get; init; }
    
    
    protected Approach()
    {
        TimeStarted = DateTime.UtcNow;
    }
    public Approach(MathTask task, List<Answer> studentAnswers, StudentTaskProgress progress)
    {
        TimeStarted = DateTime.UtcNow;

        bool fine = task.RightAnswer.All(answer => studentAnswers.Any(studAnswer => studAnswer.CurrentAnswer == answer.CurrentAnswer));

        if (fine && studentAnswers.Count == task.RightAnswer.Count)
        {
            Passed = true;
        }
        Progress = progress;
    }

}
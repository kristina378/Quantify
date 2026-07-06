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
        TimeStarted = DateTime.Now;
    }
    public Approach(MathTask task, List<Answer> studentAnswers, StudentTaskProgress progress)
    {
        TimeStarted = DateTime.Now;

        bool fine = true;
        foreach(var answer in studentAnswers)
        {
            if (!task.RightAnswer.Any(ra => ra.CurrentAnswer == answer.CurrentAnswer))
            {
                fine = false;
                break;
            }
        }
        if (fine)
        {
            Passed = true;
        }
        Progress = progress;
    }

}
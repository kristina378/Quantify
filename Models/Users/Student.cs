using Quantify.Core.Models;

namespace Quantify.Core.Users;

public class Student: User
{
    public long CoinsCount{get; private set;}
    public List<StudentTaskProgress> Approaches {get; set;} = new List<StudentTaskProgress>();
    public List<Tutor> Tutors {get; set;} = new List<Tutor>();

    public Student()
    {
        CoinsCount = 0;
    }

    public Student(List<Tutor> tutors)
    {
        CoinsCount = 0;
        Tutors = tutors;
    }


    public void AddAnotherTaskProgress(MathTask task, List<Answer> studentAnswers)
    {
        bool alreadyExists = false;
        foreach (StudentTaskProgress progress in Approaches)
        {
            if(progress.TaskId == task.TaskId)
            {
                alreadyExists = true;
                break;
            }
        }

        if (alreadyExists)
        {
            return;
        }

        StudentTaskProgress newTaskProgress = new StudentTaskProgress(this.Id, task, studentAnswers);
        Approaches.Add(newTaskProgress);

        if (newTaskProgress.Passed)
        {
            //AddCoints();
        }
        return;
    }

    public void AddCoints(int CointsCount)
    {
        this.CoinsCount += CointsCount;
    }
}
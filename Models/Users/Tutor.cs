using System.Diagnostics.CodeAnalysis;

namespace Quantify.Core.Users;

public class Tutor: User
{
    public string? Experience {get; private set;}
    public string? EmploymentPlace {get; set;}
    public string? AboutTutor {get; set;}
    public List<Opinion> Opinions {get; set;} = new List<Opinion>();
    public List<Student> Students {get; set;} = new List<Student>();

    protected Tutor(){}

    [SetsRequiredMembers]
    public Tutor(string name, string surname, string email, string phoneNumber, string passwordHash,
                    string expirience, string employmentPlace, string aboutTutor):base(name, surname, email, phoneNumber,passwordHash)
    {
        Experience = expirience;
        EmploymentPlace = employmentPlace;
        AboutTutor = aboutTutor;
    }


    public void AddOpinion(long userId, int starsCount, string? opinion)
    {
        Opinion newOpinion = new Opinion(userId, starsCount, opinion);
        Opinions.Add(newOpinion);
    }

    public void AddStudent(Student newStudent)
    {
        Students.Add(newStudent);
    }
}
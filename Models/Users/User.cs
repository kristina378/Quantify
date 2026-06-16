namespace Quantify.Core.Users;

public enum Permissions
{
    All = 1,
    None = 0
}
public abstract class User
{
    public long Id {get; private set;}
    public Permissions Permission { get; protected set;}

    public required string Name {get; set;}
    public required string Surname {get; set;}
    public required string Email {get; set;}
    public required string PhoneNumber {get; set;}

    protected User(){}
    public User(string name, string surname, string email, string phoneNumber)
    {
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
    }
}
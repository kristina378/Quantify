using Microsoft.AspNetCore.Identity;
using System.Diagnostics.CodeAnalysis;


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

    public required string PasswordHash { get; set; }

    protected User(){}

    [SetsRequiredMembers]
    public User(string name, string surname, string email, string phoneNumber,string passwordHash)
    {
        Name = name;
        Surname = surname;
        Email = email;
        PhoneNumber = phoneNumber;
        PasswordHash = passwordHash;
    }
}
using System.Diagnostics.CodeAnalysis;

namespace Quantify.Core.Users;

public class Admin : User
{
    [SetsRequiredMembers]
    public Admin(string name, string surname, string email, string phoneNumber,string passwordHash):base(name, surname, email, phoneNumber,passwordHash)
    {
        Permission = Permissions.All;
    }
}
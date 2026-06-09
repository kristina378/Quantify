namespace Quantify.Core.Users;

public class Admin : User
{
    public Admin(string name, string surname, string email, string phoneNumber):base(name, surname, email, phoneNumber)
    {
        Permission = Permissions.All;
    }
}
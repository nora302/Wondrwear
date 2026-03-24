namespace Wondwear.Domain.Entities;

public class Admin : User
{
    public Admin()
    {
    }
    public Admin(string userName)
    {
        UserName = userName;
    }
}

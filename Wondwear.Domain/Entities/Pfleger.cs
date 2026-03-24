namespace Wondwear.Domain.Entities;

public class Pfleger : User
{
    public string Name { get; set; }
    public string NachName { get; set; }
    public DateTime Geburtsdatum { get; set; }
    public virtual List<BewohnerCase> Cases { get; set; }
    public Pfleger()
    {
        
    }
    public Pfleger(string userName,string email,string telefonnummber,DateTime geburtsdatum ,string name,string nachName)
    {
        UserName = userName;
        PhoneNumber = telefonnummber;
        Email = email;
        Geburtsdatum = geburtsdatum;
        Name = name;
        NachName = nachName;
        Cases = new List<BewohnerCase>();
    }


}

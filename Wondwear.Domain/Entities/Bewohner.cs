namespace Wondwear.Domain.Entities;

public class Bewohner : User
{
    public string Name{ get; set; }
    public string NachName{ get; set; }
    public DateTime Geburtsdatum { get; set; }
    public DateTime Einzugsdatum { get; set; }
    public int ZimmerNummer { get; set; }
    public virtual List<BewohnerCase> Cases{ get; set; }
    public Bewohner()
    {
        
    }
    public Bewohner(string userName,int zimmernummer, string name, string nachName, DateTime geburtsdatum, DateTime einzugsdatum, string telefonnummer)
    {
        UserName = userName;
        Cases = new List<BewohnerCase>();
        ZimmerNummer = zimmernummer;
        Name = name;
        NachName = nachName;
        Geburtsdatum = geburtsdatum;
        Einzugsdatum = einzugsdatum;
        PhoneNumber = telefonnummer;  
    }


}

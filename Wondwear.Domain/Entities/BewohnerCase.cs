namespace Wondwear.Domain.Entities;

public class BewohnerCase
{
    public int Id { get; set; }
    public int BewohnerId { get; set; }
    public virtual Bewohner Bewohner { get; set; }
    public int? PflegerId { get; set; }
    public virtual Pfleger? Pfleger { get; set; }
    public string? Notes { get; set; }
    public bool Done { get; set; }
    public DateTime CreatedAt { get; set; }
    public BewohnerCase()
    {
        
    }
    public BewohnerCase(int bewohnerId )
    {
        BewohnerId = bewohnerId;
        Done = false;
        CreatedAt = DateTime.UtcNow;
    }

}
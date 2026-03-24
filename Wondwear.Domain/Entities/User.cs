
namespace Wondwear.Domain.Entities;

public class User : IdentityUser<int>
{
    public string? FcmToken { get; set; }
    public virtual ICollection<Notification> Notifications { get; set; } = new List<Notification>();

}

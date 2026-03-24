

namespace Wondwear.Domain.Entities;

public class Notification
{
    public int Id { get; set; }
    public string Body { get; set; }
    public string Title { get; set; }
    public int UserId { get; set; }
    public virtual User User { get; set; }
    public DateTime CreatedAt { get; set; }
    public Notification(string title, string body, int userId)
    {
        Title = title;
        Body = body;
        UserId = userId;
        CreatedAt = DateTime.UtcNow;
    }
    public Notification()
    {

    }

}

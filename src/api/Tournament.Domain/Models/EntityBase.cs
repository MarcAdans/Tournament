using Flunt.Notifications;

namespace Tournament.Domain.Models
{
    public class EntityBase : Notifiable
    {
        public virtual void Validate()
        {
        }
    }
}
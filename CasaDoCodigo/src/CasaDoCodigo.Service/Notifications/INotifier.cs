using System.Collections.Generic;

namespace CasaDoCodigo.Service.Notifications
{
    public interface INotifier
    {
        bool HaveNotification();
        List<Notification> GetNotifications();
        void Handle(Notification notification);
    }
}
using System;
using System.Collections.Generic;
using System.Text;
using task.Core.Interfaces;

namespace task.Core
{
    public class Notificacao
    {
        INotificationManager manager;
        public Notificacao()
        {
            manager = Xamarin.Forms.DependencyService.Get<INotificationManager>();
        }

        public void AgendeNotificacao(string titulo, string mensagem, DateTime dataInicioTask)
        {
            manager.SendNotification(titulo, mensagem, dataInicioTask);
        }

    }

    public class NotificationEventArgs : EventArgs
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }
}

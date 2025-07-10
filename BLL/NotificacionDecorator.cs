using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal class NotificacionDecorator : INotificacion
    {
        protected INotificacion _notificacion;

        public NotificacionDecorator(INotificacion notificacion)
        {
            _notificacion = notificacion;
        }

        public virtual void Enviar(string mensaje)
        {
            //Delego la responsabilidad de envío al objeto decorado
            _notificacion.Enviar(mensaje);
        }

    }
}

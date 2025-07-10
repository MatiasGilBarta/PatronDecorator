using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    internal class NotificacionBasica : INotificacion
    {
        //Leer desde app.config
        private string _correoOrigen = "tu-email@gmail.com"; // Correo remitente
        private string _contraseña = "tu-contraseña"; // Contraseña
        private string _correoDestino = "destinatario@example.com"; // Correo destinatario
        private string _smtpServer = "smtp.gmail.com"; // Servidor SMTP
        private int _smtpPort = 587; // Puerto SMTP

        public void Enviar(string mensaje)
        {
            try
            {
                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(_correoOrigen);
                mail.To.Add(_correoDestino);
                mail.Subject = "Notificación Importante";
                mail.Body = mensaje;
                //mail.IsBodyHtml = true; // Si el mensaje es HTML

                SmtpClient smtpClient = new SmtpClient(_smtpServer, _smtpPort);
                smtpClient.Credentials = new NetworkCredential(_correoOrigen, _contraseña);
                smtpClient.EnableSsl = true;
                smtpClient.Send(mail);

                Console.WriteLine("Correo enviado correctamente.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al enviar el correo: {ex.Message}");
            }
        }
    }
}

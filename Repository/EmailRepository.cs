using CarsRent.Entities;
using System.Net;
using System.Net.Mail;

namespace CarsRent.Repository
{
    public class EmailRepository : IEmailRepository
    {
        public void SendEmailReservation(string recipient, string subject, Reservation reservationInfo)
        {
            var smtpClient = new SmtpClient
            {
                Credentials = new NetworkCredential("kkacper909@gmail.com", "fovpjyiadybsvxmi"),
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                UseDefaultCredentials = false
            };

            var mailMessage = new MailMessage
            {
                From = new MailAddress("kkacper909@gmail.com"),
                Subject = subject,
                Body = $"Testowy email"
            };

            mailMessage.To.Add(recipient);
            smtpClient.Send(mailMessage);
        }
    }
}

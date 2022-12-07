using CarsRent.Entities;

namespace CarsRent.Repository
{
    public interface IEmailRepository
    {
        void SendEmailReservation(string recipient, string subject, Reservation reservationInfo);
    }
}

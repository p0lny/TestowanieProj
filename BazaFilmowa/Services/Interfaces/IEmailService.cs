using BazaFilmowa.Entities;

namespace BazaFilmowa.Services
{
    public interface IEmailService
    {
        void SendVerificationEmail(string email, RegistrationToken registrationToken);
    }
}
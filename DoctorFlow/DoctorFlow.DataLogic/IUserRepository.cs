using DoctorFlow.Entities.Models;

namespace DoctorFlow.DataLogic
{
    public interface IUserRepository
    {
        bool CreateUser(User newUser);
        bool InitiatePasswordRecovery(string email, string passKey);
        int Login(string userNameEmail, string password);
        bool ResetPassword(string email, string newPassword, string passKey);
        bool EditUser(User EditUser);
    }
}
using DoctorFlow.Entities.Models;

namespace DoctorFlow.DataLogic
{
    public interface IUserRepository
    {
        bool CreateUser(User newUser);
        bool InitiatePasswordRecovery(string email,string tempPassword);
        bool Login(string userNameEmail, string password);
    }
}
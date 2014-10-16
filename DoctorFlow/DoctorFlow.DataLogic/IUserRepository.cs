using DoctorFlow.Entities.Models;

namespace DoctorFlow.DataLogic
{
    public interface IUserRepository
    {
        bool CreateUser(User newUser);
        bool CreateDoctor(User newUset, Doctor newDoctor);
        bool InitiatePasswordRecovery(string email, string passKey);
        User Login(string userNameEmail, string password);
        bool ResetPassword(string email, string newPassword, string passKey);
        bool EditUser(User EditUser);
        bool DisableUser(User EditUser);
        string UserName(int UserId);
        User EditUser2(User editUser);
        
        bool ActivateUser(string userNameEmail, string password, string activateCode);
        User getUser(int idUser);
        User getUser(string userNameEmail);

        Doctor getDoctor(int idUser);
        bool isDoctor(int userId);

        bool EditDoctor(Doctor EditDoctor);
    }
}

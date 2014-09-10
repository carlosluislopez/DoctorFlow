using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
using DoctorFlow.Entities;
using DoctorFlow.Entities.Context;
using DoctorFlow.Entities.Models;

namespace DoctorFlow.DataLogic
{
    public class UserRepository : IUserRepository
    {

        public bool CreateUser(User newUser)
        {
            using (var db=new DoctorFlowContext())
            {
                db.Users.Add(newUser);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool InitiatePasswordRecovery(string email,string tempPassword)
        {
            using (var db=new DoctorFlowContext())
            {
                var user = (from u in db.Users
                    where Equals(u.Email, email)
                    select u).First();
                if (user == null) return false;
                if (user.PasswordFlag) return false;
                user.TempPassword = tempPassword;
                user.PasswordFlag = true;
                db.SaveChanges();
            }
            return true;
        }
        public bool Login(string userNameEmail, string password)
        {
            using (var db = new DoctorFlowContext())
            {
                var usuarios = from u in db.Users
                               where Equals(u.Password, password) && (Equals(u.Email, userNameEmail) || Equals(u.UserName, userNameEmail))
                               select u;

                if (usuarios.Any())
                    return true;

            }
            return false;
        }
    }
}

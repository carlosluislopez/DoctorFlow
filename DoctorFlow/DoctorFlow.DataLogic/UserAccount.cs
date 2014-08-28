using System;
using System.Collections.Generic;
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
    public class UserAccount
    {
        public bool CreateUser(string UserName, string Password, string Name, string LastName, string Email)
        {
            using (var db=new DoctorFlowContext())
            {
                var newUser = new User { UserName = UserName,Password = Password,Name = Name,Email = Email,LastName = LastName, RegisterDate = Convert.ToDateTime("12/2/2014"),Status = true};
                db.Users.Add(newUser);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool Login(string UserNameEmail, string Password)
        {
            using (var db = new DoctorFlowContext())
            {
                var usuarios = from u in db.Users
                               where Equals(u.Password, Password) && (Equals(u.Email, UserNameEmail) || Equals(u.UserName, UserNameEmail))
                               select u;

                if (usuarios.Any())
                    return true;

            }
            return false;
        }
    }
}

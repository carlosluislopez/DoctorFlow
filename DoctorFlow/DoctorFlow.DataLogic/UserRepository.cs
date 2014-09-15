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
                db.Users.Attach(newUser);
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public bool CreateDoctor(User newUser,Doctor newDoctor)
        {
            using (var db = new DoctorFlowContext())
            {
                
                db.Users.Add(newUser);
                db.Doctor.Add(newDoctor);
                db.SaveChanges();
                return true;
            }
            return false;
        }

        public bool ResetPassword(string email, string newPassword, string passKey)
        {
            using (var db = new DoctorFlowContext())
            {
                var today = DateTime.Now;
                var userQueryable = (from u in db.Users
                                     where Equals(u.Email, email) && Equals(u.TempPassword,passKey)
                                     select u);
                if (!userQueryable.Any())
                    return false;
                var user = userQueryable.First();
                if (user.PasswordFlag.AddDays(1) < today)
                    return false;
                user.TempPassword = null;
                user.PasswordFlag = today;
                user.Password = newPassword;
                db.SaveChanges();
            }
            return true;
        }
        public bool InitiatePasswordRecovery(string email,string passKey)
        {
            using (var db=new DoctorFlowContext())
            {
                var today = DateTime.Now;
                var userQueryable = (from u in db.Users
                    where Equals(u.Email, email)
                    select u);
                if (!userQueryable.Any())
                    return false;
                var user = userQueryable.First();
                if (user.PasswordFlag.AddDays(1) > today) 
                    return false;
                user.TempPassword = passKey;
                user.PasswordFlag = today;
                db.SaveChanges();
            }
            return true;
        }
        public User Login(string userNameEmail, string password)
        {
            using (var db = new DoctorFlowContext())
            {
                try
                {
                    var users = from user in db.Users
                                where Equals(user.Password, password)
                                && (Equals(user.Email, userNameEmail) || Equals(user.UserName, userNameEmail))
                                && user.Status
                                select user;

                    if (users.Any())
                        return users.First();
                }
                catch (Exception ex) { }
            }
            return null;
        }

        public bool EditUser(User EditUser)
        {
            using (var db = new DoctorFlowContext())
            {
                var userQueryable = (from u in db.Users
                                     where Equals(u.Id, EditUser.Id)
                                     select u
                                    );
                
                if (!userQueryable.Any())
                    return false;

                var user = userQueryable.First();

                user.Name = EditUser.Name;
                user.LastName = EditUser.LastName;
                user.Phone = EditUser.Phone;
                user.SocialSecurityNumber = EditUser.SocialSecurityNumber;
                user.UserName = EditUser.UserName;
                user.Address = EditUser.Address;
                user.BirthDate = EditUser.BirthDate;
                user.BloodType = EditUser.BloodType;
                user.Email = EditUser.Email;
                user.Height = EditUser.Height;
                user.MaritalStatus = EditUser.MaritalStatus;
                user.Photo = EditUser.Photo;
                try
                {
                    db.SaveChanges();
                    return true;
                }catch (Exception ex) { }
            }
            return false;
        }

        public string UserName(int UserId)
        {
            using (var db = new DoctorFlowContext())
            {
                try
                {
                    var userQueryable = (from u in db.Users
                                         where Equals(u.Id, UserId)
                                         select u
                                    );

                    if (!userQueryable.Any())
                        return "";

                    var user = userQueryable.First();
                    return user.UserName;
                }
                catch (Exception ex) { }
            }
            return "";
        }

        public User EditUser2(User editUser)
        {
            return null;
        }

        public User getUser(int idUser)
        {
            using (var db = new DoctorFlowContext())
            {
                try
                {
                    var users = from user in db.Users
                                where user.Id == idUser
                                select user;

                    if (users.Any())
                        return users.First();
                }
                catch (Exception ex) { }
            }
            return null;
        }
    }
}

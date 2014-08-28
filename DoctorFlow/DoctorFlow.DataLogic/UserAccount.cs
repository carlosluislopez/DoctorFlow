using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.Entity;
//using DoctorFlow.Entities;
//using DoctorFlow.Entities.Context;
//using DoctorFlow.Entities.Models;

namespace DoctorFlow.DataLogic
{
    public class UserAccount
    {
        public bool CreateUser(string UserName, string Password, string Name, string LastName, string Email)
        {
            return false;
        }

        public bool Login(string UserNameEmail, string Password)
        {
            return false;
        }
    }
}

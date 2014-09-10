using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFlow.Entities.Models
{
    public class User
    {
        public int Id { set; get; }
        public string UserName { set; get; }
        public string Password { set; get; }
        public string Name { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        public DateTime RegisterDate { set; get; }
        public bool Status { set; get; }
        public bool PasswordFlag { set; get; }
        public string TempPassword { get; set; }
    }
}

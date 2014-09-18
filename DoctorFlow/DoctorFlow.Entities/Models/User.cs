using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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
        public DateTime PasswordFlag { set; get; }
        public string TempPassword { get; set; }
        public DateTime BirthDate { get; set; }
        public string SocialSecurityNumber { get; set; }
        public string Phone { get; set; }
        public string MaritalStatus { get; set; }
        public int Height { get; set; }
        public string BloodType { get; set; }
        public string Allergy { get; set; }
        public string Address { get; set; }
        public byte[] Photo { get; set; }
        public string ActivateCode { get; set; }
    }
}

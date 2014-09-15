using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoctorFlow.Entities.Models
{
    public class Doctor
    {
        public int Id { get; set; }
        public User MyUserData { get; set; }
        public string Specialty { get; set; }
        public string WorkPlace { get; set; }
        public string WorkAddress { get; set;}
        public string WorkPhoneNumber { get; set; }
        public string ScheduleStart { get; set; }
        public string ScheduleEnd { get; set; }
        public List<int> Reputation { get; set; }
        public int MedicalLicenseNumber { get; set;}
    }
}

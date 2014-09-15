using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorFlow.Models.UserModels
{
    public class DoctorRegisterModel: UserRegisterModel
    {
        [Required]
        [Display(Name = "Especialidad")]
        public string Specialty { set; get; }
        [Required]
        [Display(Name = "Número de colegiatura")]
        public int MedicalLicenseNumber { get; set; } 
    }
}
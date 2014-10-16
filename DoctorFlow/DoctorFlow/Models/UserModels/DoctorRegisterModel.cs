using System.ComponentModel.DataAnnotations;

namespace DoctorFlow.Models.UserModels
{
    public class DoctorRegisterModel: UserRegisterModel
    {
        [Display(Name = "Especialidad")]
        public string Specialty { set; get; }
        [Display(Name = "Número de colegiatura")]
        public int MedicalLicenseNumber { get; set; } 
    }
}
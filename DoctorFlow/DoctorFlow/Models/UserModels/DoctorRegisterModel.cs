using System.ComponentModel.DataAnnotations;

namespace DoctorFlow.Models.UserModels
{
    public class DoctorRegisterModel: UserRegisterModel
    {
        [Required(ErrorMessage = "Este campo es requerido!")]
        [Display(Name = "Especialidad")]
        public string Specialty { set; get; }
        [Required(ErrorMessage = "Este campo es requerido!")]
        [Display(Name = "Número de colegiatura")]
        public int MedicalLicenseNumber { get; set; } 
    }
}
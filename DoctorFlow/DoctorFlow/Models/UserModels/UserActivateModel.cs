using System.ComponentModel.DataAnnotations;

namespace DoctorFlow.Models.UserModels
{
    public class UserActivateModel
    {
        [Required]
        [Display(Name = " Correo/Usuario")]
        public string EmailOrUserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]

        public string Password { get; set; }

        [Required]
        [Display(Name = "Codigo Activacion")]
        public string ActivateCode { get; set; }

    }
}
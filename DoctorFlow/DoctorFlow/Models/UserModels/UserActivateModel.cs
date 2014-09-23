using System.ComponentModel.DataAnnotations;

namespace DoctorFlow.Models.UserModels
{
    public class UserActivateModel
    {
        [Required(ErrorMessage = "Este campo es requerido!")]
        [Display(Name = " Correo/Usuario")]
        public string EmailOrUserName { get; set; }

        [Required(ErrorMessage = "Este campo es requerido!")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]

        public string Password { get; set; }

        [Required(ErrorMessage = "Este campo es requerido!")]
        [Display(Name = "Codigo Activacion")]
        public string ActivateCode { get; set; }

    }
}
using System.ComponentModel.DataAnnotations;

namespace DoctorFlow.Models.UserModels
{
    public class UserActivateModel
    {
        [Display(Name = " Correo/Usuario")]
        public string EmailOrUserName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]

        public string Password { get; set; }

        [Display(Name = "Codigo de Activación")]
        public string ActivateCode { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorFlow.Models
{
    public class UserLoginModel
    {
        [Required(ErrorMessage = "Este campo es requerido!")]
        [Display(Name = " Correo/Usuario")]
        public string EmailOrUserName { get; set; }

        [Required(ErrorMessage = "Este campo es requerido!")]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]

        public string Password { get; set; }
    }
}
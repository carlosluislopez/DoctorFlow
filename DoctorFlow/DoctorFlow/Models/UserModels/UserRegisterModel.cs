using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorFlow.Models
{
    public class UserRegisterModel
    {
        [Display(Name = "Nombre de Usuario")]
        public string UserName { get; set; }

        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar la Contraseña")]
        public string ConfirmPassword { get; set; }

        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }
}
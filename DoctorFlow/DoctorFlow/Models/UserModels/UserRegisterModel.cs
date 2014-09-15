using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorFlow.Models
{
    public class UserRegisterModel
    {
        [Display(Name = "Nombre de Usuario"),Required,StringLength(100,ErrorMessage = "No debe estar vacio.",MinimumLength = 1)]
        public string UserName { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "La contraseña deberia tener al menos {2} caracteres.", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirmar la Contraseña")]
        [Compare("Password", ErrorMessage = "La confirmación y la contraseña no coinciden.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }
    }
}
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web; 
namespace DoctorFlow.Models
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
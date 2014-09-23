using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace DoctorFlow.Models.UserModels
{
    public class UserPasswordRecoveryModel
    {
        [EmailAddress]
        [Required(ErrorMessage = "Este campo es requerido!")]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
    }
}
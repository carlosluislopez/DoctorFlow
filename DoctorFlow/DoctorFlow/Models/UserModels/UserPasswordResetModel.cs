using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorFlow.Models.UserModels
{
    public class UserPasswordResetModel
    {
        [Display(Name = "Clave")]
        public string PassKey { set; get; }
        [EmailAddress]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Nueva Contraseña")]
        public string NewPassword { set; get; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirmar Contraseña")]    
        public string ConfirmNewPassword { set; get; }
    }
}
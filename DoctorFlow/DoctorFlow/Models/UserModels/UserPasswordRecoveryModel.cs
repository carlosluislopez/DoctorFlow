﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorFlow.Models.UserModels
{
    public class UserPasswordRecoveryModel
    {
        [EmailAddress]
        [Required]
        [Display(Name = "Correo Electrónico")]
        public string Email { get; set; }
    }
}
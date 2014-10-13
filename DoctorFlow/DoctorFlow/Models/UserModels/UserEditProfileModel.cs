using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorFlow.Models.UserModels
{
    public class UserEditProfileModel
    {
        [Required(ErrorMessage = "Este campo es requerido!")]
        [Display(Name = "Nombre de Usuario")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Este campo es requerido!")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Este campo es requerido!")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Este campo es requerido!")]
        [Display(Name = "Correo electrónico")]
        public string Email { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Fecha de Nacimiento")]
        public DateTime BirthDate { get; set; }

        [Display(Name = "Número de seguro social")]
        public string SocialSecurityNumber { get; set; }

        [Display(Name = "Teléfono")]
        public string Phone { get; set; }

        [Display(Name = "Estado civil")]
        public string MaritalStatus { get; set; }

        [Display(Name = "Altura (cm)")]
        public int Height { get; set; }

        [Display(Name = "Tipo de sangre")]
        public string BloodType { get; set; }

        [Display(Name = "Alergias")]
        public string Allergy { get; set; }

        [Display(Name = "Dirección")]

        [DataType(DataType.MultilineText)]
        public string Address { get; set; }

        [DataType(DataType.Upload)]
        public byte[] Photo { get; set; }
    }
}
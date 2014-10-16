using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorFlow.Models
{
    public class DoctorEditProfileModel
    {
        [Required(ErrorMessage = "Este campo es requerido!")]
        [Display(Name = "Especialidad del medico")]
        public string Specialty { get; set; }

        [Required(ErrorMessage = "Este campo es requerido!")]
        [Display(Name = "Lugar de Trabajo")]
        public string WorkPlace { get; set; }

        [Required(ErrorMessage = "Este campo es requerido!")]
        [Display(Name = "Dirección del trabajo")]
        public string WorkAddress { get; set; }

        [Required(ErrorMessage = "Este campo es requerido!")]
        [Display(Name = "Telefono del Trabajo")]
        public string WorkPhoneNumber { get; set; }

        [Required(ErrorMessage = "Este campo es requerido!")]
        [Display(Name = "Hora de Entrada")]
        public string ScheduleStart { get; set; }

        [Required(ErrorMessage = "Este campo es requerido!")]
        [Display(Name = "Hora de Salida")]
        public string ScheduleEnd { get; set; }

        [Required(ErrorMessage = "Este campo es requerido!")]
        [Display(Name = "Numero Colegio Medico")]
        public int MedicalLicenseNumber { get; set; }
    }
}
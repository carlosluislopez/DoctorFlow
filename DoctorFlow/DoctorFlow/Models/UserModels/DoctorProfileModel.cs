using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace DoctorFlow.Models
{
    public class DoctorProfileModel
    {
        [Display(Name = "Especialidad del medico")]
        public string Specialty { get; set; }
        
        [Display(Name = "Lugar de Trabajo")]
        public string WorkPlace { get; set; }

        [Display(Name = "Dirección del trabajo")]
        public string WorkAddress { get; set; }

        [Display(Name = "Telefono del Trabajo")]
        public string WorkPhoneNumber { get; set; }

        [Display(Name = "Hora de Entrada")]
        public string ScheduleStart { get; set; }

        [Display(Name = "Hora de Salida")]
        public string ScheduleEnd { get; set; }

        [Display(Name = "Numero Colegio Medico")]
        public int MedicalLicenseNumber { get; set; }
    }
}
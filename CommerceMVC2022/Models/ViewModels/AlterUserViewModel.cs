using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CommerceMVC2022.Models.ViewModels
{
    public class AlterUserViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre de usuario")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Correo")]
        [EmailAddress]
        public string Correo { get; set; }

        [Required]
        [Display(Name = "Fecha Nacimiento")]
        [DataType(DataType.Date)]
        public DateTime FechaNacimiento { get; set; }

    }
}
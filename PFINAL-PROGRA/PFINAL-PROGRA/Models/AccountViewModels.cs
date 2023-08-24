using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;


namespace PFINAL_PROGRA.Models
{
    public class LoginViewModel
        {
            [Required]
            [Display(Name = "Nombre de usuario")]
            public string nombreUsuario { get; set; }

            [Required]
            [EmailAddress]
            [Display(Name = "Correo electrónico")]
            public string correo { get; set; }

            [Required]
            [DataType(DataType.Password)]
            [Display(Name = "Contraseña")]
            public string contrasena { get; set; }

            [Display(Name = "Rol")]
            public string Rol { get; set; } = "Usuario";
    }





     
     public class RegisterViewModel
     {
        [Required]
        [Display(Name = "Nombre de usuario")]
        public string nombreUsuario { get; set; }

        [Required]
        [EmailAddress]
        [Display(Name = "Correo electrónico")]
        public string correo { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2}.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Contraseña")]
        public string contrasena { get; set; }

        

        [Required]
        [Display(Name = "Rol")]
        public string Rol { get; set; }
    }
}



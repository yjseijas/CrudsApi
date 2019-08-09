using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudsApi.Models
{
    public class Usuarios
    {
        public int idUsuario { set; get; }

        [Display(Name = "Nombre Usuario")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string nombre { set; get; }

        [Display(Name = "PASSWORD")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string password { set; get; }
    }
}
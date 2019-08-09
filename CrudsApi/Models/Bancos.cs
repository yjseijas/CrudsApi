using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudsApi.Models
{
    public class Bancos
    {
        public int idBanco { set; get; }

        [Display(Name = "Nombre Banco")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string descripcion { set; get; }

        [Display(Name = "CUIT")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string numerocuit { set; get; }
    }
}
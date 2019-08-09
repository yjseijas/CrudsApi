using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudsApi.Models
{
    public class Cuentas
    {
        [Display(Name = "Código")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int idCuenta { set; get; }

        [Display(Name = "Nombre")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string descripcion { set; get; }

        [Display(Name = "Recibe Asientos")]
        public bool recibeasientos { set; get; }
        [Display(Name = "Ajustable")]
        public bool ajustable { set; get; }

        public bool activo { set; get; }

        [Display(Name = "Tipo")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public int idTipoCuenta { set; get; }

        public virtual TiposCuentas tiposcuentas { get; set; }

    }
}
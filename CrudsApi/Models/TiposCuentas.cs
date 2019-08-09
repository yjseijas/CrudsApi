using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CrudsApi.Models
{
    public class TiposCuentas
    {
        public int idTipoCuenta { set; get; }

        [Display(Name = "Nombre Tipo Cuenta")]
        [StringLength(50, ErrorMessage = "El campo {0} debe estar entre {2} y {1} carácteres", MinimumLength = 3)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string descripcion { set; get; }

        public bool asientosmanuales { set; get; }
        public bool activo { set; get; }

        public virtual ICollection<Cuentas> cuentas { set; get; }
    }
}
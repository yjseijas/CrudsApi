using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudsApi.Models
{
    public class Clientes
    {
        public int idCliente { get; set; }
        public string descripcion { get; set; }
        public string email { get; set; }
        public string mobile { get; set; }
        public int idCiudad { get; set; }
        public DateTime fechaAlta { get; set; }
        public bool activo { get; set; }

    }
}
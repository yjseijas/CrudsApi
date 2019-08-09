using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudsApi.Models
{
    public class ClientesView : Clientes
    {
        public string desCiudad { get; set; }
        public string desActivo { get; set; }
        public string fechaCorta { get; set; }
    }
}
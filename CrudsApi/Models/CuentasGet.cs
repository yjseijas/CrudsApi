using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudsApi.Models
{
    public class CuentasGet : Cuentas
    {
        public string descriTipo { get; }
        public string descriRecibe { get; }
        public string descriAjusta { get; }
        public string descriActivo { get; }

    }
}
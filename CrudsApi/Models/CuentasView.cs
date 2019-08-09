using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudsApi.Models
{
    public class CuentasView : Cuentas
    {
        public string desTipo { set; get; }
        public string descriRecibe { get; set; }
        public string descriAjusta { get; set; }
        public string descriActivo { get; set; }
    }
}
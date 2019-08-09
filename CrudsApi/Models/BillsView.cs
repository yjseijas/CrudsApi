using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudsApi.Models
{
    public class BillsView : Bills
    {
        public string nombreCliente { get; set; }
        public string fechaCorta { get; set; }
    }
}
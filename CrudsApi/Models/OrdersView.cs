using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudsApi.Models
{
    public class OrdersView : Orders
    {
        public string nombreProvedor { get; set; }
    }
}
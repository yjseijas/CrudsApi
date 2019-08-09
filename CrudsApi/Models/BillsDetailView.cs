using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudsApi.Models
{
    public class BillsDetailView : BillsDetail
    {
        public string itemName { get; set; }
        public float Total { get; set; }
        public float Precio { get; set; }
    }
}
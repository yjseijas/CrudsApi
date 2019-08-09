using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudsApi.Models
{
    public class Items
    {
        public int itemId { get; set; }
        public string name { get; set; }
        public float price { get; set; }
    }
}
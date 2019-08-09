using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudsApi.Models
{
    public class BillsDetail
    {
        public int billDetailId { get; set; }
        public int idBill { get; set; }
        public int itemId { get; set; }
        public int Quantity { get; set; }

        public virtual Orders order { get; set; }
    }
}
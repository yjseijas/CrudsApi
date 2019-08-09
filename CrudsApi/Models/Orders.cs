using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudsApi.Models
{
    public class Orders
    {
        public int ordersId { get; set; }
        public string orderNo { get; set; }
        public int idProveedor { get; set; }
        public string pMethod { get; set; }
        public float gTotal { get; set; }

        public virtual ICollection<OrdersDetail> OrdersItems { get; set; }
    }
}
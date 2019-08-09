using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudsApi.Models
{
    public class Response
    {
        public IEnumerable<OrdersView> order { get; set; }
        public IEnumerable<OrdersDetailView> detail { get; set; }
    }
}
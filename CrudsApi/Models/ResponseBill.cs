using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudsApi.Models
{
    public class ResponseBill
    {
        public IEnumerable<BillsView> bill { get; set; }
        public IEnumerable<BillsDetailView> detail { get; set; }
    }
}
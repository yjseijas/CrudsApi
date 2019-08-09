using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudsApi.Models
{
    public class Bills
    {
        public int idBill { get; set; }
        public string billNo { get; set; }
        public int idCliente { get; set; }
        public string pMethod { get; set; }
        public float gTotal { get; set; }
        public DateTime dateDoc { get; set; }

        public virtual ICollection<BillsDetail> billItems { get; set; }
    }
}
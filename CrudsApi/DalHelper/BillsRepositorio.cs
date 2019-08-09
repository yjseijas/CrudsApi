using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudsApi.Models;

namespace CrudsApi.DalHelper
{
    public class BillsRepositorio : IBillsRepositorio
    {
        public bool add(Bills bill, int idCompany)
        {
            return DalHelper.AddBill(bill,idCompany);
        }

        public bool delete(int idBill, int idCompany)
        {
            return DalHelper.deleteBill(idBill,idCompany);
        }

        public IEnumerable<BillsView> find(int idCompany)
        {
            return DalHelper.GetBills(idCompany);
        }

        public ResponseBill find(int idBill, int idCompany)
        {
            return DalHelper.GetBill(idBill,idCompany);
        }

        public bool update(Bills bill, int idCompàny)
        {
            return DalHelper.UpdateBill(bill,idCompàny);
        }
    }
}
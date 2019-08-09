using CrudsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudsApi.DalHelper
{
    public interface IBillsRepositorio
    {
        IEnumerable<BillsView> find(int idCompany);
        ResponseBill find(int idBill, int idCompany);
        bool add(Bills bill, int idCompany);
        bool update(Bills bill, int idCompàny);
        bool delete(int idBill, int idCompany);
    }
}

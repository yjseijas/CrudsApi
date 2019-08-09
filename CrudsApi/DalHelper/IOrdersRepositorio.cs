using CrudsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudsApi.DalHelper
{
    public interface IOrdersRepositorio
    {
        IEnumerable<OrdersView> find(int idCompany);
        Response find(int idOrder,int idCompany);
        bool add(Orders orden,int idCompany);
        bool update(Orders orden,int idCompàny);
        bool delete(int idOrder, int idCompany);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudsApi.Models;

namespace CrudsApi.DalHelper
{
    public class OrdersRepositorio : IOrdersRepositorio
    {
        public bool add(Orders orden, int idCompany)
        {
            return DalHelper.AddOrder(orden,idCompany);
        }

        public bool delete(int idOrder, int idCompany)
        {
            return DalHelper.deleteOrder(idOrder,idCompany);
        }

        public IEnumerable<OrdersView> find(int idCompany)
        {
            return DalHelper.GetOrders(idCompany);
        }

        public Response find(int idOrder, int idCompany)
        {
            return DalHelper.GetOrder(idOrder,idCompany);
        }

        public bool update(Orders orden, int idCompàny)
        {
            return DalHelper.UpdateOrder(orden,idCompàny);
        }
    }
}
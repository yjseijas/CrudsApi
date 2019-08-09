using CrudsApi.DalHelper;
using CrudsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudsApi.Controllers
{
    public class OrdersApiController : ApiController
    {
        IOrdersRepositorio _ordersRepositorio;

        // GET: api/OrdersApi

        OrdersApiController()
        {
            _ordersRepositorio = new OrdersRepositorio();
        }
        public IEnumerable<OrdersView> Get(int idCompany)
        {
            return _ordersRepositorio.find(idCompany);
        }

        // GET: api/OrdersApi/5
        public IHttpActionResult Get(int idOrder,int idCompany)
        {
            var oResponse = _ordersRepositorio.find(idOrder,idCompany);
            var orden = (from a in oResponse.order
                         where a.ordersId == idOrder
                         select new
                         {
                             a.ordersId,
                             a.orderNo,
                             a.idProveedor,
                             a.pMethod,
                             a.gTotal,
                             a.nombreProvedor
                         });

            var detail = (from a in oResponse.detail
                          where a.ordersId == idOrder
                          select new
                          {
                             a.ordersDetailId,
                             a.ordersId,
                             a.itemId,
                             a.Quantity,
                             a.itemName,
                             a.Precio,
                             a.Total
                          }
                );

            return Ok( new {orden,detail});
        }

        // POST: api/OrdersApi
        public string Post([FromBody]Orders orden,int idCompany)
        {
            bool result;
            if (orden.ordersId == 0)
            {
                result = _ordersRepositorio.add(orden, idCompany);
            }
            else
            {
                result = _ordersRepositorio.update(orden,idCompany);
            }

            return result ? "Succes" : "Error";
        }

        // PUT: api/OrdersApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/OrdersApi/5
        public string Delete(int id,int idCompany)
        {
            bool result;
            result = _ordersRepositorio.delete(id,idCompany);

            return result ? "Succes" : "Error";
        }
    }
}

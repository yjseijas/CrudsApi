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
    public class BillsApiController : ApiController
    {
        IBillsRepositorio _ibillsRepositorio;

        BillsApiController()
        {
            _ibillsRepositorio = new BillsRepositorio();
        }

        // GET: api/BillsApi
        public IEnumerable<Bills> Get(int idCompany)
        {
            return _ibillsRepositorio.find(idCompany);
        }

        // GET: api/BillsApi/5
        public IHttpActionResult Get(int idBill,int idCompany)
        {
            var oResponse = _ibillsRepositorio.find(idBill, idCompany);
            var bill = (from a in oResponse.bill
                         where a.idBill == idBill
                         select new
                         {
                             a.idBill,
                             a.billNo,
                             a.idCliente,
                             a.pMethod,
                             a.gTotal,
                             a.nombreCliente,
                             a.dateDoc,
                             a.fechaCorta
                         });

            var detail = (from a in oResponse.detail
                          where a.idBill == idBill
                          select new
                          {
                              a.billDetailId,
                              a.idBill,
                              a.itemId,
                              a.Quantity,
                              a.itemName,
                              a.Precio,
                              a.Total
                          }
                );

            return Ok(new { bill, detail });
        }

        // POST: api/BillsApi
        public string Post([FromBody]Bills bill,int idCompany)
        {
            bool result;
            if (bill.idBill == 0)
            {
                result = _ibillsRepositorio.add(bill, idCompany);
            }
            else
            {
                result = _ibillsRepositorio.update(bill, idCompany);
            }

            return result ? "Succes" : "Error";
        }

        // PUT: api/BillsApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/BillsApi/5
        public string Delete(int idBill,int idCompany)
        {
            var result = _ibillsRepositorio.delete(idBill, idCompany);
            return result ? "Succes" : "Error";
        }
    }
}

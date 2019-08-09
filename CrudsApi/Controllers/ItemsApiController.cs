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
    public class ItemsApiController : ApiController
    {
        IItemsRepositorio _itemsRepositorio;

        public ItemsApiController()
        {
            _itemsRepositorio = new ItemsRepositorio();
        }


        // GET: api/ItemsApi
        public IEnumerable<Items> Get(int idCompany)
        {
            return _itemsRepositorio.find(idCompany);
        }

        // GET: api/ItemsApi/5
        public string Get(int id,int idCompany)
        {
            return "value";
        }

        // POST: api/ItemsApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ItemsApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ItemsApi/5
        public void Delete(int id)
        {
        }
    }
}

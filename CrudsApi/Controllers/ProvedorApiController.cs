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
    public class ProvedorApiController : ApiController
    {
        private IProvedorRepositorio _provedorRepositorio;

        public ProvedorApiController()
        {
            _provedorRepositorio = new ProvedorRepositorio();
        }

        // GET: api/ProvedorApi
        public IEnumerable<Provedor> Get(int idCompany)
        {
            return _provedorRepositorio.Find(idCompany);
        }

        // GET: api/ProvedorApi/5
        public string Get(int id,int idCompany)
        {
            return "value";
        }

        // POST: api/ProvedorApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/ProvedorApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ProvedorApi/5
        public void Delete(int id)
        {
        }
    }
}

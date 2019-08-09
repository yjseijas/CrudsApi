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
    public class TiposCuentasApiController : ApiController
    {
        ITiposCuentasRepositorio _iTiposCuentasRepositorio;

        TiposCuentasApiController()
        {
            _iTiposCuentasRepositorio = new TiposCuentasRepositorio();
        }

        // GET: api/TiposCuentasApi
        public IEnumerable<TiposCuentas> Get(int idCompany)
        {
            return _iTiposCuentasRepositorio.Find(idCompany);
        }

        // GET: api/TiposCuentasApi/5
        public string Get(int id,int idCompany)
        {
            return "value";
        }

        // POST: api/TiposCuentasApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/TiposCuentasApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/TiposCuentasApi/5
        public void Delete(int id)
        {
        }
    }
}

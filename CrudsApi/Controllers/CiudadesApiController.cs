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
    public class CiudadesApiController : ApiController
    {
        ICiudadesRepositorio _ciudadesRepositorio;

        // GET: api/CiudadesApi

        public CiudadesApiController()
        {
            _ciudadesRepositorio = new CiudadesRepositorio();
        }

        
        public IEnumerable<Ciudades> Get(int idCompany)
        {
            return _ciudadesRepositorio.GetCiudades(idCompany);
        }

        // GET: api/CiudadesApi/5
        public string Get(int id,int idCompany)
        {
            return "value";
        }

        // POST: api/CiudadesApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/CiudadesApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CiudadesApi/5
        public void Delete(int id)
        {
        }
    }
}

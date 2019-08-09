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
    public class BancosApiController : ApiController
    {
        private IBancosRepositorio _bancosRepositorio;

        public BancosApiController()
        {
            _bancosRepositorio = new BancosRepositorio();
        }

        // GET: api/Bancos
        public IEnumerable<Bancos> Get(int idCompany)
        {
            return _bancosRepositorio.Find(idCompany);
        }

        // GET: api/Bancos/5
        public IEnumerable<Bancos> Get(int idBanco, int idCompany)
        {
            return _bancosRepositorio.Find02(idBanco, idCompany);
        }

        // POST: api/Bancos
        public void Post([FromBody]Bancos banco,int idCompany)
        {
            _bancosRepositorio.addEdit(banco,idCompany);
        }

        // PUT: api/Bancos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Bancos/5
        public string Delete(int id, int idCompany)
        {
            var lResultado = _bancosRepositorio.delete(id,idCompany);
            var retorno = lResultado ? "Exitoso" : "DioError";
            return retorno;
        }
    }
}

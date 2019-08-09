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
    public class CuentasApiController : ApiController
    {
        ICuentasRepositorio _cuentasRepositorio;

        CuentasApiController()
        {
            _cuentasRepositorio = new CuentasRepositorio();
        }
        // GET: api/CuentasApi
        public IEnumerable<CuentasView> Get(int idCompany)
        {
            return _cuentasRepositorio.Find(idCompany);
        }

        // GET: api/CuentasApi/5    
        public IEnumerable<Cuentas> Get(int id,int idCompany)
        {
            return _cuentasRepositorio.Find02(id,idCompany);
        }

        // POST: api/CuentasApi
        public void Post([FromBody]Cuentas cuenta,int idCompany)
        {
            _cuentasRepositorio.addEdit(cuenta,idCompany);
        }

        // PUT: api/CuentasApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/CuentasApi/5
        public bool Delete(int idCuenta,int idCompany)
        {
            return _cuentasRepositorio.delete(idCuenta,idCompany);
        }
    }
}

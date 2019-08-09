using CrudsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrudsApi.DalHelper;

namespace CrudsApi.Controllers
{
    public class ClientesApiController : ApiController
    {
        IClientesRespositorio _clientesRepositorio;

        ClientesApiController()
        {
            _clientesRepositorio = new ClientesRespositorio();
        }
        // GET: api/ClientesApi
        public IEnumerable<ClientesView> Get(int idCompany)
        {
            return _clientesRepositorio.getClientes(idCompany);
        }

        // GET: api/ClientesApi/5
        public IEnumerable<ClientesView> Get(int idCliente,int idCompany)
        {
            return _clientesRepositorio.getCliente(idCliente,idCompany);
        }

        // POST: api/ClientesApi
        public bool Post([FromBody]Clientes clientes,int idCompany)
        {
            return _clientesRepositorio.addEdit(clientes,idCompany);
        }

        // PUT: api/ClientesApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/ClientesApi/5
        public void Delete(int idCliente,int idCompany)
        {
            _clientesRepositorio.delete(idCliente, idCompany);
        }
    }
}

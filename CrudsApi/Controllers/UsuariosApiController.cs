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
    public class UsuariosApiController : ApiController
    {
        IUsuariosRepositorio _usuariosRepositorio;

        public UsuariosApiController()
        {
            _usuariosRepositorio = new UsusariosRepositorio();
        }

        // GET: api/UsuariosApi
        public IEnumerable<Usuarios> Get(int idCompany)
        {
            return _usuariosRepositorio.Find(idCompany);
        }

        // GET: api/UsuariosApi/5
        public IEnumerable<Usuarios> Get(string nomUser,int idCompany)
        {
            return _usuariosRepositorio.Find02(nomUser,idCompany);
        }

        // POST: api/UsuariosApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/UsuariosApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/UsuariosApi/5
        public void Delete(int id)
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CrudsApi.DalHelper;
using CrudsApi.Models;

namespace CrudsApi.Controllers
{
    public class EmployeeApiController : ApiController
    {
        IEmployeeRepositorio _employeeRepositorio;

        public EmployeeApiController()
        {
            _employeeRepositorio = new EmployeeRepositorio();
        }
        // GET: api/EmployeeApi
        public IEnumerable<Employee> Get(int idCompany)
        {
            return _employeeRepositorio.Find(idCompany);
        }

        // GET: api/EmployeeApi/5
        public string Get(int id,int idCompany)
        {
            return "value";
        }

        // POST: api/EmployeeApi
        public bool Post([FromBody]Employee emp,int idCompany)
        {
            return _employeeRepositorio.addEdit(emp, idCompany);
        }

        // PUT: api/EmployeeApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/EmployeeApi/5
        public bool Delete(int idEmployee, int idCompany)
        {
            return _employeeRepositorio.delete(idEmployee,idCompany);
        }
    }
}

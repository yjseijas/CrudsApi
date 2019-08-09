using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudsApi.Models;

namespace CrudsApi.DalHelper
{
    public class EmployeeRepositorio : IEmployeeRepositorio
    {
        public bool addEdit(Employee emp, int idCompany)
        {
            return DalHelper.AddEditEmployee(emp,idCompany);
        }

        public bool delete(int idEmployee, int idCompany)
        {
            return DalHelper.deleteEmployee(idEmployee,idCompany);
        }

        public IEnumerable<Employee> Find(int idCompany)
        {
            return DalHelper.GetEmployees(idCompany);
        }

        public IEnumerable<Employee> Find02(int idBanco, int idCompany)
        {
            throw new NotImplementedException();
        }
    }
}
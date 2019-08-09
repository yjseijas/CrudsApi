using CrudsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrudsApi.DalHelper
{
    public interface IEmployeeRepositorio
    {
        IEnumerable<Employee> Find(int idCompany);
        IEnumerable<Employee> Find02(int idEmp, int idCompany);
        bool addEdit(Employee emp, int idCompany);
        bool delete(int idEmployee, int idCompany);
    }
}
using CrudsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudsApi.DalHelper
{
    public interface ICuentasRepositorio
    {
        IEnumerable<CuentasView> Find(int idCompany);
        IEnumerable<Cuentas> Find02(int idCuenta, int idCompany);
        bool addEdit(Cuentas cuenta, int idCompany);
        bool delete(int idCuenta, int idCompany);
    }
}

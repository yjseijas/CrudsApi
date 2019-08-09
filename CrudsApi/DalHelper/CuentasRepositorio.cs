using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudsApi.Models;

namespace CrudsApi.DalHelper
{
    public class CuentasRepositorio : ICuentasRepositorio
    {

        public bool addEdit(Cuentas cuenta, int idCompany)
        {
            return DalHelper.AddEditCuenta(cuenta,idCompany);
        }

        public bool delete(int idCuenta, int idCompany)
        {
            return DalHelper.deleteCuenta(idCuenta,idCompany);
        }

        public IEnumerable<CuentasView> Find(int idCompany)
        {
            return DalHelper.GetCuentas(idCompany);
        }

        public IEnumerable<Cuentas> Find02(int idCuenta, int idCompany)
        {
            return DalHelper.GetCuenta(idCuenta,idCompany);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudsApi.Models;

namespace CrudsApi.DalHelper
{
    public class TiposCuentasRepositorio : ITiposCuentasRepositorio
    {
        public bool addEdit(TiposCuentas tipoCuenta, int idTipo)
        {
            throw new NotImplementedException();
        }

        public bool delete(int idTipo, int idCompany)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TiposCuentas> Find(int idCompany)
        {
            return DalHelper.GetTipoCuentas(idCompany);
        }

        public IEnumerable<TiposCuentas> Find02(int idTipo, int idCompany)
        {
            throw new NotImplementedException();
        }
    }
}
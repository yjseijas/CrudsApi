using CrudsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudsApi.DalHelper
{
    public interface ITiposCuentasRepositorio
    {
        IEnumerable<TiposCuentas> Find(int idCompany);
        IEnumerable<TiposCuentas> Find02(int idTipo,int idCompany);
        bool addEdit(TiposCuentas tipoCuenta,int idTipo);
        bool delete(int idTipo,int idCompany);
    }
}

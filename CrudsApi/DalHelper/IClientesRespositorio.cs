using CrudsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudsApi.DalHelper
{
    public interface IClientesRespositorio
    {
        IEnumerable<ClientesView> getClientes(int idCompany);
        IEnumerable<ClientesView> getCliente(int idCliente, int idCompany);
        bool delete(int idCliente, int idCompany);
        bool addEdit(Clientes cliente, int idCompany);
    }
}

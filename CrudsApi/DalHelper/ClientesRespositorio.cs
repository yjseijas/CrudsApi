using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudsApi.Models;

namespace CrudsApi.DalHelper
{
    public class ClientesRespositorio : IClientesRespositorio
    {
        public bool addEdit(Clientes cliente, int idCompany)
        {
            return DalHelper.AddEditCliente(cliente,idCompany);
        }

        public bool delete(int idCliente, int idCompany)
        {
            return DalHelper.deleteCliente(idCliente,idCompany);
        }

        public IEnumerable<ClientesView> getCliente(int idCliente, int idCompany)
        {
            return DalHelper.getCliente(idCliente, idCompany);
        }

        public IEnumerable<ClientesView> getClientes(int idCompany)
        {
            return DalHelper.GetClientes(idCompany);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudsApi.Models;

namespace CrudsApi.DalHelper
{
    public class ProvedorRepositorio : IProvedorRepositorio
    {
        public IEnumerable<Provedor> Find(int idCompany)
        {
            return DalHelper.GetProvedores(idCompany);
        }
    }
}
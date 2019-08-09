using CrudsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudsApi.DalHelper
{
    public interface IProvedorRepositorio
    {
        IEnumerable<Provedor> Find(int idCompany);
    }
}

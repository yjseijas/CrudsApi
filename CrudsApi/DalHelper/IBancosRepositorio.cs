using CrudsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudsApi.DalHelper
{
    public interface IBancosRepositorio
    {
        IEnumerable<Bancos> Find(int idCompany);
        IEnumerable<Bancos> Find02(int idBanco, int idCompany);
        bool addEdit(Bancos banco,int idCompany);
        bool delete(int idBanco,int idCompany);
    }
}

using CrudsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudsApi.DalHelper
{
    public interface IUsuariosRepositorio
    {
        IEnumerable<Usuarios> Find(int idCompany);
        IEnumerable<Usuarios> Find02(string nomUser, int idCompany);
        bool addEdit(Usuarios user, int idCompany);
        bool delete(int idUser, int idCompany);
    }
}

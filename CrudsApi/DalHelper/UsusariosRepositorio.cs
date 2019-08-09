using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudsApi.Models;

namespace CrudsApi.DalHelper
{
    public class UsusariosRepositorio : IUsuariosRepositorio
    {
        public bool addEdit(Usuarios user, int idCompany)
        {
            throw new NotImplementedException();
        }

        public bool delete(int idUser, int idCompany)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Usuarios> Find(int idCompany)
        {
            return DalHelper.GetUsers(idCompany);
        }

        public IEnumerable<Usuarios> Find02(string nomUser, int idCompany)
        {
            return DalHelper.OneUser(nomUser,idCompany);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudsApi.Models;

namespace CrudsApi.DalHelper
{
    public class CiudadesRepositorio : ICiudadesRepositorio
    {
        public bool addEditCiudad(int idCiudad, int idCompany)
        {
            throw new NotImplementedException();
        }

        public bool deleteCiudad(int idCiudad, int idCompany)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ciudades> GetCiudad(int idCiudad, int idCompany)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Ciudades> GetCiudades(int idCompany)
        {
            return DalHelper.GetCiudades(idCompany);
        }
    }
}
using CrudsApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudsApi.DalHelper
{
    public interface ICiudadesRepositorio
    {
        IEnumerable<Ciudades> GetCiudades(int idCompany);
        IEnumerable<Ciudades> GetCiudad(int idCiudad, int idCompany);
        bool addEditCiudad(int idCiudad, int idCompany);
        bool deleteCiudad(int idCiudad, int idCompany);
    }
}

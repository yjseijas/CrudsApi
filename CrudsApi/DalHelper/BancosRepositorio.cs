using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudsApi.Models;

namespace CrudsApi.DalHelper
{
    public class BancosRepositorio : IBancosRepositorio
    {
        public bool addEdit(Bancos banco,int idCompany)
        {
            return DalHelper.AddEditBanco(banco,idCompany);
        }

        public bool delete(int idBanco,int idCompany)
        {
            return DalHelper.deleteBanco(idBanco,idCompany);
        }

        public IEnumerable<Bancos> Find(int idCompany)
        {
            return DalHelper.GetBancos(idCompany);
        }

        public IEnumerable<Bancos> Find02(int idBanco, int idCompany)
        {
            return DalHelper.Banco(idBanco,idCompany);
        }
    }
}
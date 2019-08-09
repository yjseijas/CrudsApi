using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CrudsApi.Models;

namespace CrudsApi.DalHelper
{
    public class ItemsRepositorio : IItemsRepositorio
    {
        public IEnumerable<Items> find(int idCompany)
        {
            return DalHelper.GetItems(idCompany);
        }
    }
}
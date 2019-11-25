using Library.Entities;
using System;
using System.Collections.Generic;

namespace Library.DalContracts
{
    public interface ICatalogueCartDao
    {
        bool Add(CatalogueCart cart);

        bool Delete(int id);

        bool Edit(int id);

        ICollection<CatalogueCart> GrtAll();

        CatalogueCart GetById(int id);
    }
}

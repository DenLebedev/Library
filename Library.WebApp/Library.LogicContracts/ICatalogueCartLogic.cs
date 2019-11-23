using Library.Entities;
using System;
using System.Collections.Generic;

namespace Library.LogicContracts
{
    public interface ICatalogueCartLogic
    {
        bool Add(CatalogueCart cart);

        bool Delete(int id);

        bool Edit(int id);

        ICollection<CatalogueCart> GrtAll();

        CatalogueCart GetById(int id);

    }
}

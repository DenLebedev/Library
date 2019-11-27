using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DalContracts
{
    public interface INewspaperNameDao
    {
        bool Add(NewspaperName name);

        bool Delete(int id);

        bool Edit(NewspaperName name);

        ICollection<NewspaperName> GetAll();

        NewspaperName GetById(int id);
    }
}

using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DalContracts
{
    public interface IAuthorDao
    {
        bool Add(Author author);

        bool Delete(int id);

        bool Edit(int id);

        ICollection<Author> GetAll();

        Author GetById(int id);
    }
}

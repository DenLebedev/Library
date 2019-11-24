using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.LogicContracts
{
    public interface IAuthorLogic
    {
        bool Add(Author author);

        bool Delete(int id);

        bool Edit(Author author);

        IEnumerable<Author> GetAll();

        Author GetById(int id);
    }
}

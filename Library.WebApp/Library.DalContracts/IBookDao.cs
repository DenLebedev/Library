using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DalContracts
{
    public interface IBookDao
    {
        bool Add(Book book);

        bool Delete(int id);

        bool Edit(Book book);

        ICollection<Book> GetAll();

        Book GetById(int id);
    }
}

using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.LogicContracts
{
    public interface IBookLogic
    {
        bool Add(Book book);

        bool Delete(int id);

        bool Edit(Book book);

        ICollection<Book> GetAll();

        Book GetById(int id);
    }
}

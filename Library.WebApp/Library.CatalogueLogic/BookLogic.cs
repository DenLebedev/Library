using Library.DalContracts;
using Library.Entities;
using Library.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.CatalogueLogic
{
    public class BookLogic : IBookLogic
    {
        private readonly IBookDao books;

        public BookLogic(IBookDao bookDao)
        {
            this.books = bookDao;
        }

        public bool Add(Book book)
        {
            return books.Add(book);
        }

        public bool Delete(int id)
        {
            return books.Delete(id);
        }

        public bool Edit(Book book)
        {
            return books.Edit(book);
        }

        public ICollection<Book> GetAll()
        {
            return books.GetAll().ToList();
        }

        public Book GetById(int id)
        {
            return books.GetById(id);
        }

        public ICollection<Book> GetTopTen()
        {
            return books.GetTopTen().ToList();
        }
    }
}

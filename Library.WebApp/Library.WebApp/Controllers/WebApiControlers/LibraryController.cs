using Library.Entities;
using Library.LogicContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library.WebApp.Controllers.WebApiControlers
{
    public class LibraryController : ApiController
    {
        private readonly IBookLogic books;

        public LibraryController(IBookLogic bookLogic)
        {
            this.books = bookLogic;
        }

        public LibraryController() { }

        public List<Book> GetAllBooks()
        {
            return books.GetAll().ToList();
        }

        public Book GetBook(int id)
        {
            return books.GetById(id);
        }

        public bool PostBook(Book book)
        {
            return books.Add(book);
        }

        public bool PutBook(Book book)
        {
            return books.Edit(book);
        }

        public bool DeleteBook(int id)
        {
            return books.Delete(id);
        }
    }
}

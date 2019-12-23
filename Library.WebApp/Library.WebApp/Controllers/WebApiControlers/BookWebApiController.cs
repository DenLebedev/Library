using AutoMapper;
using Library.Entities;
using Library.LogicContracts;
using Library.WebApp.Models.MapperProfile;
using Library.WebApp.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Library.WebApp.Controllers.WebApiControlers
{
    public class BookWebApiController : ApiController
    {
        private readonly IBookLogic books;
        private readonly MapperConfiguration config;
        private readonly IMapper mapper;

        public BookWebApiController(IBookLogic bookLogic)
        {
            this.books = bookLogic;
            config = new MapperConfiguration(cfg => {
                cfg.AddProfile<BookAutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        //public BookWebApiController() { }

        public IHttpActionResult GetAllBooks()
        {
            var model = mapper.Map<ICollection<IndexBookViewModel>>(books.GetAll());
            if (model.Count == 0)
            {
                return NotFound();
            }
            return Ok(model.ToList());
        }

        public Book GetBook(int id)
        {
            return books.GetById(id);
        }

        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid data.");

            if (!books.Add(book))
                return BadRequest("Invalid data.");            

            return Ok();
        }

        public bool PutBook(Book book)
        {
            return books.Edit(book);
        }

        public IHttpActionResult DeleteBook(int id)
        {
            if (id <= 0)
                return BadRequest("Not a valid Book id");
            books.Delete(id);
            return Ok();                
        }
    }
}

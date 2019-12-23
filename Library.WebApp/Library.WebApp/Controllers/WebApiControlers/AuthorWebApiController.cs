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
    public class AuthorWebApiController : ApiController
    {
        private readonly IAuthorLogic authors;
        private readonly MapperConfiguration config;
        private readonly IMapper mapper;

        public AuthorWebApiController(IAuthorLogic authorLogic)
        {
            this.authors = authorLogic;
            config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AuthorAutoMapperProfile>();
            });
            mapper = config.CreateMapper();
        }

        public IHttpActionResult GetAllAuthors()
        {
            var model = mapper.Map<ICollection<IndexAuthorViewModel>>(authors.GetAll());
            if (model.Count == 0)
            {
                return NotFound();
            }
            return Ok(model.ToList());
        }

        public Author GetAuthor(int id)
        {
            return authors.GetById(id);
        }

        public bool PostAuthor(Author author)
        {
            return authors.Add(author);
        }

        public bool PutAuthor(Author author)
        {
            return authors.Edit(author);
        }

        public bool DeleteAuthor(int id)
        {
            return authors.Delete(id);
        }
    }
}

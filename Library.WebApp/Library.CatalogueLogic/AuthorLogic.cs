using Library.Entities;
using Library.LogicContracts;
using Library.DalContracts;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Library.LogicValidation;

namespace Library.CatalogueLogic
{
    public class AuthorLogic : IAuthorLogic
    {
        private readonly IAuthorDao authors;
        readonly AuthorValidation  validation = new AuthorValidation();

        public AuthorLogic(IAuthorDao authorDao)
        {
            this.authors = authorDao;
        }

        public bool Add(Author author)
        {            
            validation.Validate(author);
            return authors.Add(author);
        }

        public bool Delete(int id)
        {
            return authors.Delete(id);
        }

        public bool Edit(Author author)
        {
            return authors.Edit(author);
        }

        public ICollection<Author> GetAll()
        {
            return authors.GetAll().ToList();
        }

        public Author GetById(int id)
        {
            return authors.GetById(id);
        }
    }
}

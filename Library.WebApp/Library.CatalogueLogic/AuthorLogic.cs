using Library.Entities;
using Library.LogicContracts;
using Library.DalContracts;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;

namespace Library.CatalogueLogic
{
    public class AuthorLogic : IAuthorLogic
    {
        private readonly IAuthorDao authors;

        public AuthorLogic(IAuthorDao authorDao)
        {
            this.authors = authorDao;
        }

        public bool Add(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException(nameof(author));
            }

            if (string.IsNullOrWhiteSpace(author.Name))
            {
                throw new ArgumentException("Name");
            }

            if (string.IsNullOrWhiteSpace(author.Surname))
            {
                throw new ArgumentException("Surname");
            }

            return authors.Add(author);
        }

        public bool Delete(int id)
        {
            return authors.Delete(id);
        }

        public bool Edit(Author author)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Author> GetAll()
        {
            return authors.GetAll().ToList();
        }

        public Author GetById(int id)
        {
            return authors.GetById(id);
        }
    }
}

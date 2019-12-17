using Library.Entities;
using Library.LogicContracts;
using Library.LogicContracts.ValidationLogicContracts;
using Library.DalContracts;
using System;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using NLog;

namespace Library.CatalogueLogic
{
    public class AuthorLogic : IAuthorLogic
    {
        private readonly IAuthorDao authors;
        private readonly IAuthorValidationLogic validation;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public AuthorLogic(IAuthorDao authorDao, IAuthorValidationLogic authorValidation)
        {
            this.authors = authorDao;
            this.validation = authorValidation;
        }

        public bool Add(Author author)
        {
            if (validation.Validate(author).Count > 0)
            {
                foreach (var res in validation.Validate(author))
                {
                    if (res.IsValidate)
                    {
                        logger.Error(res.ValidationMessage.ToString());
                    }
                }
            }
            return authors.Add(author);
        }

        public bool Delete(int id)
        {
            return authors.Delete(id);
        }

        public bool Edit(Author author)
        {
            if (validation.Validate(author).Count > 0)
            {
                foreach (var res in validation.Validate(author))
                {
                    if (res.IsValidate)
                    {
                        logger.Error(res.ValidationMessage.ToString());
                    }
                }
            }
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

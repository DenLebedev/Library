using Library.DalContracts;
using Library.Entities;
using Library.LogicContracts;
using Library.LogicContracts.ValidationLogicContracts;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.CatalogueLogic
{
    public class BookLogic : IBookLogic
    {
        private readonly IBookDao books;
        private readonly IBookValidationLogic validation;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public BookLogic(IBookDao bookDao, IBookValidationLogic bookValidation)
        {
            this.books = bookDao;
            this.validation = bookValidation;
        }

        public bool Add(Book book)
        {
            if (validation.Validate(book).Count > 0)
            {
                foreach (var res in validation.Validate(book))
                {
                    if (res.IsValidate)
                    {
                        logger.Error(res.ValidationMessage.ToString());
                    }
                }
            }
            return books.Add(book);
        }

        public bool Delete(int id)
        {
            return books.Delete(id);
        }

        public bool Edit(Book book)
        {
            List<ValidationResult> validationResults = validation.Validate(book);
            if (validationResults.Count > 0)
            {
                foreach (var res in validationResults)
                {
                    if (res.IsValidate)
                    {
                        logger.Error(res.ValidationMessage.ToString());
                    }
                }
            }
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

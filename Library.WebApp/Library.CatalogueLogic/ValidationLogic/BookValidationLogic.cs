using Library.Entities;
using Library.LogicContracts.ValidationLogicContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.CatalogueLogic.ValidationLogic
{
    public class BookValidationLogic : IBookValidationLogic
    {
        public List<ValidationResult> Validate(Book book)
        {
            List<ValidationResult> results = new List<ValidationResult>();

            if (book == null)
            {
                results.Add(new ValidationResult(true, new ArgumentNullException(nameof(book)).Message.ToString()));
            }

            if (string.IsNullOrWhiteSpace(book.Name))
            {
                results.Add(new ValidationResult(true, new ArgumentException("Name").Message.ToString()));
            }

            if (book.Author == null)
            {
                results.Add(new ValidationResult(true, new ArgumentNullException(nameof(book.Author)).Message.ToString()));
            }

            if (book.City == null)
            {
                results.Add(new ValidationResult(true, new ArgumentNullException(nameof(book.City)).Message.ToString()));
            }

            if (book.Publishing == null)
            {
                results.Add(new ValidationResult(true, new ArgumentNullException(nameof(book.Publishing)).Message.ToString()));
            }

            if (book.PageCount <= 0)
            {
                results.Add(new ValidationResult(true, new ArgumentException("PageCount").Message.ToString()));
            }

            if (book.YearPublication > DateTime.UtcNow.Year)
            {
                results.Add(new ValidationResult(true, new ArgumentException("YearPublication more than Now").Message.ToString()));
            }

            return results;
        }
    }
}

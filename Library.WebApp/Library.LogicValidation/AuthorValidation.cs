using Library.Entities;
using System;

namespace Library.LogicValidation
{
    public class AuthorValidation
    {
        public void Validate(Author author)
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
        }
    }
}

using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DalContracts
{
    public interface IPublishingDao
    {
        bool Add(Publishing publishing);

        bool Delete(int id);

        bool Edit(Publishing publishing);

        ICollection<Publishing> GetAll();

        Publishing GetById(int id);
    }
}

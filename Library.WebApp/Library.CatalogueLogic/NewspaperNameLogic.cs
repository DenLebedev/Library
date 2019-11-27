using Library.DalContracts;
using Library.Entities;
using Library.LogicContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.CatalogueLogic
{
    public class NewspaperNameLogic : INewspaperNameLogic
    {
        private readonly INewspaperNameDao nameDao;

        public NewspaperNameLogic(INewspaperNameDao nameDao)
        {
            this.nameDao = nameDao;
        }

        public bool Add(NewspaperName name)
        {
            return nameDao.Add(name);
        }

        public bool Delete(int id)
        {
            return nameDao.Delete(id);
        }

        public bool Edit(NewspaperName name)
        {
            return nameDao.Edit(name);
        }

        public ICollection<NewspaperName> GetAll()
        {
            return nameDao.GetAll();
        }

        public NewspaperName GetById(int id)
        {
            return nameDao.GetById(id);
        }
    }
}

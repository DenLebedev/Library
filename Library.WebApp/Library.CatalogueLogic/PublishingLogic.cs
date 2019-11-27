using Library.DalContracts;
using Library.Entities;
using Library.LogicContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.CatalogueLogic
{
    public class PublishingLogic : IPublishingLogic
    {
        private readonly IPublishingDao publishingDao;

        public PublishingLogic(IPublishingDao publishingDao)
        {
            this.publishingDao = publishingDao;
        }

        public bool Add(Publishing publishing)
        {
            return publishingDao.Add(publishing);
        }

        public bool Delete(int id)
        {
            return publishingDao.Delete(id);
        }

        public bool Edit(Publishing publishing)
        {
            return publishingDao.Edit(publishing);
        }

        public ICollection<Publishing> GetAll()
        {
            return publishingDao.GetAll();
        }

        public Publishing GetById(int id)
        {
            return publishingDao.GetById(id);
        }
    }
}

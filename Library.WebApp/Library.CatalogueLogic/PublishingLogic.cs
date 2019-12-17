using Library.DalContracts;
using Library.Entities;
using Library.LogicContracts;
using Library.LogicContracts.ValidationLogicContracts;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.CatalogueLogic
{
    public class PublishingLogic : IPublishingLogic
    {
        private readonly IPublishingDao publishingDao;
        private readonly IPublishingValidationLogic validation;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public PublishingLogic(IPublishingDao publishingDao, IPublishingValidationLogic publishingValidation)
        {
            this.publishingDao = publishingDao;
            this.validation = publishingValidation;
        }

        public bool Add(Publishing publishing)
        {
            if (validation.Validate(publishing).Count > 0)
            {
                foreach (var res in validation.Validate(publishing))
                {
                    if (res.IsValidate)
                    {
                        logger.Error(res.ValidationMessage.ToString());
                    }
                }
            }
            return publishingDao.Add(publishing);
        }

        public bool Delete(int id)
        {
            return publishingDao.Delete(id);
        }

        public bool Edit(Publishing publishing)
        {
            if (validation.Validate(publishing).Count > 0)
            {
                foreach (var res in validation.Validate(publishing))
                {
                    if (res.IsValidate)
                    {
                        logger.Error(res.ValidationMessage.ToString());
                    }
                }
            }
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

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
    public class NewspaperNameLogic : INewspaperNameLogic
    {
        private readonly INewspaperNameDao nameDao;
        private readonly INewspaperNameValidationLogic validation;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public NewspaperNameLogic(INewspaperNameDao nameDao, INewspaperNameValidationLogic newspaperNameValidation)
        {
            this.nameDao = nameDao;
            this.validation = newspaperNameValidation;
        }

        public bool Add(NewspaperName name)
        {
            if (validation.Validate(name).Count > 0)
            {
                foreach (var res in validation.Validate(name))
                {
                    if (res.IsValidate)
                    {
                        logger.Error(res.ValidationMessage.ToString());
                    }
                }
            }
            return nameDao.Add(name);
        }

        public bool Delete(int id)
        {
            return nameDao.Delete(id);
        }

        public bool Edit(NewspaperName name)
        {
            if (validation.Validate(name).Count > 0)
            {
                foreach (var res in validation.Validate(name))
                {
                    if (res.IsValidate)
                    {
                        logger.Error(res.ValidationMessage.ToString());
                    }
                }
            }
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

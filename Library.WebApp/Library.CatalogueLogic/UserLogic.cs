using Library.DalContracts;
using Library.Entities;
using Library.LogicContracts;
using NLog;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.CatalogueLogic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao userDao;
        private readonly IUserValidationLogic validation;
        private static Logger logger = LogManager.GetCurrentClassLogger();

        public UserLogic(IUserDao userDao, IUserValidationLogic validationLogic)
        {
            this.userDao = userDao;
            this.validation = validationLogic;
        }

        public bool Add(User user)
        {
            if (validation.Validate(user).Count > 0)
            {
                foreach (var res in validation.Validate(user))
                {
                    if (res.IsValidate)
                    {
                        logger.Error(res.ValidationMessage.ToString());
                    }
                }
            }
            return userDao.Add(user);
        }

        public bool Delete(int id)
        {
            return userDao.Delete(id);
        }

        public bool Edit(User user)
        {
            return userDao.Edit(user);
        }

        public ICollection<User> GetAll()
        {
            return userDao.GetAll();
        }

        public User GetById(int id)
        {
            return userDao.GetById(id);
        }

        public User GetByName(string name)
        {
            return userDao.GetByName(name);
        }

        public bool Login(User user)
        {
            return userDao.Login(user);
        }
    }
}

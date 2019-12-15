using Library.DalContracts;
using Library.Entities;
using Library.LogicContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.CatalogueLogic
{
    public class UserLogic : IUserLogic
    {
        private readonly IUserDao userDao;

        public UserLogic(IUserDao userDao)
        {
            this.userDao = userDao;
        }

        public bool Add(User user)
        {
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

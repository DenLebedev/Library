using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DalContracts
{
    public interface IUserDao
    {
        bool Add(User user);

        bool Delete(int id);

        bool Edit(User user);

        ICollection<User> GetAll();

        User GetById(int id);

        bool Login(User user);

        User GetByName(string name);
    }
}

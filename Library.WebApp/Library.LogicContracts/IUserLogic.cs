using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Library.Entities;

namespace Library.LogicContracts
{
    public interface IUserLogic
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
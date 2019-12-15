using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.DalContracts
{
    public interface IUserRoleDao
    {
        ICollection<UserRole> GetAll();
    }
}

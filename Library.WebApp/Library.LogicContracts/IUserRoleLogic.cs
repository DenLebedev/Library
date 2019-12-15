using Library.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.LogicContracts
{
    public interface IUserRoleLogic
    {
        ICollection<UserRole> GetAll();
    }
}

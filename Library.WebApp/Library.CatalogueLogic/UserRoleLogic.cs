using Library.DalContracts;
using Library.Entities;
using Library.LogicContracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.CatalogueLogic
{
    public class UserRoleLogic : IUserRoleLogic
    {
        private readonly IUserRoleDao role;

        public UserRoleLogic(IUserRoleDao userRole)
        {
            this.role = userRole;
        }

        public ICollection<UserRole> GetAll()
        {
            return role.GetAll();
        }
    }
}

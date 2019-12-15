using Library.Entities;
using Library.LogicContracts;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Library.WebApp.Models
{
    public class LibraryAppRoleProvider : RoleProvider
    {
        private IUserLogic userLogic;

        [Inject]
        public void UserLogic(IUserLogic userLogic)
        {
            this.userLogic = userLogic;
        }

        public override string[] GetRolesForUser(string username)
        {
            string[] roles = new string[] { };
            try
            {
                User user = userLogic.GetByName(username);
                if (user != null && user.RoleName != null)
                {
                    roles = new string[] { user.RoleName };
                }
            }
            catch
            {

            }
            return roles;
        }
        public override bool IsUserInRole(string username, string roleName)
        {
            bool isInRole = false;
            try
            {
                User user = userLogic.GetByName(username);
                if (user != null && user.RoleName != null && user.RoleName == roleName)
                {
                    isInRole = true;
                }
            }
            catch
            {

            }
            return isInRole;
        }

        #region NotImplementedSection

        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        } 

        #endregion

    }
}
using Library.DalContracts;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Library.SqlDal
{
    public class UserRoleDao : IUserRoleDao
    {
        SqlDalConfig config;

        public UserRoleDao(SqlDalConfig config)
        {
            this.config = config;
        }

        public ICollection<UserRole> GetAll()
        {
            using (var con = new SqlConnection(config.ConnectionString))
            {
                using (var cmnd = new SqlCommand("user_roles_get_all", con))
                {
                    cmnd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    using (var reader = cmnd.ExecuteReader())
                    {
                        var userRoles = new List<UserRole>();
                        while (reader.Read())
                        {
                            var userRole = new UserRole();
                            userRole.Id = (int)reader["id"];
                            userRole.Name = (string)reader["role_name"];
                            userRoles.Add(userRole);
                        }
                        return userRoles;
                    }
                }
            }
        }
    }
}

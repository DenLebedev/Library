using Library.DalContracts;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Library.SqlDal
{
    public class UserDao : IUserDao
    {
        SqlDalConfig config;

        public UserDao(SqlDalConfig config)
        {
            this.config = config;
        }

        public bool Add(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            if (user.Name == null || user.Name.Length > 50)
            {
                throw new ArgumentException("User Name");
            }

            try
            {
                using (var con = new SqlConnection(config.ConnectionString))
                {
                    using (var cmnd = new SqlCommand("user_add", con))
                    {
                        cmnd.CommandType = CommandType.StoredProcedure;
                        cmnd.Parameters.AddWithValue("@name", user.Name);
                        cmnd.Parameters.AddWithValue("@password", user.Password);

                        cmnd.Parameters.Add("@id", SqlDbType.Int, 4);
                        cmnd.Parameters["@id"].Direction = ParameterDirection.Output;
                        con.Open();
                        cmnd.ExecuteNonQuery();
                        int? id = cmnd.Parameters["@id"].Value as int?;
                        if (id != null)
                        {
                            user.Id = (int)cmnd.Parameters["@id"].Value;
                            return true;
                        }
                        else
                        {
                            return false;
                        }                        
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var con = new SqlConnection(config.ConnectionString))
                {
                    using (var cmnd = new SqlCommand("user_delete", con))
                    {
                        cmnd.CommandType = CommandType.StoredProcedure;
                        cmnd.Parameters.AddWithValue("@id", id);
                        con.Open();
                        cmnd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public bool Edit(User user)
        {
            try
            {
                using (var con = new SqlConnection(config.ConnectionString))
                {
                    using (var cmnd = new SqlCommand("user_edit", con))
                    {
                        cmnd.CommandType = CommandType.StoredProcedure;
                        cmnd.Parameters.AddWithValue("@id", user.Id);
                        cmnd.Parameters.AddWithValue("@name", user.Name);
                        cmnd.Parameters.AddWithValue("@role_id", user.RoleId);
                        con.Open();
                        cmnd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        public ICollection<User> GetAll()
        {
            using (var con = new SqlConnection(config.ConnectionString))
            {
                using (var cmnd = new SqlCommand("users_get_all", con))
                {
                    cmnd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    using (var reader = cmnd.ExecuteReader())
                    {
                        var users = new List<User>();
                        while (reader.Read())
                        {
                            var user = new User();
                            user.Id = (int)reader["id"];
                            user.Name = (string)reader["name"];
                            user.RoleId = (int)reader["role_id"];
                            user.RoleName = (string)reader["role"];
                            users.Add(user);
                        }
                        return users;
                    }
                }
            }
        }

        public User GetById(int id)
        {
            using (var con = new SqlConnection(config.ConnectionString))
            {
                using (var cmnd = new SqlCommand("user_get_by_id", con))
                {
                    cmnd.CommandType = CommandType.StoredProcedure;
                    cmnd.Parameters.AddWithValue("@id", id);
                    con.Open();

                    using (var reader = cmnd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Id = (int)reader["id"],
                                Name = (string)reader["username"],
                                RoleId = (int)reader["role_id"],
                                RoleName = (string)reader["role_name"],
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public User GetByName(string name)
        {
            using (var con = new SqlConnection(config.ConnectionString))
            {
                using (var cmnd = new SqlCommand("user_get_by_name", con))
                {
                    cmnd.CommandType = CommandType.StoredProcedure;
                    cmnd.Parameters.AddWithValue("@name", name);
                    con.Open();

                    using (var reader = cmnd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new User
                            {
                                Name = (string)reader["name"],
                                RoleName = (string)reader["role_name"],
                            };
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        public bool Login(User user)
        {
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            if (user.Name == null || user.Name.Length > 50)
            {
                throw new ArgumentException("User Name");
            }

            try
            {
                using (var con = new SqlConnection(config.ConnectionString))
                {
                    using (var cmnd = new SqlCommand("user_login", con))
                    {
                        cmnd.CommandType = CommandType.StoredProcedure;
                        cmnd.Parameters.AddWithValue("@name", user.Name);
                        cmnd.Parameters.AddWithValue("@password", user.Password);

                        cmnd.Parameters.Add("@id", SqlDbType.Int, 4);
                        cmnd.Parameters.Add("@role_name", SqlDbType.NVarChar, 50);
                        cmnd.Parameters.Add("@role_id", SqlDbType.Int, 4);
                        cmnd.Parameters["@id"].Direction = ParameterDirection.Output;
                        cmnd.Parameters["@role_name"].Direction = ParameterDirection.Output;
                        cmnd.Parameters["@role_id"].Direction = ParameterDirection.Output;
                        con.Open();
                        cmnd.ExecuteNonQuery();
                        int? id = cmnd.Parameters["@id"].Value as int?;
                        if (id != null)
                        {
                            user.Id = (int)cmnd.Parameters["@id"].Value;
                            user.RoleName = (string)cmnd.Parameters["@role_name"].Value;
                            user.RoleId = (int)cmnd.Parameters["@role_id"].Value;
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }
    }
}

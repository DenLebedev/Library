using Library.DalContracts;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Library.SqlDal
{
    public class NewspaperNameDao : INewspaperNameDao
    {
        SqlDalConfig config;

        public NewspaperNameDao(SqlDalConfig config)
        {
            this.config = config;
        }

        public bool Add(NewspaperName newspaper)
        {
            if (newspaper == null)
            {
                throw new ArgumentNullException();
            }

            if (newspaper.Name == null || newspaper.Name.Length > 300)
            {
                throw new ArgumentException("NewspaperName Name");
            }

            try
            {
                using (var con = new SqlConnection(config.ConnectionString))
                {
                    using (var cmnd = new SqlCommand("newspaper_name_add", con))
                    {
                        cmnd.CommandType = CommandType.StoredProcedure;
                        cmnd.Parameters.AddWithValue("@name", newspaper.Name);
                        cmnd.Parameters.Add("@id", SqlDbType.Int, 4);
                        cmnd.Parameters["@id"].Direction = ParameterDirection.Output;
                        con.Open();
                        cmnd.ExecuteNonQuery();
                        int? id = cmnd.Parameters["@id"].Value as int?;
                        if (id != null)
                        {
                            newspaper.Id = (int)cmnd.Parameters["@id"].Value;
                        }
                        return true;
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
                    using (var cmnd = new SqlCommand("newspaper_name_delete", con))
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

        public bool Edit(NewspaperName newspaper)
        {
            try
            {
                using (var con = new SqlConnection(config.ConnectionString))
                {
                    using (var cmnd = new SqlCommand("newspaper_name_edite", con))
                    {
                        cmnd.CommandType = CommandType.StoredProcedure;
                        cmnd.Parameters.AddWithValue("@name", newspaper.Name);
                        cmnd.Parameters.AddWithValue("@id", newspaper.Id);
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

        public ICollection<NewspaperName> GetAll()
        {
            using (var con = new SqlConnection(config.ConnectionString))
            {
                using (var cmnd = new SqlCommand("newspapers_names_get_all", con))
                {
                    cmnd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    using (var reader = cmnd.ExecuteReader())
                    {
                        var newspapersNames = new List<NewspaperName>();
                        while (reader.Read())
                        {
                            var newspaper = new NewspaperName();
                            newspaper.Id = (int)reader["id"];
                            newspaper.Name = (string)reader["name"];
                            newspapersNames.Add(newspaper);
                        }
                        return newspapersNames;
                    }
                }
            }
        }

        public NewspaperName GetById(int id)
        {
            using (var con = new SqlConnection(config.ConnectionString))
            {
                using (var cmnd = new SqlCommand("newspaper_name_get_by_id", con))
                {
                    cmnd.CommandType = CommandType.StoredProcedure;
                    cmnd.Parameters.AddWithValue("@id", id);
                    con.Open();

                    using (var reader = cmnd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new NewspaperName
                            {
                                Id = (int)reader["id"],
                                Name = (string)reader["name"],
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
    }
}

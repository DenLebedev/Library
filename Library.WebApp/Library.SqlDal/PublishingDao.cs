using Library.DalContracts;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Library.SqlDal
{
    public class PublishingDao : IPublishingDao
    {
        SqlDalConfig config;

        public PublishingDao(SqlDalConfig config)
        {
            this.config = config;
        } 

        public bool Add(Publishing publishing)
        {
            if (publishing == null)
            {
                throw new ArgumentNullException();
            }

            if (publishing.Name == null || publishing.Name.Length > 300)
            {
                throw new ArgumentException("Publishing Name");
            }

            try
            {
                using (var con = new SqlConnection(config.ConnectionString))
                {
                    using (var cmnd = new SqlCommand("publishing_add", con))
                    {
                        cmnd.CommandType = CommandType.StoredProcedure;
                        cmnd.Parameters.AddWithValue("@name", publishing.Name);
                        cmnd.Parameters.Add("@id", SqlDbType.Int, 4);
                        cmnd.Parameters["@id"].Direction = ParameterDirection.Output;
                        con.Open();
                        cmnd.ExecuteNonQuery();
                        int? id = cmnd.Parameters["@id"].Value as int?;
                        if (id != null)
                        {
                            publishing.Id = (int)cmnd.Parameters["@id"].Value;
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
                    using (var cmnd = new SqlCommand("publishing_delete", con))
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

        public bool Edit(Publishing publishing)
        {
            try
            {
                using (var con = new SqlConnection(config.ConnectionString))
                {
                    using (var cmnd = new SqlCommand("publishing_edite", con))
                    {
                        cmnd.CommandType = CommandType.StoredProcedure;
                        cmnd.Parameters.AddWithValue("@name", publishing.Name);
                        cmnd.Parameters.AddWithValue("@id", publishing.Id);
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

        public ICollection<Publishing> GetAll()
        {
            using (var con = new SqlConnection(config.ConnectionString))
            {
                using (var cmnd = new SqlCommand("publishing_get_all", con))
                {
                    cmnd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    using (var reader = cmnd.ExecuteReader())
                    {
                        var publishings = new List<Publishing>();
                        while (reader.Read())
                        {
                            var publishing = new Publishing();
                            publishing.Id = (int)reader["id"];
                            publishing.Name = (string)reader["name"];
                            publishings.Add(publishing);
                        }
                        return publishings;
                    }
                }
            }
        }

        public Publishing GetById(int id)
        {
            using (var con = new SqlConnection(config.ConnectionString))
            {
                using (var cmnd = new SqlCommand("publishing_get_by_id", con))
                {
                    cmnd.CommandType = CommandType.StoredProcedure;
                    cmnd.Parameters.AddWithValue("@id", id);
                    con.Open();

                    using (var reader = cmnd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new Publishing
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

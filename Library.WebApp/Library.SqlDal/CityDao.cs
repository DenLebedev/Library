using Library.DalContracts;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Library.SqlDal
{
    public class CityDao : ICityDao
    {
        SqlDalConfig config;

        public CityDao(SqlDalConfig config)
        {
            this.config = config;
        }

        public bool Add(City city)
        {
            if (city == null)
            {
                throw new ArgumentNullException();
            }

            if (city.Name == null || city.Name.Length > 200)
            {
                throw new ArgumentException("City Name");
            }

            try
            {
                using (var con = new SqlConnection(config.ConnectionString))
                {
                    using (var cmnd = new SqlCommand("city_add", con))
                    {
                        cmnd.CommandType = CommandType.StoredProcedure;
                        cmnd.Parameters.AddWithValue("@name", city.Name);
                        cmnd.Parameters.Add("@id", SqlDbType.Int, 4);
                        cmnd.Parameters["@id"].Direction = ParameterDirection.Output;
                        con.Open();
                        cmnd.ExecuteNonQuery();
                        int? id = cmnd.Parameters["@id"].Value as int?;
                        if (id != null)
                        {
                            city.Id = (int)cmnd.Parameters["@id"].Value;
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
                    using (var cmnd = new SqlCommand("city_delete", con))
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

        public bool Edit(City city)
        {
            try
            {
                using (var con = new SqlConnection(config.ConnectionString))
                {
                    using (var cmnd = new SqlCommand("city_edite", con))
                    {
                        cmnd.CommandType = CommandType.StoredProcedure;
                        cmnd.Parameters.AddWithValue("@name", city.Name);
                        cmnd.Parameters.AddWithValue("@id", city.Id);
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

        public ICollection<City> GetAll()
        {
            using (var con = new SqlConnection(config.ConnectionString))
            {
                using (var cmnd = new SqlCommand("cities_get_all", con))
                {
                    cmnd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    using (var reader = cmnd.ExecuteReader())
                    {
                        var cities = new List<City>();
                        while (reader.Read())
                        {
                            var city = new City();
                            city.Id = (int)reader["id"];
                            city.Name = (string)reader["name"];
                            cities.Add(city);
                        }
                        return cities;
                    }
                }
            }
        }

        public City GetById(int id)
        {
            using (var con = new SqlConnection(config.ConnectionString))
            {
                using (var cmnd = new SqlCommand("city_get_by_id", con))
                {
                    cmnd.CommandType = CommandType.StoredProcedure;
                    cmnd.Parameters.AddWithValue("@id", id);
                    con.Open();

                    using (var reader = cmnd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new City
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

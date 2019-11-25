using Library.DalContracts;
using Library.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Library.SqlDal
{
    public class AuthorDao : IAuthorDao
    {
        SqlDalConfig config;

        public AuthorDao(SqlDalConfig config)
        {
            this.config = config;
        }

        public bool Add(Author author)
        {
            if (author == null)
            {
                throw new ArgumentNullException();
            }

            if (author.Name == null || author.Name.Length > 50)
            {
                throw new ArgumentException("Author Name");
            }

            if (author.Surname == null || author.Surname.Length > 200)
            {
                throw new ArgumentException("Author Lastname");
            }

            try
            {
                using (var con = new SqlConnection(config.ConnectionString))
                {
                    var cmnd = new SqlCommand("add_author", con);
                    cmnd.CommandType = CommandType.StoredProcedure;
                    cmnd.Parameters.AddWithValue("@name", author.Name);
                    cmnd.Parameters.AddWithValue("@surname", author.Surname);
                    cmnd.Parameters.Add("@id", SqlDbType.Int, 4);
                    cmnd.Parameters["@id"].Direction = ParameterDirection.Output;
                    con.Open();
                    cmnd.ExecuteNonQuery();
                    author.Id = (int)cmnd.Parameters["@id"].Value;
                    return true;
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
                    var cmnd = new SqlCommand("delete_author", con);
                    cmnd.CommandType = CommandType.StoredProcedure;
                    cmnd.Parameters.AddWithValue("@id", id);
                    con.Open();
                    cmnd.ExecuteNonQuery();
                    return true;
                }
            }
            catch
            {
                return false;
            }
        }

        public IEnumerable<Author> GetAll()
        {
            using (var con = new SqlConnection(config.ConnectionString))
            {
                var cmnd = new SqlCommand("get_all_authors", con);
                cmnd.CommandType = CommandType.StoredProcedure;
                con.Open();

                var reader = cmnd.ExecuteReader();
                while (reader.Read())
                {
                    yield return new Author
                    {
                        Id = (int)reader["id"],
                        Name = (string)reader["name"],
                        Surname = (string)reader["surname"],
                    };
                }
            }
        }

        public Author GetById(int id)
        {
            using (var con = new SqlConnection(config.ConnectionString))
            {
                var cmnd = new SqlCommand("get_by_id", con);
                cmnd.CommandType = CommandType.StoredProcedure;
                cmnd.Parameters.AddWithValue("@id", id);
                con.Open();

                var reader = cmnd.ExecuteReader();
                if (reader.Read())
                {
                    return new Author
                    {
                        Id = (int)reader["id"],
                        Name = (string)reader["name"],
                        Surname = (string)reader["surname"],
                    };
                }
                else
                {
                    return null;
                }
            }
        }

        public bool Edit(Author author)
        {
            try
            {
                using (var con = new SqlConnection(config.ConnectionString))
                {
                    var cmnd = new SqlCommand("edite_author", con);
                    cmnd.CommandType = CommandType.StoredProcedure;
                    cmnd.Parameters.AddWithValue("@name", author.Name);
                    cmnd.Parameters.AddWithValue("@surname", author.Surname);
                    cmnd.Parameters.AddWithValue("@id", author.Id);

                    con.Open();
                    cmnd.ExecuteNonQuery();

                    return true;
                }
            }
            catch
            {
                return false;
            }            
        }
    }
}

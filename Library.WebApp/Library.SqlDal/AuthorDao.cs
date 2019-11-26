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
                    using (var cmnd = new SqlCommand("author_add", con))
                    {
                        cmnd.CommandType = CommandType.StoredProcedure;
                        cmnd.Parameters.AddWithValue("@name", author.Name);
                        cmnd.Parameters.AddWithValue("@surname", author.Surname);
                        cmnd.Parameters.Add("@id", SqlDbType.Int, 4);
                        cmnd.Parameters["@id"].Direction = ParameterDirection.Output;
                        con.Open();
                        cmnd.ExecuteNonQuery();
                        int? id = cmnd.Parameters["@id"].Value as int?;
                        if (id != null)
                        {
                            author.Id = (int)cmnd.Parameters["@id"].Value;
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
                    using (var cmnd = new SqlCommand("author_delete", con))
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

        public ICollection<Author> GetAll()
        {
            using (var con = new SqlConnection(config.ConnectionString))
            {
                using (var cmnd = new SqlCommand("authors_get_all", con))
                {
                    cmnd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    using (var reader = cmnd.ExecuteReader())
                    {
                        var authors = new List<Author>();
                        while (reader.Read())
                        {
                            var author = new Author();
                            author.Id = (int)reader["id"];
                            author.Name = (string)reader["name"];
                            author.Surname = (string)reader["surname"];
                            authors.Add(author);
                        }
                        return authors;
                    }
                }
            }
        }

        public Author GetById(int id)
        {
            using (var con = new SqlConnection(config.ConnectionString))
            {
                using (var cmnd = new SqlCommand("author_get_by_id", con))
                {
                    cmnd.CommandType = CommandType.StoredProcedure;
                    cmnd.Parameters.AddWithValue("@id", id);
                    con.Open();

                    using (var reader = cmnd.ExecuteReader())
                    {
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
            }
        }

        public bool Edit(Author author)
        {
            try
            {
                using (var con = new SqlConnection(config.ConnectionString))
                {
                    using (var cmnd = new SqlCommand("author_edite", con))
                    {
                        cmnd.CommandType = CommandType.StoredProcedure;
                        cmnd.Parameters.AddWithValue("@name", author.Name);
                        cmnd.Parameters.AddWithValue("@surname", author.Surname);
                        cmnd.Parameters.AddWithValue("@id", author.Id);
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
    }
}

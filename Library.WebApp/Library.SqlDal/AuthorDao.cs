using Library.DalContracts;
using Library.Entities;
using System;
using System.Collections.Generic;
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
                    var cmnd = con.CreateCommand();
                    cmnd.CommandText = "INSERT INTO dbo.authors (name, surname) VALUES (@Name, @Surname); SELECT scope_identity()";
                    cmnd.Parameters.AddWithValue("@Name", author.Name);
                    cmnd.Parameters.AddWithValue("@Surname", author.Surname);

                    con.Open();
                    author.Id = (int)(decimal)cmnd.ExecuteScalar();

                    return true;
                }
            }
            catch
            {

                throw;
            }
        }

        public bool Delete(int id)
        {
            try
            {
                using (var con = new SqlConnection(config.ConnectionString))
                {
                    var cmnd = con.CreateCommand();
                    cmnd.CommandText = "DELETE FROM dbo.authors WHERE id = @Id";
                    cmnd.Parameters.AddWithValue("@Id", id);

                    con.Open();
                    return cmnd.ExecuteNonQuery() > 0;
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
                var cmnd = con.CreateCommand();
                cmnd.CommandText = "SELECT id, name, surname FROM dbo.authors";

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
                var cmnd = con.CreateCommand();
                cmnd.CommandText = "SELECT TOP 1 id, name, surname FROM dbo.authors WHERE id=@Id";
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
                    var cmnd = con.CreateCommand();
                    cmnd.CommandText = "UPDATE dbo.authors SET name = @Name, surname = @Surname WHERE id = @Id";
                    cmnd.Parameters.AddWithValue("@Name", author.Name);
                    cmnd.Parameters.AddWithValue("@Surname", author.Surname);
                    cmnd.Parameters.AddWithValue("@Id", author.Id);

                    con.Open();
                    return cmnd.ExecuteNonQuery() > 0;
                }
            }
            catch
            {
                return false;
            }            
        }
    }
}

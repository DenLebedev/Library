using Library.DalContracts;
using Library.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Library.SqlDal
{
    public class BookDao : IBookDao
    {
        SqlDalConfig config;

        public BookDao(SqlDalConfig config)
        {
            this.config = config;
        }

        public bool Add(Book book)
        {  
            try
            {
                using (var con = new SqlConnection(config.ConnectionString))
                {
                    using (var cmnd = new SqlCommand("book_add", con))
                    {
                        cmnd.CommandType = CommandType.StoredProcedure;
                        var jsonQuery = JsonConvert.SerializeObject(book);

                        cmnd.Parameters.AddWithValue("@book", jsonQuery);

                        cmnd.Parameters.Add("@id", SqlDbType.Int, 4);
                        cmnd.Parameters["@id"].Direction = ParameterDirection.Output;
                        con.Open();
                        cmnd.ExecuteNonQuery();
                        int? id = cmnd.Parameters["@id"].Value as int?;
                        if (id != null)
                        {
                            book.Id = (int)cmnd.Parameters["@id"].Value;
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
                    using (var cmnd = new SqlCommand("book_delete", con))
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

        public bool Edit(Book book)
        {
            try
            {
                using (var con = new SqlConnection(config.ConnectionString))
                {
                    using (var cmnd = new SqlCommand("book_edit", con))
                    {
                        cmnd.CommandType = CommandType.StoredProcedure;
                        var jsonQuery = JsonConvert.SerializeObject(book);
                        cmnd.Parameters.AddWithValue("@book", jsonQuery);
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

        public ICollection<Book> GetAll()
        {
            return GetBooks("publications_get_all");            
        }

        public ICollection<Book> GetTopTen()
        {
            return GetBooks("publications_get_top_ten");
        }

        public Book GetById(int id)
        {
            using (var con = new SqlConnection(config.ConnectionString))
            {
                using (var cmnd = new SqlCommand("book_get_by_id", con))
                {
                    cmnd.CommandType = CommandType.StoredProcedure;
                    cmnd.Parameters.AddWithValue("@id", id);
                    con.Open();

                    using (var reader = cmnd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            Book book = new Book();
                            book.Id = (int)reader["Id"];
                            book.Name = (string)reader["Name"];
                            book.PageCount = (int)reader["PageCount"];
                            book.Notes = (reader["Notes"] == DBNull.Value) ? string.Empty : (string)reader["Notes"];
                            book.MarkDelete = reader.GetBoolean(reader.GetOrdinal("MarkDelete"));
                            book.YearPublication = (int)reader["YearPublication"];
                            book.ISBN = (reader["ISBN"] == DBNull.Value) ? string.Empty : (string)reader["ISBN"];
                            book.City.Id = (int)reader["CityId"];
                            book.City.Name = (string)reader["CityName"];
                            book.Publishing.Id = (int)reader["PublishingId"];
                            book.Publishing.Name = (string)reader["PublishingName"];
                            book.Author.Id = (int)reader["AuthorId"];
                            book.Author.Name = (string)reader["AuthorName"];
                            book.Author.Surname = (string)reader["AuthorSurname"];

                            return book;
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        private ICollection<Book> GetBooks(string cmdText)
        {
            using (var con = new SqlConnection(config.ConnectionString))
            {
                using (var cmnd = new SqlCommand(cmdText, con))
                {
                    cmnd.CommandType = CommandType.StoredProcedure;
                    con.Open();

                    using (var reader = cmnd.ExecuteReader())
                    {
                        var books = new List<Book>();
                        while (reader.Read())
                        {
                            var book = new Book();
                            book.Id = (int)reader["Id"];
                            book.Name = (string)reader["Name"];
                            book.PageCount = (int)reader["PageCount"];
                            book.Notes = (reader["Notes"] == DBNull.Value) ? string.Empty : (string)reader["Notes"];
                            book.MarkDelete = reader.GetBoolean(reader.GetOrdinal("MarkDelete"));
                            book.YearPublication = (int)reader["YearPublication"];
                            book.ISBN = (reader["ISBN"] == DBNull.Value) ? string.Empty : (string)reader["ISBN"];
                            book.City.Id = (int)reader["CityId"];
                            book.City.Name = (string)reader["CityName"];
                            book.Publishing.Id = (int)reader["PublishingId"];
                            book.Publishing.Name = (string)reader["PublishingName"];
                            book.Author.Id = (int)reader["AuthorId"];
                            book.Author.Name = (string)reader["AuthorName"];
                            book.Author.Surname = (string)reader["AuthorSurname"];
                            books.Add(book);
                        }
                        return books;
                    }
                }
            }
        }
    }
}

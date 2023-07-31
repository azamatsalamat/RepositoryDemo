using Dapper;
using Microsoft.Data.SqlClient;
using RepositoryDemo.Models;
using System.Data;

namespace RepositoryDemo.Repository
{
    public class DapperBookRepository : IRepository<Book>
    {
        private readonly IDbConnection _db;
        public DapperBookRepository()
        {
            _db = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=RepositoryDemo;Trusted_Connection=true");
        }

        public void Create(Book item)
        {
            if (_db.State != ConnectionState.Open)
            {
                _db.Open();
            }

            var sql = @"insert into [dbo].[Books] (price, title, isbn) values (@price, @title, @isbn)";
            var parameters = new { price = item.Price, title = item.Title, isbn = item.ISBN };

            _db.Execute(sql, parameters);
        }

        public void Delete(int id)
        {
            if (_db.State != ConnectionState.Open)
            {
                _db.Open();
            }

            var sql = @"delete from [dbo].[Books] where id = @id";
            var parameters = new { id };

            _db.Execute(sql, parameters);
        }

        public void Dispose()
        {
            if (_db.State != ConnectionState.Closed)
            {
                _db.Close();
            }
        }

        public Book Get(int id)
        {
            if (_db.State != ConnectionState.Open)
            {
                _db.Open();
            }

            var result = _db.Query<Book>(@"select * from [dbo].[Books] where id = @id", new { id = id }).SingleOrDefault();
            return result;
        }

        public IEnumerable<Book> GetAll(int page, int itemsPerPage)
        {
            var result = _db.Query<Book>(@"select * from [dbo].[Books] ORDER BY Id OFFSET @offset ROWS FETCH NEXT @limit ROWS ONLY", new { offset = (page - 1) * itemsPerPage, limit = itemsPerPage });
            return result;
        }

        public void Save()
        {
            _db.Close();
        }

        public void Update(Book item)
        {
            if (_db.State != ConnectionState.Open)
            {
                _db.Open();
            }

            var sql = @"update [dbo].[Books] set title = @title, isbn = @isbn, price = @price where id = @id";
            var parameters = new { title = item.Title, isbn = item.ISBN, price = item.Price, id = item.Id };

            _db.Execute(sql, parameters);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using RepositoryDemo.Data;
using RepositoryDemo.Models;

namespace RepositoryDemo.Repository
{
    public class EfCoreBookRepository : IRepository<Book>
    {
        private SqlStoreContext _db;
        public EfCoreBookRepository()
        {
            _db = new SqlStoreContext();
        }

        public void Create(Book item)
        {
            _db.Books.Add(item);
        }

        public void Delete(int id)
        {
            var book = _db.Books.Find(id);
            if (book != null)
            {
                _db.Books.Remove(book);
            }
        }

        public Book Get(int id)
        {
            return _db.Books.Find(id);
        }

        public IEnumerable<Book> GetAll(int page, int itemsPerPage)
        {
            return _db.Books.Skip((page - 1) * itemsPerPage).Take(itemsPerPage);
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public void Update(Book item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed && disposing)
            {
                _db.Dispose();
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

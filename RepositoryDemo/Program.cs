using RepositoryDemo.Models;
using RepositoryDemo.Repository;

namespace RepositoryDemo
{
    public class Program
    {
        static void Main(string[] args)
        {
            var repo = new DapperBookRepository();
            //repo.Create(new Book { Title = "War and Peace", ISBN = "1234567890", Price = 10.99 });
            //repo.Create(new Book { Title = "Pride and Prejudice", ISBN = "1234567890", Price = 10.99 });
            //repo.Save();

            var books = repo.GetAll(1, 10);

            foreach (var book in books)
            {
                Console.WriteLine(book.Title);
            }
        }
    }
}
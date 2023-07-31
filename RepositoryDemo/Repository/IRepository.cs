namespace RepositoryDemo.Repository
{
    public interface IRepository<T> : IDisposable where T : class 
    {
        IEnumerable<T> GetAll(int page, int itemsPerPage);
        T Get(int id);
        void Create(T item);
        void Update(T item);
        void Delete(int id);
        void Save();
    }
}

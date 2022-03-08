namespace BooksStore.Domain.Contracts
{
    public interface IQueriesRepository<T> where T : class
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
    }
}

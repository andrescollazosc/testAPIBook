namespace BooksStore.Domain.Contracts
{
    public interface IGenericRepository<T> : IDMLRepositories<T>, IQueriesRepository<T> where T : class
    {  }
}

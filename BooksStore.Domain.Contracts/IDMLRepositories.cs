namespace BooksStore.Domain.Contracts
{
    public interface IDMLRepositories<T> where T : class
    {
        Task<bool> Add(T entity);
        Task<bool> Update(T entity);
        Task<bool> Delete(int id);
    }
}

using BooksStore.Domain.Contracts;
using BooksStore.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace BooksStore.Ifrastructure.Data.Repositories
{
    public class BookRepository : IGenericRepository<Book>
    {
        private readonly BookContext _context;

        public BookRepository(BookContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(Book entity)
        {
            entity.Active = true;
            await _context.AddAsync(entity);

            return _context.SaveChanges() > 0 ? true : false;
        }

        public async Task<bool> Delete(int id)
        {
            var result = await GetById(id);
            result.Active = false;

            return await _context.SaveChangesAsync() > 0 ? true : false;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            var result = await _context.Books.Where(x => x.Active == true).ToListAsync();

            return result;
        }

        public async Task<Book> GetById(int id)
        {
            var result = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);

            return result;
        }

        public async Task<bool> Update(Book entity)
        {
            var result = await GetById(entity.Id);

            result.Name = entity.Name;
            result.Price = entity.Price;
            
            return await _context.SaveChangesAsync() > 0 ? true : false;
        }
    }
}

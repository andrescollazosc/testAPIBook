using BooksStore.Domain.Models;
using BooksStore.Services.Dto;

namespace BooksStore.Services.WebApi.Mapper
{
    public class Mapper : IMapper
    {
        public Book Map(BookDto entity)
        {
            return new Book { 
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Active = entity.Active,
            };
        }

        public BookDto Map(Book entity)
        {
            return new BookDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Price = entity.Price,
                Active = entity.Active,
            };
        }
    }
}

using BooksStore.Domain.Models;
using BooksStore.Services.Dto;

namespace BooksStore.Services.WebApi.Mapper
{
    public interface IMapper
    {
        Book Map(BookDto entity);
        BookDto Map(Book entity);
    }
}

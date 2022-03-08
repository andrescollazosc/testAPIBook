using BooksStore.Domain.Contracts;
using BooksStore.Domain.Models;
using BooksStore.Services.Dto;
using BooksStore.Services.WebApi.Mapper;
using Microsoft.AspNetCore.Mvc;

namespace BooksStore.Services.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookController : ControllerBase
    {
        private IGenericRepository<Book> _bookRepository;
        private readonly IMapper _mapper;

        public BookController(IGenericRepository<Book> bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        [HttpGet("books")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<Book>>> GetBooks()
        {
            var result = await _bookRepository.GetAll();

            return result.ToList();
        }

        [HttpGet("book/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<ActionResult<BookDto>> GetBooks(int id)
        {
            var result = await _bookRepository.GetById(id);

            return _mapper.Map(result);
        }

        [HttpPost("save")]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> Add(BookDto bookDto)
        {
            var result = await _bookRepository.Add(_mapper.Map(bookDto));

            return result;
        }

        [HttpPut("update")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<BookDto>> Update(BookDto bookDto)
        {
            await _bookRepository.Update(_mapper.Map(bookDto));

            var newBookDto = _mapper.Map(_bookRepository.GetById(bookDto.Id).GetAwaiter().GetResult());

            return newBookDto;
        }

        [HttpDelete("delete")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<bool>> Delete(int id)
        {
            await _bookRepository.Delete(id);

            return NoContent();
        }

    }
}

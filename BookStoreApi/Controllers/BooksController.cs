using BookStoreApi.Models;
using BookStoreApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly BooksService _booksService;

        public BooksController(BooksService booksService)
        {
            _booksService = booksService;
        }

        [HttpPost]
        public async Task Create(Book book)
        {
            await _booksService.CreateAsync(book);
        }

        [HttpGet]
        public async Task<List<Book>> GetAll()
        {
            var books = await _booksService.GetAsync();

            return books;
        }

        [HttpGet("{id:length(24)}")]
        public async Task<Book> GetAll(string id)
        {
            var book = await _booksService.GetAsync(id);

            return book;
        }

        [HttpPut("{id:length(24)}")]
        public async Task UpdateAsync(string id, Book book)
        {
            await _booksService.UpdateAsync(id, book);
        }

        [HttpDelete("{id:length(24)}")]
        public async Task Delete(string id)
        {
            await _booksService.RemoveAsync(id);
        }
    }
}

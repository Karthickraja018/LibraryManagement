using LibraryManagement.DTOs;
using LibraryManagement.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _service;

        public BooksController(IBookService service)
        {
            _service = service;
        }

        [HttpGet]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetAllBooks(
            [FromQuery] string searchTerm = "",
            [FromQuery] int? year = null,
            [FromQuery] int pageNumber = 1,
            [FromQuery] int pageSize = 10)
        {
            var pagedBooks = await _service.GetPagedBooksAsync(searchTerm, year, pageNumber, pageSize);
            return Ok(pagedBooks);
        }

        [HttpGet("{isbn}")]
        [Authorize(Roles = "Admin,User")]
        public async Task<IActionResult> GetBookByISBN(string isbn)
        {
            var book = await _service.GetByISBNAsync(isbn);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> AddBook(BookCreateDTO dto)
        {
            var book = await _service.AddBookAsync(dto);
            return CreatedAtAction(nameof(GetBookByISBN), new { isbn = book.ISBN }, book);
        }

        [HttpPut("{isbn}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> UpdateBook(string isbn, BookUpdateDTO dto)
        {
            try
            {
                await _service.UpdateBookAsync(isbn, dto);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpDelete]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteBook(string isbn)
        {
            try
            {
                await _service.DeleteBookAsync(isbn);
                return NoContent();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }
    }
}

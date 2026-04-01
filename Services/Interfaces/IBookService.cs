using LibraryManagement.DTOs;
using LibraryManagement.Models;

namespace LibraryManagement.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<PagedResult<Book>> GetPagedBooksAsync(string searchTerm, int? year, int pageNumber, int pageSize);
        Task<Book> GetByISBNAsync(string isbn);
        Task<Book> AddBookAsync(BookCreateDTO book);
        Task UpdateBookAsync(string isbn,BookUpdateDTO book);
        Task DeleteBookAsync(string isbn);
    }
}

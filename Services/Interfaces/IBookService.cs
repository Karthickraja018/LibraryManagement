using LibraryManagement.DTOs;
using LibraryManagement.Models;

namespace LibraryManagement.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAllBooksAsync();
        Task<Book> GetByISBNAsync(string isbn);
        Task<Book> AddBookAsync(BookCreateDTO book);
        Task UpdateBookAsync(string isbn,BookUpdateDTO book);
        Task DeleteBookAsync(string isbn);
    }
}

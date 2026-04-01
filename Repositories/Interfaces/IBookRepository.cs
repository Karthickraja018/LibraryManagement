using LibraryManagement.Models;

namespace LibraryManagement.Repositories.Interfaces
{
    public interface IBookRepository
    {
        Task<IEnumerable<Book>> GetAllAsync();
        Task<PagedResult<Book>> GetPagedAsync(string searchTerm, int? year, int pageNumber, int pageSize);
        Task<Book> GetByISBNAsync(string isbn);
        Task AddAsync(Book book);
        Task UpdateAsync(Book book);
        Task RemoveAsync(Book book);
    }
}

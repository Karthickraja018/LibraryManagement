using Microsoft.EntityFrameworkCore;
using LibraryManagement.Models;
using LibraryManagement.Repositories.Interfaces;
using LibraryManagement.DTOs;
using LibraryManagement.Data;

namespace LibraryManagement.Repositories
{
    public class BookRepository : IBookRepository
    {
        private readonly AppDbContext _context;
        public BookRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAllAsync()
        {
            return await _context.Books.ToListAsync();
        }

        public async Task<PagedResult<Book>> GetPagedAsync(string searchTerm, int? year, int pageNumber, int pageSize)
        {
            var query = _context.Books.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(b => b.Title.Contains(searchTerm) || b.Author.Contains(searchTerm) || b.ISBN.Contains(searchTerm));
            }

            if (year.HasValue)
            {
                query = query.Where(b => b.PublicationYear == year.Value);
            }

            var totalCount = await query.CountAsync();
            var items = await query.Skip((pageNumber - 1) * pageSize)
                                   .Take(pageSize)
                                   .ToListAsync();

            return new PagedResult<Book>
            {
                Items = items,
                TotalCount = totalCount,
                PageNumber = pageNumber,
                PageSize = pageSize
            };
        }

        public async Task<Book> GetByISBNAsync(string isbn)
        {
            return await _context.Books.FindAsync(isbn);
        }

        public async Task AddAsync(Book book)
        {
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
        }

        public async Task RemoveAsync(Book book) {
            _context.Books.Remove(book);
            await _context.SaveChangesAsync();
        }

    }
}

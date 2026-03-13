using AutoMapper;
using LibraryManagement.DTOs;
using LibraryManagement.Models;
using LibraryManagement.Repositories.Interfaces;
using LibraryManagement.Services.Interfaces;

namespace LibraryManagement.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<Book>> GetAllBooksAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book> GetByISBNAsync(string isbn)
        {
            return await _bookRepository.GetByISBNAsync(isbn);
        }

        public async Task<Book> AddBookAsync(BookCreateDTO dto)
        {
            var book = _mapper.Map<Book>(dto);
            await _bookRepository.AddAsync(book);
            return book;
        }

        public async Task UpdateBookAsync(string isbn, BookUpdateDTO dto)
        {
            var existingBook = await _bookRepository.GetByISBNAsync(isbn);
            if (existingBook == null)
            {
                throw new Exception("Book not found");
            }

            _mapper.Map(dto, existingBook);
            await _bookRepository.UpdateAsync(existingBook);
        }

        public async Task DeleteBookAsync(string isbn)
        {
            var book = await _bookRepository.GetByISBNAsync(isbn);
            if (book == null)
            {
                throw new Exception("Book not found");
            }

            await _bookRepository.RemoveAsync(book);
        }
    }
}

using Library.Application.Interfaces;
using Library.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure
{
    public class BookRepository : IBookRepository
    {
        private readonly MainDbContext _mainDbContext;

        public BookRepository(MainDbContext mainDbContext)
        {
            _mainDbContext = mainDbContext;
        }
        public async Task<List<Book>> GetAllBooks()
        {
           return await _mainDbContext.Books.ToListAsync();
        }
        public async Task<Book> GetBookById(int id)
        {
           return await _mainDbContext.Books.FirstOrDefaultAsync(b => b.BookId == id);

        }

        public async Task<Book> GetBookByISBN(int isbn)
        {
            return await _mainDbContext.Books.FirstOrDefaultAsync(b => b.ISBN == isbn);
        }
        public async Task<Book> CreateBook(Book book)
        {
          _mainDbContext.Books.Add(book);
          await _mainDbContext.SaveChangesAsync();
          return book;
        }
        public async Task<Book> UpdateBook(Book book)
        {
            _mainDbContext.Books.Update(book);
            await _mainDbContext.SaveChangesAsync();
            return book;
        }

        public async Task<Book> DeleteBook(int id)
        {
            var bookToDelete = await _mainDbContext.Books.FirstOrDefaultAsync(book => book.BookId == id);

            if (bookToDelete != null)
            {
                _mainDbContext.Books.Remove(bookToDelete);
                await _mainDbContext.SaveChangesAsync();
                return bookToDelete;
            }
            return null;
        }




    }
}

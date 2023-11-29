using Library.Application.Repositories;
using Library.Domain;
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
        public List<Book> GetAllBooks()
        {
           return _mainDbContext.Books.ToList();
        }
        public Book GetBookById(int id)
        {
           return _mainDbContext.Books.FirstOrDefault(b => b.BookId == id);

        }

        public Book GetBookByISBN(int isbn)
        {
            return _mainDbContext.Books.FirstOrDefault(b => b.ISBN == isbn);
        }
        public Book CreateBook(Book book)
        {
          _mainDbContext.Books.Add(book);
            _mainDbContext.SaveChanges();
            return book;
        }
        public Book UpdateBook(Book book)
        {
            _mainDbContext.Books.Update(book);
            _mainDbContext.SaveChanges();
            return book;
        }

        public Book DeleteBook(int id)
        {
            var bookToDelete = _mainDbContext.Books.FirstOrDefault(book => book.BookId == id);

            if (bookToDelete != null)
            {
                _mainDbContext.Books.Remove(bookToDelete);
                _mainDbContext.SaveChanges();
                return bookToDelete;
            }
            return null;
        }




    }
}

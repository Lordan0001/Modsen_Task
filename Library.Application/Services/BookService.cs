using Library.Application.Repositories;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public List<Book> GetAllBooks()
        {
           var books = _bookRepository.GetAllBooks();
           return books;
        }
        public Book GetBookById(int id)
        {
            return _bookRepository.GetBookById(id);
        }
        public Book GetBookByISBN(int isbn)
        {
            return _bookRepository.GetBookByISBN(isbn);
        }
        public Book CreateBook(Book book)
        {
            _bookRepository.CreateBook(book);
            return book;
        }
        public Book UpdateBook(Book book)
        {
            /*            var existingBook = _bookRepository.GetBookById(book.BookId);
                        if (existingBook == null)
                        {
                            throw new Exception($"Book to update not found.");
                        }
                        //ADD AUTOMAPPER
                        existingBook.ISBN = book.ISBN;
                        existingBook.Title = book.Title;
                        existingBook.Genre = book.Genre;
                        existingBook.Description = book.Description;
                        existingBook.Author = book.Author;

                        _bookRepository.UpdateBook(existingBook);

                        return existingBook;*/



            _bookRepository.UpdateBook(book);

            return book;
        }

    
        public Book DeleteBook(int id)
        {
          return _bookRepository.DeleteBook(id);
        }
    }
}

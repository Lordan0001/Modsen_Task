using AutoMapper;
using Library.Application.Dto;
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

        private readonly IMapper _mapper;

        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
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
        public Book CreateBook(BookDTO bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _bookRepository.CreateBook(book);
            return book;
        }
        public Book UpdateBook(BookDTO bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            _bookRepository.UpdateBook(book);

            return book;
        }

        public Book DeleteBook(int id)
        {
          return _bookRepository.DeleteBook(id);
        }
    }
}

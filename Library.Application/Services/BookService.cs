using AutoMapper;
using Library.Application.Dto;
using Library.Application.Interfaces;
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
        public async Task<List<Book>> GetAllBooks()
        {
           var books = await _bookRepository.GetAllBooks();
           return books;
        }
        public async Task <Book> GetBookById(int id)
        {
            return await _bookRepository.GetBookById(id);
        }
        public async Task<Book> GetBookByISBN(int isbn)
        {
            return await _bookRepository.GetBookByISBN(isbn);
        }
        public async Task<Book> CreateBook(BookDTO bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookRepository.CreateBook(book);
            return book;
        }
        public async Task<Book> UpdateBook(BookDTO bookDto)
        {
            var book = _mapper.Map<Book>(bookDto);
            await _bookRepository.UpdateBook(book);
            return book;
        }

        public async Task<Book> DeleteBook(int id)
        {
          return await _bookRepository.DeleteBook(id);
        }
    }
}

using AutoMapper;
using Library.Application.Dto;
using Library.Application.Interfaces;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Reflection.Metadata.BlobBuilder;

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
        public async Task<List<BookDTO>> GetAllBooks()
        {
            var books = await _bookRepository.GetAllBooks();
            return _mapper.Map<List<BookDTO>>(books);//return dto from service instead of entities

        }
        public async Task <BookDTO> GetBookById(int id)
        {
            var book = await _bookRepository.GetBookById(id);
            return _mapper.Map<BookDTO>(book);
        }
        public async Task<BookDTO> GetBookByISBN(int isbn)
        {
            var book = await _bookRepository.GetBookByISBN(isbn);
            return _mapper.Map<BookDTO>(book);
        }
        public async Task<BookDTO> CreateBook(BookDTO BookDto)
        {
            var book = _mapper.Map<Book>(BookDto);
            var createdBook = await _bookRepository.CreateBook(book);
            return _mapper.Map<BookDTO>(createdBook);
        }
        public async Task<BookDTO> UpdateBook(BookDTO BookDto)
        {
            var book = _mapper.Map<Book>(BookDto);
            var updatedBook = await _bookRepository.UpdateBook(book);
            return _mapper.Map<BookDTO>(updatedBook);
        }

        public async Task<BookDTO> DeleteBook(int id)
        {
           var deletedBook = await _bookRepository.DeleteBook(id);
            return _mapper.Map<BookDTO>(deletedBook);
        }
    }
}

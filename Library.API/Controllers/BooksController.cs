using AutoMapper;
using Library.Application.Dto;
using Library.Application.Interfaces;
using Library.Domain;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;


        public BooksController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<ActionResult<List<Book>>> GetAllBooks()
        {
            var booksFromService = await _bookService.GetAllBooks();
            return Ok(booksFromService);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Book>> GetBookById(int id)
        {
            var bookFromService = await _bookService.GetBookById(id);
            return Ok(bookFromService);
        }
        [HttpGet("isbn/:{isbn}")]
        public async Task<ActionResult<Book>> GetBookByIsbn(int isbn)
        {
            var bookFromService = await _bookService.GetBookByISBN(isbn);
            return Ok(bookFromService);
        }
        [HttpPost]
        public async Task<ActionResult<Book>> PostBook(BookDTO bookDTO)
        { 
           var createdBook = await _bookService.CreateBook(bookDTO);
           return Ok(createdBook);
        }
        [HttpPut]
        public async Task<ActionResult<Book>> PutBook(BookDTO bookDto)
        {
            var updatedBook = await _bookService.UpdateBook(bookDto);
            return Ok(updatedBook);
        }
        [HttpDelete]
        public async Task<ActionResult> DeleteBook(int id)
        {
            var deleted = await _bookService.DeleteBook(id);
            return Ok(deleted);
        }


    }
}

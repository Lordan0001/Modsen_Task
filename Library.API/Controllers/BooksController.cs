using Library.Application.Services;
using Library.Domain;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.API.Controllers
{
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
        public ActionResult<List<Book>> GetAllBooks()
        {
            var booksFromService = _bookService.GetAllBooks();
            return Ok(booksFromService);
        }
        [HttpGet("{id}")]
        public ActionResult<Book> GetBookById(int id)
        {
            var bookFromService = _bookService.GetBookById(id);
            return Ok(bookFromService);
        }
        [HttpGet("isbn/:{isbn}")]
        public ActionResult<Book> GetBookByIsbn(int isbn)
        {
            var bookFromService = _bookService.GetBookByISBN(isbn);
            return Ok(bookFromService);
        }
        [HttpPost]
        public ActionResult<Book> PostBook(Book book)
        {
           var createdBook = _bookService.CreateBook(book);
           return Ok(createdBook);
        }
        [HttpPut]
        public ActionResult<Book> PutBook(Book book)
        {
            var updatedBook = _bookService.UpdateBook(book);
            return Ok(updatedBook);
        }
        [HttpDelete]
        public ActionResult DeleteBook(int id)
        {
            var deleted = _bookService.DeleteBook(id);
            return Ok(deleted);
        }


    }
}

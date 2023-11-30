using AutoMapper;
using Library.Application.Services;
using Library.Domain;
using Library.Domain.Dto;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;

        private readonly IMapper _mapper;

        public BooksController(IBookService bookService, IMapper mapper)
        {
            _bookService = bookService;
            _mapper = mapper;
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
        public ActionResult<Book> PostBook(BookDTO bookDTO)
        {
            //ADD AUTOMAPPER
/*            var book = new Book
            {
                ISBN = bookDTO.ISBN,
                Title = bookDTO.Title,
                Genre = bookDTO.Genre,
                Description = bookDTO.Description,
                Author = bookDTO.Author

            };*/

           var book = _mapper.Map<Book>(bookDTO);  
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

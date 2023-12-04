using Library.Application.Dto;
using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IBookService
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        Book GetBookByISBN(int isbn);
        Book CreateBook(BookDTO bookDto);
        Book UpdateBook(BookDTO bookDto);
        Book DeleteBook(int id);
    }
}

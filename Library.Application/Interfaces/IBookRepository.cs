using Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IBookRepository
    {
        List<Book> GetAllBooks();
        Book GetBookById(int id);
        Book GetBookByISBN(int isbn);
        Book CreateBook(Book book);
        Book UpdateBook(Book book);
        Book DeleteBook(int id);
    }
}

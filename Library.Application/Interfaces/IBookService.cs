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
        Task<List<Book>> GetAllBooks();
        Task<Book> GetBookById(int id);
        Task<Book> GetBookByISBN(int isbn);
        Task<Book> CreateBook(BookDTO bookDto);
        Task<Book> UpdateBook(BookDTO bookDto);
        Task<Book> DeleteBook(int id);
    }
}

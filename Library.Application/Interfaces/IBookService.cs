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
        Task<List<BookDTO>> GetAllBooks();
        Task<BookDTO> GetBookById(int id);
        Task<BookDTO> GetBookByISBN(int isbn);
        Task<BookDTO> CreateBook(BookDTO bookDto);
        Task<BookDTO> UpdateBook(BookDTO bookDto);
        Task<BookDTO> DeleteBook(int id);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Dto
{
    public class BookDTO
    {
        public int BookId { get; set; }
        public int ISBN { get; set; }
        public string Title { get; set; } = String.Empty;
        public string Genre { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Author {  get; set; } = String.Empty;
    }
}

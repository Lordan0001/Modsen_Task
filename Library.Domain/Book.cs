using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain
{
    public class Book
    {
        public int BookId { get; set; } 
        public int ISBN { get; set; } 
        public string Title { get; set; } = String.Empty;
        public string Genre { get; set; } = String.Empty;
        public string Description { get; set; } = String.Empty;
        public string Author { get; set; } = String.Empty;
        public DateTime BookWasTakenDate { get; set; } = DateTime.Now;
        public DateTime BookWasReturnedDate { get; set; } = DateTime.Now.AddDays(31);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TristanRosel.Models
{
    public class Library
    {
        public Guid LibraryId { get; set; } 
        public string? Name { get; set; }
        public string? Location { get; set; }
        public int EstablishedYear { get; set; }

        
        public List<Book> Books { get; set; } = new List<Book>();
    }

}

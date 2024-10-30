using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TristanRosel.Models
{
    public class Book
    {
        public Guid BookId { get; set; } 
        public string? Title { get; set; }
        public string? Author { get; set; }
        public string? ISBN { get; set; }

        
        public Guid LibraryId { get; set; }
        public Library? Library { get; set; }
    }

}

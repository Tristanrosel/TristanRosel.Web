using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using TristanRosel.Contracts;
using TristanRosel.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace TristanRosel.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ILibraryService _libraryService;
        private readonly IBookService _bookService;

        public List<Library> Libraries { get; set; }
        public List<Book> Books { get; set; }

        public IndexModel(ILogger<IndexModel> logger, ILibraryService libraryService, IBookService bookService)
        {
            _logger = logger;
            _libraryService = libraryService;
            _bookService = bookService;
        }

        public async Task OnGetAsync()
        {
            Libraries = (await _libraryService.GetAllAsync()).ToList();
            Books = (await _bookService.GetAllAsync()).ToList();
        }
    }
}

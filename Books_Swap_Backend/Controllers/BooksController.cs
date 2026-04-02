using DbConnection;
using DbConnection.DbModels;
using Microsoft.AspNetCore.Mvc;

namespace Books_Swap_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Book> GetAllBooks()
        {
            var items = new List<Book>();

            using (var dbContext = new BooksSwapContext())
            {
                foreach (var book in dbContext.Books)
                {
                    items.Add(book);
                }
            }

            return items;
        }

        [HttpGet("/books")]
        public IEnumerable<Book> SearchForBooksByTitle([FromQuery] string title)
        {
            var items = new List<Book>();

            using (var dbContext = new BooksSwapContext())
            {
                items = dbContext.Books
                    .Where(
                        b => b.Title.ToLower().Contains(title)
                        )
                    .ToList();
            }

            return items;
        }
    }
}

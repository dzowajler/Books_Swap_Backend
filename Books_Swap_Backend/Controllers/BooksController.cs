using DbAccess.Queries;
using DbAccess.QueryHandlers;
using DbConnection;
using DbConnection.DbModels;
using Microsoft.AspNetCore.Mvc;
using ResponseModels.ViewModels;
using SearchService;

namespace Books_Swap_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly ILogger<BooksController> _logger;
        private readonly IBookQueryService _bookQueryService; 

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
            _bookQueryService = new BookQueryService();
        }

        [HttpGet]
        public async Task<IEnumerable<BookViewModel>> GetAllBooks()
        {
            var result = await _bookQueryService.SearchForBooksAsync(null, null);

            return result;
        }

        [HttpGet("/books")]
        public async Task<IEnumerable<BookViewModel>> SearchForBooksByTitleAsync([FromQuery] string title)
        {
            var result = await _bookQueryService.SearchForBooksAsync(title, null);

            return result;
            //return Results.Ok(items);
            //stworzyæ dodatkow¹ klasê z odpowiedzi¹ HTTP implementuj¹c¹ IResult
        }
    }
}

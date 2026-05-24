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
        private readonly IBooksSearchService _bookQueryService; 

        public BooksController(ILogger<BooksController> logger)
        {
            _logger = logger;
            _bookQueryService = new BooksSearchService();
        }

        [HttpGet]
        public async Task<IEnumerable<BookViewModel>> GetAllBooks(CancellationToken cancellationToken)
        {

            try
            {
                var result = await _bookQueryService.SearchForBooksAsync(null, null, cancellationToken);

                return result;
            }
            catch (OperationCanceledException ex) when (HttpContext.RequestAborted.IsCancellationRequested)
            {
                throw;
            }
            catch (OperationCanceledException ex)
            {
                throw;
            }
        }

        [HttpGet("/books")]
        public async Task<IEnumerable<BookViewModel>> SearchForBooksByTitleAsync([FromQuery] string title)
        {
            var result = await _bookQueryService.SearchForBooksAsync(title, null, new CancellationToken());

            return result;
            //return Results.Ok(items);
            //stworzyæ dodatkow¹ klasê z odpowiedzi¹ HTTP implementuj¹c¹ IResult
        }
    }
}

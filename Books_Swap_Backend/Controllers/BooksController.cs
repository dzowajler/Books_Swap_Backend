using DbAccess.Queries;
using DbAccess.QueryHandlers;
using DbConnection;
using DbConnection.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ResponseModels.ViewModels;
using SearchService;
using System.Threading.Tasks;

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

        [HttpGet("/books")]
        public async Task<IEnumerable<BookViewModel>> GetAllBooksAsync(CancellationToken cancellationToken)
        {

            try
            {
                var result = await _bookQueryService.SearchForBooksAsync(null, null, null, cancellationToken);

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

        [Authorize]
        [HttpGet("/books/{id:int:min(1)}")]
        public async Task<IEnumerable<BookViewModel>> GetBookById(int id)
        {
            var result = await _bookQueryService.SearchForBooksAsync(null, null, id, new CancellationToken());
            
            return result;
        }

       [HttpGet("/books/search")]
        public async Task<IEnumerable<BookViewModel>> SearchForBooksByTitleAsync([FromQuery] string title)
        {
            var result = await _bookQueryService.SearchForBooksAsync(title, null, null, new CancellationToken());

            return result;
            //return Results.Ok(items);
            //stworzyæ dodatkow¹ klasê z odpowiedzi¹ HTTP implementuj¹c¹ IResult
        }
    }
}

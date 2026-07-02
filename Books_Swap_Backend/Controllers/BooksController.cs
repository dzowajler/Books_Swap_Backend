using DbAccess.Queries;
using DbAccess.QueryHandlers;
using DbConnection;
using DbConnection.DbModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Models.ApiResponseModels;
using ResponseModels.ViewModels;
using SearchService.BooksSearches;
using System.Threading.Tasks;

namespace Books_Swap_Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IBooksSearchService _bookQueryService; 

        public BooksController(ILogger<BooksController> logger)
        {
            _bookQueryService = new BooksSearchService();
        }

        [HttpGet("/books")]
        public async Task<ApiResponse> GetAllBooksAsync(CancellationToken cancellationToken)
        
        {
            return await _bookQueryService.SearchForBooksAsync(null, null, null, cancellationToken);
        }

        [Authorize]
        [HttpGet("/books/{id:int:min(1)}")]
        public async Task<ApiResponse> GetBookByIdAsync(int id, CancellationToken cancellationToken)
        {
            return await _bookQueryService.SearchForBooksAsync(null, null, id, cancellationToken);
        }

        [HttpGet("/books/search")]
        public async Task<ApiResponse> SearchForBooksByTitleAsync([FromQuery] string title, CancellationToken cancellationToken)
        {
            return await _bookQueryService.SearchForBooksAsync(title, null, null, cancellationToken);
        }
    }
}

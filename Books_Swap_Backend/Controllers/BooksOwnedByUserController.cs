using CommandService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ApiResponseModels;
using ResponseModels.ViewModels;
using SearchService.BooksByUserSearches;

namespace Books_Swap_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksOwnedByUserController : ControllerBase
    {
        private Lazy<IBooksOwnedByUserSearchService> _booksOwnedByUserSearch { get; set; }
        private Lazy<IBookOwnedByUserCommandService> _bookOwnedByUserCommandService { get; set; }

        public BooksOwnedByUserController(IBooksOwnedByUserSearchService booksOwnedByUserSearchService, IBookOwnedByUserCommandService bookOwnedByUserCommandService)
        {
            _booksOwnedByUserSearch = new Lazy<IBooksOwnedByUserSearchService>(
                () => booksOwnedByUserSearchService
                );
            _bookOwnedByUserCommandService = new Lazy<IBookOwnedByUserCommandService>(
                () => bookOwnedByUserCommandService
                );
        }

        [Authorize]
        [HttpGet("/users/{userId:int:min(1)}/books/{bookId:int:min(1)}")]
        public async Task<ApiResponse> GetBookByIdForSpecificUser(int userId, int bookId, CancellationToken cancellationToken)
        {
            return await Task.Run(() => { return new ApiSucces(); });
        }

       
        [HttpGet("/users/{userId:int:min(1)}/books")]
        public async Task<ApiResponse> GetAllBooksForSpecificUser(int userId, CancellationToken cancellationToken)
        {
            return await _booksOwnedByUserSearch.Value.GeAlltBooksByUserIdAsync(userId, cancellationToken);
        }

        [Authorize]
        [HttpPost("/users/{userId:int:min(1)}/books")]
        public async Task<ApiResponse> CreateBookForSpecificUser(int userId, [FromBody]BookViewModel bookViewModel, CancellationToken cancellationToken)
        {
            return await _bookOwnedByUserCommandService.Value.CreateBookForUserAsync(userId, bookViewModel, cancellationToken);
        }

        [HttpPut("/users/{userId:int:min(1)}/books/{bookId:int:min(1)}")]
        public async Task<ApiResponse> UpdateBookForSpecificUser(int userId, int bookId, [FromBody]BookViewModel bookViewModel, CancellationToken cancellationToken)
        {
            return await _bookOwnedByUserCommandService.Value.UpdateBookForUserAsync(userId, bookViewModel, cancellationToken);
        }

        [RequestFormLimits(MultipartBodyLengthLimit = 10485760)] // e.g., 10MB
        [RequestSizeLimit(10485760)]
        [DisableRequestSizeLimit]
        [HttpPost("/sendFile")]
        public async Task<ApiResponse> UpdatePhotoFile(IFormFile myFile)
        {
            return null;
        }
    }
}

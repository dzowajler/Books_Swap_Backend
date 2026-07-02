using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models.ApiResponseModels;
using SearchService.BooksByUserSearches;

namespace Books_Swap_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersBooksController : ControllerBase
    {
        private IBooksByUserSearch _booksByUserSearch { get; set; }

        public UsersBooksController()
        {
            _booksByUserSearch = new BooksByUserSearch();
        }

        [HttpGet("/users/{userId:int:min(1)}/books/{bookId:int:min(1)}")]
        public async Task<ApiResponse> GetBookByIdForSpecificUser(int userId, int bookId, CancellationToken cancellationToken)
        {
            return await Task.Run(() => { return new ApiSucces(); });
        }

        [HttpGet("/users/{userId:int:min(1)}/books")]
        public async Task<ApiResponse> GetAllBooksForSpecificUser(int userId, CancellationToken cancellationToken)
        {
            return await _booksByUserSearch.GeAlltBooksByUserIdAsync(userId, cancellationToken);
        }
    }
}

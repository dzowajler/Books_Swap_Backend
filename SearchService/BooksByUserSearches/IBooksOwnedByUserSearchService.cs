using Models.ApiResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchService.BooksByUserSearches
{
    public interface IBooksOwnedByUserSearchService
    {
        Task<ApiResponse> GeAlltBooksByUserIdAsync(int userId, CancellationToken cancellation);
        //Task<ApiResponse> CreateBookToUserById(int userId, CancellationToken cancellation);
        Task<ApiResponse> GetBookByIdForUserId(int userId, CancellationToken cancellation);
    }
}

using Models.ApiResponseModels;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchService.BooksByUserSearches
{
    public class BooksOwnedByUserSearchService : IBooksOwnedByUserSearchService
    {
        private BooksOwnedByUserRepository _booksOwnedByUserRepository;
        public BooksOwnedByUserSearchService()
        {
            _booksOwnedByUserRepository = new BooksOwnedByUserRepository();
        }

        public async Task<ApiResponse> GeAlltBooksByUserIdAsync(int userId, CancellationToken cancellation)
        {
            cancellation.ThrowIfCancellationRequested();

            var result = await _booksOwnedByUserRepository.GetAllBooksByUserIdAsync(userId);

            if (result == null)
            {
                return new ApiError() { Code = "500", Message = "No data found" };
            }

            return new ApiSucces() { Code = "200", Message = "Data found", ResponseData = result };
        }
       
        public async Task<ApiResponse> GetBookByIdForUserId(int userId, CancellationToken cancellation)
        {
            return null;
        }
    }
}

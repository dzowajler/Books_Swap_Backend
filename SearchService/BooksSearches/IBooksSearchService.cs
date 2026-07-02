using Models.ApiResponseModels;
using ResponseModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchService.BooksSearches
{
    public interface IBooksSearchService
    {
       Task<ApiResponse> SearchForBooksAsync(string? title, string? author, int? id, CancellationToken ct);
    }
}

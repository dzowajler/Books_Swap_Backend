using DbAccess.Queries;
using DbAccess.QueryHandlers;
using Models.ApiResponseModels;

namespace SearchService.BooksSearches
{
    public class BooksSearchService : IBooksSearchService
    {
        private IBookQueryHandler _bookQueryHandler;

        public BooksSearchService()
        {
            _bookQueryHandler = new BookQueryHandler();
        }

        public async Task<ApiResponse> SearchForBooksAsync(string? title,
            string? author, int? id, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            try
            {
                var bookQuery = new GetBookQuery()
                {
                    BookId = id,
                    Title = title,
                    Author = author
                };

                var result = await _bookQueryHandler.HandleAsync(bookQuery);

                return new ApiSucces()
                {
                    Code = "200",
                    Message = "true",
                    ResponseData = result
                };
            }
            //catch (OperationCanceledException ex) when (HttpContext.RequestAborted.IsCancellationRequested)
            //{
            //    throw;
            //}
            catch (OperationCanceledException ex){

                return new ApiError()
                {
                    Code = "500",
                    Message = ex.Message,
                };
            }
            catch (Exception ex) {
                
                return new ApiError()
                {
                    Code = "500",
                    Message = ex.Message,
                };
            }
        }
    }
}

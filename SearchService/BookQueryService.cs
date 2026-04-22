using DbAccess.Queries;
using DbAccess.QueryHandlers;
using DbConnection.DbModels;
using ResponseModels.Mappers;
using ResponseModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchService
{
    public class BookQueryService : IBookQueryService
    {
        private IBookQueryHandler _bookQueryHandler;
        private IDatabaseToViewModelMappers _dbToViewModelMappers;
        public BookQueryService()
        {
            _bookQueryHandler = new BookQueryHandler();
            _dbToViewModelMappers = new DatabaseToViewModelMappers();
        }

        public async Task<IEnumerable<BookViewModel>> SearchForBooksAsync(string? title,
            string? author)
        {
            var bookQuery = new GetBookQuery() 
            {
                Title = title,
                Author = author
            };

            var result = await _bookQueryHandler.HandleAsync(bookQuery);

            if (result == null) {
                return Enumerable.Empty<BookViewModel>();
            }

            var vmResult = new List<BookViewModel>();

            foreach(var item in result)
            {
                vmResult.Add(_dbToViewModelMappers.ToViewModel(item));
            }
            return vmResult;

            //if result == null return NOT FOUND
            // if result == cos tam return 200 ok
            // if exception return backend 500 + exception
            // stworzyc ViewModele
            // poczytac o Cancellation Token i async programming
        }
    }
}

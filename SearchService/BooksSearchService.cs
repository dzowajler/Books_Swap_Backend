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
    public class BooksSearchService : IBooksSearchService
    {
        private IBookQueryHandler _bookQueryHandler;

        public BooksSearchService()
        {
            _bookQueryHandler = new BookQueryHandler();
        }

        public async Task<IEnumerable<BookViewModel>> SearchForBooksAsync(string? title,
            string? author, int? id, CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            var bookQuery = new GetBookQuery() 
            {
                BookId = id,
                Title = title,
                Author = author
            };

            return await _bookQueryHandler.HandleAsync(bookQuery);

            //if result == null return NOT FOUND
            // if result == cos tam return 200 ok
            // if exception return backend 500 + exception
            // stworzyc ViewModele
            // poczytac o Cancellation Token i async programming
        }
    }
}

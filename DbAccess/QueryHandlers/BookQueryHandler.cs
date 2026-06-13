using DbAccess.Queries;
using DbConnection;
using DbConnection.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using ResponseModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;

namespace DbAccess.QueryHandlers
{
    public class BookQueryHandler : IBookQueryHandler
    {
        private BooksSwapDbContext _booksSwapDbContext;

        //zrobic dispose na dbContext i poczytac o dbContext how to tread safe per
        // request in async programinng
        public BookQueryHandler()
        {
            _booksSwapDbContext = new BooksSwapDbContext();
        }

        //rozważyć wszystkie edge casy
        public async Task<IEnumerable<BookViewModel>> HandleAsync(GetBookQuery query)
        {
            if (query == null)
                throw new ArgumentNullException("query");

            var dbResult = await CreateBooksSearchQuery(query).ToListAsync();

            if (dbResult.IsNullOrEmpty<Book>())
                return Enumerable.Empty<BookViewModel>();

            var booksAndGenreDict = GroupByBooksByGenreId(dbResult);

            return await CreteBookViewModelFromBooksAndGenresAsync(booksAndGenreDict);
        }

        private async Task<IEnumerable<BookViewModel>> CreteBookViewModelFromBooksAndGenresAsync(
            Dictionary<int, List<Book>> booksAndGenreDict)
        {
            var viewModelResult = new List<BookViewModel>();

            foreach (var bookAndGenre in booksAndGenreDict)
            {
                var genreDbText = await _booksSwapDbContext.BookGenres
                    .Where(g => g.BookGenreId == bookAndGenre.Key)
                    .Select(x => x.Genre).SingleAsync();

                //dodać osobno metode do tworzenia view Modeli
                foreach (var book in bookAndGenre.Value)
                {
                    viewModelResult.Add(new BookViewModel
                    {
                        Author = book.Author,
                        Genre = genreDbText,
                        Description = book.Description,
                        Price = book.Price,
                        Title = book.Title,
                        Id = book.BookId
                    });
                }
            }

            return viewModelResult;
        }

        private Dictionary<int, List<Book>> GroupByBooksByGenreId(IEnumerable<Book> dbResult) =>
           dbResult.GroupBy(b => b.BookGenreId).ToDictionary(g => g.Key, g => g.ToList());
       
        private IQueryable<Book> CreateBooksSearchQuery(GetBookQuery bookQuery)
        {
            var booksTable = _booksSwapDbContext.Books;
            IQueryable<Book> query = booksTable.AsQueryable();

            if (bookQuery.BookId != null)
                query = query
                    .Where(x => bookQuery.BookId == x.BookId);
            if (bookQuery.Title != null)
                query = query.Where(x => x.Title.Contains(bookQuery.Title));
            if (bookQuery.Author != null)
                query = query.Where(x => x.Author.Contains(bookQuery.Author));

            return query;
        }
    }
}

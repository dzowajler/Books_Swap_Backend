using DbAccess.Queries;
using DbConnection;
using DbConnection.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
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
        public async Task<IEnumerable<Book>> HandleAsync(GetBookQuery query)
        {
            if (query == null) {
                throw new ArgumentNullException("query");
            }

            var result = await CreateBooksSearchQuery(query).ToListAsync();

            return result;
        }

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

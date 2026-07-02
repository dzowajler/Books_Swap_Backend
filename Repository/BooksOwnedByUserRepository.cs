using DbConnection;
using DbConnection.DbModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class BooksOwnedByUserRepository
    {
        private BooksSwapDbContext _dbContext;

        public BooksOwnedByUserRepository() 
        {
            _dbContext = new BooksSwapDbContext();
        }

        public async Task<IEnumerable<Book>> GetAllBooksByUserIdAsync(int userId)
        {
            var booksIdsTakenByUserId = await _dbContext.BookOwners.Where(u => u.UserId == userId)
                .Select(x => x.BookId)
                .ToListAsync();

            if (booksIdsTakenByUserId.IsNullOrEmpty())
                return Enumerable.Empty<Book>(); 

            var books = new List<Book>();

            foreach(var bookId in booksIdsTakenByUserId)
            {
                books.Add(_dbContext.Books.Where(b => b.BookId == bookId).Single());
            }

            return books;
        }
    }
}

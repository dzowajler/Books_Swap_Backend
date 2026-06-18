using DbAccess.Commands;
using DbConnection;
using DbConnection.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.CommandHandlers
{
    public class LoginCommandHandler : ILoginCommandHandler
    {
        private BooksSwapDbContext _booksSwapDbContext;

        public LoginCommandHandler()
        {
            _booksSwapDbContext = new BooksSwapDbContext();
        }

        public async Task<User> HandleAsync(LoginUserCommand userCommand)
        {
            var result = _booksSwapDbContext.Users.Where(u => u.UserName == userCommand.EmailOrUsername
                && u.PasswordHash == userCommand.Password).ToList();

            if (result.Count == 1)
                return result.Single();
            else 
                return null;
        }
    }
}

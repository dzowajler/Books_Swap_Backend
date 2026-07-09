using DbAccess.Commands;
using DbAccess.Queries;
using DbConnection;
using DbConnection.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.CommandHandlers.AuthCommandHandlers
{
    public class RegisterCommandHandler : IRegisterCommandHandler
    {
        private BooksSwapDbContext _booksSwapDbContext;

        public RegisterCommandHandler()
        {
            _booksSwapDbContext = new BooksSwapDbContext();
        }

        public async Task<bool> HandleAsync(CreateUserCommand userCommand)
        {
            if (userCommand == null)
            {
                throw new ArgumentNullException("userCommand");
            }

            var result = CreateUserInDatabaseQuery(userCommand);

            await _booksSwapDbContext.SaveChangesAsync();

            return result;
        }

        public bool CreateUserInDatabaseQuery(CreateUserCommand userCommand)
        {
            try
            {
                _booksSwapDbContext.Users.Add(
                    new User() {
                    Email = userCommand.Email,
                    PasswordHash = userCommand.Password,
                    Name = userCommand.Name,
                    Surname = userCommand.Surname,
                    UserName = userCommand.UserName}
                 );

                return true;
            }
            catch (Exception ex) { 

                return false;
            }
        }
    }
}

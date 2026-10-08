using DbAccess.Commands.BookCommands;
using DbConnection;
using DbConnection.DbModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.CommandHandlers.BookOwnerCommandsHandlers.UpdateBookHandler
{
    public class UpdateBookForUserCommandHandler : IUpdateBookForUserCommandHandler
    {
        private BooksSwapDbContext _booksSwapDbContext { get; set; }

        public UpdateBookForUserCommandHandler()
        {
            _booksSwapDbContext = new BooksSwapDbContext();
        }

        public async Task<bool> HandleAsync(UpdateBookCommand bookCommand)
        {
            if(bookCommand == null)
                throw new ArgumentNullException(nameof(bookCommand));

            return await UpdateBookForUserCommandAsync(bookCommand);
        }

        private async Task<bool> UpdateBookForUserCommandAsync(UpdateBookCommand updateBookCommand)
        {
            try
            {
                var bookAssignedToUser = await _booksSwapDbContext.BookOwners
                        .Where((b => b.UserId == updateBookCommand.UserId && b.BookId == updateBookCommand.BookId))
                        .SingleAsync();

                if (bookAssignedToUser != null)
                    return await UpdateBookAsync(updateBookCommand);
                
                return false;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        private async Task<bool> UpdateBookAsync(UpdateBookCommand updateBookCommand)
        {
            var bookToUpdate = await _booksSwapDbContext.Books.FindAsync(updateBookCommand.BookId);

            try
            {
                bookToUpdate.Author = updateBookCommand.Author;
                bookToUpdate.Title = updateBookCommand.Title;
                bookToUpdate.Description = updateBookCommand.Description;
                bookToUpdate.Price = updateBookCommand.Price;

                await _booksSwapDbContext.SaveChangesAsync();

                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}

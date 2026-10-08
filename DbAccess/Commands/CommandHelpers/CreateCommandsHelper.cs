using DbAccess.Commands.BookCommands;
using DbConnection.DbModels;
using ResponseModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.Commands.CommandHelpers
{
    public static class CreateCommandsHelper
    {
        public static CreateBookCommand CreateBookCommand(this BookViewModel bookViewModel, int userId)
        {
            return new CreateBookCommand()
            {
                UserId = userId,
                Title = bookViewModel.Title,
                Description = bookViewModel.Description,
                Author = bookViewModel.Author,
                Genre = bookViewModel.Genre,
                Price = bookViewModel.Price,
            };
        }

        public static UpdateBookCommand UpdateBookCommand(this BookViewModel bookViewModel, int userId)
        {
            return new UpdateBookCommand()
            {
                UserId = userId,
                BookId = bookViewModel.Id,
                Title = bookViewModel.Title,
                Description = bookViewModel.Description,
                Author = bookViewModel.Author,
                Genre = bookViewModel.Genre,
                Price = bookViewModel.Price,
            };
        }
    }
}

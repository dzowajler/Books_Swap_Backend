using DbAccess.Commands.BookCommands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.CommandHandlers.BookOwnerCommandsHandlers.UpdateBookHandler
{
    public interface IUpdateBookForUserCommandHandler
    {
        Task<bool> HandleAsync(UpdateBookCommand bookCommand);
    }
}

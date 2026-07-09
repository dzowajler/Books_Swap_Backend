using DbAccess.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.CommandHandlers.BookOwnerCommandsHandlers
{
    public interface ICreateBookForUserCommandHandler
    {
        Task<bool> HandleAsync(CreateBookCommand bookCommand);
    }
}

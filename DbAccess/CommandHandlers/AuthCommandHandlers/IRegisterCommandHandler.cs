using DbAccess.Commands;
using DbConnection.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.CommandHandlers.AuthCommandHandlers
{
    public interface IRegisterCommandHandler
    {
        Task<bool> HandleAsync(CreateUserCommand userCommand);
    }
}

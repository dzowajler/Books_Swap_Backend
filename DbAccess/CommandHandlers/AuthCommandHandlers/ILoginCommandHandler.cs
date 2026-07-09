using DbAccess.Commands;
using DbConnection.DbModels;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.CommandHandlers.AuthCommandHandlers
{
    public interface ILoginCommandHandler
    {
        Task<User> HandleAsync(LoginUserCommand userCommand);
    }
}

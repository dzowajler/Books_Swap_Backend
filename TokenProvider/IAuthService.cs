using DbAccess.Commands;
using Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthService
{
    public interface IAuthService
    {
        Task<TokenResponse> LogInAsync(LoginUserCommand userCommand);
    }
}

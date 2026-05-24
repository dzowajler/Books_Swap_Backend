using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.Commands
{
    public class LoginUserCommand
    {
        public string EmailOrUsername { get; set; }
        public string Password { get; set; }
    }
}

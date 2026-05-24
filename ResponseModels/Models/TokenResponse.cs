using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Models
{
    public class TokenResponse
    {
        public string AccessToken { get; set; } = string.Empty;
        public RefreshToken RefreshToken { get; set; }
    }
}

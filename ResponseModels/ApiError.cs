using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ResponseModels
{
    public class ApiError 
    {
        public string Code { get; set; }
        public string Message { get; set; }

        IEnumerable<ProblemDetails>? Details = null;
    }
}

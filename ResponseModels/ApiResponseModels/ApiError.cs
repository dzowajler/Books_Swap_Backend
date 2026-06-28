using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Models.ApiResponseModels
{
    public class ApiError : ApiResponse
    {
        IEnumerable<ProblemDetails>? Details = null;
    }
}

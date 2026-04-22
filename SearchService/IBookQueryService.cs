using ResponseModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchService
{
    public interface IBookQueryService
    {
       Task<IEnumerable<BookViewModel>> SearchForBooksAsync(string? title, string? author);
    }
}

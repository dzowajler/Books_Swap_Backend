using DbAccess.Queries;
using DbConnection.DbModels;
using ResponseModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.QueryHandlers
{
    public interface IBookQueryHandler
    {
        public Task<IEnumerable<BookViewModel>> HandleAsync(GetBookQuery query);
    }
}

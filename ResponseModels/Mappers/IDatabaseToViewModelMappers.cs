using DbConnection.DbModels;
using ResponseModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseModels.Mappers
{
    public interface IDatabaseToViewModelMappers
    {
        BookViewModel ToViewModel(Book book);
    }
}

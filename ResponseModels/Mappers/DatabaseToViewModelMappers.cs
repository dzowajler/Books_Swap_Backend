using DbConnection.DbModels;
using ResponseModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ResponseModels.Mappers
{
    public class DatabaseToViewModelMappers: IDatabaseToViewModelMappers
    {
        public BookViewModel ToViewModel(Book book)
        {
            return new BookViewModel()
            {
                Id = book.BookId,
                Title = book.Title,
                Author = book.Author,
                Description = book.Description,
                Price = book.Price,
            };
        }
    }
}

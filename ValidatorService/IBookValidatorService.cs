using ResponseModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorService
{
    public interface IBookValidatorService
    {
        IEnumerable<string> ValidateBook(BookViewModel bookViewModel);
    }
}

using ResponseModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationService.BooksValidators
{
    public static class AuthorValidators
    {
        public static bool HasAuthorTextContainsAtLeast3Characters(this string author)
        {
            return author.Length >= 3;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationService.BooksValidators
{
    public static class TitleValidators
    {
        public static bool HasTitleContainsAtLeast1Character(this string title)
        {
            return title.Length >= 1;
        } 
    }
}

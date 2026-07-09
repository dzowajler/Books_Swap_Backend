using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationService.BooksValidators
{
    public static class DescriptionValidators
    {
        public static bool HasDescriptionFieldContainAtLeast20Characters(this string description)
        {
            return description.Length >= 20;
        }
    }
}

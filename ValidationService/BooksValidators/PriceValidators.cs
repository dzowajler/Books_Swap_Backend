using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidationService.BooksValidators
{
    public static class PriceValidators
    {
        public static bool IsPriceGreaterThan0(this decimal price)
        {
            return price > 0;
        }

        public static bool IsPriceLesserThan5000(this decimal price)
        {
            return price < 5000;
        }
    }
}

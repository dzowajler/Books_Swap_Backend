using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidatorService
{
    public static class ValidationErrorMessages
    {
        public static string TooShortAuthorName
            = "Author field is too short. It should contain at least 3 characters";

        public static string TooShortTitle
            = "Title is too short. It should contain at least one character";

        public static string TooShortDescription
            = "Description is too short. It should contain at least 20 characters";

        public static string PriceIsOutOfLowerRange
            = "Price is out of range. It should be greater than 0.00";

        public static string PriceIsOutOfUpperRange
            = "Price is out of range. It should be lower than 5000.00";
    }
}

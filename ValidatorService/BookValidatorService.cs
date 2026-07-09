using ResponseModels.ViewModels;
using System.Runtime.CompilerServices;
using ValidationService.BooksValidators;

namespace ValidatorService
{
    public class BookValidatorService : IBookValidatorService
    {
        private Dictionary<string, Func<bool>> _bookValidationErrorDictionary;

        public BookValidatorService()
        {

        }

        public IEnumerable<string> ValidateBook(BookViewModel bookViewModel)
        {
            SetValidationErrorDictionary(bookViewModel);

            LeaveDictRecordsWhichDontPassValidation();

            if (_bookValidationErrorDictionary.Count != 0)
                return ExtractValidationErrors();

            return Enumerable.Empty<string>();
        }

        private IEnumerable<string> ExtractValidationErrors()
        {
            return _bookValidationErrorDictionary.Select(item => item.Key).ToList();
        }

        private void LeaveDictRecordsWhichDontPassValidation()
        {
            foreach (var item in _bookValidationErrorDictionary)
            {
                if (item.Value.Invoke() == true)
                    _bookValidationErrorDictionary.Remove(item.Key);
            }
        }

        private void SetValidationErrorDictionary(BookViewModel bookViewModel)
        {
            _bookValidationErrorDictionary = new Dictionary<string, Func<bool>>()
            {
                { ValidationErrorMessages.TooShortAuthorName,
                    bookViewModel.Author.HasAuthorTextContainsAtLeast3Characters },
                { ValidationErrorMessages.TooShortDescription,
                    bookViewModel.Description.HasDescriptionFieldContainAtLeast20Characters },
                { ValidationErrorMessages.TooShortTitle,
                   bookViewModel.Title.HasTitleContainsAtLeast1Character },
            };
        }
    }
}

using DbAccess.CommandHandlers.BookOwnerCommandsHandlers;
using DbAccess.Commands;
using Models.ApiResponseModels;
using ResponseModels.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ValidatorService;

namespace CommandService
{
    public class BookOwnedByUserCommandService : IBookOwnedByUserCommandService
    {
        private ICreateBookForUserCommandHandler _createBookForUserCommandHandler { get; set; }
        private IBookValidatorService _bookValidatorService { get; set; }

        public BookOwnedByUserCommandService()
        {
            _createBookForUserCommandHandler = new CreateBookForUserCommandHandler();
            _bookValidatorService = new BookValidatorService();
        }

        public async Task<ApiResponse> CreateBookForUserAsync(int userId, BookViewModel bookViewModel, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if(userId < 1 || bookViewModel == null)
            {
                return new ApiError() 
                { 
                  Code = "500",
                  Message = "userId or bookViewModel is Empty" 
                };
            }

            var validationResult = _bookValidatorService.ValidateBook(bookViewModel);

            if (validationResult != null) 
            {
                return new ApiError()
                {
                    Code = "500",
                    Message = "Validation errors",
                    Details = new List<ProblemDetails>()
                    {
                        new ProblemDetails(){
                            Details = validationResult
                        }
                    }
                };
            }

            var createBookCommand = new CreateBookCommand()
            {
                UserId = userId,
                Title = bookViewModel.Title,
                Description = bookViewModel.Description,
                Author = bookViewModel.Author,
                Genre = bookViewModel.Genre,
                Price = bookViewModel.Price,
            };

            var result = await _createBookForUserCommandHandler.HandleAsync(createBookCommand);

            return new ApiSucces() { };
        }
    }
}

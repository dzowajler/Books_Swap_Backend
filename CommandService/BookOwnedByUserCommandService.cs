using DbAccess.CommandHandlers.BookOwnerCommandsHandlers.CreateBookHandler;
using DbAccess.CommandHandlers.BookOwnerCommandsHandlers.UpdateBookHandler;
using DbAccess.Commands;
using DbAccess.Commands.BookCommands;
using DbAccess.Commands.CommandHelpers;
using Microsoft.IdentityModel.Tokens;
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
        private Lazy<ICreateBookForUserCommandHandler> _createBookForUserCommandHandler { get; set; }
        private Lazy<IUpdateBookForUserCommandHandler> _updateBookForUserCommandHandler { get; set; }  
        private IBookValidatorService _bookValidatorService { get; set; }

        public BookOwnedByUserCommandService()
        {
            _createBookForUserCommandHandler = new Lazy<ICreateBookForUserCommandHandler>
                (() => new CreateBookForUserCommandHandler());
            _updateBookForUserCommandHandler = new Lazy<IUpdateBookForUserCommandHandler>(
                () => new UpdateBookForUserCommandHandler());
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

            var validationResult = ValidateBook(bookViewModel);

            if (!validationResult.IsNullOrEmpty()) 
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

            var createBookCmnd = bookViewModel.CreateBookCommand(userId);

            var result = await _createBookForUserCommandHandler.Value.HandleAsync(createBookCmnd);

            return new ApiSucces()
            { 
                Code = "201", Message = "Rescource Created"
            };
        }

        public async Task<ApiResponse> UpdateBookForUserAsync(int userId, BookViewModel bookViewModel, CancellationToken cancellationToken)
        {
            cancellationToken.ThrowIfCancellationRequested();

            if (userId < 1 || bookViewModel == null)
            {
                return new ApiError()
                {
                    Code = "500",
                    Message = "userId or bookViewModel is Empty"
                };
            }

            var validationResult = ValidateBook(bookViewModel);

            if (!validationResult.IsNullOrEmpty())
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

            var updateBookCommannd = bookViewModel.UpdateBookCommand(userId);

            var result = await _updateBookForUserCommandHandler.Value.HandleAsync(updateBookCommannd);

            return new ApiSucces()
            {
                Code = "204",
                Message = "Rescource Updated"
            };

        }

        private IEnumerable<string> ValidateBook(BookViewModel bookViewModel)
        {
            return _bookValidatorService.ValidateBook(bookViewModel);
        }
    }
}

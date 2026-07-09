using DbAccess.Commands;
using DbConnection;
using DbConnection.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbAccess.CommandHandlers.BookOwnerCommandsHandlers
{
    public class CreateBookForUserCommandHandler : ICreateBookForUserCommandHandler
    {
        private BooksSwapDbContext _booksSwapDbContext;

        public CreateBookForUserCommandHandler()
        {
            _booksSwapDbContext = new BooksSwapDbContext();
        }

        public async Task<bool> HandleAsync(CreateBookCommand bookCommand)
        {
            if (bookCommand == null)
            {
                throw new ArgumentNullException(nameof(bookCommand));
            }

            var result = await CreateBookForUserCommandAsync(bookCommand);

            return result;
        }

        private async Task<bool> CreateBookForUserCommandAsync(CreateBookCommand createBookCommand)
        {
            try
            {
                var user = await _booksSwapDbContext.Users.FindAsync(createBookCommand.UserId);
                //edge case: sprawdzić czy o podanym Id istenieje użytkownik
                // w bazie - jesli tak - przejdź do tworzenia książki, jeśli nie, 
                // zwróć kod 500 - nie ma takiego użytkownika w bazie

                //napisac walidatory
                //napisac customExceptions

                if(user != null) { 

                    var createdBookId = await CreateBookInDatabaseAsync(createBookCommand);

                    if (createdBookId.HasValue)
                    {
                        _booksSwapDbContext.BookOwners.Add(new BookOwners()
                        {
                            BookId = createdBookId.Value,
                        });
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                return false; 
            }
        }

        private async Task<int?> CreateBookInDatabaseAsync(CreateBookCommand createBookCommand)
        {
            //how to handle databse exceptions? obsługa edge casów
            try
            {
                var bookInsertedIntoDb = new Book()
                {
                    Title = createBookCommand.Title,
                    Description = createBookCommand.Description,
                    Author = createBookCommand.Author,
                    Price = createBookCommand.Price,
                    BookGenreId = 1
                };

                var item = await _booksSwapDbContext.Books.AddAsync(bookInsertedIntoDb); 

                await _booksSwapDbContext.SaveChangesAsync();

                return bookInsertedIntoDb.BookId;
            }
            catch (Exception ex){

                return null;
            }
        }
    }
}

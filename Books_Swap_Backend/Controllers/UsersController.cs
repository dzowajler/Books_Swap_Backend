using AuthService;
using DbAccess.CommandHandlers;
using DbAccess.Commands;
using Microsoft.AspNetCore.Mvc;
using Models.Models;
using TokenProvider;


namespace Books_Swap_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        //dodać lazy loading tutaj
        private IRegisterCommandHandler _userCommandHandler { get; set; }
        private ILoginCommandHandler _loginCommandHandler { get; set; }
        private IAuthService _authService { get; set; }

        public UsersController()
        {
            _userCommandHandler = new RegisterCommandHandler();
            _loginCommandHandler = new LoginCommandHandler();
            _authService = new MyAuthenticationService();
        }

        [HttpPost("/register")]
        public async Task<bool> Register([FromBody] CreateUserCommand userCommand)
        {
            var result = await _userCommandHandler.HandleAsync(userCommand);

            return result;
            //return Results.Ok(items);
            //stworzyć dodatkową klasę z odpowiedzią HTTP implementującą IResult
        }

        [HttpPost("/login")]
        public async Task<TokenResponse> LoginAsync([FromBody] LoginUserCommand userCommand)
        {
            return await _authService.LogInAsync(userCommand);
        }
    }
}

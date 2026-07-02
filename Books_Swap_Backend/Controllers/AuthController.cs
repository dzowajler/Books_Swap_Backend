using AuthService;
using DbAccess.CommandHandlers;
using DbAccess.Commands;
using Microsoft.AspNetCore.Mvc;
using Models.ApiResponseModels;
using Models.Models;
using TokenProvider;


namespace Books_Swap_Backend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        //dodać lazy loading tutaj
        private IRegisterCommandHandler _userCommandHandler { get; set; }
        private ILoginCommandHandler _loginCommandHandler { get; set; }
        private IAuthService _authService { get; set; }

        public AuthController()
        {
            _userCommandHandler = new RegisterCommandHandler();
            _loginCommandHandler = new LoginCommandHandler();
            _authService = new MyAuthenticationService();
        }

        [HttpPost("/register")]
        public async Task<bool> RegisterAsync([FromBody] CreateUserCommand userCommand)
        {
            return await _userCommandHandler.HandleAsync(userCommand);
        }

        [HttpPost("/login")]
        public async Task<ApiResponse> LoginAsync([FromBody] LoginUserCommand userCommand)
        {
            return await _authService.LogInAsync(userCommand);
        }
    }
}

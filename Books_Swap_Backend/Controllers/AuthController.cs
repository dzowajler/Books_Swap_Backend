using AuthService;
using DbAccess.CommandHandlers;
using DbAccess.CommandHandlers.AuthCommandHandlers;
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
        private Lazy<IRegisterCommandHandler> _userCommandHandler { get; set; }
        private Lazy<ILoginCommandHandler> _loginCommandHandler { get; set; }
        private Lazy<IAuthService> _authService { get; set; }

        public AuthController()
        {
            _userCommandHandler = new Lazy<IRegisterCommandHandler>(() => new RegisterCommandHandler());
            _loginCommandHandler = new Lazy<ILoginCommandHandler>(() => new LoginCommandHandler());
            _authService = new Lazy<IAuthService>(() => new AuthenticationService());
        }

        [HttpPost("/register")]
        public async Task<bool> RegisterAsync([FromBody] CreateUserCommand userCommand)
        {
            return await _userCommandHandler.Value.HandleAsync(userCommand);
        }

        [HttpPost("/login")]
        public async Task<ApiResponse> LoginAsync([FromBody] LoginUserCommand userCommand)
        {
            return await _authService.Value.LogInAsync(userCommand);
        }
    }
}

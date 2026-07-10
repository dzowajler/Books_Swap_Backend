using AuthService;
using DbAccess.CommandHandlers.AuthCommandHandlers;
using DbAccess.Commands;
using DbConnection.DbModels;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Models.ApiResponseModels;
using Models.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace TokenProvider
{
    public class AuthenticationService : IAuthService
    {
        private IRegisterCommandHandler _registerCommandHandler { get; set; }
        private ILoginCommandHandler _loginCommandHandler { get; set; }

        private readonly IConfiguration _configuration;

        public AuthenticationService() 
        {
            _registerCommandHandler = new RegisterCommandHandler();
            _loginCommandHandler = new LoginCommandHandler();
            _configuration = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
        }

        public async Task<ApiResponse> LogInAsync(LoginUserCommand userCommand)
        {
            var user = await _loginCommandHandler.HandleAsync(userCommand);

            if (user != null)
            {
                var tokenResponse = new TokenResponse();
                tokenResponse.AccessToken = GenerateAccessToken(user);
                return new ApiSucces() { Code = "200", ResponseData = tokenResponse, Message = "Token sucessfully generated" };
            }

            return new ApiError() { Code = "500", Message = "login unsuccesfull" };
        }

        private string GenerateAccessToken(User user)
        {
            var jwtSettings = _configuration.GetSection("Jwt");
            var key = Encoding.UTF8.GetBytes(jwtSettings["Key"]!);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Name, user.Name),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString())
            };

            var creds = new SigningCredentials(
                new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["AccessTokenExpirationMinutes"]!)),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        //private async Task<RefreshToken> GenerateRefreshTokenAsync(User user)
        //{
        //    var refreshToken = new RefreshToken
        //    {
        //        Token = Guid.NewGuid().ToString(),
        //        UserId = user.Id,
        //        Expires = DateTime.UtcNow.AddDays(
        //            double.Parse(_configuration["Jwt:RefreshTokenExpirationDays"]!))
        //    };

        //    _context.RefreshTokens.Add(refreshToken);
        //    await _context.SaveChangesAsync();
        //    return refreshToken;
        //}
    }
}

using HumanManagement.DataAccess.Models;
using HumanManagement.DataAccess.UnitOfWork.Interfaces;
using HumanManagement.Services.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace HumanManagement.Services.Implementation
{
    public class AuthenticateServices : IAuthenticateServices
    {

        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IUnitOfWork _unitOfWork;


        public AuthenticateServices(IConfiguration configuration, IHttpContextAccessor httpContextAccessor, IUnitOfWork unitOfWork)
        {
            //_key = configuration["Jwt:Key"];
            //_issuer = configuration["Jwt:Issuer"];
            //_refreshTokenKey = configuration["Jwt:RefreshTokenKey"];
            this._configuration = configuration;
            this._httpContextAccessor = httpContextAccessor;
            this._unitOfWork = unitOfWork;
        }

        public string createToken(User user)
        {
            List<Claim> claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.Username),
                new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                new Claim("UserId", user.UserId.ToString())
            };

            var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration.GetSection("JWT:Secret").Value));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha512Signature);
            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            var jwt = new JwtSecurityTokenHandler().WriteToken(token);
            return jwt;
        }

        public Token generateRefreshToken()
        {
            var refreshToken = new Token
            {
                TokenString = Convert.ToBase64String(RandomNumberGenerator.GetBytes(64)),
                ExpirationDate = DateTime.Now.AddDays(1)
            };

            return refreshToken;
        }

        public string refreshToken(string refreshToken)
        {
            throw new NotImplementedException();
        }

        public void setRefreshToken(User user, Token token)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Expires = user.RefreshTokenExpired
            };
            _httpContextAccessor.HttpContext.Response.Cookies.Append("refreshToken", token.TokenString, cookieOptions);

            user.RefreshToken = token.TokenString;
            user.RefreshTokenExpired = token.ExpirationDate;
            _unitOfWork.Users.Update(user);
        }
    }
}

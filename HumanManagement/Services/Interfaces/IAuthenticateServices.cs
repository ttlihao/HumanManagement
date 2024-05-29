using HumanManagement.DataAccess.Models;

namespace HumanManagement.Services.Interfaces
{
    public interface IAuthenticateServices
    {
        string refreshToken(string refreshToken);
        Token generateRefreshToken();
        string createToken(User user);
        void setRefreshToken(User user, Token token);
    }
}

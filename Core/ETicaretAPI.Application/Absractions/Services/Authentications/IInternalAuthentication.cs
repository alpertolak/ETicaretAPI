
namespace ETicaretAPI.Application.Absractions.Services.Authentications
{
    public interface IInternalAuthentication
    {
        Task<DTOs.Token> Login(String usernameOrEmail, String password, int accessTokenLifeTime);
    }
}

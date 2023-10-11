
namespace ETicaretAPI.Application.Absractions.Services.Authentications
{
    public interface IExternalAuthentication
    {
        Task<DTOs.Token> GoogleLogin(string idToken, int accessTokenLifeTime);
    }
}

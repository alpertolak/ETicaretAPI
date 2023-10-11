using ETicaretAPI.Application.Absractions.Services.Authentications;


namespace ETicaretAPI.Application.Absractions.Services
{
    public interface IAuthService : IInternalAuthentication, IExternalAuthentication
    {

    }
}

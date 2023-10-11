using ETicaretAPI.Application.Absractions.Services;
using ETicaretAPI.Application.Absractions.Token;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Application.Features.Commands.AppUser.LoginUser;
using ETicaretAPI.Domain.Entities.Identity;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;

namespace ETicaretAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;
        readonly IConfiguration _configuration;
        readonly SignInManager<AppUser> _signInManager;
        readonly UserService _userSevice;

        public AuthService(
            UserManager<AppUser> userManager,
            ITokenHandler tokenHandler,
            IConfiguration configuration,
            SignInManager<AppUser> signInManager,
            UserService userSevice)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
            _signInManager = signInManager;
            _userSevice = userSevice;
        }

        public async Task<Token> GoogleLogin(string idToken,int accessTokenLifeTime)
        {
            var settings = new GoogleJsonWebSignature.ValidationSettings()
            {
                Audience = new List<string> { _configuration["ExternalLoginSettings:Google:ClientId"] }
            }; 

            var payload = await GoogleJsonWebSignature.ValidateAsync(idToken, settings);
            
            var info = new UserLoginInfo("GOOGLE", payload.Subject, "GOOGLE");

            AppUser user = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            bool result = user != null;
            if (user == null)
            {
                user = await _userManager.FindByEmailAsync(payload.Email);
                if (user == null)
                {
                    user = new()
                    {
                        Id = Guid.NewGuid().ToString(),
                        Email = payload.Email,
                        UserName = payload.Email,
                        NameSurname = payload.Name,
                    };
                    var identityResult = await _userManager.CreateAsync(user);
                    result = identityResult.Succeeded;
                }
            }

            if (result)
            {
                await _userManager.AddLoginAsync(user, info);
                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime);
                await _userSevice.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 5); //refreshtoken oluşturuluyor.
                //kullanıcıya göre oluşan token bilgisi geri dönderiliyor
                return token;
            }
            throw new Exception("Invalid External authentication!");
        }

        public async Task<Token> Login(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            AppUser user = await _userManager.FindByNameAsync(usernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(usernameOrEmail);

            if (user == null)
                throw new NotFoundUserException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded) //authentication başarılı!
            {
                var token = _tokenHandler.CreateAccessToken(accessTokenLifeTime); //başarılı olan kullanıcının token 
                await _userSevice.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 5); //refreshtoken oluşturuluyor.
                return token;
            }
            throw new AuthenticationErrorException();
        }
    }
}

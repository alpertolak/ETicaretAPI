using ETicaretAPI.Application.Absractions.Services;
using ETicaretAPI.Application.Absractions.Token;
using ETicaretAPI.Application.DTOs;
using ETicaretAPI.Application.Exceptions;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Identity;
using ETicaretAPI.Persistence.Contexts;
using ETicaretAPI.Persistence.Repositories;
using Google.Apis.Auth;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace ETicaretAPI.Persistence.Services
{
    public class AuthService : IAuthService
    {
        readonly UserManager<AppUser> _userManager;
        readonly ITokenHandler _tokenHandler;
        readonly IConfiguration _configuration;
        readonly SignInManager<AppUser> _signInManager;
        readonly IUserService _userSevice;
        private readonly IProductReadRepository _productReadRepository;

        public AuthService(
            UserManager<AppUser> userManager,
            ITokenHandler tokenHandler,
            IConfiguration configuration,
            SignInManager<AppUser> signInManager,
            IUserService userSevice,
            IProductReadRepository productReadRepository)
        {
            _userManager = userManager;
            _tokenHandler = tokenHandler;
            _configuration = configuration;
            _signInManager = signInManager;
            _userSevice = userSevice;
            _productReadRepository = productReadRepository;
        }

        //GOOGLE LOGİN
        public async Task<Token> GoogleLogin(string idToken, int accessTokenLifeTime)
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

                Token token = _tokenHandler.CreateAccessToken(accessTokenLifeTime,user);

                await _userSevice.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 60*5); //refreshtoken oluşturuluyor.
                //kullanıcıya göre oluşan token bilgisi geri dönderiliyor
                return token;
            }
            throw new Exception("Invalid External authentication!");
        }

        //LOGİN
        public async Task<Token> Login(string usernameOrEmail, string password, int accessTokenLifeTime)
        {
            Console.WriteLine();
            AppUser user = await _userManager.FindByNameAsync(usernameOrEmail);
            if (user == null)
                user = await _userManager.FindByEmailAsync(usernameOrEmail);

            if (user == null)
                throw new NotFoundUserException();

            SignInResult result = await _signInManager.CheckPasswordSignInAsync(user, password, false);

            if (result.Succeeded) //authentication başarılı!
            {
                var token = _tokenHandler.CreateAccessToken(accessTokenLifeTime,user); //başarılı olan kullanıcının token 
                await _userSevice.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 60*5); //refreshtoken oluşturuluyor.
                return token;
            }
            else
                throw new AuthenticationErrorException();
        }

        public async Task<Token> RefreshTokenLoginAsync(string RefreshToken)
        {
            AppUser? user = await _userManager.Users.FirstOrDefaultAsync(u => u.RefreshToken == RefreshToken);

            if (user != null && user?.RefreshTokenEndDate > DateTime.UtcNow)
            {
                Token token = _tokenHandler.CreateAccessToken(15,user);
                await _userSevice.UpdateRefreshToken(token.RefreshToken, user, token.Expiration, 60 * 5);
                return token;
            }
            else
                throw new NotFoundUserException();
            
        }
    }
} 

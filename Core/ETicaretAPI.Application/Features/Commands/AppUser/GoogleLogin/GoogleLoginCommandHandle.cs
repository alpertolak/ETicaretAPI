using ETicaretAPI.Application.Absractions.Services;
using MediatR;


namespace ETicaretAPI.Application.Features.Commands.AppUser.GoogleLogin
{
    public class GoogleLoginCommandHandle : IRequestHandler<GoogleLoginCommandRequest, GoogleLoginCommandResponse>
    {
        IAuthService _authService;

        public GoogleLoginCommandHandle(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<GoogleLoginCommandResponse> Handle(GoogleLoginCommandRequest request, CancellationToken cancellationToken)
        { 
            var token = await _authService.GoogleLogin(request.IdToken, 60 * 15);

            return new()
            {
                Token = token,
            };
        }
    }
}

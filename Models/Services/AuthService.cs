using ProductManagementWebApi.Models.Interfaces;

namespace ProductManagementWebApi.Models.Services
{
    public class AuthService : IAuthService
    {
        readonly ITokenService tokenService;
        public AuthService(ITokenService _tokenService)
        {
            this.tokenService = _tokenService;
        }

        public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
        {
            UserLoginResponse response = new();

            if (String.IsNullOrEmpty(request.Username) ||  String.IsNullOrEmpty(request.Password))
            {
                throw new ArgumentNullException(nameof(request));
            }

            //kullanıcının var olup olmadığını kontrol edecek
            if (request.Username == "Azra" && request.Password == "123")
            {
                var generateTokenInformation = await tokenService.GenerateTokenAsync(new GenerateTokenRequest { Username = request.Username });
                response.AccessTokenExpireDate = generateTokenInformation.TokenExpireDate;
                response.AuthenticateResult = true;
                response.AuthToken = generateTokenInformation.Token;
            }
            return response;
        }
    }
}

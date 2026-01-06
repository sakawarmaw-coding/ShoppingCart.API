using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ShoppingCart.API.Business.Services
{
    public class JwtService
    {
        private readonly IConfiguration _config;
        private readonly AppDbContext _db;

        public JwtService(AppDbContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        public async Task<UserRespModel> Authenticate(UserReqModel userReq)
        {
            if (string.IsNullOrEmpty(userReq.Username) || string.IsNullOrEmpty(userReq.Password))
                return null!;
            var user = await _db.tblUser.FirstOrDefaultAsync(x => x.LoginName == userReq.Username);
            if (user is null || user.Password != userReq.Password)
                return null!;

            var issuer = _config["Jwt:Issuer"];
            var audience = _config["Jwt:Audience"];
            var key = _config["Jwt:Key"];
            var expireMins = _config.GetValue<int>("Jwt:ExpiryMinutes");
            var tokenExpiryTimeStamp = DateTime.UtcNow.AddMinutes(expireMins);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(JwtRegisteredClaimNames.Name, userReq.Username),
                }),
                Expires = tokenExpiryTimeStamp,
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key!)), SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var securityToken = tokenHandler.CreateToken(tokenDescriptor);
            var accessToken = tokenHandler.WriteToken(securityToken);

            return new UserRespModel
            {
                LoginName = userReq.Username,
                AccessToken = accessToken,
                ExpireSecond = (int)tokenExpiryTimeStamp.Subtract(DateTime.UtcNow).TotalSeconds
            };
        }
    }
}

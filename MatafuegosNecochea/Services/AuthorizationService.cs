using Microsoft.IdentityModel.Tokens;
using System.Diagnostics.CodeAnalysis;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MatafuegosNecochea.Services
{   
    public class AuthorizationService()
    {
        private readonly string? _secretKey;

        public AuthorizationService(IConfiguration configuration):this()
        {
            if (string.IsNullOrWhiteSpace(configuration["JWT_SECRET_KEY"])) { throw new Exception("missing environment variable for secret"); }
            _secretKey = configuration["JWT_SECRET_KEY"];
        }



        //Generate JWT
        public string CreateJWT(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username)) { throw new ArgumentNullException("username"); }
            if (string.IsNullOrWhiteSpace(password)) {  throw new ArgumentNullException("password"); }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));

            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, username),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(7),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);

        }


        //Verify JWT
       public ClaimsPrincipal? VerifyToken(string jwt)
        {
            try
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_secretKey));

                var tokenValidationParams = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = key,
                    ClockSkew = TimeSpan.Zero
                };

                var tokenHandler = new JwtSecurityTokenHandler();

                var claimsPrincipal = tokenHandler.ValidateToken(jwt, tokenValidationParams, out _);

                return claimsPrincipal;


            }
            catch (Exception)
            {
                return null;
            }
        }



    }
}

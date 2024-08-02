using HospitalManagement.Application.Abstractions.Token;
using HospitalManagement.Application.DTOs;
using HospitalManagement.Application.Utilities.Security.Encryption;
using HospitalManagement.Application.Utilities.Security.JWT;
using HospitalManagement.Domain.Entities.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace HospitalManagement.Infrastructure.Services
{
    //public class TokenHandler : ITokenHandler
    //{
    //    readonly IConfiguration _configuration;

    //    public TokenHandler(IConfiguration configuration)
    //    {
    //        _configuration = configuration;
    //    }

    //    public Application.DTOs.Token CreateAccessToken(int second, AppUser appUser)
    //    {
    //        Application.DTOs.Token token = new();

    //        SymmetricSecurityKey securityKey = new(Encoding.UTF8.GetBytes(_configuration["Token:SecurityKey"]));

    //        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512);

    //        //token options
    //        token.Expiration = DateTime.UtcNow.AddSeconds(second);
    //        JwtSecurityToken securityToken = new(
    //            audience: _configuration["Token:Audience"],
    //            issuer: _configuration["Token:Issuer"],
    //            expires: token.Expiration,
    //            notBefore: DateTime.UtcNow,
    //            signingCredentials: signingCredentials,
    //            //claims
    //            claims: new List<Claim> { new(ClaimTypes.Name, appUser.UserName) }
    //            );

    //        JwtSecurityTokenHandler tokenHandler = new();
    //        token.AccessToken = tokenHandler.WriteToken(securityToken);

    //        //refresh token
    //        token.RefreshToken = CreateRefreshToken();

    //        return token;
    //    }

    //    public string CreateRefreshToken()
    //    {
    //        byte[] number = new byte[32];
    //        using RandomNumberGenerator random = RandomNumberGenerator.Create();
    //        random.GetBytes(number);
    //        return Convert.ToBase64String(number);

    //    }
    //}
    public class TokenHandler : ITokenHandler
    {
        private readonly IConfiguration _configuration;
        private readonly TokenOptions _tokenOptions;
        private DateTime _accessTokenExpiration;

        public TokenHandler(IConfiguration configuration)
        {
            _configuration = configuration;
            _tokenOptions = _configuration.GetSection("Token").Get<TokenOptions>();
        }

        public Token CreateAccessToken(int hour, AppUser appUser)
        {
            _accessTokenExpiration = DateTime.UtcNow.AddHours(hour);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions,appUser,signingCredentials);
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var tokenString = jwtSecurityTokenHandler.WriteToken(jwt);
            var token = new Application.DTOs.Token
            {
                AccessToken = tokenString,
                Expiration = _accessTokenExpiration,
                RefreshToken = CreateRefreshToken()
            };

            return token;

        }

        public string CreateRefreshToken()
        {
            byte[] number = new byte[32];
            using RandomNumberGenerator random = RandomNumberGenerator.Create();
            random.GetBytes(number);
            return Convert.ToBase64String(number);
        }

        private JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions, AppUser appUser, SigningCredentials signingCredentials)
        {
            var jwt = new JwtSecurityToken
                (
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audience,
                expires: _accessTokenExpiration,
                notBefore: DateTime.UtcNow,
                claims: SetClaims(appUser),
                signingCredentials: signingCredentials
                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(AppUser appUser)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name, appUser.UserName),
                new Claim(ClaimTypes.Email, appUser.Email)
            };
            return claims;
        }
    }
}

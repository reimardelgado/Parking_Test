using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using ParkingLots.Domain.DTOs.JWT;
using ParkingLots.Domain.Interfaces.Services;

namespace ParkingLots.Infrastructure.Security
{
    public class JwtTokenService : IJwtTokenService
    {
        private ILogger<JwtTokenService> _logger;
        private readonly string _jwtSecret;

        public JwtTokenService(ILogger<JwtTokenService> logger, IConfiguration config)
        {
            _logger = logger;
            _jwtSecret = config.GetValue<string>("JWT:Key");
        }

        public string GenerateJwtToken(JwtPayloadDto payload)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var securityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_jwtSecret));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        
            var claims = new[] {
                new Claim(JwtRegisteredClaimNames.Sub, payload.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.GivenName, payload.Fullname),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var secToken = new JwtSecurityToken(null, null, claims, null,
                null, signingCredentials)
            {
                Payload =
                {
                    ["permissions"] = payload.Permissions,
                    ["scope"] = payload.Scope
                }
            };

            _logger.LogInformation("Creating security token for {@Token}", secToken);

            var jwtToken = tokenHandler.WriteToken(secToken);
            return jwtToken;
        }
    }
}


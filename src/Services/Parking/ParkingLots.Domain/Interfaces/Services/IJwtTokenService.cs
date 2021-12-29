using ParkingLots.Domain.DTOs.JWT;

namespace ParkingLots.Domain.Interfaces.Services
{
    public interface IJwtTokenService
    {
        
        /// <summary>
        ///  Creates JWT Tokens to authenticate with any microservice. 
        /// </summary>
        /// <param name="payload">Specify claims and permissions. </param>
        /// <returns></returns>
        public string GenerateJwtToken(JwtPayloadDto payload);
    }
}


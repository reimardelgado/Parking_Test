using System;
using ParkingLots.Domain.Models;

namespace ParkingLots.API.DTOs.Responses
{
    public class LoginResponse : BaseResponse<string>
    {
        public LoginResponse(Guid correlationId) : base(correlationId)
        {
        }
        
        public void SetResponse(EntityResponse<string> response)
        {
            Value = response.Value;
        }
    }
}